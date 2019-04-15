using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PremierLeagueGoals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> teamKeys = new List<string>();
            var totalGoals = 0;
            var jsonInput = "";

            using (WebClient wc = new WebClient())
            {
                jsonInput = wc.DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2014-15/en.1.json");

                var jsonData = JsonConvert.DeserializeObject<PremierLeague>(jsonInput);

                foreach (var teamKey in jsonData.Rounds[0].Matches)
                {
                    teamKeys.Add(teamKey.Team1.Key);
                    teamKeys.Add(teamKey.Team2.Key);
                }

                var sortedTeamList = teamKeys.OrderBy(x => x).ToList();

                Console.WriteLine("Please enter one of the following teams as listed below:");

                foreach (var team in sortedTeamList)
                {
                    Console.WriteLine(team);
                }

                Console.Write(Environment.NewLine);

                string teamInput = Console.ReadLine().ToString();

                if (sortedTeamList.Contains(teamInput, StringComparer.OrdinalIgnoreCase))
                {
                    foreach (var round in jsonData.Rounds)
                    {
                        foreach (var match in round.Matches)
                        {
                            if (teamInput == match.Team1.Key)
                                totalGoals += match.Score1;
                            else if (teamInput == match.Team2.Key)
                                totalGoals += match.Score2;
                        }
                    }
                }
                else
                    throw new Exception("Input didn't match any teams. Re-run the application to try again.");
            }

            Console.WriteLine(totalGoals.ToString());
            Console.Read();
        }
    }
}
