namespace IdentifiableObject
{
    public class LocationTests
    {
        Item bow, goldcoin, boot;
        Player p;
        Location _location;


        [SetUp]
        public void Setup()
        {
            bow = new Item(new string[] { "bow" }, "Whispering Wind", "An exquisite bow crafted from ancient wood." );
            goldcoin = new Item(new string[] { "coin" }, "Golden Sun coin", "A forgotten currency of the old kingdom.");
            boot = new Item(new string[] { "boot" }, "Wanderer's Boots", "Made from dragonhide leather with mithril string.");

            _location = new Location(new string[] {"cave"} ,"Echoing Cavern", "A deep cave within the hearts of the North mountain");

            p = new Player("Hale", "The Adventurer");

            _location.Inventory.Put(bow);
            _location.Inventory.Put(goldcoin);
            p.Location = _location;
        }

        [Test]      //Locations can identify themselves
        public void SelfIdentify()
        {
            Assert.IsTrue(_location.AreYou("cave"));
            Assert.That(_location.Locate("cave"), Is.SameAs(_location));
        }




        [Test]      //Locations can locate items they have
        public void IdentifyItems()
        {

            Assert.That(bow, Is.EqualTo(_location.Locate("bow")));
            Assert.That(goldcoin, Is.EqualTo(_location.Locate("coin")));
        }


        [Test]      //Players locate items in their location
        public void Playerslocate()
        {
            Assert.That(p.Locate("bow"), Is.EqualTo(bow));          //Player doesn't have bow in their inventory, thus can locate on their locations instead.
        }
    }
}