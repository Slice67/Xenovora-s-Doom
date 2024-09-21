namespace Xenovora_s_Doom.Class {
    internal class Village {
        private List<Family> Families;
        public int FoodSupply { get; set; }
        public int WaterSupply { get; set; }
        public int WoodSupply { get; set; }

        public Village() {
            Families = new List<Family>();
            FoodSupply = 2;
            WaterSupply = 4;
            WoodSupply = 6;
        }
        public void AddFamily(Family family) { 
            Families.Add(family);
        }
        public void PrintSettlerFamily(string familyName) {
            Family family = Families.Find(f =>f.FamilyName == familyName);
            if ( family != null ) {
                family.PrintFamilyMembers();
            }
        }
    }
}
