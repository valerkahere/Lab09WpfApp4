namespace Exam19_20
{

    public enum Position
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
    internal class Player : IComparable
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

        public int CompareTo(object obj)
        {
            Player that = obj as Player;
            //return this.PreferredPosition.CompareTo(that.PreferredPosition);
            // compare preferred position of this object
            // with position of the object beside it
            // sort microsoft method will do rearranging for us 
            // once we've identified here what it is we're comparing to sort objects

            // if the position is the same, then sort on first name
            if (this.PreferredPosition > that.PreferredPosition)
            {
                return 1;
            }
            else if (this.PreferredPosition < that.PreferredPosition)
            {
                return -1;
            }
            else
            {
                // otherwise positions are identical,
                // so then return comparison of first names
                // CompareTo will do a similar thing: return 1, -1, or 0
                return this.FirstName.CompareTo(that.FirstName);
            }
        }
    }


}
