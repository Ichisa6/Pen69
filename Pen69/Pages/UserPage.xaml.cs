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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            InitializeComponent();
            var alltypes = App.db.Type.ToList();
            alltypes.Insert(0, new Model.Type
            {
                Name = "Все"
            });

            TypeCb.ItemsSource = alltypes;
            var allcolors = App.db.Color.ToList();
            allcolors.Insert(0, new Model.Color
            {
                Name = "Все"
            });
            ColorCB.ItemsSource = allcolors;

            var allview = App.db.View.ToList();
            allview.Insert(0, new Model.View
            {
                Name = "Все"
            });
            ViewCB.ItemsSource = allview;
            Refresh();
        }
        public void Refresh()
        {
            IEnumerable<Pencil> filterService = App.db.Pencil.Where(x => x.IsDelete != 1).ToList();
            if (ViewCB.SelectedIndex > 0)
            {
                filterService = filterService.Where(x => x.ViewId == ViewCB.SelectedIndex).ToList();
            }
            if (TypeCb.SelectedIndex > 0)
            {
                filterService = filterService.Where(x => x.TypeId == TypeCb.SelectedIndex).ToList();
            }
            if (ColorCB.SelectedIndex > 0)
            {
                filterService = filterService.Where(x => x.ColorId == ColorCB.SelectedIndex).ToList();
            }
            if (TitleDescriptionTb.Text.Length > 0)
            {
                filterService = filterService.Where(a => a.Name.ToLower().Contains(TitleDescriptionTb.Text.ToLower())).ToList();

            }
            LVus.ItemsSource = filterService.ToList();
        }



        private void TitleDescriptionTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBproiz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

    }

}
