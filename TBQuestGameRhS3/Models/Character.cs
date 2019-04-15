using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGameRH.Models
{
    public abstract class Character : ObservableObject
    {
        #region ENUMS

        public enum Status
        {
            Normal, Frenzied, Hallucinating
        }



        #endregion

        #region FIELDS

        protected int _id;
        protected string _name;
        protected int _locationid;        
        private int _hp;
        protected bool _isAlive;
        protected Status _status;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int LocationId
        {
            get { return _locationid; }
            set { _locationid = value; }
        }

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public Status CurrentStatus
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, int id, int locationid)
        {
            _name = Name;
            _id = ID;
            _locationid = LocationId;
        }

        public virtual string DefaultGreeting()
        {
            return "What's the score here?";
        }

        public virtual string DefaultFarewell()
        {
            return "Buy the ticket, take the ride.";
        }

        public abstract bool DeadOrAlive();


        public abstract bool IsHit();


        #endregion
    }
}
