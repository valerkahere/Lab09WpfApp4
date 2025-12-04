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
            int currentYear = DateTime.Now.Year;
            // generate set number of positions
            Position currentPosition = Position.Goalkeeper;
            for (int i = 0; i < firstNames.Length; i++)
            {
                // generate random date where age is 20-30
                // now is 2025
                int desiredAge = random.Next(20, 31);

                // simply generating random month (1-12) and days amount (1-28)
                int month = random.Next(1, 13);
                int day = random.Next(1, 29);


                switch (i)
                {
                    case 2:
                        currentPosition = Position.Defender;
                        break;
                    case 8:
                        currentPosition = Position.Midfielder;
                        break;
                    case 14:
                        currentPosition = Position.Forward;
                        break;
                }

                Player p = new Player()
                {
                    FirstName = firstNames[random.Next(0, firstNames.Length)],
                    Surname = lastNames[random.Next(0, lastNames.Length)],
                    DateOfBirth = new DateTime(currentYear - desiredAge, month, day),
                    PreferredPosition = currentPosition
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

            // Clearing the selected List Box
            lbxSelected.ItemsSource = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            // && allPlayers.Contains(selectedItem)

            //string? selectedItem = lbxAll.SelectedItem.ToString();
            //// If the selection is actually made (not null) and the players list contains it, then add it to selectedPlayers list and listbox
            //if (!(string.IsNullOrEmpty(selectedItem)))
            //{
            //    // Now safely getting the player object
            //    Player? player = lbxAll.SelectedItem as Player;
            //    selectedPlayers.Add(player);



            //}

            //lbxSelected.ItemsSource = selectedPlayers;
            //lbxAll.SelectedItem = null;

            // Determine what was selected - need to put as Player because list box can return any type of object
            Player selected = lbxAll.SelectedItem as Player;

            // Check not null
            if (selected != null)
            {
                // Take action - move to other list
                selectedPlayers.Add(selected);
                allPlayers.Remove(selected);

                // Because using list, not observable collections - reset needed
                // refreshes that list on the screen
                lbxAll.ItemsSource = null;
                lbxAll.ItemsSource = allPlayers;
            }

            // Finally display in selected list box
            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = selectedPlayers;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}