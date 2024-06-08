using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
     public class Location : Game_Object, IHaveInventory
    {
        Inventory _inventory;

        public Location(string[] id, string name, string desc) : base(id, name, desc)
        {
            _inventory = new Inventory();
        }

        public Game_Object Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public Inventory Inventory { get { return _inventory; } }

        public string FullDesc
        {
            get { return $"You are currently at {Name}. Item(s) in this location: " + _inventory.ItemList; }
        }



    }
}
