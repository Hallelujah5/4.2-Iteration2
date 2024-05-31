using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Player : Game_Object
    {

        private Inventory _inventory;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
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
        
        public override string FullDescription 
        {
            get { return $"{Name}:\n {_inventory.ItemList} "; }        
        }


        public Inventory Inventory { get { return _inventory; } }







    }
}
 