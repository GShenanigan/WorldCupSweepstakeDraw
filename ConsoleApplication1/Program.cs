using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorldCupSweepstake
{
    struct Result
    {
        public string Player {get;set;}
        public string TopTeam {get;set;}
        public string BottomTeam {get;set;}
    }

    class Program
    {
        private static int _min = 0;
        private static int _max = 15;
        private static List<string> _participants = ConfigurationManager.AppSettings["Players"].Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        private static List<string> _top = new List<string>()
            {
                "Brazil",
                "Belgium",
                "Germany",
                "Spain",
                "Switzerland",
                "Argentina",
                "Colombia",
                "Uruguay",
                "Portugal",
                "Italy",
                "England",
                "Greece",
                "USA",
                "Chile",
                "Netherlands",
                "France"
            };

        private static List<string> _bottom = new List<string>()
            {
                "Croatia",
                "Russia",
                "Mexico",
                "Bosnia and Herzegovina",
                "Algeria",
                "Ivory Coast",
                "Ecuador",
                "Costa Rica",
                "Honduras",
                "Ghana",
                "Iran",
                "Nigeria",
                "Japan",
                "South Korea",
                "Cameroon",
                "Australia"
            };

        static void Main(string[] args)
        {
            Console.WriteLine("Picking teams\r\n");
            foreach (var result in PickTeams())
            {
                //Wait to build suspense
                Thread.Sleep(2000);

                Console.Write(String.Format("{0}'s teams are", result.Player));
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(String.Format("{0}", result.BottomTeam));
                Thread.Sleep(500);
                Console.Write(" & ");
                Thread.Sleep(1000);
                Console.Write(String.Format("{0}", result.TopTeam));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Draw complete!");
            Console.ReadLine();
        }

        static List<Result> PickTeams()
        {
            var results = new List<Result>();

            int max = _max;

            foreach (string player in _participants)
            {
                //Get top team
                var topRand = new Random();
                int topIdx = topRand.Next(_min, max);
                string topTeam = _top[topIdx];
                _top.RemoveAt(topIdx);

                //Wait to improve seeding
                Thread.Sleep(100);

                //Get bottom team
                var bottomRand = new Random();
                int bottomIdx = bottomRand.Next(_min, max);
                string bottomTeam = _bottom[bottomIdx];
                _bottom.RemoveAt(bottomIdx);

                //Add to table
                results.Add(new Result(){ Player = player, TopTeam = topTeam, BottomTeam = bottomTeam});

                max--;
            }
            
            return results;
        }
    }
}
