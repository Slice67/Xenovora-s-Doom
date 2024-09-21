﻿using System;
namespace Xenovora_s_Doom.Class {
    internal class Settler : Character {
        public string FamilyName { get; set; }
        public bool isTakenCareOf { get; set; } //jestli je osadník dobře živený

        public Settler(string name, int health, int hunger, int thirst, string familyName)
            : base(name, health, hunger, thirst) {
            isTakenCareOf = true;
            FamilyName = familyName;
        }

        public Settler(string name, int health, int hunger, int thirst)
    : base(name, health, hunger, thirst) {
            isTakenCareOf = true;
        }

        public void Work() {
            Console.WriteLine($"{Name} pracuje na zlepšení podmínek v osadě.");
        }

        public void CheckStatus() {
            Console.WriteLine($"{Name}: Jídlo: {Hunger}, Voda: {Thirst}");
        }
    }
}
