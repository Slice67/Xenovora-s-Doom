namespace Xenovora_s_Doom.Class {
    internal class ForestLocation : Location {
        public ForestLocation()
            : base("Les", "Tmavý a hustý les plný zvuků zvěře.") { }

        public override void ShowActions() {
            Console.WriteLine("1) Lovit divokou zvěř.");
            Console.WriteLine("2) Vrátit se do osady.");
            Console.WriteLine("3) Sbírat dřevo.");
            Console.WriteLine("4) Rozdělat oheň a odpočinout si. Spotřebuje 1 dřevo");
        }


        public override async void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    Console.WriteLine($"{player.Name} loví zvířata.");
                    Item animal = new Item("Zvěř", "Ulovené zvíře", 1, 1); // Max. 1 na slot
                    if ( player.PlayerInventory.AddItem(animal) ) {
                        Console.WriteLine("Lov se podařil, ulovil jsi zvěř.");
                    } else {
                        Console.WriteLine("Nemáš místo v inventáři na další zvěř.");
                    }
                    break;
                case 2:
                    await game.ChangeLocation(new VillageLocation(game.GetVillage()));
                    break;
                case 3:
                    Console.WriteLine($"{player.Name} sbírá dřevo.");
                    Item wood = new Item("Dřevo", "Nasbírané dřevo", 1, 10); // Max. 10 na slot
                    if ( player.PlayerInventory.AddItem(wood) ) {
                        Console.WriteLine("Nasbíral jsi dřevo.");
                    } else {
                        Console.WriteLine("Nemáš místo v inventáři nebo už máš maximální množství dřeva.");
                    }
                    break;
                case 4:
                    await player.Rest();
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }
    }
}
