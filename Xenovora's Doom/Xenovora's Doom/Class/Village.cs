namespace Xenovora_s_Doom.Class {
    internal class Village {
        private List<Family> Families;
        public int FoodSupply { get; set; }
        public int WaterSupply { get; set; }
        public int WoodSupply { get; set; }

        public Village() {
            Families = new List<Family>();
            FoodSupply = 100;
            WaterSupply = 100;
            WoodSupply = 100;
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
    }
}
