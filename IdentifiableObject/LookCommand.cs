
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"})
        {
        
        }
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _inv;
            string _itemID ;


            /*
             text[     0 ,   1,    2,    3,    4]   

                   "look"  "at"   ___   "in"   ___


            - text[0] must be "look"  \   return error;
            - text[1] must be "at"    \   What do you want to look at
            - text[3] must be "in" if text[].length == 5
            - if text.length == 3,  Player is the container.
            - if text.length == 5, containerID == text[4], FetchContainer(p, text[4]) 
            - itemID == text[2]
            - LookAtIn
             */
            
            if (text.Length == 5 || text.Length == 3)
            {   
                if (text[0].ToLower() != "look") {
                    return "Error in look input";
                }
                if (text[1].ToLower() != "at")
                {
                    return "What do you want to look at?";
                }


                switch (text.Length)
                {
                    case 5:
                        if (text[3].ToLower() != "in") { return "What do you want to look in?"; }
                        else
                        {
                            _itemID = text[2];
                            _inv = FetchContainer(p, text[4]);      //getting the container
                            if (_inv == null)
                            {
                                return "I cannot find the " + text[4];       //Container not found
                            }
                            return lookAtIn(_itemID, _inv);
                        }

                    case 3:
                        _itemID = text[2];
                        IHaveInventory? inventoryContainer = p as IHaveInventory;
                        if (inventoryContainer == null)
                        {
                            return "Error: Player does not have an inventory to look at.";
                        }
                        return lookAtIn(_itemID, inventoryContainer);
                    default:
                        return "I don't know how to look like that";
                }

                

            }
            return "I don't know how to look like that  ";




        }
            
        IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory; 
        }

        string lookAtIn (string ItemID, IHaveInventory container)
        {
            if (container.Locate(ItemID) == null) 
            {
                return "I cannot find the " + ItemID ;
            }
            else if (container == null) { return "The container can't be found."; }
            else return container.Locate(ItemID).FullDescription;
        }


    }
}
 