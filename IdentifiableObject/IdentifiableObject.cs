using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentifiableObject
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>(); 



        //Constructor
        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }



        //Methods
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }


        //Properties
        public string FirstID
        {
            get
            {
                if (_identifiers.Count == 0) { return ""; }
                else { return _identifiers.First(); }
            }
        }

    }
}
