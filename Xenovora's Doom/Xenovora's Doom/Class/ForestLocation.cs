using System.Numerics;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Xenovora_s_Doom.Class {
    internal class ForestLocation : Location {

        private Random random = new Random();
        public ForestLocation()
            : base("Les", "Tmavý a hustý les plný zvuků zvěře.") { }

        public override void ShowActions() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Možnosti akcí ===");
            Console.ResetColor();
            Console.WriteLine("1) Prozkoumat les");
            Console.WriteLine("2) Vrátit se do osady.");
            Console.WriteLine("3) Sbírat dřevo.");
            Console.WriteLine("4) Nabrat vodu.");
            Console.WriteLine("5) Rozdělat oheň a odpočinout si. Spotřebuje 1 dřevo.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================");
            Console.ResetColor();
        }


        public override async void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    Console.WriteLine("Prozkoumáváš les...");

                    Enemy enemy = GenerateRandomEnemy();


                    if ( enemy.IsAggressive ) {
                        Console.WriteLine($"Narazil jsi na {enemy.Name}!");
                        Console.WriteLine("Nepřítel je agresivní! Můžeš bojovat nebo utéct.");
                        Console.WriteLine("1) Bojovat\n2) Utéct");
                        int anotherChoice;
                        if ( int.TryParse(Console.ReadLine(), out anotherChoice) ) {
                            switch ( anotherChoice ) {
                                case 1:
                                    Battle(player, enemy);
                                    break;
                                case 2:
                                    AttemptToFlee(enemy, player);
                                    break;
                                default:
                                    Console.WriteLine("Neplatná volba.");
                                    break;
                            }
                        }
                    } else {
                        Console.WriteLine($"{enemy.Name} není agresivní. Můžeš lovit.");
                        Console.WriteLine("1) Bojovat\n2) Utéct");
                        int anotherChoice;
                        if ( int.TryParse(Console.ReadLine(), out anotherChoice) ) {
                            switch ( anotherChoice ) {
                                case 1:
                                    Item loot = new Item("jídlo", "Jídlo z ulovené zvěře", 1, 5);
                                    player.PlayerInventory.AddItem(loot);
                                    Console.WriteLine($"Úspěšně jsi ulovil {loot.Name}.");
                                    break;
                                case 2:
                                    Console.WriteLine($"Úspěšně jsi utekl před {enemy.Name}!");
                                    break;
                                default:
                                    Console.WriteLine("Neplatná volba.");
                                    break;
                            }
                        }
                    }
                    break;
                case 2:
                    await game.ChangeLocation(new VillageLocation(game.GetVillage()));
                    break;
                case 3:
                    Item wood = new Item("Dřevo", "Nasbírané dřevo", 1, 10);
                    if ( player.PlayerInventory.AddItem(wood) ) {
                        Console.WriteLine("Nasbíral jsi dřevo.");
                        player.Stamina -= 5;
                    } else {
                        Console.WriteLine("Nemáš místo v inventáři nebo už máš maximální množství dřeva.");
                    }
                    break;
                case 4:
                    Item water = new Item("voda", "Nabraná voda", 1, 10);
                    if ( player.PlayerInventory.AddItem(water) ) {
                        Console.WriteLine("Nabral jsi vodu do láhve.");
                        player.Stamina -= 2;
                    } else {
                        Console.WriteLine("Nemáš místo v láhvi");
                    }
                    break;
                case 5:
                    await player.Rest(game.GetCurrentLocation());
                    break;

                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }

        private Enemy GenerateRandomEnemy() {
            int enemyType = random.Next(100);

            if ( enemyType < 75 ) { // 60% šance na zvíře
                if ( random.Next(100) < 50 ) {
                    return new Animal("Jelen", 20, false, 0, "ten");
                } else if ( random.Next(100) < 30 ) {
                    return new Animal("Srnka", 10, false, 0, "ta");
                } else if ( random.Next(100) < 20 ) {
                    return new Animal("Medvěd", 40, true, 15, "ten");
                } else {
                    return new Animal("Prase", 30, true, 12, "to");
                }
            } else {
                return new Bandit("Bandita", 40, 15, "ten");
            }
        }

        private async void Battle(MainCharacter player, Enemy enemy) {
            Console.WriteLine("Boj začíná!");
            while ( player.Health > 0 && enemy.IsAlive() ) {
                await Task.Delay(1000);
                if ( random.Next(100) < 75 ) { // 75% šance na zásah
                    int damage = random.Next(5, 16); // Náhodné poškození mezi 5 a 15
                    enemy.TakeDamage(damage);
                    Console.WriteLine($"{player.Name} útočí na {enemy.Name} a způsobuje {damage} poškození!");
                } else {
                    Console.WriteLine($"{player.Name} minul!");
                }
                await Task.Delay(1500);
                if ( enemy.IsAlive() ) {
                    enemy.Attack(player);

                    Console.WriteLine($"{enemy.Name} útočí na {player.Name} a způsobuje {enemy.Damage} poškození!");
                }
            }
            if ( player.Health <= 0 ) {
                Console.WriteLine($"{player.Name} byl poražen!");
            } else {
                Console.WriteLine($"{enemy.Name} byl{enemy.SetRod()} poražen{enemy.SetRod()}!");
            }
        }


        private void AttemptToFlee(Enemy enemy, MainCharacter player) {
            if ( random.Next(100) < 35 ) { // 35% šance na útěk
                Console.WriteLine($"Úspěšně jsi utekl před {enemy.Name}!");
            } else {
                Console.WriteLine($"Nedaří se ti utéct! {enemy.Name} tě napadá!");
                enemy.Attack(player);
            }
        }
    }
}
