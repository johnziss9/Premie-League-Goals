using Newtonsoft.Json;
using System;
using System.Net;

namespace PremierLeagueGoals
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalGoals = 0;
            string inputTeam = "manutd"; // Same as the key in JSON
            var jsonInput = "";

            using (WebClient wc = new WebClient())
            {
                jsonInput = wc.DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2014-15/en.1.json");

                var jsonData = JsonConvert.DeserializeObject<PremierLeague>(jsonInput);

                foreach (var round in jsonData.Rounds)
                {
                    foreach (var match in round.Matches)
                    {
                        if (inputTeam == match.Team1.Key)
                            totalGoals += match.Score1;
                        else if (inputTeam == match.Team2.Key)
                            totalGoals += match.Score2;
                    }
                }
            }

            Console.WriteLine(totalGoals.ToString());
            Console.Read();
        }
    }
}
