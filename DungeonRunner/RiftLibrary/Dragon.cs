using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLibrary
{
    public class Dragon : Monster
    {
        public bool IsFlying { get; set; }

        public Dragon(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string desciption, bool isFlying) : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, desciption)
        {
            IsFlying = isFlying;
        }

        public override string ToString()
        {
            return base.ToString() + (IsFlying ? "\nIt's hovering just over the ground." : "\nThe ground trembles beneath it.");
        }

        public override int CalcBlock()
        {
            //int calculatedBlock = Block;
            //
            //if (IsFlying)
            //{
            //    calculatedBlock += calculatedBlock / 2;
            //}

            //return calculatedBlock;

            return IsFlying ? Block + Block / 2 : Block;
        }
    }
}
