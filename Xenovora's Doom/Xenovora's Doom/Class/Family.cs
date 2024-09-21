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
    }
}
