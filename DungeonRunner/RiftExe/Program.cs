using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiftLibrary;

namespace RiftExe
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "Tristram";

            int playerLives = 3;

            do
            {               
                Console.WriteLine("Welcome to Tristram, hero. Many like you have come before and fallen.\nWhat shall we call you?");
                string playerName = Console.ReadLine();
                Race characterRace = Race.Barbarian;

                Console.WriteLine("And what be your class {0}?\nB)arbarian\nD)emon Hunter\nM)onk", playerName);
                ConsoleKey userRace = Console.ReadKey(true).Key;
                switch (userRace)
                {                
                    case ConsoleKey.B:
                        characterRace = Race.Barbarian;
                        break;
                    case ConsoleKey.D:
                        characterRace = Race.DemonHunter;
                        break;
                    case ConsoleKey.M:
                        characterRace = Race.Monk;
                        break;
                    case ConsoleKey.P:
                        characterRace = Race.Pleb;
                        break;
                    default:
                        break;
                }
                Console.Clear();

                Weapon scimitar = new Weapon("Rusty Dull Scimitar", 10, 20, 0, false);

                Player player = new Player(playerName, 75, 25, 50, 50, 10, characterRace, scimitar);
                Console.WriteLine("\nWelcome to Tristram.\nYou see the charred remains of buildings. Scorched corpses litter the ground. It is but a small glimpse into Hell.\n");

                int killCount = 0;
                bool exit = false;

                do
                {
                    Monster m1 = new Monster("Spider", 50, 0, 15, 15, 1, 10, "It looks like a spider, only smaller.");
                    Dragon d1 = new Dragon("Smol Dragon", 60, 20, 30, 30, 3, 15, "It looks like a dragon, only smaller", false);
                    Dragon d2 = new Dragon("Smol Dragon", 60, 20, 30, 30, 3, 15, "It looks like a dragon, only smaller", true);
                    Dragon d3 = new Dragon("Big Dragon", 70, 40, 50, 50, 5, 15, "Definitely a big dragon.", false);
                    Dragon d4 = new Dragon("Big Dragon", 70, 40, 70, 70, 5, 15, "Definitely a big dragon.", true);

                    Monster[] monsters = { m1, d3, d2 };
                    Monster monster = monsters[new Random().Next(monsters.Length)];

                    //TODO Display a Room
                    Console.WriteLine(Room.RoomDescription() + "\n" + "In this room you see a " + monster.Name);

                    bool reloadRoom = false;

                    do
                    {
                        Console.WriteLine("\nChoose an Action:\n" +
                            "A)ttack\n" +
                            "H)eal\n" +
                            "R)UN AWAY!\n" +
                            "P)layer Stats\n" +
                            "M)onster Stats\n" +
                            "(Esc to exit game)");
                        ConsoleKey userChoice = Console.ReadKey().Key;

                        Console.Clear();

                        switch (userChoice)
                        {
                            case ConsoleKey.A:
                                Combat.DoAttack(player, monster);
                                if (monster.Life > 0)
                                {
                                    Combat.DoAttack(monster, player);
                                }
                                if (monster.Life < 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("\nYou have slain the minion of hell, {0}.", monster.Name);
                                    Console.ResetColor();
                                    reloadRoom = true;
                                    killCount++;
                                }
                                break;
                            case ConsoleKey.H:
                                Combat.DoHeal(player, monster);
                                break;
                            case ConsoleKey.R:
                                Console.WriteLine("The " + monster.Name + " attacks you as you flee.");
                                Combat.DoAttack(monster, player);
                                reloadRoom = true;
                                break;
                            case ConsoleKey.P:
                                Console.WriteLine(player + "\nMonsters slain: " + killCount);
                                Console.WriteLine("Lives remaining: " + playerLives);
                                break;
                            case ConsoleKey.M:
                                Console.WriteLine(monster);
                                break;
                            case ConsoleKey.Escape:
                                Console.WriteLine("Goodbye nephalem. Hell waits for you.");
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Try again nephalem");
                                break;
                        }
                        if (player.Life < 1 && playerLives >= 1)
                        {
                            Console.WriteLine("YOU HAVE BEEN SLAIN!\n" + monster.Name + " dealt the final blow.\n Try again, maybe be a little more cautious this time.");
                            player.Life = player.MaxLife;
                            --playerLives;
                            Console.WriteLine("Lives remaining: " + playerLives);
                            exit = false;
                        }
                        else if (player.Life < 1 && playerLives <= 0)
                        {
                            Console.WriteLine("YOU HAVE BEEN SLAIN!\n" + monster.Name + " dealt the final blow.\n You make try again.");

                            exit = true;
                        }

                    } while (!reloadRoom && !exit);
                } while (!exit);

                Console.WriteLine(player.Name + " managed to slay {0} monster{1} before falling.",
                    killCount,
                    killCount == 1 ? "" : "s");


            } while (playerLives <= 0);

            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Lives remaining:" + playerLives);



        }
    }
}
