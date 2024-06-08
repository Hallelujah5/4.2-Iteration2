using System;

namespace IdentifiableObject
{
    public class Program
    {
        static void Main(string[] args)
        {   
            Command _look = new LookCommand();
            string[] input = new[] {""};
            Player p;
            Bag b = new Bag(new string[] { "Bag" }, "A lootbag", "Small leather lootbag found in dungeon.");
            Item _weapon = new Item(new string[] { "crossbow", }, "Elven's Crossbow", "Powerful, silver-forged crossbow used to repel monsters.");
            Item _shield = new Item(new string[] { "Shield" }, "Hardened shield", "A durable heater shield made out of darkwood and steel.");
            Item _herb = new Item(new string[] { "herb" }, "Medicine herb", "Can be eaten or crafted to relieve some pain.");

            Console.WriteLine("Please input desired name:\n");
            string p_name = Console.ReadLine();
            Console.WriteLine("\nEnter the player's description:\n");
            string p_desc = Console.ReadLine();
            p = new Player(p_name, p_desc);

            p.Inventory.Put(_weapon);
            p.Inventory.Put(_shield);
            b.Inventory.Put(_herb);
            p.Inventory.Put(b);
            Console.Clear();
            Console.WriteLine("Welcome to SwinRPG!\n");
            Console.WriteLine("You are " + p_name + ", " + p_desc + ".\n");
            Console.WriteLine(">>type QUIT to exit<<\n\n");

            while (true) 
            {
                Console.Write("Input command: ->  ");
                string command = Console.ReadLine();
                if (command == "quit") { break; }
                input = command.Split(" ");
                Console.WriteLine(_look.Execute(p,input));

            }
        }
    }
}