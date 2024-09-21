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
            Console.WriteLine($"Rodina {FamilyName}:");
            foreach ( var member in Members ) {
                Console.WriteLine($"- {member.Name}");
                Console.Write($" - status: \n{member.CheckStatus}"); // TODO udelat timer
            }
        }
    }
}
