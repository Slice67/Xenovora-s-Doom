namespace Xenovora_s_Doom.Class {
    internal class Family {
        public string FamilyName { get; set; }
        public List<Settler> Members { get; set; }

        public Family(string familyName) {
            FamilyName = familyName;
            Members = new List<Settler>();
        }

        public void AddMember(Settler[] settler) {
            Members.AddRange(settler);
        }

        public void PrintFamilyMembers() {
            foreach ( var member in Members ) {
                member.CheckStatus();
            }
        }

        public int GetFoodConsumption() {
            return Members.Count;
        }

        public int GetWaterConsumption() {
            return Members.Count * 2;
        }

        public int GetWoodConsumption() {
            return 1;
        }
    }
}
