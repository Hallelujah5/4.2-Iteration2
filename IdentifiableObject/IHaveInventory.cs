using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public interface IHaveInventory 
    {
        public Game_Object Locate(string id);

        public string Name { get; }

    }
}
