namespace Trivia
{
    public class Player
    {
        private int locationOnBoard;

        public string Name { get; }

        public int Coins { get; set; }

        public bool IsInPenaltyBox { get; set; }

        public int LocationOnBoard
        {
            get => locationOnBoard;
            set => locationOnBoard = value > 11
                ? locationOnBoard = value - 12
                : locationOnBoard = value;
        }

        public Player(string name)
        {
            Name = name;
        }
    }
}