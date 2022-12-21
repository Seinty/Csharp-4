using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class MagazinesChangedEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }
        public Update upd { get; set; }
        public string NameM { get; set; }
        public TKey Key { get; set; }

        public MagazinesChangedEventArgs (string colname, Update upd, string nameM, TKey key)
            {
            CollectionName = colname;
            this.upd=upd;
            NameM = nameM;
            Key= key;
        }

        public override string ToString()
        {
            string result ="Название коллекции:" + CollectionName + "Информация о событии " + upd + "Название свойства " + NameM + "Ключ объекта"+ Key;
            return result;
        }
    }
}
