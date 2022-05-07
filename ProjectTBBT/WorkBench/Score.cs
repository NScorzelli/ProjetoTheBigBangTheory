using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBench
{
    public class Score
    {
        public int PlayerScore { get; set; }
        public int SheldonScore { get; set; }
        public int FinalScore { get; set; }
        public string SheldonWins { get; }
        public string PlayerWins { get; set; }
        public string Draw { get; set; }
        public int Round { get; set; }
        public string MatchPoint { get; set; }

        public Score()
        {
            SheldonWins = "Sheldon diz: Bazinga!";
            PlayerWins = "Sheldon diz: Você trapaceou, seu cheaterzinho.";
            Draw = "Empate...";
            Round = 0;
        }


    }
}
