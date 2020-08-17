using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLibrary
{
    public class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }


        public Player(string name, int hitChance, int block, int life, int maxLife, int heal, Race characterRace, Weapon equippedWeapon)
            : base(name, hitChance, block, life, maxLife)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            switch (CharacterRace)
            {
                case Race.Barbarian:
                    life += 20;
                    MaxLife += 20;
                    Block += 20;
                    HitChance -= 20;
                    break;
                //case Race.WitchDoctor:
                //    HitChance += 20;
                //    Block -= 20;
                //    break;
                //case Race.Necromancer:
                //   MaxLife += 20;
                //   Life += 20;
                //   HitChance -= 10;
                //    break;
                //case Race.Crusader:
                //    Block += 40;
                //    break;
                case Race.DemonHunter:
                    HitChance += 25;
                    MaxLife -= 10;
                    Life -= 10;
                    break;
                case Race.Monk:
                    MaxLife += 10;
                    Life += 10;
                    break;
                //case Race.Wizard:
                //    MaxLife -= 10;
                //    Life -= 10;
                //    HitChance -= 10;
                //    Block -= 10;
                //    break;
                case Race.Pleb:
                    MaxLife += 100;
                    life += 100;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Barbarian:
                    description = "You are a Barbarian";
                    break;
                //    case Race.WitchDoctor:
                //    description = "You are a Witch Doctor.";
                //    break;
                //    case Race.Necromancer:
                //    description = "The undead are yours to command, Necromancer";
                //    break;
                //    case Race.Crusader:
                //    description = "Crusader!";
                //    break;
                case Race.DemonHunter:
                    description = "Demons fear you, Demon Hunter.";
                    break;
                case Race.Monk:
                    description = "Always walk the path of light in the darkness, Monk.";
                    break;
                //case Race.Wizard:
                //    description = "";
                //    break;
                case Race.Pleb:
                    description = "You shouldn't have found this... Special powers granted.";
                    break;
                default:
                    break;
            }//end switch

            return string.Format("<=~ {0} ~=>\nLife: {1} of {2}\nHit Chance: {3}%\nWeapon: \n{4}\nHeal: {5}\nBlock: {6}\n{7}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Heal,
                Block,
                description);
        }//to string

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }

        public virtual int CalcHeal()
        {
            return new Random().Next(EquippedWeapon.MinDamage, ((EquippedWeapon.MaxDamage + 1) / 2));
        }

        //public override int CalcBlock()
        //{
        //    if (EquippedWeapon.IsTwoHanded)
        //    {
        //        EquippedWeapon.MinDamage += 1;
        //        EquippedWeapon.MaxDamage = EquippedWeapon.MaxDamage + (EquippedWeapon.MaxDamage / 4);
        //        Block -= 10;
        //    }
        //}
    }
}
