using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMSinglePage.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand listeCommand { get; set; }
        public ICommand addCommand { get; set; }
        public Grid maGrille;

        public MainWindowViewModel(Grid g)
        {
            maGrille = g;
            listeCommand = new RelayCommand(ListWindow);
            addCommand = new RelayCommand(AddWindow);
        }

        public void ListWindow()
        {
            maGrille.Children.Clear();
            maGrille.DataContext = new ListClientsViewModel();
            ListView l = new ListView();
            GridView gridView = new GridView();
            gridView.Columns.Add(
                new GridViewColumn()
                {
                    Header = "Nom",
                    Width = 100,
                    DisplayMemberBinding = new Binding("Nom")
                }
                );
            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "Prénom",
                Width = 100,
                DisplayMemberBinding = new Binding("Prenom")
            });
            l.View = gridView;
            l.ItemsSource = (maGrille.DataContext as ListClientsViewModel).listeClients;
            maGrille.Children.Add(l);
        }
        public void AddWindow()
        {
            maGrille.Children.Clear();
            maGrille.DataContext = new AddClientViewModel();
            maGrille.Children.Add(new Button { Content = "Ajouter Client" });
        }
    }
}
