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
    /// Logique d'interaction pour calculatrice.xaml
    /// </summary>
    public partial class calculatrice : Window
    {
        public Grid maGrille;
        public Label monLabel;
        public bool newOperation = true;
        public string operation = null;
        public double lastValue;
        public bool isPourcentage = false;
        public calculatrice()
        {
            InitializeComponent();
            maGrille = new Grid();
            string[] tabElement = new string[] { "C", "+/-", "%", "/", "7", "8", "9", "X", "4", "5", "6", "-", "1", "2", "3", "+", "0", ",", "=" };
            string[] tabOrange = new string[] { "/", "X", "-", "+", "=" };
            for(int i=1; i<=6; i++)
            {
                GridLength hauteur = (i == 1) ? new GridLength(3, GridUnitType.Star) : new GridLength(1, GridUnitType.Star);
                GridLength largeur = new GridLength(1, GridUnitType.Star);
                maGrille.RowDefinitions.Add(new RowDefinition { Height = hauteur });
                if(i <=4)
                {
                    maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = largeur });
                }
            }
            monLabel = new Label
            {
                Content = "0",
                Background = Brushes.Black,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                FontSize = 50
            };
            maGrille.Children.Add(monLabel);
            Grid.SetColumn(monLabel, 0);
            Grid.SetRow(monLabel, 0);
            Grid.SetColumnSpan(monLabel, 4);
            int x = 1, y = 0;
            foreach(string c in tabElement)
            {
                Button b = new Button
                {
                    Content = c
                };
                b.Click += ClickBouton;
                maGrille.Children.Add(b);
                Grid.SetRow(b, x);
                Grid.SetColumn(b, y);
                if(c == "0")
                {
                    Grid.SetColumnSpan(b, 2);
                    y++;
                }
                if (tabOrange.Contains(c))
                {
                    b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA500"));
                    b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA500"));
                    b.Foreground = Brushes.White;
                }
                if((y+1)%4 != 0)
                {
                    y++;
                }
                else
                {
                    x++;
                    y = 0;
                }
            }
            Content = maGrille;
        }

        private void ClickBouton(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string valueButton = b.Content.ToString();
            double valueNumber;
            if(Double.TryParse(valueButton, out valueNumber))
            {
                if (newOperation)
                {
                    monLabel.Content = valueNumber;
                    newOperation = false;
                }
                else
                {
                    monLabel.Content += valueNumber.ToString();
                }
            }
            else
            {
                switch(valueButton)
                {
                    case "+":
                        if(operation == null)
                        {
                            lastValue = Convert.ToDouble(monLabel.Content); 
                        }
                        else
                        {
                            MakeOperation();
                        }
                        operation = "+";
                        newOperation = true;
                        break;
                    case "-":
                        if (operation == null)
                        {
                            lastValue = Convert.ToDouble(monLabel.Content);
                        }
                        else
                        {
                            MakeOperation();
                        }
                        operation = "-";
                        newOperation = true;
                        break;
                    case "X":
                        if (operation == null)
                        {
                            lastValue = Convert.ToDouble(monLabel.Content);
                        }
                        else
                        {
                            MakeOperation();
                        }
                        operation = "X";
                        newOperation = true;
                        break;
                    case "%":
                        isPourcentage = true;
                        break;
                    case "/":
                        if (operation == null)
                        {
                            lastValue = Convert.ToDouble(monLabel.Content);
                        }
                        else
                        {
                            MakeOperation();
                        }
                        operation = "/";
                        newOperation = true;
                        break;
                    case "=":
                        if(operation != null)
                        {
                            MakeOperation();
                            newOperation = true;
                            lastValue = 0;
                        }
                        break;
                    case "C":
                        monLabel.Content = "0";
                        newOperation = true;
                        operation = null;
                        break;
                    case "+/-":
                        monLabel.Content = (Convert.ToDouble(monLabel.Content) * -1).ToString();
                        break;
                    case ",":
                        if (!monLabel.Content.ToString().Contains(","))
                        {
                            monLabel.Content += ",";
                            newOperation = false;
                        }
                        break;
                }
            }
        } 
        
        private void MakeOperation()
        {
            double value2 = (isPourcentage) ? lastValue / Convert.ToDouble(monLabel.Content) : Convert.ToDouble(monLabel.Content);
            switch (operation)
            {
                case "+":
                    lastValue = lastValue + value2;
                    monLabel.Content = lastValue.ToString();
                    break;
                case "-":
                    lastValue = lastValue - value2;
                    monLabel.Content = lastValue.ToString();
                    break;
                case "X":
                    lastValue = lastValue * value2;
                    monLabel.Content = lastValue.ToString();
                    break;
                case "/":
                    lastValue = lastValue / value2;
                    monLabel.Content = lastValue.ToString();
                    break;
            }
            isPourcentage = false;
        }
    }
}
