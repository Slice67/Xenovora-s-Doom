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

        public bool AddItem(Item item) {
            if ( items.Count < maxItems ) {
                items.Add(item);
                return true;
            }
            return false;
        }

        public void RemoveItem(Item item) {
            items.Remove(item);
        }

        public void PrintItems() {
            Console.WriteLine("Inventář: ");
            foreach (var item in items ) {
                Console.WriteLine($"- {item.Name}: {item.Description}.");
            }
        }
    }
        
}
