namespace Xenovora_s_Doom.Class {
    internal class Game {
        private MainCharacter player; // Hlavní postava
        private Location currentLocation; // Aktuální lokace
        private Village village;
        private TimeManager timeManager;

        public Game() {
            player = new MainCharacter("Arwen", 100, 100, 100, 100);
            village = new Village();
            timeManager = new TimeManager(village, player, this);
            currentLocation = new VillageLocation(village);
            InitializeVillage(); // Zavolání metody pro inicializaci vesnice
        }

        private void InitializeVillage() {
            // Rodina Luminara
            Family luminara = new Family("Luminara");
            Settler[] luminaraSettlers = {
                new Settler("Elara", 100, 100, 100),
                new Settler("Thalion", 100, 100, 100)
            };
            luminara.AddMember(luminaraSettlers);

            // Rodina Stormwind
            Family stormwind = new Family("Stormwind");
            Settler[] stormwindSettlers = {
                new Settler("Kael", 100, 100, 100),
                new Settler("Lyra", 100, 100, 100),
                new Settler("Finn", 100, 100, 100),
                new Settler("Mira", 100, 100, 100)
            };
            stormwind.AddMember(stormwindSettlers);

            // Rodina Nightshade
            Family nightshade = new Family("Nightshade");
            Settler[] nightshadeSettlers = {
                new Settler("Draven", 100, 100, 100),
                new Settler("Selene", 100, 100, 100),
                new Settler("Nyx", 100, 100, 100)
            };
            nightshade.AddMember(nightshadeSettlers);

            // Rodina Ironwood
            Family ironwood = new Family("Ironwood");
            Settler[] ironwoodSettlers = {
                new Settler("Garrick", 100, 100, 100),
                new Settler("Freya", 100, 100, 100),
                new Settler("Leif", 100, 100, 100),
                new Settler("Astrid", 100, 100, 100)
            };
            ironwood.AddMember(ironwoodSettlers);

            // Přidání rodin do vesnice
            village.AddFamily(luminara);
            village.AddFamily(stormwind);
            village.AddFamily(nightshade);
            village.AddFamily(ironwood);

        }

        public void ChangeLocation(Location newLocation) {
            currentLocation = newLocation;
        }

        public Location GetCurrentLocation() {
            return currentLocation;
        }

        public void GameLoop(MainCharacter player) {
            while ( true ) {
                Console.WriteLine($"\nJsi na místě: {currentLocation.Name}");
                currentLocation.ShowActions();

                string input = Console.ReadLine();
                int choice;
                if ( int.TryParse(input, out choice) ) {
                    currentLocation.HandleAction(choice, player, this);
                } else {
                    Console.WriteLine("Neplatný vstup. Zadej číslo akce.");
                }
            }
        }

        public Village GetVillage() {
            return village;
        }
    }
}
