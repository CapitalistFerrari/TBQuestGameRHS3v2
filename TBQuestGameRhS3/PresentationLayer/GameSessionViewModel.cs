using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGameRH.Models;
using TBQuestGameRH;
using System.Windows.Threading;
using TBQuestGameRH.DataLayer;
using System.Collections.ObjectModel;

namespace TBQuestGameRH.PresentationLayer
{
    public partial class GameSessionViewModel : ObservableObject
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private TimeSpan _gameTime;
        private Player _player;
        private Map _gameMap;
        private Location _currentLocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private GameItem _currentGameItem;
        private string _currentLocationInformation;

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return _currentLocation.Message; }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }

        public string MissionTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(MissionTimeDisplay));
            }
        }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;

            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();

            GameTimer();
        }

        #endregion

        #region METHODS

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            _player.UpdateInventoryCategories();
            _currentLocationInformation = CurrentLocation.Description;
        }

        private void UpdateAvailableTravelPoints()
        {
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation(_player) != null)
            {
                NorthLocation = _gameMap.NorthLocation(_player);
            }

            if (_gameMap.EastLocation(_player) != null)
            {
                EastLocation = _gameMap.EastLocation(_player);
            }

            if (_gameMap.SouthLocation(_player) != null)
            {
                SouthLocation = _gameMap.SouthLocation(_player);
            }

            if (_gameMap.WestLocation(_player) != null)
            {
                WestLocation = _gameMap.WestLocation(_player);
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                
            }
        }

        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                
            }
        }

        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                
            }
        }

        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                
            }
        }

        #region GAME TIME METHODS

        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        public void GameTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += OnGameTimerTick;
            timer.Start();
        }

        void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            MissionTimeDisplay = "Elapsed Time" + _gameTime.ToString(@"hh\:mm\ss");
        }

        #endregion

        #region ACTION METHODS


        /// <param name="selectedItem"></param>
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }


        /// <param name="selectedItem"></param>
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }


        /// <param name="gameItem">new game item</param>
        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.Level += gameItem.Level;
        }


        /// <param name="gameItem">new game item</param>
        private void OnPlayerPutDown(GameItem gameItem)
        {
        }


        /// </summary>
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Drug drug:
                    ProcessPotionUse(drug);
                    break;
                default:
                    break;
            }
        }
        /// <param name="potion">potion</param>
        private void ProcessPotionUse(Drug drug)
        {
            _player.HP += drug.HPChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
        }

        // todo 33 GameSessionViewModel: add method to handle the player dies event
        /// <summary>
        /// process player dies with option to reset and play again
        /// </summary>
        /// <param name="message">message regarding player death</param>
        //private void OnPlayerDies(string message)
        //{
        //    string messagetext = message +
        //        "\n\nWould you like to play again?";

        //    string titleText = "Death";
        //    MessageBoxButton button = MessageBoxButton.YesNo;
        //    MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

        //    switch (result)
        //    {
        //        case MessageBoxResult.Yes:
        //            ResetPlayer();
        //            break;
        //        case MessageBoxResult.No:
        //            QuiteApplication();
        //            break;
        //    }
        //}

        /// <summary>
        /// player chooses to exit game
        /// </summary>
        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// player chooses to reset game
        /// </summary>
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }

        #endregion

        #endregion

        #region EVENTS


        #endregion
    }
}
