namespace Xenovora_s_Doom.Class {
    internal class MainCharacter : Character {
        public int Stamina { get; set; } 
        public Inventory PlayerInventory { get; set; }

        public MainCharacter(string name, int health, int hunger, int thirst, int stamina)
            : base(name, health, hunger, thirst) { // Zavolá konstruktor rodiče
            Stamina = stamina;
            PlayerInventory = new Inventory();
        }
    }
}
