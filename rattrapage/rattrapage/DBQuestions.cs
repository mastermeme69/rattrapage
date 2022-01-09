using System;
using System.Collections.Generic;
using System.Text;

namespace DBQuestions
{
    class DBQuestion
    {
        Random rand = new Random();
        List<string> ListeQuestions = new List<string>() { "Aimez vous les brocolis ?","Avez vous déjà voyagé sur un autre continent ?",
            "Aimeriez-vous parler à un extraterrestre ?","Aimeriez-vous être un animal domestique","Aimez vous les bananes ?" };


        public string getRandomQuestion() 
        {
            return ListeQuestions[rand.Next(ListeQuestions.Count)];
        }
    }

}
