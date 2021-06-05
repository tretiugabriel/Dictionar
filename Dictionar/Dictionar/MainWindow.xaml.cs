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

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Functions x = new Functions();
            
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Cautare x = new Cautare();
            x.Show();
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Modificare x = new Modificare();
            x.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Joc x = new Joc();
            x.Show();
            Close();
        }
    }
}
