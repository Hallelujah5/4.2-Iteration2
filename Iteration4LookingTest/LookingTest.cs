using IdentifiableObject;
using System;
namespace Iteration4LookingTest
{
    public class LookingTests
    {
        Item _gem, _weapon, _potion, _shield;
        Player p;
        Bag b;
        Command _lookCommand;
        string[] input;

        [SetUp]
        public void Setup()
        {
            _lookCommand = new LookCommand(); // Construct new look command
            _gem = new Item(new string[] {"Gem"}, "Gemstone", "A rare gem mineral.");
            p = new Player("Phuc", "Main protagonist");
            b = new Bag(new string[] {"Bag"}, "A lootbag", "Small leather lootbag found in dungeon.");
            _weapon = new Item(new string[] {"Weapon"}, "Hunter's Crossbow", "Powerful, silver-forged crossbow used to repel monsters.");
            _potion = new Item(new string[] {"Potion"}, "Healing potion", "Small potion of healing, can be used to treat non-fatal wounds."  );
            _shield = new Item(new string[] { "Shield" }, "Hardened shield", "A durable heater shield made out of darkwood and steel.");



            p.Inventory.Put(_shield);
            p.Inventory.Put(_weapon);
            p.Inventory.Put(_potion);
        }

        [Test]          //Look at me
         public void LookMe()
        {

            input = new string[] { "look", "at", "inventory" };
            Assert.That(_lookCommand.Execute(p, input), Is.EqualTo("Phuc:\n \tHardened shield (shield)\n\tHunter's Crossbow (weapon)\n\tHealing potion (potion)\n "));
        }
        [Test]      //Look at Gem
        public void lookAtGem()
        {
            p.Inventory.Put(_gem);   
            input = new string[] { "look", "at", "gem" };
            string Expected = "A rare gem mineral.";
            Assert.That(Expected, Is.EqualTo(_lookCommand.Execute(p, input)));
        }
        [Test]      //Look at Unknown
        public void lookAtUnknown()
        {
            input = new string[] {"look", "at", "gem"};
            string result = "I cannot find the gem";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }

        [Test]      //Look at Gem in Me
        public void lookAtGemInMe()
        {
            p.Inventory.Put( _gem);
            input = new string[] { "look", "at", "gem","in","me" };
            string result = "A rare gem mineral.";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }

        [Test]      //Look at Gem in Bag
        public void LookAtGemInBag()
        {
            b.Inventory.Put( _gem);
            p.Inventory.Put(b);
            input = new string[] { "look", "at", "gem", "in", "bag" };
            string result = "A rare gem mineral.";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));

        }
        [Test]      //Look at Gem in no bag
        public void LookAtGemInNoBag()
        {
            b.Inventory.Put(_gem);
            //p.Inventory.Put(b);       //player didn't have bag in their inventory this time.
            input = new string[] { "look", "at", "gem", "in", "bag" };
            string result = "I cannot find the bag";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }           

        [Test]      //Look at no Gem in bag 
        public void LookAtNoGemInBag()
        {
            p.Inventory.Put(b);
            input = new string[] { "look", "at", "gem", "in", "bag" };
            string result = "I cannot find the gem";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));

        }

        [Test]      //Test invalid look
        public void invalidLook()
        {
            input = new string[] { "look", "around" };                    //Invalid "around" and 2-word command.
            string result = "I don't know how to look like that  ";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }

        [Test]      //Test invalid look
        public void invalidLook2()
        {
            input = new string[] { "hello" };                            //Invalid one-word command, if it's 4-word command then same output.
            string result = "I don't know how to look like that  ";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }
        [Test]      //Test invalid look
        public void invalidLook3()
        {
            input = new string[] { "look", "at", "gem", "on", "shelf" };        //invalid 4th letter "on"
            string result = "What do you want to look in?";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }
        [Test]      //Test invalid look
        public void invalidLook4()
        {
            input = new string[] { "look", "at", "axe" };             //Axe doesn't exist, yet.
            string result = "I cannot find the axe";
            Assert.That(result, Is.EqualTo(_lookCommand.Execute(p, input)));
        }
    }
}