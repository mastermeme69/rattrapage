using System;
using System.Collections.Generic;
using System.Text;
using parties;
using rattrapage;
using Tours;
namespace Joueurs
{
  public  class Joueur
    {
       public string Nom;
        public string Prénom;
        public Partie PartieEnCours;
        public int score;
        private Window2 window2;

        public Joueur(Partie partie)
        {
            PartieEnCours = partie;
            (new Window1(this)).Show();
            score = 0;
            
        }

        public void setInfosJoueurs(string nom,string prénom) {
            Nom = nom;
            Prénom = prénom;
            window2 = new Window2(this);
            PartieEnCours.rejoindre(this);
            window2.Show();
        }
        public void EnvoyerQuestion(string Question)
        {
            window2.EnvoieQuestion(Question);
        }

        public void EnvoyerVote(int pari, bool reponse)
        {
            PartieEnCours.tour.EnregistrePari(this, pari,reponse);
        }

        public void MetAJourPoints(int points)
        {
            score += points;
            window2.MetAJourScore(score);
        }

    }
}
