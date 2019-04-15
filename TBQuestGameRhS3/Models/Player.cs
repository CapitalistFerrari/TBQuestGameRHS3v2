using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGameRH.Models
{
    public class Player : Character
    {
        #region ENUMS

        public new enum Status
        {
            Normal, Frenzied, Hallucinating
        }


        #endregion

        #region FIELDS

        protected new int _id;
        protected new string _name;
        protected new int _locationid;
        private int _hp;
        protected new bool _isAlive;
        protected new Status _status;
        protected int _level;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _drugs;
        private ObservableCollection<GameItem> _loot;
        private ObservableCollection<GameItem> _weapons;
        


        #endregion

        #region PROPERTIES

        public new string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public new int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public new int LocationId
        {
            get { return _locationid; }
            set { _locationid = value; }
        }

        public new int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public new bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public new Status CurrentStatus
        {
            get { return _status; }
            set { _status = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItem> Drugs
        {
            get { return _drugs; }
            set { _drugs = value; }
        }

        public ObservableCollection<GameItem> Loot
        {
            get { return _loot; }
            set { _loot = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _locationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItem>();
            _loot = new ObservableCollection<GameItem>();
            _drugs = new ObservableCollection<GameItem>();
            
        }

        public override string DefaultGreeting()
        {
            return "What's the score here?";
        }

        public override string DefaultFarewell()
        {
            return "Buy the ticket, take the ride.";
        }

        public override bool DeadOrAlive()
        {
            if (HP < 1)
            {
                return false;
            }
            else if (HP >= 1)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public override bool IsHit()
        {
            return false;
        }


        #endregion

        #region METHODS

        public void UpdateInventoryCategories()
        {
            Drugs.Clear();
            Weapons.Clear();
            Loot.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Drug) Drugs.Add(gameItem);
                if (gameItem is Weapon) Weapons.Add(gameItem);
                if (gameItem is Loot) Loot.Add(gameItem);
            }
        }

        ///<param name = "selectedGameItem" > selected item</param>

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }

        ///<param name = "selectedGameItem" > selected item</param>

        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }
        #endregion
    }
}
