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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login != null && Properties.Settings.Default.Password != null)
            {
                LoginTb.Text = Properties.Settings.Default.Login;
                PasswordTb.Password = Properties.Settings.Default.Password;
            }
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var employee = App.db.User.FirstOrDefault(emp => emp.Login == LoginTb.Text); //косяк
            if (employee == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (employee.Password != PasswordTb.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            App.AutorizateUser = employee;
            if (SaveCb.IsChecked == true)
            {
                Properties.Settings.Default.Login = LoginTb.Text;
                Properties.Settings.Default.Password = employee.Password;
                Properties.Settings.Default.Save();
            }
            if (employee.RoleId == 1)
            {
                NavigationService.Navigate(new UserPage());
            }
            if (employee.RoleId == 2)
            {
               NavigationService.Navigate(new SpisokPenPage());
            }
         

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegAuthPage());
        }

        private void SaveCb_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
