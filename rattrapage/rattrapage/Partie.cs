using System;
using System.Collections.Generic;
using System.Text;
using Joueurs;
using Tours;
using System.Windows;
namespace parties
{
   public  class Partie
    {
       static int NombreJoueurs;
       static int NombreTours;
      public List<Joueur> ListeJoueurs = new List<Joueur>();
       public Tour tour;
        
     

        public Partie( int NbJoueurs, int NbTours)
        {

                NombreJoueurs = NbJoueurs;
                NombreTours = NbTours;
                

                for(int i = 0; i < NbJoueurs; i++) {
                    new Joueur(this);
                   
           
         }
        } 

        public void rejoindre(Joueur joueur) {
            ListeJoueurs.Add(joueur);
            if (ListeJoueurs.Count == NombreJoueurs)
            {
              tour= new Tour(1, this, ListeJoueurs);
            }
        }


        public void TermineTour(int tourIdx)
        {
            if (NombreTours == tourIdx)
            {
                // Fin Partie
                ListeJoueurs.Sort(delegate (Joueur x, Joueur y)
                {
                    return x.score = y.score;
                });
              //  ListeJoueurs.Reverse();
                string msg = "Joueur gagnant: " + ListeJoueurs[0].Prénom + " " + ListeJoueurs[0].Nom + "!";
                string caption = "Fin de Partie";
///                MessageBoxButtons buttons = MessageBoxButtons.Ok;
                var res = MessageBox.Show(msg, caption);
                //             System.Windows.Forms.Application.Exit();
                Application.Current.Shutdown();
            } else

            {
                tour = new Tour(tourIdx + 1, this, ListeJoueurs);
            }
        }

    }
    

}
