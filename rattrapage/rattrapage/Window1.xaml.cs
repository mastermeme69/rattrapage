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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Joueur joueur;
        public Window1(Joueur joueur_)
        {
            joueur = joueur_;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                joueur.setInfosJoueurs(textBox1.Text, textBox2.Text);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox1.Text = textBox1.Text;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            textBox2.Text = textBox2.Text;
        }
    }
}
