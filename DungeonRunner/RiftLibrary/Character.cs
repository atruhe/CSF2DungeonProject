using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLibrary
{
    public class Character
    {
        private int _life;
        private int _heal;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end Life
        public int Heal
        {
            get { return _heal; }
            set { _heal = value <= MaxLife ? value : MaxLife;
            }
        }



        //even though we won't be making Character objects, we want a ctor to use as a foundation
        //for child classes
        public Character(string name, int hitChance, int block, int life, int maxLife)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }//FQCTOR

        //Becuase we want different outputs for the Player and the Monster we will
        //not write a ToString() here.

        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        //because we have no way to calculate the damage in this class but 
        //both child classes will need to be able to do so we will create
        //some base functionality here that we will override in each child:

        public virtual int CalcDamage()
        {
            return 0;
        }
    }
}
