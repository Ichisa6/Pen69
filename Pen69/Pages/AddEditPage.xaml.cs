using Microsoft.Win32;
using Pen69.Model;
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

namespace Pen69.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Pencil contextpencil;
        public AddEditPage(Pencil pencil)
        {
            InitializeComponent();
            contextpencil = pencil;
            DataContext = contextpencil;
            TypeCB.ItemsSource = App.db.Type.ToList();
            ColorCB.ItemsSource = App.db.Color.ToList();
            ViewCB.ItemsSource = App.db.View.ToList();

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contextpencil.Id == 0)
            {
                App.db.Pencil.Add(contextpencil);
            }
            App.db.SaveChanges();
            MessageBox.Show("Успешно");
            NavigationService.Navigate(new SpisokPenPage());
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {

                ServiceImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
