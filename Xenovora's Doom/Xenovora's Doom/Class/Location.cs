namespace Xenovora_s_Doom.Class {
    internal abstract class Location {
        public string Name { get; set; }
        public string Description { get; set; }

        protected Location previousLocation;

        public Location(string name, string description) {
            Name = name;
            Description = description;
        }

        public virtual void ShowInfo() {
            Console.WriteLine($"{Name}: {Description}");
        }

        public abstract void ShowActions();

        public Location ReturnToPreviousLocation() {
            return previousLocation;
        }

        public abstract void HandleAction(int choice, MainCharacter player, Game game);
    }   
}
