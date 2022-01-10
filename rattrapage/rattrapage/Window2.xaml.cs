using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Joueurs;
namespace rattrapage
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Joueur joueur_;
        public Window2(Joueur joueur)
        {
            joueur_ = joueur;
            InitializeComponent();
            NomLabel.Content = joueur_.Prénom +" "+ joueur_.Nom;
            questionLabel.Content = "//Pending question//";
            ScoreLabel.Content = "Score: 0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int pari = Int32.Parse(ValeurPari.Text);

                bool reponse = Oui.IsChecked ?? true;
                joueur_.EnvoyerVote(pari, reponse);
            }
            catch
            {
                 MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        public void MetAJourScore(int score)
        {
            ScoreLabel.Content = "Score: " + score.ToString(); 
        }
        public void EnvoieQuestion(string question)
        {
            questionLabel.Content = question;
        }
    }
}
