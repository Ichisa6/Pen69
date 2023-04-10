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
    /// Логика взаимодействия для RegAuthPage.xaml
    /// </summary>
    public partial class RegAuthPage : Page
    {
        public RegAuthPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim().Length <= 0 || PasswordTb.Text.Trim().Length <= 0 || TwoPasswordTb.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                if (PasswordTb.Text.Trim().Length != TwoPasswordTb.Text.Trim().Length)
                {
                    MessageBox.Show("Пароли не совпадают!");
                }

                else
                {
                    App.AutorizateUser = App.db.User.ToList().Find(x => x.Login == LoginTb.Text);
                    if (App.AutorizateUser != null)
                    {
                        MessageBox.Show("Такой пользователь уже есть!");
                    }
                    else
                    {
                        App.db.User.Add(new User()
                        {
                            Login = LoginTb.Text.Trim(),
                            Password = PasswordTb.Text.Trim(),
                            RoleId = 2
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Регистрация прошла успешно!");
                        NavigationService.Navigate(new AuthPage());
                    }
                }
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Clear();
            PasswordTb.Clear();
            TwoPasswordTb.Clear();
        }
    }

}
