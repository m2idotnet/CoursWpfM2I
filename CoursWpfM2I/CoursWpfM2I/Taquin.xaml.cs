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

namespace CoursWpfM2I
{
    /// <summary>
    /// Logique d'interaction pour Taquin.xaml
    /// </summary>
    public partial class Taquin : Window
    {
        public int nb = 3;
        public string[] tabElement = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        public Taquin()
        {
            InitializeComponent();
            start.Click += (sender, e) =>
             {
                 GenerateButton();
             };
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
    }
}
