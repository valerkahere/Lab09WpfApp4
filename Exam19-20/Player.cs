namespace Exam19_20
{

    public enum Position
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
    internal class Player
    {
        // Properties - use shorthand unless there is a need for longer properties
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public Position PreferredPosition { get; set; }

        public DateTime DateOfBirth { get; set; }

        private int _age;

        public int Age
        {
            get
            {
                // Determine age and account for birthday that has not happened yet
                _age = DateTime.Now.Year - DateOfBirth.Year;
                if (DateOfBirth.DayOfYear >= DateTime.Now.DayOfYear) // then birth hasn't happened yet
                {
                    _age--;
                }
                return _age;
            }
        }


        // Constructors
        public Player()
        {

        }

        // Methods
        public override string ToString()
        {
            // Need to convert Preferred Position to string because it's enum
            return $"{FirstName} {Surname} ({Age}) {PreferredPosition.ToString().ToUpper()}";
        }
    }


}
