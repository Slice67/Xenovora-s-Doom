namespace Xenovora_s_Doom.Class {
    internal class MainCharacter : Character {
        public int Stamina { get; set; } 
        public Inventory PlayerInventory { get; set; }

        public MainCharacter(string name, int health, int hunger, int thirst, int stamina)
            : base(name, health, hunger, thirst) { 
            Stamina = stamina;
            PlayerInventory = new Inventory();
        }


        public async Task Rest() {
            Item wood = PlayerInventory.Items.FirstOrDefault(i => i.Name == "Dřevo");
            if ( wood != null && wood.Quantity > 0 ) {
                Console.WriteLine("Odpočíváš a pálíš dřevo, aby ses zahřál...");

                wood.Quantity--;
                if ( wood.Quantity == 0 ) {
                    PlayerInventory.RemoveItem(wood);
                }

                await Task.Delay(10000);

                Stamina += 20;
                if ( Stamina >= 100 ) {
                    Stamina = 100;
                }

                Console.WriteLine($"Odpočal sis, nyní máš {Stamina} energie. Zbývá ti {wood?.Quantity ?? 0} dřeva.");
            } else {
                Console.WriteLine("Nemáš žádné dřevo, nemůžeš si odpočinout mimo osadu!");
            }
        }

    }
}
