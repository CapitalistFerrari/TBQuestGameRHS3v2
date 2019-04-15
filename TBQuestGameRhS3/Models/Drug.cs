using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGameRH.Models
{
    public class Drug : GameItem
    {
        public int HPChange { get; set; }

        public Drug(int id, string name, int value, int hpChange, string description, int level)
            : base(id, name, value, description, level)
        {
            HPChange = hpChange;
        }

        public override string InformationString()
        {
            if (HPChange != 0)
            {
                return $"{Name}: {Description}\nHP: {HPChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
