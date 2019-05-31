using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CoursWpfM2I
{
    /// <summary>
    /// Logique d'interaction pour Taquin.xaml
    /// </summary>
    public partial class Taquin : Window
    {
        public int nb = 3;
        private string ChaineWin = "ABCDEFGH#";
        private int nbClick = 0;
       
        public string[] tabElement = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        public Taquin()
        {
            InitializeComponent();
            start.Click += (sender, e) =>
             {
                 GenerateButton();
             };
            //Création du dispatcherTimer pour incrementer nombre de second
            DispatcherTimer di = new DispatcherTimer();
            //definition de l'interval => toutes les secondes
            di.Interval = new TimeSpan(0, 0, 1);
            //Seconde de départ
            int second = 0;
            //Event Tick à chaque interval
            di.Tick += new EventHandler((sender, e) =>
            {
                //Incremente les secondes à chaque tick
                second++;
                monLabel.Content = second;
            });
            di.Start();
        }

        public void Shuffle(string[] tab)
        {
            Random r = new Random();
            for(int i=0; i < tab.Length; i++)
            {
                int index = r.Next(0, tab.Length);
                string tmp = tab[i];
                tab[i] = tab[index];
                tab[index] = tmp;
            }
        }

        public void GenerateButton()
        {
            nbClick = 0;
            monLabel.Content = "Nbre de déplacement : " + nbClick;
            grilleTaquin.Children.Clear();
            grilleTaquin.RowDefinitions.Clear();
            grilleTaquin.ColumnDefinitions.Clear();
            for(int i=1; i <= nb; i++)
            {
                grilleTaquin.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grilleTaquin.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            Shuffle(tabElement);
            int x = 0, y = 0;
            foreach(string c in tabElement)
            {
                Button b = new Button
                {
                    Content = c
                };
                b.Click += ClickBouton;
                grilleTaquin.Children.Add(b);
                Grid.SetColumn(b, y);
                Grid.SetRow(b, x);
                if((y+1)%3 == 0)
                {
                    x++;
                    y = 0;
                }
                else
                {
                    y++;
                }
            }
        }

        private void ClickBouton(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int x = Grid.GetColumn(b);
            int y = Grid.GetRow(b);
            if (TestDeplacement(x, y + 1) && y+1 < 3)
            {
                Grid.SetRow(b,y + 1);
            }
            else if(TestDeplacement(x, y-1) && y-1 >=0)
            {
                Grid.SetRow(b, y - 1);
            }
            else if(TestDeplacement(x-1, y) && x-1  >=0)
            {
                Grid.SetColumn(b, x - 1);
            }
            else if(TestDeplacement(x+1, y) && x+1 < 3)
            {
                Grid.SetColumn(b, x + 1);
            }
            nbClick++;
            monLabel.Content = "Nbre de déplacement : " + nbClick;
            if (testWin())
            {
                MessageBox.Show("Bravo");
            }
        }

        private bool TestDeplacement(int x, int y)
        {
            bool test = true;
            foreach(UIElement element in grilleTaquin.Children)
            {
                if(Grid.GetRow(element) == y && Grid.GetColumn(element) == x)
                {
                    test = false;
                    break;
                }
            }
            return test;
        }

        private bool testWin()
        {
            bool test = false;
            string chaineTest = "";
            for(int x = 0; x <= 2; x++)
            {
                for(int y=0; y <= 2; y++)
                {
                    UIElement e = grilleTaquin.Children.Cast<UIElement>().FirstOrDefault(element => Grid.GetColumn(element) == y && Grid.GetRow(element) == x);
                    if(e != null)
                    {
                        chaineTest += (e as Button).Content.ToString();
                    }
                    else
                    {
                        chaineTest += "#";
                    }
                }
            }
            
            
            if(chaineTest == ChaineWin)
            {
                test = true;
            }
            return test;
        }
    }
}
