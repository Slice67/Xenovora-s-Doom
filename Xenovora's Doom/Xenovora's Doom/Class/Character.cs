namespace Xenovora_s_Doom.Class {
    internal class Character {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Hunger { get; set; }
        public int Thirst { get; set; }

        public Character(string name, int health, int hunger, int thirst) {
            Name = name;
            Health = health;
            Hunger = hunger;
            Thirst = thirst;
        }

        public void Eat(int foodAmmount) {
            Hunger += foodAmmount;
            Console.WriteLine($"{Name} se najedl.");
        }

        public void Drink(int waterAmmount) {
            Thirst += waterAmmount;
            Console.WriteLine($"{Name} se napil.");
        }
    }
}
