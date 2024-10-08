﻿namespace Xenovora_s_Doom.Class {
    internal class Game {
        public MainCharacter player; // Hlavní postava
        private Location currentLocation; // Aktuální lokace
        private Village village;
        private TimeManager timeManager;
        private bool isInputBlocked = false; // Přidána proměnná pro blokaci vstupu

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
                new Settler("Elara", 100),
                new Settler("Thalion", 100)
            };
            luminara.AddMember(luminaraSettlers);

            // Rodina Stormwind
            Family stormwind = new Family("Stormwind");
            Settler[] stormwindSettlers = {
                new Settler("Kael", 100),
                new Settler("Lyra", 100),
                new Settler("Finn", 100),
                new Settler("Mira", 100)
            };
            stormwind.AddMember(stormwindSettlers);

            // Rodina Nightshade
            Family nightshade = new Family("Nightshade");
            Settler[] nightshadeSettlers = {
                new Settler("Draven", 100),
                new Settler("Selene", 100),
                new Settler("Nyx", 100)
            };
            nightshade.AddMember(nightshadeSettlers);

            // Rodina Ironwood
            Family ironwood = new Family("Ironwood");
            Settler[] ironwoodSettlers = {
                new Settler("Garrick", 100),
                new Settler("Freya", 100),
                new Settler("Leif", 100),
                new Settler("Astrid", 100)
            };
            ironwood.AddMember(ironwoodSettlers);

            village.AddFamily(luminara);
            village.AddFamily(stormwind);
            village.AddFamily(nightshade);
            village.AddFamily(ironwood);
        }

        public async Task ChangeLocation(Location newLocation) {
            int staminaCost = 5;

            if ( player.Stamina >= staminaCost ) {
                player.Stamina -= staminaCost;
                Console.WriteLine($"Přesouváš se do {newLocation.Name}.");
                await Task.Delay(2000);
                currentLocation = newLocation;

                Console.WriteLine($"Dorazil jsi do {newLocation.Name}. Zbývá ti {player.Stamina} energie.");
                currentLocation.ShowActions();

            } else {
                Console.WriteLine("Nemáš dost energie na přesun. Musíš si odpočinout!");
            }

            Console.WriteLine($"Aktuální stamina po cestě: {player.Stamina}");
        }

        public Location GetCurrentLocation() {
            return currentLocation;
        }

        public void GameLoop() {
            currentLocation.ShowActions();
            while ( true ) {
                string input = Console.ReadLine();
                int choice;
                if ( int.TryParse(input, out choice) ) {
                    currentLocation.HandleAction(choice, player, this);
                }
            }
        }

        public Village GetVillage() {
            return village;
        }
    }
}
