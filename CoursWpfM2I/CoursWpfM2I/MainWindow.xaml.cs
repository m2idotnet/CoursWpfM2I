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

namespace CoursWpfM2I
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //monBouton.Content = "New Content";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(q1non.IsChecked.ToString());
            MessageBox.Show(text1.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Impot windowImpot = new Impot();
            this.Closing += (s, ev) =>
            {
                ev.Cancel = true;
            };
            windowImpot.Show();
        }

        //public void MaMethodeClick(object sender, EventArgs e)
        //{
        //    Button b = sender as Button;
        //    MessageBox.Show("Bonjour tout le monde " + b.Content);
        //    b.Content = "new Contenu";
        //}
    }
}
