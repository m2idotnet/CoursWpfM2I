using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MultithreadingWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Thread.Sleep(3000);
            Task t = Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    monWrap.Children.Add(new TextBlock { Text = "start Task" });
                });
                //Action de la task
                Thread.Sleep(3000);
                //On Invoke le thread principal de l'application
                //Application.Current.Dispatcher.Invoke(() =>
                //{
                //    monWrap.Children.Add(new TextBlock { Text = "end Task" });
                //});

                string contenuBouton = "bouton crée par la task";
                //Application.Current.Dispatcher.Invoke(() =>
                //{
                //    Button b = new Button
                //    {
                //        Content = contenuBouton
                //    };
                //    monWrap.Children.Add(b);
                //});
                List<string> maListeString = new List<string>();
                for(Char c = 'A'; c <= 'Z'; c++)
                {
                    maListeString.Add(c.ToString());
                }
                Application.Current.Dispatcher.Invoke(() =>
                {
                    monWrap.Children.Add(new TextBlock { Text = "end Task" });
                    Button b = new Button
                    {
                        Content = contenuBouton
                    };
                    b.Click += (sender2, e2) =>
                    {
                        Fentre2 w = new Fentre2();
                        w.Show();
                    };
                    monWrap.Children.Add(b);
                    listBoxTest.ItemsSource = maListeString;
                });
            });
        }
    }
}
