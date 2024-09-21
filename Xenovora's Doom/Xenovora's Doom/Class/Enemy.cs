namespace Xenovora_s_Doom.Class {
    internal class Enemy {
        public int Health { get; set; }
        public string Name { get; set; }
        public bool IsAggressive { get; set; }
        public int Damage { get; set; }

        public Enemy(string name, int health, bool isAggressive, int damage) {
            Name = name;
            Health = health;
            IsAggressive = isAggressive;
            Damage = damage;
        }

        public void Attack(MainCharacter target) {
            if ( IsAggressive ) {
                Console.WriteLine($"{Name} útočí na {target} a způsobuje {Damage} poškození.");
                target.Health -= Damage;
            } else {
                Console.WriteLine($"{Name} není agresivní a neútočí");
            }
        }

        public void TakeDamage(int amount) {
            Health -= Math.Clamp(Health - amount,0,100);
            Console.WriteLine($"{Name} utrpěl {amount} poškození, zbývá {Health} zdraví.");
        }

        public void Flee() {
            if ( Health < 20 ) {
                Console.WriteLine($"{Name} má málo zdraví a utíká.");
            } else {
                Console.WriteLine($"{Name} se rozhodl zůstat a bojovat.");
            }
        }
    }
}
