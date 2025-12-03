namespace Exam19_20
{
    internal class Player
    {
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public Position Position { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
        
        public Player()
        {

        }

    }

    public enum Position
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
}
