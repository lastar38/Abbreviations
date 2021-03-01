using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbreviations
{
    class Abbreviations
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public Abbreviations()
        {
            var lines = File.ReadAllLines("Abbreviations.txt");
            _dict = lines.Select(line => line.Split('='))
                         .ToDictionary(x => x[0], x => x[1]);
        }

        public void Add(string abbr, string japanese)
        {
            _dict[abbr] = japanese;
        }

        public string this[string abbr]
        {
            get
            {
                return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
            }
        }

        public string ToAbbreviation(string japanese)
        {
            return _dict.FirstOrDefault(x => x.Value == japanese).Key;
        }

        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring)
        {
            foreach (var item in _dict)
            {
                if (item.Value.Contains(substring))
                {
                    yield return item;
                }
            }
        }

        public int Count()
        {
            return _dict.Count();
        }

        public bool Remove(string 省略語)
        {
            if (_dict.ContainsKey(省略語))
            {
                _dict.Remove(省略語);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<KeyValuePair<string, string>> Filter(int 文字数)
        {
            foreach (var item in _dict)
            {
                var key = item.Key.ToCharArray();
                if(key.Length == 文字数)
                {
                    yield return item;
                }
            }
        }
    }
}
