namespace Xenovora_s_Doom.Class {
    internal class Enemy {
        public int Health { get; set; }
        public string Name { get; set; }
        public bool IsAggressive { get; set; }
        public int Damage { get; set; }

        public string Rod { get; set; }

        public Enemy(string name, int health, bool isAggressive, int damage, string rod) {
            Name = name;
            Health = health;
            IsAggressive = isAggressive;
            Damage = damage;
            Rod = rod;
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

        public string SetRod() {
            if (Rod == "ten" ) {
                return "";
            } else if(Rod == "ta") {
                return "a";
            } else { 
                return "o";
            }
        }
    }
}
