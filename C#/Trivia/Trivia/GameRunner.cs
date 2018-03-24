namespace Trivia
{
    using System;
    using System.Threading;

    public class GameRunner
    {
        private readonly Dice dice;
        private readonly IAnsweringStrategy answeringStrategy;
        private readonly Random rand;
        private bool isWinner;
        private readonly Game game;

        public GameRunner(
            Dice dice,
            IAnsweringStrategy answeringStrategy,
            Random rand,
            Game game)
        {
            this.dice = dice;
            this.answeringStrategy = answeringStrategy;
            this.rand = rand;
            this.game = game;
        }

        public void Start()
        {
            AddPlayers();

            var timer = new Timer(_ => IsGameTimedout = true, null, TimeSpan.FromMilliseconds(-1), TimeSpan.FromMinutes(30));

            do
            {
                var roll = dice.Roll(rand);

                game.MovePlayer(roll);

                isWinner = !answeringStrategy.IsNotWinner(game);
            }
            while (!isWinner || IsGameTimedout);
        }

        public bool IsGameTimedout { get; private set; }

        private void AddPlayers()
        {
            game.AddPlayer("Chet");
            game.AddPlayer("Pat");
            game.AddPlayer("Sue");
        }
    }
}
