using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenovora_s_Doom.Class {
    internal class Item {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int MaxStack { get; set; }

        public Item(string name, string description, int quantity, int maxStack) {
            Name = name;
            Description = description;
            Quantity = quantity;
            MaxStack = maxStack;
        }

        public bool IsStackable() {
            return Quantity < MaxStack;
        }
    }
}
