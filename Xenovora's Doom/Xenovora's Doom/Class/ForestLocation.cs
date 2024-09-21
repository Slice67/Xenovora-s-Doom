namespace Xenovora_s_Doom.Class {
    internal class ForestLocation : Location {
        public ForestLocation()
            : base("Les", "Tmavý a hustý les plný zvuků zvěře.") { }

        public override void ShowActions() {
            Console.WriteLine("1) Lovit divokou zvěř.");
            Console.WriteLine("2) Vrátit se do osady.");
            Console.WriteLine("3) Sbírat dřevo.");
        }


        public override void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    Console.WriteLine($"{player.Name} loví zvířata.");
                    // TODO přidat mechaniku loveni
                    break;
                case 2:
                    Console.WriteLine("Vracíš se do osady");
                    game.ChangeLocation(new VillageLocation(game.GetVillage()));
                    break;
                case 3:
                    Console.WriteLine("Sbíráš dřevo");
                    GatherWood(player);
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }

        private void GatherWood(MainCharacter player) {
            Random rand = new Random();
            int randomNum = rand.Next(1, 101);

            if(randomNum <=50) {
                Item wood = new Item("Dřevo", "Užitečné pro osadu na oheň.");
                if ( player.PlayerInventory.AddItem(wood) ) {
                    Console.WriteLine("Nasbíral jsi dřevo"); // TODO přidat náhodný počet dřeva
                } else {
                    Console.WriteLine("Inventář je plný, nemůžeš nasbírat dřevo.");
                }
            } else {
                Console.WriteLine("Nenašel jsi nic");
            }
        }
    }
}
