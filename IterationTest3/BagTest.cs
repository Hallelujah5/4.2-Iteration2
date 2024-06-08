using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class BagTests       
    {
        Item herb;
        Item potion;
        Item scrap;
        Item shield;
        Item rag;
        Item dagger;


        Bag b1;
        Bag b2;

        [SetUp]
        public void Setup()
        {
            herb = new Item(new string[] { "herb" }, "Medicine herb", "A herb material used for medicine.");
            potion = new Item(new string[] { "potion" }, "Healing potion", "Potion of Healing.");
            scrap = new Item(new string[] { "scrap" }, "Metal scrap", "A piece of scrap, can be salvaged.");
            shield = new Item(new string[] { "shield" }, "Wooden shield", "A durable wooden shield.");
            rag = new Item(new string[] { "rag" }, "Piece of rag", "Can be made into bandages.");
            dagger = new Item(new string[] { "dagger" }, "A dagger", "Rusted iron dagger, still reliable.");

            b1 = new Bag(new string[] { "b1" }, "Monster lootbag", "Lootbag dropped from monsters.");
            b2 = new Bag(new string[] { "b2" }, "Chest lootbag", "Lootbag found in chests.");


            b1.Inventory.Put(dagger);   b2.Inventory.Put(shield);
            b1.Inventory.Put(scrap);    b2.Inventory.Put(herb);
            b1.Inventory.Put(rag);      b2.Inventory.Put(potion);
        }

        [Test]      //Locates item
        public void LocateItem()
        {
            Assert.IsTrue(b2.Inventory.HasItem("herb"));
            Assert.IsTrue(b2.Inventory.HasItem("potion"));

            Assert.IsTrue(b1.Locate(dagger.FirstID) == dagger);
            Assert.IsTrue(b2.Locate(shield.FirstID) == shield);
        }

        [Test]      //Locates itself
        public void LocateSelf()
        {
            Assert.IsTrue(b1.Locate(b1.FirstID) == b1);
            Assert.IsTrue(b2.Locate("b2") == b2);
        }

        [Test]      //Locates nothing
        public void LocateNothing()
        {
            Assert.IsTrue(b1.Locate(shield.FirstID) == null);  //b1 does not have shield
            Assert.IsTrue(b1.Locate(herb.FirstID) == null);
        }

        [Test]      //Full Description
        public void FullDesc()
        {
            var output1 = "In the Monster lootbag you can see: \tA dagger (dagger)\n\tMetal scrap (scrap)\n\tPiece of rag (rag)\n";
            Assert.AreEqual(b1.FullDescription, output1);
        }

        [Test]      //Bag in bag
        public void BaginBag()
        {
            b1.Inventory.Put(b2);
            Assert.IsTrue(b1.Locate(dagger.FirstID) == dagger);     //b1 can still locate its stored item
            Assert.IsTrue(b1.Locate(b2.FirstID) == b2);         //b1 can locate b2
            Assert.IsFalse(b1.Locate(herb.FirstID) == herb);        //b1 cannot b2's items
        }

    }
}