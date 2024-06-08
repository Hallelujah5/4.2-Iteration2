using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class InventoryTests
    {

        Item herb = new Item(new string[] {"herb"}, "Medicine herb", "A herb material used for medicine.");
        Item potion = new Item(new string[] {"potion"}, "Healing potion", "Potion of Healing.");

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindItems()
        {
            Inventory inv = new Inventory();
            inv.Put(herb);
            Assert.IsTrue(inv.HasItem(herb.FirstID));
        }
        [Test]
        public void NotFindItems()
        {
            Inventory inv = new Inventory();
            inv.Put(herb);
            Assert.IsFalse(inv.HasItem(potion.FirstID));
        }

        [Test]              //Fetch
        public void FetchItems()
        {
            Inventory inv = new Inventory();
            inv.Put(herb);
            Item fetchedItem = inv.Fetch(herb.FirstID);
            Assert.IsTrue(fetchedItem == herb);     //Item, not string, see if it fetches the correct item
            Assert.IsTrue(inv.HasItem(herb.FirstID));       //See if it still exists inside inventory        
        }

        [Test]          //Take
        public void TakeItems()
        {
            Inventory inv = new Inventory();
            inv.Put(herb);
            Item _takeItem = inv.Take(herb.FirstID);
            Assert.IsTrue(_takeItem == herb);           //sees if takes the correct item
            Assert.IsFalse(inv.HasItem(herb.FirstID));      //No longer in inventory
        }


        [Test]          //Item List
        public void itemLists()
        {
            Inventory inventory = new Inventory();
            inventory.Put(herb);
            inventory.Put(potion);
            Assert.IsTrue(inventory.HasItem(herb.FirstID));
            Assert.IsTrue(inventory.HasItem(potion.FirstID));

            Assert.AreEqual(inventory.ItemList, "\tMedicine herb (herb)\n\tHealing potion (potion)\n");
        }









    }
}