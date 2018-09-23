using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kampus.WordSearcher.Client; 

namespace Kampus.WordSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Query query = new Query("http://intern-test.skbkontur.ru", "1b0116f0-222d-447a-86b7-cb31d393ace9");
            query.Start();
            query.SurrenderWords();

            Console.ReadKey();
        }
    }
}
