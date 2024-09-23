using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Xenovora_s_Doom.Class {
    internal class Inventory {
        private List<Item> items;
        private const int maxItems = 10;

        public Inventory() {
            items = new List<Item>();
        }

        public List<Item> Items { get { return items; } }

        public bool AddItem(Item newItem) {
            var existingItem = items.FirstOrDefault(i => i.Name == newItem.Name);
            if ( existingItem != null ) {
                if ( existingItem.IsStackable() ) {
                    int availableSpace = existingItem.MaxStack - existingItem.Quantity;
                    int toAdd = Math.Min(availableSpace, newItem.Quantity);
                    existingItem.Quantity += toAdd;
                    Console.WriteLine($"Sebral jsi {toAdd} {newItem.Name}. Nyní máš {existingItem.Quantity}/{existingItem.MaxStack}.");
                    return true;
                } else {
                    Console.WriteLine($"{newItem.Name} už má maximální množství v inventáři.");
                    return false;
                }
            }
            if ( items.Count < maxItems ) {
                items.Add(newItem);
                Console.WriteLine($"Přidal jsi {newItem.Quantity} {newItem.Name}.");
                return true;
            } else {
                Console.WriteLine("Inventář je plný.");
                return false;
            }
        }

        public void RemoveItem(Item item) {
            items.Remove(item);
        }

        public void PrintItems() {
            Console.WriteLine("Inventář: ");
            foreach (var item in items ) {
                Console.WriteLine($"- {item.Name}: {item.Quantity}/{item.MaxStack} ({item.Description}).");
            }
        }
    }
        
}
