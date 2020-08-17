using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(250);
            if (diceRoll <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name,
                    defender.Name,
                    damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} MISSED!", attacker.Name);
            }
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }

        public static void DoHeal(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(250);
            if (diceRoll <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                int lifeHealed = attacker.CalcDamage();

                attacker.Life += lifeHealed;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("{0} healed for {1} life!",
                    attacker.Name,
                    lifeHealed);
                Console.ResetColor();
            }
            else {
                Console.WriteLine("{0} FAILED TO HEAL!", attacker.Name);
                DoAttack(defender, attacker);
            }
        }
    }
}
