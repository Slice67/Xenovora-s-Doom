namespace Xenovora_s_Doom.Class {
    internal class Bandit : Enemy {
        public Bandit(string name, int health, bool isAggressive, int damage)
            : base(name, health, isAggressive, damage) {
        }

        public void Steal(MainCharacter target) {
            Console.WriteLine($"{Name} se pokouší okrást {target.Name}");
            // TODO bojování
            //logika kradeze
        }
    }
}
