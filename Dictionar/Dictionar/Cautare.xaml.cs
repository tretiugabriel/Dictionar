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
using System.IO;


namespace Dictionar
{
    /// <summary>
    /// Interaction logic for Cautare.xaml
    /// </summary>
    public partial class Cautare : Window
    {
        List<Cuvant> cuvinte = new List<Cuvant>();
        Functions f = new Functions();
        public Cautare()
        {

            InitializeComponent();
            Cuvant.Visibility = Visibility.Collapsed;
            Categorie.Visibility = Visibility.Collapsed;
            Definitie.Visibility = Visibility.Collapsed;
            
            List<string> categorii = f.Categorie();
            foreach (string i in categorii)
            {
                comboBox.Items.Add(i);
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            Close();
        }
        private void cautare_Click(object sender, RoutedEventArgs e)
        {
            
            cuvinte = f.Citire();
            foreach (Cuvant x in cuvinte)
            {
                Console.WriteLine(x.Nume);
            }
            string strx = searchBox.Text;
            Cuvant cuvantgasit = new Cuvant();
            bool result = false;

            foreach (Cuvant y in cuvinte)
            {
                if (y.Nume == strx)
                {
                    cuvantgasit = y;
                    result = true;
                    break;

                }
            }

            if (result == true)
            {
                t1.Text = cuvantgasit.Nume;
                t2.Text = cuvantgasit.Categorie;
                t3.Text = cuvantgasit.Definitie;
                Cuvant.Visibility = Visibility.Visible;
                Categorie.Visibility = Visibility.Visible;
                Definitie.Visibility = Visibility.Visible;
            }
            else
            {
                t1.Text = "cuvantul nu a fost gasit";
                Cuvant.Visibility = Visibility.Collapsed;
                Categorie.Visibility = Visibility.Collapsed;
                Definitie.Visibility = Visibility.Collapsed;
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.Items.Clear();
            cuvinte = f.Citire();
            if (searchBox.Text.Length >= 1)
            {
                foreach (Cuvant x in cuvinte)
                {
                    if (comboBox.Text.Length == 0)
                    {
                        if (x.Nume.StartsWith(searchBox.Text)&& x.Nume != searchBox.Text)
                        {
                                listView.Items.Add(x.Nume);            
                        }
                    }
                    else
                    {
                        if (x.Nume.StartsWith(searchBox.Text) && x.Categorie == comboBox.Text && x.Nume != searchBox.Text)
                        { 
                            listView.Items.Add(x.Nume);
                        }

                    }
                }
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;
            searchBox.Text = listView.SelectedItem.ToString();
        }


    }
}
