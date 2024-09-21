using Xenovora_s_Doom.Class;

namespace Xenovora_s_Doom {
    class Program {
        static void Main(string[] args) {

            MainCharacter player = new MainCharacter("Arwen", 100, 100, 100, 100);
            // Vytvoříme novou hru
            Game game = new Game();

            // Spustíme hru
            game.GameLoop(player);
        }
    }
}
