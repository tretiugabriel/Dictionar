using System;
using System.Collections.Generic;
using System.IO;
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
using System.Threading.Tasks;

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for Modificare.xaml
    /// </summary>
    public partial class Modificare : Window
    {
        Functions f = new Functions();
        public Modificare()
        {
            InitializeComponent();
            
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

        private void adauga_Click(object sender, RoutedEventArgs e)
        {
            string str1 = nume.Text;
            string str2 = comboBox.Text;
            string str3 = definitie.Text;
            Cuvant cuvantNou = new Cuvant(str1,str2,str3);
            List<Cuvant> cuvinte = f.Citire();
            List<string> cuvintenoi = f.Cuvinte();
            if(cuvintenoi.Contains(cuvantNou.Nume)==false)
                cuvinte.Add(cuvantNou);
            f.Afisare(cuvinte);
            
        }

        private void sterge_Click(object sender, RoutedEventArgs e)
        {
            
            List<Cuvant> cuvinte = f.Citire();
            string x = stergeBox.Text;
            List<Cuvant> copie =new List<Cuvant>();
            foreach(Cuvant i in cuvinte)
            {
                if(i.Nume!=x)
                {
                    copie.Add(i);
                }
            }
            f.Afisare(copie);
        }

       
    }
}
