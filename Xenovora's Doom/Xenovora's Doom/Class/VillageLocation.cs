namespace Xenovora_s_Doom.Class {
    internal class VillageLocation : Location {
        private Village village;

        public VillageLocation(Village village) 
            : base("Loduq", "Bezpečná osada s domy a zásobami."){
            this.village = village;
        }

        public override void ShowActions() {
            Console.WriteLine("1) Odpočívat.");
            Console.WriteLine("2) Jít do lesa");

            // TODO přidat možnost odevzdat ulovenou kořist nebo dřevo, až bude inventář
        }

        public override void HandleAction(int choice, MainCharacter player, Game game) {
            switch ( choice ) {
                case 1:
                    Console.WriteLine($"{player.Name} odpočívá.");
                    break;
                case 2:
                    Console.WriteLine("Vydáváš se do lesa.");
                    game.ChangeLocation(new ForestLocation());
                    break;
                    //TODO moznost zkontrolovat statusy rodin
                default:
                    Console.WriteLine("Neplatná volba");
                    break;
            }
        }



    }
}
