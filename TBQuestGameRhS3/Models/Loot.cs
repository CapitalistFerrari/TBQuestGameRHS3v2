using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGameRH.Models
{
    class Loot : GameItem
    {
        public enum Loottype
        {
            Coin,
            Jewel,
            Manuscript
        }

        public Loottype Type { get; set; }

        public Loot(int id, string name, int value, Loottype type, string description, int level)
            : base(id, name, value, description, level)
        {
            Type = type;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }
    }
}
