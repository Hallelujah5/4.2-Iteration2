using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;


        public Bag(string[] ids, string name, string desc) : base(ids, name, desc) 
        {
            _inventory = new Inventory();
        }


        public Game_Object Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id)) {return _inventory.Fetch(id); }
            return null;
        }

        public override string FullDescription
        {
            get { return $"In the {Name} you can see: " + _inventory.ItemList; }
        }
        public Inventory Inventory { get { return _inventory; } }
    }
}
