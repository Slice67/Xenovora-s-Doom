namespace Xenovora_s_Doom.Class {
    internal class Bandit : Enemy {
        public Bandit(string name, int health, int damage, string rod)
            : base(name, health, true, damage, rod) {
        }

        public void Steal(MainCharacter target) {
            Console.WriteLine($"{Name} se pokouší okrást {target.Name}");
            //logika kradeze
        }
    }
}
