using System.Windows;

namespace Exam19_20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> allPlayers = new List<Player>();
        List<Player> selectedPlayers = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private List<Player> CreatePlayers()
        {
            List<Player> players = new List<Player>();

            string[] firstNames = {
                "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily",
                "Emma", "Grace", "Hannah", "Harry", "Jack", "James",
                "Lucy", "Luke", "Mia", "Michael", "Noah", "Sean", "Sophie"};
            // 20
            string[] lastNames = {
                "Brennan", "Byrne", "Daly", "Doyle", "Dunne", "Fitzgerald", "Kavanagh",
                "Kelly", "Lynch", "McCarthy", "McDonagh", "Murphy", "Nolan", "O'Brien",
                "O'Connor", "O'Neill", "O'Reilly", "O'Sullivan", "Ryan", "Walsh"
            };

            // Create players
            Random random = new Random();

            for (int i = 0; i < firstNames.Length; i++)
            {
                // generate random date where age is 20-30
                // now is 2025
                int currentYear = 2025;
                int desiredAge = random.Next(20, 31);

                Player p = new Player()
                {
                    FirstName = firstNames[random.Next(0, firstNames.Length)],
                    Surname = lastNames[random.Next(0, lastNames.Length)],
                    DateOfBirth = new DateTime(currentYear - desiredAge, 1, 1)
                };

                players.Add(p);


            }

            return players;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create Players
            allPlayers = CreatePlayers();

            // Displaying Players in List Box
            lbxAll.ItemsSource = allPlayers;
        }
    }

}