namespace Xenovora_s_Doom.Class {
    internal class ForestLocation : Location {
        public ForestLocation()
            : base("Les", "Tmavý a hustý les plný zvuků zvěře.") { }

        public override void ShowActions() {
            Console.WriteLine("1) Lovit divokou zvěř.");
            Console.WriteLine("2) Vrátit se do osady.");

            // TODO sbírání dřeva až bude inventory
        }


        public override void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    Console.WriteLine($"{player.Name} loví zvířata.");
                    player.Hunt();
                    break;
                case 2:
                    Console.WriteLine("Vracíš se do osady");
                    game.ChangeLocation(new VillageLocation(game.GetVillage()));
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }
    }
}
