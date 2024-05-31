using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Inventory 
    {
        List<Item> _items = new List<Item>();  
        
        
        
        public Inventory() {
            _items = new List<Item>(); 
        }


        public bool HasItem(string id) 
        {   
            foreach (Item itm in _items) { if (itm.AreYou(id)) { return true; } } //Check each items id in inventory see if it exists
            return false;       //if not returns false
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item _take = this.Fetch(id);
            _items.Remove(_take);
            return _take;
        }
        public Item Fetch(string id) {
            foreach (Item itm in _items){ if (itm.AreYou(id) ){ return itm; } }
            return null;
        }



        public string ItemList
        {
            
            get
            {   
                string _itemlist = "";
                foreach (Item itm in _items)
                {
                    _itemlist +=  "\t" + itm.ShortDescription.ToString() +"\n" ;
                }
                return _itemlist;
            }
        }
    }
}
