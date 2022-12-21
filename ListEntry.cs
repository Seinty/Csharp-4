using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class ListEntry
    {
        public string CollectionName { get; set; }
        public Update WhatUpd { get; set; }
        public string NameM { get; set; }
        public string key { get; set; }

        public ListEntry(string colname, Update what, string funcname, string key)
            {
            this.CollectionName = colname;
            this.WhatUpd = what;
            this.NameM = funcname;
            this.key = key;
            }

        public override string ToString()
        {
            return CollectionName + ": " + "Information: [" + WhatUpd + "] Name: [" + NameM + "] Key: [" + key + "]";
        }

    }
}
