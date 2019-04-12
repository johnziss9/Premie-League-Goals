using System;
using System.Collections.Generic;

namespace PremierLeagueGoals
{
    class PremierLeague
    {
        public string Name { get; set; }
        public List<Rounds> Rounds { get; set; }
    }

    class Rounds
    {
        public string Name { get; set; }
        public List<Matches> Matches { get; set; }
    }

    class Matches
    {
        public DateTime Date { get; set; }
        public Team1 Team1 { get; set; }
        public Team2 Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
    }

    class Team1
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    class Team2
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
