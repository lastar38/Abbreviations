using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbreviations
{
    class Program
    {
        static void Main(string[] args)
        {
            var abbrs = new Abbreviations();

            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names)
            {
                var fullname = abbrs[name];
                if(fullname == null)
                {
                    Console.WriteLine("{0}は見つかりません", name);
                }
                else
                {
                    Console.WriteLine("{0}={1}", name, fullname);
                }
            }
            Console.WriteLine();

            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
            {
                Console.WriteLine("{0}は見つかりません", japanese);
            }
            else
            {
                Console.WriteLine("「{0}」の略語は{1}です", japanese, abbreviation);
            }
            Console.WriteLine();

            foreach (var item in abbrs.FindAll("国際"))
            {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }

            Console.WriteLine(abbrs.Count());

            if (abbrs.Remove("IOC"))
            {
                Console.WriteLine("削除しました");
            }

            Console.WriteLine(abbrs.Count());

            foreach (var item in abbrs.Filter(3))
            {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }

        }
    }
}
