using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGameRH.Models
{
    public class Location
    {
        #region ENUMS


        #endregion

        #region FIELDS

        private int _id; 
        private string _name;
        private string _description;
        private bool _accessible;
        private int _requiredLevel;
        private int _modifiyLevel;
        private int _modifyHealth;
        private string _message;
        private ObservableCollection<GameItem> _gameItems;


        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int ModifyLevel
        {
            get { return _modifiyLevel; }
            set { _modifiyLevel = value; }
        }

        public int RequiredLevel
        {
            get { return _requiredLevel; }
            set { _requiredLevel = value; }
        }

        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        #endregion




        #region CONSTRUCTORS

        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }

        #endregion


        #region METHODS

        public bool IsAccessibleByLevel(int playerLevel)
        {
            return playerLevel >= _requiredLevel ? true : false;
        }

        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();

            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }

        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Add(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }


        #endregion
    }
}
