using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Player : Game_Object, IHaveInventory
    {

        private Inventory _inventory;
        Location _location;
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
    var item = _inventory.Fetch(id);
    if (item != null)
    {
        return item;
    }
    if (_location != null)
    {
        return _location.Locate(id);
    }
    return null;
}

        
        public override string FullDescription 
        {
            get { return $"{Name}:\n {_inventory.ItemList} "; }        
        }


        public Inventory Inventory { get { return _inventory; } }


        public Location Location    
        {
            get { return _location; }
            set {  _location = value; }
        }




    }
}
 