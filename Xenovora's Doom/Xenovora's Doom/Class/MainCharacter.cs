namespace Xenovora_s_Doom.Class {
    internal class MainCharacter : Character {
        public int Stamina { get; set; } 
        public int Hunger { get; set; }
        public int Thirst { get; set; }
        public Inventory PlayerInventory { get; set; }

        public MainCharacter(string name, int health, int hunger, int thirst, int stamina)
            : base(name, health) { 
            Stamina = stamina;
            PlayerInventory = new Inventory();
            Hunger = hunger;
            Thirst = thirst;
        }


        public async Task Rest(Location currentLocation) {
            if ( currentLocation.Name == "Loduq") {
                Console.WriteLine("Odpočíváš bezpečně v osadě...");

                Stamina += 20;
                if ( Stamina > 100 ) {
                    Stamina = 100;
                }

                Console.WriteLine($"Odpočal sis, nyní máš {Stamina} energie.");
            }
            else {
                Item wood = PlayerInventory.Items.FirstOrDefault(i => i.Name == "Dřevo");
                if ( wood != null && wood.Quantity > 0 ) {
                    Console.WriteLine("Odpočíváš a pálíš dřevo, aby ses zahřál...");

                    wood.Quantity--;
                    if ( wood.Quantity == 0 ) {
                        PlayerInventory.RemoveItem(wood);
                    }


                    Stamina += 20;
                    if ( Stamina > 100 ) {
                        Stamina = 100;
                    }

                    Console.WriteLine($"Odpočal sis, nyní máš {Stamina} energie. Zbývá ti {wood?.Quantity ?? 0} dřeva.");
                } else {
                    Console.WriteLine("Nemáš žádné dřevo, nemůžeš si odpočinout mimo osadu!");
                }
            }
        }


    }
}
