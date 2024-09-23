namespace Xenovora_s_Doom.Class {
    internal class Animal : Enemy {
        public Animal(string name, int health, bool isAggressive, int damage)
            : base(name, health, isAggressive, damage) {
        }

        public void Roam() {
            Console.WriteLine($"{Name} se potuluje po lese.");
        }

        public Item Hunt() {
            Console.WriteLine($"{Name} byl uloven!");

            return new Item("jídlo", "Ulovené maso", 1, 4);
        }
    }
}
