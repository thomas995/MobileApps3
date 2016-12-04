using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MVVMJSON
{
    
    public sealed partial class BattlePage : Page
    {
        private Player _player; // reads in vars from Player class
        private Enemy _enemy; // reads in vars from Enemy class

        public BattlePage()
        {
            this.InitializeComponent();

            _player = new Player(); // creates new instance from the player class
            _enemy = new Enemy();   // creates new instance from the enemy class

            // PLAYER STARTING STATS
            _player.CurrentHP = 20;
            _player.Potions = 1;
            _player.Experience = 0;
            _player.Level = 0;
            _player.ExpNeeded = 100;
            _player.CurrentAttack = 4;
            _player.DefEnemies = 0;

            // ENEMY STARTING STATS
            _enemy.CurrentEnemyHP = 0;
            _enemy.CurrentEnemyAttack = 0;


            // Player Stats Displayed
            txtCurrentHP.Text = _player.CurrentHP.ToString();
            txtPotions.Text = _player.Potions.ToString();
            txtEXP_Points.Text = _player.Experience.ToString();
            txtLevel.Text = _player.Level.ToString();
            txtExpNeeded.Text = _player.ExpNeeded.ToString();

            txtCurrentAttack.Text = _player.CurrentAttack.ToString();

            // Enemy Stats Displayed
            txtCurrentEnemyHP.Text = _enemy.CurrentEnemyHP.ToString();
            txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
            
            // Randomly selects an enemy to start with at the start of the game
            Random rand = new Random();
            int dice = rand.Next(1, 4); // chooses between cases 1 through 4

            switch (dice)
            {
                case 1:

                    imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/Ahriman_398.png"));
                    _enemy.CurrentEnemyAttack = 1;
                    _enemy.CurrentEnemyHP = 4;

                    txtCurrentEnemyHP.Text = _enemy.CurrentEnemyHP.ToString();
                    txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();

                    break;
                case 2:

                    imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/FF_Cactuar_4581.png"));
                    _enemy.CurrentEnemyAttack = 2;
                    _enemy.CurrentEnemyHP = 6;

                    txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
                    txtCurrentEnemyHP.Text = _enemy.CurrentEnemyHP.ToString();
                    break;
                case 3:

                    imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/a6wjm.jpg"));
                    _enemy.CurrentEnemyAttack = 3;
                    _enemy.CurrentEnemyHP = 8;

                    txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
                    txtCurrentEnemyHP.Text = _enemy.CurrentEnemyHP.ToString();

                    break;
                case 4:
                    imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/87-Mantisant.png"));
                    _enemy.CurrentEnemyAttack = 4;
                    _enemy.CurrentEnemyHP = 10;
                    break;
            }
        }
            /*
            public static async Task LoadLocalData()
            {
                var file = await Package.Current.InstalledLocation.GetFileAsync("Data/myEnemy.txt");
                var result = await FileIO.ReadTextAsync(file);

                var jEnemyList = JsonArray.Parse(result);
                CreateEnemyList(jEnemyList);
            }

            private static void CreateEnemyList(JsonArray jEnemyList)
            {
                foreach (var item in jEnemyList)
                {
                    var oneEnemy = item.GetObject();
                    myEnemy nEnemy = new myEnemy();

                    foreach (var key in oneEnemy.Keys)
                    {
                        IJsonValue value;
                        if (!oneEnemy.TryGetValue(key, out value))
                            continue;

                        switch (key)
                        {
                            case "breed":
                                nEnemy.enemy = value.GetString();
                                break;
                            case "category":
                                nEnemy.health = value.GetNumber();
                                break;
                            case "grooming":
                                nEnemy.attack = value.GetNumber();
                                break;
                            case "image":
                                nEnemy.image = value.GetString();
                                break;
                        } // end switch
                    } // end foreach(var key in oneDog.Keys )
                    //eEnemyList.Add(nEnemy);
                } // end foreach (var item in jDogList)
            }

            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                //await LoadLocalData();

                GridViewEnemy.ItemsSource = eEnemyList;

            }
        */
        // functionality of game when the BATTLE button is clicked on
             private async void btnBattle_Click(object sender, RoutedEventArgs e)
        {
            _enemy.CurrentEnemyHP = _enemy.CurrentEnemyHP - _player.CurrentAttack; // takes away enemy's health equal to player's attack
            txtCurrentEnemyHP.Text = _enemy.CurrentEnemyHP.ToString(); // display new health stat

            _player.CurrentHP = _player.CurrentHP - _enemy.CurrentEnemyAttack; // takes away player's health equal to enemy's attack
            txtCurrentHP.Text = _player.CurrentHP.ToString(); // displays new health stat

            if (_enemy.CurrentEnemyHP <= 0) // if enemy health is 0
            {
                var dialog = new Windows.UI.Popups.MessageDialog("You defeated the enemy!" + " Now on to the next one!" + " You obtained a potion ingredient. 100 Exp earned!");
                var result = await dialog.ShowAsync(); // display text in dialog box

                _player.DefEnemies = _player.DefEnemies + 1; // defeated enemy stat increases by one

                _player.Potions = _player.Potions + 0.2; // player's potion value goes up by a bit
                txtPotions.Text = _player.Potions.ToString(); // displays new potion value

                _enemy.CurrentEnemyHP = _enemy.CurrentEnemyAttack + 6; // enemy attacks goes up by the enemy's attack plus 6

                _player.Experience = _player.Experience + 100; // experience increases by 100

                // displays new stat values
                txtEXP_Points.Text = _player.Experience.ToString(); 
                txtCurrentHP.Text = _player.CurrentHP.ToString(); 
                txtCurrentEnemyHP.Text = _enemy.CurrentEnemyHP.ToString();
                txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
                txtEXP_Points.Text = _player.Experience.ToString();

                // randomly selects enemy once again after the previous enemy is defeated
                Random rand = new Random();
                int dice = rand.Next(1, 4);

                switch (dice)
                {
                    case 1:

                        imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/Ahriman_398.png"));
                        _enemy.CurrentEnemyAttack++; // increments the enemy attack so that it is stronger the next time
                        txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
                        break;
                    case 2:

                        imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/FF_Cactuar_4581.png"));
                        _enemy.CurrentEnemyAttack++;
                        txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
                        break;
                    case 3:

                        imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/a6wjm.jpg"));
                        _enemy.CurrentEnemyAttack++;
                        txtCurrentEnemyAttack.Text = _enemy.CurrentEnemyAttack.ToString();
                        break;
                    case 4:
                        imgEnemy.Source = new BitmapImage(new Uri("ms-appx:/Images/EnemyImages/87-Mantisant.png"));
                        break;
                }
            }
            if (_player.CurrentHP <= 0) // if the player is defeated and health hits 0
            {
                var dialog = new Windows.UI.Popups.MessageDialog("You Have Been Slain. To Bad! The good news is you defeated " + _player.DefEnemies + " enemies! :D");
                var result = await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage)); // displays the above message and sends the player back to the home page of the app
            }
        }
        // button to level up the player
        private async void btnLevelUp_Click(object sender, RoutedEventArgs e)
        { 
            // if experience is more than what is required
            if (_player.Experience >= _player.ExpNeeded)
            {
                // takes away req experience from current experience
                _player.Experience = _player.Experience - _player.ExpNeeded;
                txtEXP_Points.Text = _player.Experience.ToString();

                // req exp for next time increases by 100
                _player.ExpNeeded = _player.ExpNeeded + 100;
                txtExpNeeded.Text = _player.ExpNeeded.ToString();

                // player level increments by one
                _player.Level++;
                txtLevel.Text = _player.Level.ToString();

                // increases attack of player by 2
                _player.CurrentAttack = _player.CurrentAttack + 2;
                txtCurrentAttack.Text = _player.CurrentAttack.ToString();

                // current player's hp increases by its base plus 5 more for every level they are
                _player.CurrentHP = 20 + (5 * _player.Level);

                var dialog = new Windows.UI.Popups.MessageDialog("You have leveled up to Level " + _player.Level + " Your Attack is now " + _player.CurrentAttack + " and Health is now at " + _player.CurrentHP);
                var result = await dialog.ShowAsync(); // displays message to confirm that the player has leveled up

                txtCurrentHP.Text = _player.CurrentHP.ToString();

            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("You need more experience!"); 
                var result = await dialog.ShowAsync(); // displays message to say you don't have enough exp
            }
        }

        private async void btnPotion_Click(object sender, RoutedEventArgs e)
        {
            if (_player.Potions <= 0.99) // when you have less than 1 potion in your inventoru
            {
                var dialog = new Windows.UI.Popups.MessageDialog("You have no potions in your inventory");
                var result = await dialog.ShowAsync(); // message is displayed saying that you don't have any
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("You have increased your health by 20");
                var result = await dialog.ShowAsync(); // message is displayed saying you have increase your health

                _player.CurrentHP = _player.CurrentHP + 20; // health increases by 20
                txtCurrentHP.Text = _player.CurrentHP.ToString();

                if(_player.CurrentHP >= 20) // if health goes above 20
                {
                    _player.CurrentHP = 20 + (5 * _player.DefEnemies); // health = 20 plus 5 for every level the player is
                    txtCurrentHP.Text = _player.CurrentHP.ToString();

                }

                txtCurrentHP.Text = _player.CurrentHP.ToString(); // updates player's stat

                _player.Potions = _player.Potions - 1; // takes away a potion
                txtPotions.Text = _player.Potions.ToString();
            }
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            //Player playerdata = new Player();
            //playerdata.CURRENT_HP = txtCurrentHP.Text;

            //SaveToXml.SaveData(playerdata, "save.xml");

        }
    }
    
}
