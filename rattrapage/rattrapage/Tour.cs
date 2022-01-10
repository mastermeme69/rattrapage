using System;
using System.Collections.Generic;
using System.Text;
using parties;
using DBQuestions;
using Joueurs;
namespace Tours
{
   public class Tour
    {
        List<(Joueur, int, bool)> InfoTour= new List<(Joueur, int, bool)> { };
        static  DBQuestion DB = new DBQuestion();
        int NombreJoueur;
        Partie partie;
        int tourIdx;
       public Tour(int tourIdx_, Partie partie_, List<Joueur> joueurs)
        {
            tourIdx = tourIdx_;
            partie = partie_;
            NombreJoueur = joueurs.Count;
            string Question = DB.getRandomQuestion();
            foreach( Joueur joueur in joueurs)
            {
                joueur.EnvoyerQuestion(Question);
            }
        }

       
        public void EnregistrePari(Joueur joueur, int pari, bool reponse)
        {
            InfoTour.Add((joueur, pari, reponse));
            if (InfoTour.Count == NombreJoueur)
            {

                var InfoResult = this.CalculerPoint ();
                foreach((Joueur jouer, int point) in InfoResult)
                {
                    joueur.MetAJourPoints(point);
                }
                partie.TermineTour(tourIdx);
            }

        }

        public List<(Joueur joueur, int score)> CalculerPoint()
        { int NbOui = 0;
            //Step1: Count Yes answer
            foreach ((Joueur joueur, int pari, bool reponse) in InfoTour) {
                if (reponse)
                {
                    NbOui++;
                }
            }
            //step2: Order bets
            InfoTour.Sort(delegate ((Joueur, int, bool) x, (Joueur, int, bool) y)
            {
                return x.Item2 - y.Item2;

            });
            InfoTour.Reverse();
            // step3: save score
            List<(Joueur, int)> ListeResultat = new List<(Joueur, int)> { };
            int pariTmp = -1;
            foreach ((Joueur joueur, int pari, bool reponse) in InfoTour)
            {
                if (pari > NbOui)
                {
                    continue;
                }
                if (pari== NbOui)
                {
                    ListeResultat.Add((joueur, 2));
                }
                if (pari < NbOui && ListeResultat.Count == 0)
                {
                    ListeResultat.Add((joueur, 1));
                    pariTmp = pari;
                }
                if (pari < NbOui && pari == pariTmp)
                {
                    ListeResultat.Add((joueur, 1));
                }
                if (pari < NbOui && pari != pariTmp)
                {
                    break;
                }
            }
            return ListeResultat;         
        }
    }
}
