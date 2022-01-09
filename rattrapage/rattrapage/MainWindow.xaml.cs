using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Joueurs;
using parties;

namespace rattrapage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int NbJoueurs = Int32.Parse(textBox1.Text);
            int NbTours = Int32.Parse(textBox2.Text);
            Partie partie = new Partie(NbJoueurs,NbTours);
            this.Close();
        }
        
        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            textBox1.Text = textBox1.Text;
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            textBox2.Text = textBox2.Text;
        }
    }
}
