namespace UglyTrivia
{
    using System.Collections.Generic;
    using System.Linq;

    using Trivia;

    public class Game
    {
        private readonly IGameLogger logger;
        private readonly List<Player> players = new List<Player>();

        private readonly LinkedList<string> popQuestions;
        private readonly LinkedList<string> scienceQuestions;
        private readonly LinkedList<string> sportsQuestions;
        private readonly LinkedList<string> rockQuestions;

        private int currentPlayer;
        private bool isGettingOutOfPenaltyBox;
        private readonly ICategorySelector categorySelector;

        public Game(
            IGameLogger logger,
            ICategorySelector categorySelector,
            IQuestionFactory questionFactory)
        {
            this.logger = logger;
            this.categorySelector = categorySelector;

            popQuestions = questionFactory.GenerateQuestionsForCategory(QuestionCategory.Pop);
            scienceQuestions = questionFactory.GenerateQuestionsForCategory(QuestionCategory.Science);
            sportsQuestions = questionFactory.GenerateQuestionsForCategory(QuestionCategory.Sports);
            rockQuestions = questionFactory.GenerateQuestionsForCategory(QuestionCategory.Rock);
        }

        public bool IsPlayable()
        {
            return players.Count >= 2;
        }

        public bool AddPlayer(string playerName)
        {
            players.Add(new Player(playerName));

            logger.Log(playerName + " was added");
            logger.Log("They are player number " + players.Count);
            return true;
        }

        public void MovePlayer(int roll)
        {
            logger.Log(players[currentPlayer].Name + " is the current player");
            logger.Log("They have rolled a " + roll);

            if (players[currentPlayer].IsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    logger.Log(players[currentPlayer].Name + " is getting out of the penalty box");
                    ExecuteMove(roll);
                }
                else
                {
                    logger.Log(players[currentPlayer].Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                ExecuteMove(roll);
            }
        }

        private void ExecuteMove(int roll)
        {
            players[currentPlayer].LocationOnBoard += roll;

            logger.Log(players[currentPlayer].Name
                       + "'s new location is "
                       + players[currentPlayer].LocationOnBoard);
            logger.Log("The category is " + categorySelector.GetCategoryForField(players[currentPlayer].LocationOnBoard));
            AskQuestion();
        }

        private void AskQuestion()
        {
            var categoryForField = categorySelector.GetCategoryForField(players[currentPlayer].LocationOnBoard);
            switch (categoryForField)
            {
                case QuestionCategory.Pop:
                    GetNextQuestion(popQuestions);
                    break;
                case QuestionCategory.Science:
                    GetNextQuestion(scienceQuestions);
                    break;
                case QuestionCategory.Sports:
                    GetNextQuestion(sportsQuestions);
                    break;
                case QuestionCategory.Rock:
                    GetNextQuestion(rockQuestions);
                    break;
            }
        }

        private void GetNextQuestion(LinkedList<string> questions)
        {
            logger.Log(questions.First());
            questions.RemoveFirst();
        }

        public bool WasCorrectlyAnswered()
        {
            if (players[currentPlayer].IsInPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    return AnswerCorrectly();
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                return AnswerCorrectly();
            }
        }

        private bool AnswerCorrectly()
        {
            logger.Log("Answer was correct!!!!");
            players[currentPlayer].Coins++;
            logger.Log(players[currentPlayer].Name
                       + " now has "
                       + players[currentPlayer].Coins
                       + " Gold Coins.");

            bool winner = DidPlayerWin();
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            return winner;
        }

        public bool WrongAnswer()
        {
            logger.Log("Question was incorrectly answered");
            logger.Log(players[currentPlayer].Name + " was sent to the penalty box");
            players[currentPlayer].IsInPenaltyBox = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }

        private bool DidPlayerWin()
        {
            return players[currentPlayer].Coins != 6;
        }
    }
}
