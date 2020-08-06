using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set
        }

        public Monster(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string desciption) : base(name, hitChance, block, life, maxLife)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = desciption;
        }

        public override string ToString()
        {
            return string.Format("###{0}###\n{1}.\n???/{2}", Name, Description, MaxLife);
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }
    }
}
