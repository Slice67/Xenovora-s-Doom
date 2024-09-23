namespace Xenovora_s_Doom.Class {
    internal class Character {
        public int Health { get; set; }
        public string Name { get; set; }

        public Character(string name, int health) {
            Name = name;
            Health = health;
        }
    }
}
