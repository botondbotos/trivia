namespace Trivia
{
    using System;
    using UglyTrivia;

    public class GameRunner
    {
        private readonly Dice dice;
        private readonly IAnsweringStrategy answeringStrategy;
        private readonly Random rand;
        private bool isWinner;
        private Game game;

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

            do
            {
                var roll = this.dice.Roll(this.rand);

                this.game.MovePlayer(roll);

                this.isWinner = !this.answeringStrategy.IsNotWinner(this.game);
            }
            while (!this.isWinner);
        }

        private void AddPlayers()
        {
            this.game.AddPlayer("Chet");
            this.game.AddPlayer("Pat");
            this.game.AddPlayer("Sue");
        }
    }
}
