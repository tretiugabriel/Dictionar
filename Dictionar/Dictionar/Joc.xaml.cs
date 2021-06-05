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
using System.Windows.Shapes;

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for Joc.xaml
    /// </summary>
    public partial class Joc : Window
    {
        Functions x = new Functions();
        List<Cuvant> cuvinte = new List<Cuvant>();
        Random rnd = new Random();
        Cuvant cuvantCurent = new Cuvant();
        int runde = 0;
        int scor = 0;

        public Joc()
        {
            InitializeComponent();

            raspuns.Visibility = Visibility.Hidden;
            raspunsBox.Visibility = Visibility.Hidden;
            definitie.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Hidden;
            
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            Close();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {


            raspuns.Visibility = Visibility.Visible;
            raspunsBox.Visibility = Visibility.Visible;
            definitie.Visibility = Visibility.Visible;
            next.Visibility = Visibility.Visible;
            scorBox.Visibility = Visibility.Visible;
            rundaBox.Visibility = Visibility.Visible;

            cuvinte = x.Citire();
            runde = 0;
            scor = 0;
            rundaBox.Text = "Nivel:" + (runde + 1).ToString() + "/5";
            scorBox.Text = "Scor:" + scor.ToString() + "/5";
            cuvantCurent = cuvinte[rnd.Next(cuvinte.Count())];
            textBlock.Text = cuvantCurent.Definitie;

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {

            if (runde == 4)
            {
                if (raspunsBox.Text == cuvantCurent.Nume)
                {
                    scor++;
                }
                scorBox.Text = "Scor:" + scor.ToString() + "/5";
                MessageBox.Show("Felicitari ati obtinut: " + scor + " puncte");
                textBlock.Text = "Pentru a reincepe jocul apasati pe start";
                raspuns.Visibility = Visibility.Hidden;
                raspunsBox.Visibility = Visibility.Hidden;
                definitie.Visibility = Visibility.Hidden;
                next.Visibility = Visibility.Hidden;
                scorBox.Visibility = Visibility.Hidden;
                rundaBox.Visibility = Visibility.Hidden;
                return;
            }
            else if (runde != 5)
            {
                if (raspunsBox.Text == cuvantCurent.Nume)
                {
                    scor++;
                }
                scorBox.Text = "Scor:" + scor.ToString() + "/5";
                cuvantCurent = cuvinte[rnd.Next(cuvinte.Count())];
                textBlock.Text = cuvantCurent.Definitie;
                runde++;
                rundaBox.Text = "Nivel:" + (runde + 1).ToString() + "/5";
                if (runde == 4)
                {
                    next.Content = "Finish";
                }

            }
        }


    }
}
