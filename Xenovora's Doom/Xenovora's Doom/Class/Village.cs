using System.Timers;

namespace Xenovora_s_Doom.Class {
    internal class Village {
        public List<Family> Families;
        public int FoodSupply { get; set; }
        public int WaterSupply { get; set; }
        public int WoodSupply { get; set; }

        public Village() {
            Families = new List<Family>();
            FoodSupply = 45;
            WaterSupply = 60;
            WoodSupply = 10;
        }
        public void AddFamily(Family family) { 
            Families.Add(family);
        }
        public void PrintSettlerFamily(string familyName) {
            Family family = Families.Find(f => f.FamilyName == familyName);
            if ( family != null ) {
                family.PrintFamilyMembers();
            }
        }

        public void PrintSupplies() {
            Console.WriteLine($"Jídlo: {FoodSupply}.");
            Console.WriteLine($"Voda: {WaterSupply}.");
            Console.WriteLine($"Dřevo: {WoodSupply}.");
        }

        public void AddSupplies(string resourceType, int amount) {
            switch ( resourceType.ToLower() ) {
                case "jídlo":
                    FoodSupply += amount;
                    Console.WriteLine($"Přidáno {amount} jídla. Celkem: {FoodSupply}");
                    break;
                case "voda":
                    WaterSupply += amount;
                    Console.WriteLine($"Přidáno {amount} vody. Celkem: {WaterSupply}");
                    break;
                case "dřevo":
                    WoodSupply += amount;
                    Console.WriteLine($"Přidáno {amount} dřeva. Celkem: {WoodSupply}");
                    break;
                default:
                    Console.WriteLine("Neznámý typ zdroje.");
                    break;
            }
        }

        private void UpdateSupplies(object sender, ElapsedEventArgs e) {
            int totalFoodConsumption = Families.Sum(f => f.GetFoodConsumption());
            int totalWaterConsumption = Families.Sum(f => f.GetWaterConsumption());
            int totalWoodConsumption = Families.Sum(f => f.GetWoodConsumption());

            FoodSupply -= totalFoodConsumption;
            WaterSupply -= totalWaterConsumption;
            WoodSupply -= totalWoodConsumption; // Zde můžeš také zohlednit dřevo, pokud je potřeba

            // Zajištění, že zásoby nejdou pod nulu
            if ( FoodSupply < 0 ) FoodSupply = 0;
            if ( WaterSupply < 0 ) WaterSupply = 0;
            if ( WoodSupply < 0 ) WoodSupply = 0;

            Console.WriteLine($"Aktualizované zásoby: Jídlo: {FoodSupply}, Voda: {WaterSupply}, Dřevo: {WoodSupply}");
        }
    }
}
