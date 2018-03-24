namespace UglyTrivia
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly IGameLogger logger;
        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer;
        bool isGettingOutOfPenaltyBox;
        private readonly ICategorySelector categorySelector;

        public Game(
            IGameLogger logger,
            ICategorySelector categorySelector,
            IQuestionFactory questionFactory)
        {
            this.logger = logger;
            this.categorySelector = categorySelector;

            popQuestions = questionFactory.GenerateQuestionsForCategory("Pop");
            scienceQuestions = questionFactory.GenerateQuestionsForCategory("Science");
            sportsQuestions = questionFactory.GenerateQuestionsForCategory("Sports");
            rockQuestions = questionFactory.GenerateQuestionsForCategory("Rock");
        }

        public bool IsPlayable()
        {
            return HowManyPlayers() >= 2;
        }

        public bool AddPlayer(string playerName)
        {
            players.Add(playerName);
            places[HowManyPlayers()] = 0;
            purses[HowManyPlayers()] = 0;
            inPenaltyBox[HowManyPlayers()] = false;

            logger.Log(playerName + " was added");
            logger.Log("They are player number " + players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return players.Count;
        }

        public void MovePlayer(int roll)
        {
            logger.Log(players[currentPlayer] + " is the current player");
            logger.Log("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    logger.Log(players[currentPlayer] + " is getting out of the penalty box");
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    logger.Log(players[currentPlayer]
                            + "'s new location is "
                            + places[currentPlayer]);
                    logger.Log("The category is " + categorySelector.GetCategoryForField(places[currentPlayer]));
                    AskQuestion();
                }
                else
                {
                    logger.Log(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                logger.Log(players[currentPlayer]
                        + "'s new location is "
                        + places[currentPlayer]);
                logger.Log("The category is " + categorySelector.GetCategoryForField(places[currentPlayer]));
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            if (categorySelector.GetCategoryForField(places[currentPlayer]) == "Pop")
            {
                logger.Log(popQuestions.First());
                popQuestions.RemoveFirst();
            }

            if (categorySelector.GetCategoryForField(places[currentPlayer]) == "Science")
            {
                logger.Log(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }

            if (categorySelector.GetCategoryForField(places[currentPlayer]) == "Sports")
            {
                logger.Log(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }

            if (categorySelector.GetCategoryForField(places[currentPlayer]) == "Rock")
            {
                logger.Log(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }

        public bool WasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    logger.Log("Answer was correct!!!!");
                    purses[currentPlayer]++;
                    logger.Log(players[currentPlayer]
                            + " now has "
                            + purses[currentPlayer]
                            + " Gold Coins.");

                    bool winner = DidPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    return winner;
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
                logger.Log("Answer was corrent!!!!");
                purses[currentPlayer]++;
                logger.Log(players[currentPlayer]
                        + " now has "
                        + purses[currentPlayer]
                        + " Gold Coins.");

                bool winner = DidPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            logger.Log("Question was incorrectly answered");
            logger.Log(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }

        private bool DidPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }
}
