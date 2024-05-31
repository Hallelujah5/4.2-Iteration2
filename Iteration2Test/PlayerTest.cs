using NuGet.Frameworks;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class PlayerTests
    {
        Player player = new Player("Phuc", "main protagonist");
        Item herb = new Item(new string[] {"herb"}, "Medicine herb", "A herb material used for medicine.");
        Item potion = new Item(new string[] {"potion"}, "Healing potion", "Potion of Healing.");
        Item scrap = new Item(new string[] {"scrap"}, "Metal scrap", "A piece of scrap, can be salvaged." );


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AreYou1()
        {
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }

        [Test]      //Locates items
        public void locateItem()
        {
            var output = false;
            player.Inventory.Put(scrap);
            var _locatedItem = player.Locate("scrap");    
            if (_locatedItem == scrap)
            {
                output = true;
            }
            Assert.IsTrue(output);
        }

        [Test]      //Locates self
        public void locateSelf()
        {
            var output = false;
            var self = player.Locate("me");
            var inv = player.Locate("inventory");

            if ((self == player) || (inv == player) )
            {
                output = true;
            }
            Assert.IsTrue(output);
        }

        [Test]      //Locates nothing
        public void locateVoid()
        {
            var output = false; 
            player.Inventory.Put(scrap);
            var _locatedItem = player.Locate("shield");
            if (_locatedItem == null)       //Doesn't exist in inv
            {
                output = true;      //If does not have, returns true
            }
            Assert.IsTrue(output);
        }


        [Test]      //Full descript
        public void playerFullDescription()
        {
            player.Inventory.Put(scrap);
            player.Inventory.Put(herb);
            player.Inventory.Put(potion);
            var output = "Phuc:\n \tMetal scrap (scrap)\n\tMedicine herb (herb)\n\tHealing potion (potion)\n ";
            Assert.AreEqual(player.FullDescription, output);
        }



    }
}
