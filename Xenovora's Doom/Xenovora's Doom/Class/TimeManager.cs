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

            gameTimer = new System.Timers.Timer(60000); // 1 minuta
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
            if ( player.Hunger > 50 && player.Health != 100 ) {
                player.Health++;
            }

            if ( player.Hunger == 0 && player.Health != 0 ) {
                player.Health--;
                Console.WriteLine("Měl bys něco sníst!");
            }

            if ( player.Thirst <= 30 && player.Stamina != 0 ) {
                player.Stamina--;
                Console.WriteLine("Měl by ses něčeho napít!");
            }

            int totalFoodConsumption = village.Families.Sum(f => f.GetFoodConsumption());
            int totalWaterConsumption = village.Families.Sum(f => f.GetWaterConsumption());
            int totalWoodConsumption = village.Families.Sum(f => f.GetWoodConsumption());

            village.FoodSupply -= totalFoodConsumption;
            village.WaterSupply -= totalWaterConsumption;
            village.WoodSupply -= totalWoodConsumption;

            // Kontrola zásob
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
        }
    }
}
