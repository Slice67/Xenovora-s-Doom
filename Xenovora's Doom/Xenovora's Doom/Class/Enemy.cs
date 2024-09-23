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
                target.Health -= Damage;
        }

        public void TakeDamage(int amount) {
            Health -= amount;
            if ( Health < 0 ) Health = 0;
        }

        public bool IsAlive() {
            return Health > 0;
        }
    }
}
