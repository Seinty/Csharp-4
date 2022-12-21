using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class TestCollection<TKey,TValue>
    {
        private System.Collections.Generic.Dictionary<TKey,TValue> _dictionary=new Dictionary<TKey, TValue>();
        private System.Collections.Generic.List<TKey> _list=new List<TKey>();
        private System.Collections.Generic.List<string> _list2= new List<string>();
        private System.Collections.Generic.Dictionary<string,TValue> _dictionary2=new Dictionary<string, TValue>();
        private GenerateElement<TKey,TValue> generateElement;
        public TestCollection(int count, GenerateElement<TKey, TValue> j)
        {
            if (count <= 0) throw new ArgumentException();

            generateElement = j;
            for (int i = 0; i < count; i++)
            {
                var element = generateElement(i);
                _dictionary.Add(element.Key, element.Value);
                _dictionary2.Add(element.Key.ToString(), element.Value);
                _list.Add(element.Key);
                _list2.Add(element.Key.ToString());
            }
        }
        Stopwatch timer = new Stopwatch();

        public void searchInTKeyList()
        {
            var first = _list[0];
            var center = _list[_list.Count / 2];
            var last = _list[_list.Count - 1];
            var another = generateElement(_list.Count + 10).Key;


            timer.Start();
            _list.Contains(first);
            timer.Stop();
            Console.WriteLine("In TKey List\n For the first element:  " + (int)timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            _list.Contains(center);
            timer.Stop();
            Console.WriteLine("For the central element:  " + (int)timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            _list.Contains(last);
            timer.Stop();
            Console.WriteLine("For the last element:  " + (int)timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            _list.Contains(another);
            timer.Stop();
            Console.WriteLine("For a non-existent element:  " + (int)timer.ElapsedMilliseconds + "\n");
            timer.Reset();
        }

        public void searchInStrList()
        {
            var first = _list2[0];
            var center = _list2[_list2.Count / 2];
            var last = _list2[_list2.Count - 1];
            var another = generateElement(_list2.Count + 10).Key.ToString();

            var begin = Environment.TickCount;
            _list2.Contains(first);
            var end = Environment.TickCount;
            Console.WriteLine("In string List\n For the first element:  " + (end - begin));

            begin = Environment.TickCount;
            _list2.Contains(center);
            end = Environment.TickCount;
            Console.WriteLine("For the central element:  " + (end - begin));

            begin = Environment.TickCount;
            _list2.Contains(last);
            end = Environment.TickCount;
            Console.WriteLine("For the last element:  " + (end - begin));

            begin = Environment.TickCount;
            _list2.Contains(another);
            end = Environment.TickCount;
            Console.WriteLine("For a non-existent element:  " + (end - begin) + "\n");
        }

        public void searcInTKeyDictionary()
        {
            var first = _dictionary.ElementAt(0).Key;
            var center = _dictionary.ElementAt(_dictionary.Count / 2).Key;
            var last = _dictionary.ElementAt(_dictionary.Count - 1).Key;
            var another = generateElement(_dictionary.Count + 10).Key;

            int begin = Environment.TickCount;
            _dictionary.ContainsKey(first);
            int end = Environment.TickCount;
            Console.WriteLine("In TKey  Dictionary by key\nFor the first element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary.ContainsKey(center);
            end = Environment.TickCount;
            Console.WriteLine("For the central element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary.ContainsKey(last);
            end = Environment.TickCount;
            Console.WriteLine("For the last element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary.ContainsKey(another);
            end = Environment.TickCount;
            Console.WriteLine("For a non-existent element:  " + (end - begin) + "\n");
        }

        public void searcInStrDictionary()
        {
            var first = _dictionary2.ElementAt(0).Key;
            var center = _dictionary2.ElementAt(_dictionary2.Count / 2).Key;
            var last = _dictionary2.ElementAt(_dictionary2.Count - 1).Key;
            var another = generateElement(_dictionary2.Count + 10).Key.ToString();

            int begin = Environment.TickCount;
            _dictionary2.ContainsKey(first);
            int end = Environment.TickCount;
            Console.WriteLine("In string  Dictionary by key\nFor the first element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary2.ContainsKey(center);
            end = Environment.TickCount;
            Console.WriteLine("For the central element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary2.ContainsKey(last);
            end = Environment.TickCount;
            Console.WriteLine("For the last element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary2.ContainsKey(another);
            end = Environment.TickCount;
            Console.WriteLine("For a non-existent element:  " + (end - begin) + "\n");
        }

        public void searcInTKeyDictionaryByValue()
        {
            var first = _dictionary.ElementAt(0).Value;
            var center = _dictionary.ElementAt(_dictionary.Count / 2).Value;
            var last = _dictionary.ElementAt(_dictionary.Count - 1).Value;
            var another = generateElement(_dictionary.Count + 10).Value;

            int begin = Environment.TickCount;
            _dictionary.ContainsValue(first);
            int end = Environment.TickCount;
            Console.WriteLine("In TKey  Dictionary by value\nFor the first element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary.ContainsValue(center);
            end = Environment.TickCount;
            Console.WriteLine("For the central element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary.ContainsValue(last);
            end = Environment.TickCount;
            Console.WriteLine("For the last element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary.ContainsValue(another);
            end = Environment.TickCount;
            Console.WriteLine("For a non-existent element:  " + (end - begin) + "\n");
        }

        public void searcInStrDictionaryByValue()
        {
            var first = _dictionary2.ElementAt(0).Value;
            var center = _dictionary2.ElementAt(_dictionary2.Count / 2).Value;
            var last = _dictionary2.ElementAt(_dictionary2.Count - 1).Value;
            var another = generateElement(_dictionary2.Count + 10).Value;

            int begin = Environment.TickCount;
            _dictionary2.ContainsValue(first);
            int end = Environment.TickCount;
            Console.WriteLine("In string  Dictionary by value\nFor the first element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary2.ContainsValue(center);
            end = Environment.TickCount;
            Console.WriteLine("For the central element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary2.ContainsValue(last);
            end = Environment.TickCount;
            Console.WriteLine("For the last element:  " + (end - begin));

            begin = Environment.TickCount;
            _dictionary2.ContainsValue(another);
            end = Environment.TickCount;
            Console.WriteLine("For a non-existent element:  " + (end - begin) + "\n");
        }

    }
}
