namespace Xenovora_s_Doom.Class {
    internal class VillageLocation : Location {
        private Village village;

        public VillageLocation(Village village) 
            : base("Loduq", "Bezpečná osada s domy a zásobami."){
            this.village = village;
        }

        public override void ShowActions() {
            Console.WriteLine("1) Odpočívat.");
            Console.WriteLine("2) Jít do lesa.");
            Console.WriteLine("3) Zkontrolovat status osadníků.");
            Console.WriteLine("4) Status zásob.");
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
                default:
                    Console.WriteLine("Neplatná volba");
                    break;
            }
        }



    }
}
