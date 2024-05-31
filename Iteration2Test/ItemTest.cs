using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class ItemTest
    {
        Item herb = new Item(new string[] { "herb" }, "Medicine herb", "A herb material used for medicine.");
        Item potion = new Item(new string[] { "potion" }, "Healing potion", "Potion of Healing.");
        Item scrap = new Item(new string[] { "scrap" }, "Metal scrap", "A piece of scrap, can be salvaged.");


        [SetUp]
        public void Setup()
        {

        }
        [Test]          //Identifiable items
        public void IdentifiableItem()
        {
            var item = herb.AreYou("herb");
            var item2 = potion.AreYou("scrap");
            Assert.IsTrue(item);
            Assert.IsFalse(item2);
        }

        [Test]          //Short description

        public void ShortDescription()
        {
            Assert.AreEqual(scrap.ShortDescription, "Metal scrap (scrap)");
            Assert.AreEqual(herb.ShortDescription, "Medicine herb (herb)");
            Assert.AreEqual(potion.ShortDescription, "Healing potion (potion)");

        }


        [Test]          //Full description

        public void FullDescription()
        {
            Assert.AreEqual(scrap.FullDescription, "A piece of scrap, can be salvaged.");
            Assert.AreEqual(herb.FullDescription, "A herb material used for medicine.");
            Assert.AreEqual(potion.FullDescription, "Potion of Healing.");
            Assert.AreNotEqual(potion.FullDescription, "Healing potion (potion)");
        }

    }
}
