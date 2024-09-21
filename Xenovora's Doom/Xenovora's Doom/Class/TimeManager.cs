using System.Timers;

namespace Xenovora_s_Doom.Class {
    internal class TimeManager {
        private System.Timers.Timer gameTimer;
        private Village village;
        private MainCharacter player;
        private Game game;

        public TimeManager(Village village, MainCharacter player, Game game) {
            this.village = village;
            this.player = player;
            this.game = game;

            gameTimer = new System.Timers.Timer(60000); // 10 sekund
            gameTimer.Elapsed += OnTimedEvent;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            if ( !( game.GetCurrentLocation() is VillageLocation ) ) {
                UpdateGameState(); // Aktualizace stavu jen pokud není ve vesnici
            }
        }

        private void UpdateGameState() {
            player.Hunger--;
            player.Thirst--;
            
            //regenerace HP z jídla když je >50%
            //ubírání HP když je jídlo nebo voda <30%

            village.WaterSupply--;
            village.WoodSupply--;
            village.FoodSupply--;

            if ( village.FoodSupply < 0 ) {
                village.FoodSupply = 0;
                Console.WriteLine("Zásoby jídla došly!");
            }

            if ( village.WaterSupply < 0 ) {
                village.WaterSupply = 0;
                Console.WriteLine("Zásoby vody došly!");
            }

            if ( village.WoodSupply < 0 ) {
                village.WoodSupply = 0;
                Console.WriteLine("Zásoby dřeva došly!");
            }

            //Console.WriteLine("Stavy postav a vesnice byly aktualizovány.");
        }

        public void StopTimer() {
            gameTimer.Stop();
            gameTimer.Dispose();
        }
    }
}
