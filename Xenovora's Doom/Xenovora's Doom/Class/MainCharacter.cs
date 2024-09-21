namespace Xenovora_s_Doom.Class {
    internal class MainCharacter : Character {
        public int Stamina { get; set; } 

        public MainCharacter(string name, int health, int hunger, int thirst, int stamina)
            : base(name, health, hunger, thirst) { // Zavolá konstruktor rodiče
            Stamina = stamina;
        }

        public void Hunt() {
            Console.WriteLine($"{Name} jde lovit!");
        }

        public void Rest(int hours) {
            Console.WriteLine($"Odpočinul sis {hours} a vyléčil x HP."); 
            //TODO přidat tik léčeni HP
            //logika přidávání HP
        }
    }
}
