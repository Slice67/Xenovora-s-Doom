namespace Xenovora_s_Doom.Class {
    internal class VillageLocation : Location {
        private Village village;

        public VillageLocation(Village village) 
            : base("Loduq", "Bezpečná osada s domy a zásobami."){
            this.village = village;
        }

        public override void ShowActions() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Možnosti akcí ===");
            Console.ResetColor();
            Console.WriteLine("1) Odpočívat.");
            Console.WriteLine("2) Jít do lesa.");
            Console.WriteLine("3) Zkontrolovat status osadníků.");
            Console.WriteLine("4) Status zásob.");
            Console.WriteLine("5) Odevzdat zásoby.");
            Console.WriteLine("6) Zobrazit inventář.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================");
            Console.ResetColor();
        }

        public override async void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    await player.Rest(game.GetCurrentLocation());
                    break;
                case 2:
                    await game.ChangeLocation(new ForestLocation());
                    break;
                case 3:
                    int anotherChoice;
                    Console.WriteLine("Jakou rodinu chceš zkontrolovat?\n1) Luminara\n2) Stormwind\n3) Nightshade\n4) Ironwood");
                    if ( int.TryParse(Console.ReadLine(), out anotherChoice) ) {

                        switch ( anotherChoice ) { 
                        case 1:
                            village.PrintSettlerFamily("Luminara");
                            break;
                        case 2:
                            village.PrintSettlerFamily("Stormwind");
                            break;
                        case 3:
                            village.PrintSettlerFamily("Nightshade");
                            break;
                        case 4:
                            village.PrintSettlerFamily("Ironwood");
                            break;
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Status zásob.");
                    village.PrintSupplies();
                    break;
                case 5:
                    Console.WriteLine("Jaký typ zásoby chceš odevzdat? (jídlo, voda, dřevo)");
                    string resourceType = Console.ReadLine();
                    Console.WriteLine("Kolik kusů chceš odevzdat?");
                    int amount;

                    if ( int.TryParse(Console.ReadLine(), out amount) ) {
                        Item item = player.PlayerInventory.Items.FirstOrDefault(i => i.Name.Equals(resourceType, StringComparison.OrdinalIgnoreCase));

                        if ( item != null && item.Quantity >= amount ) {
                            village.AddSupplies(resourceType, amount);
                            item.Quantity -= amount;
                            if ( item.Quantity <= 0 ) {
                                player.PlayerInventory.RemoveItem(item);
                            }

                            Console.WriteLine($"Úspěšně jsi odevzdal {amount} {resourceType}.");
                        } else {
                            Console.WriteLine("Nemáš dostatek zásob v inventáři.");
                        }
                    } else {
                        Console.WriteLine("Neplatné číslo.");
                    }
                    break;
                case 6:
                    player.PlayerInventory.PrintItems();
                    break;
                default:
                    Console.WriteLine("Neplatná volba");
                    break;
            }
        }
    }
}
