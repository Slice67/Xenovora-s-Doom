namespace Xenovora_s_Doom.Class {
    internal class ForestLocation : Location {
        public ForestLocation()
            : base("Les", "Tmavý a hustý les plný zvuků zvěře.") { }

        public override void ShowActions() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Možnosti akcí ===");
            Console.ResetColor();
            Console.WriteLine("1) Vrátit se do osady.");
            Console.WriteLine("2) Sbírat dřevo.");
            Console.WriteLine("3) Nabrat vodu.");
            Console.WriteLine("4) Lovit divokou zvěř.");
            Console.WriteLine("5) Rozdělat oheň a odpočinout si. Spotřebuje 1 dřevo.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================");
            Console.ResetColor();
        }


        public override async void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    await game.ChangeLocation(new VillageLocation(game.GetVillage()));
                    break;
                case 2:
                    Item wood = new Item("Dřevo", "Nasbírané dřevo", 1, 10);
                    if ( player.PlayerInventory.AddItem(wood) ) {
                        Console.WriteLine("Nasbíral jsi dřevo.");
                        player.Stamina -= 5;
                    } else {
                        Console.WriteLine("Nemáš místo v inventáři nebo už máš maximální množství dřeva.");
                    }
                    break;
                case 3:
                    Item water = new Item("voda", "Nabraná voda", 1, 10);
                    if ( player.PlayerInventory.AddItem(water) ) {
                        Console.WriteLine("Nabral jsi vodu do láhve.");
                        player.Stamina -= 2;
                    } else {
                        Console.WriteLine("Nemáš místo v láhvi");
                    }
                    break;
                case 4:
                    Item animal = new Item("jídlo", "Ulovené zvíře", 1, 1);
                    if ( player.PlayerInventory.AddItem(animal) ) {
                        Console.WriteLine("Lov se podařil, ulovil jsi zvěř.");
                        player.Stamina -= 5;
                    } else {
                        Console.WriteLine("Nemáš místo v inventáři na další zvěř.");
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
    }
}
