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
        // Selected Players Limit and Count
        int limit = 11;
        int count = 0;
        int spacesLeft = 3;
        int selectedGoalkeepers, selectedDefenders, selectedMidfielders, selectedForwards;
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

            // Will use IComparable - CompareTo method
            selectedPlayers.Sort();
            allPlayers.Sort();

            // Clearing the selected List Box
            lbxSelected.ItemsSource = null;

            // Showing amount of available space on program start
            tblkRemainingSpaces.Text = spacesLeft.ToString();

            // Populate Combo Box
            cbxFormation.ItemsSource = new string[] { "4-4-2", "4-3-3", "4-5-1" };
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



            // Checking space available
            // Note: count, limit, spacesLeft are declared at class level
            if (count >= limit)
            {
                // you've reached the limit
                MessageBox.Show("You have too many players selected");
            }
            else
            {
                AddSelected();
            }
        }

        private void AddSelected()
        {
            // Determine what was selected - need to put as Player because list box can return any type of object
            Player selected = lbxAll.SelectedItem as Player;

            // Check not null
            if (selected != null)
            {
                // Take action - move to other list

                // First, check that player allowed in current formation
                if (IsValidPlayer(selected))
                {
                    selectedPlayers.Add(selected);
                    allPlayers.Remove(selected);
                    RefreshScreen();
                }
                else
                {
                    MessageBox.Show("Player not allowed in formation");
                }


            }

            // Finally display in selected list box
            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = selectedPlayers;
        }

        private void cbxFormation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // reset


            // all players selected are returned to left list
            foreach (Player player in selectedPlayers)
            {
                allPlayers.Add(player);
            }


            // clear selected players
            selectedPlayers.Clear();

            // reset the allowed number of positions
            selectedGoalkeepers = 0;
            selectedDefenders = 0;
            selectedMidfielders = 0;
            selectedForwards = 0;
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            // Will use IComparable - CompareTo method
            selectedPlayers.Sort();
            allPlayers.Sort();

            // Because using list, not observable collections - reset needed
            // refreshes that list on the screen
            lbxAll.ItemsSource = null;
            lbxAll.ItemsSource = allPlayers;

            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = selectedPlayers;

            // Displaying remaining space
            count = lbxSelected.Items.Count;
            spacesLeft = (limit - count);
            tblkRemainingSpaces.Text = spacesLeft.ToString();
        }

        private bool IsValidPlayer(Player player)
        {
            bool valid = false;

            // det selected formation
            string? selectedFormation = cbxFormation.SelectedItem as string; // 4-4-2
            if (selectedFormation != null)
            {
                string[] formation = selectedFormation.Split("-");

                // det number of players in each position
                int allowedGoalkeepers = 1;
                int allowedDefenders = int.Parse(formation[0]);
                int allowedMidfielders = int.Parse(formation[1]);
                int allowedForwards = int.Parse(formation[2]);

                // check selected against allowed
                // selected Goalkeepers declared at class level
                switch (player.PreferredPosition)
                {
                    case Position.Goalkeeper:
                        if (selectedGoalkeepers < allowedGoalkeepers)
                        {
                            selectedGoalkeepers++;
                            valid = true;
                        }
                        break;
                    case Position.Defender:
                        if (selectedDefenders < allowedDefenders)
                        {
                            selectedDefenders++;
                            valid = true;
                        }
                        break;
                    case Position.Midfielder:
                        if (selectedMidfielders < allowedMidfielders)
                        {
                            selectedMidfielders++;
                            valid = true;
                        }
                        break;
                    case Position.Forward:
                        if (selectedForwards < allowedForwards)
                        {
                            selectedForwards++;
                            valid = true;
                        }
                        break;
                }
            }




            return valid;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Player selected = lbxSelected.SelectedItem as Player;

            // Check not null
            if (selected != null)
            {
                // Take action - move to other list
                allPlayers.Add(selected);
                selectedPlayers.Remove(selected);

                // Will use IComparable - CompareTo method
                selectedPlayers.Sort();
                allPlayers.Sort();


            }

            RefreshScreen();


        }
    }

}