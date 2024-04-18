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

namespace PRACT_LAB_5.Admin
{
    /// <summary>
    /// Логика взаимодействия для Auth_page.xaml
    /// </summary>
    public partial class Auth_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Auth_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Authorizations.ToList();
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                var a = table_grid.SelectedItem as Authorizations;
                a.Auth_login = login.Text;
                a.Auth_pass = pass.Text;
            }
            Reload();
        }

        private void Add_but_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && login.Text != "")
            {
                Authorizations a = new Authorizations();
                a.Auth_login = login.Text;
                a.Auth_pass = pass.Text;
                DB.Authorizations.Add(a);
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                try
                {
                    DB.Authorizations.Remove(table_grid.SelectedItem as Authorizations);
                }
                catch 
                {
                    MessageBox.Show("Вы пытаетесь удалить логин к которому привязан пользователь");
                }
            }
            Reload();
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            login.Text = (table_grid.SelectedItem as Authorizations).Auth_login;
            pass.Text = (table_grid.SelectedItem as Authorizations).Auth_pass;
        }

        void Reload()
        {
            try
            {
                DB.SaveChanges();
                table_grid.ItemsSource = DB.Authorizations.ToList();
            }
            catch 
            {
                MessageBox.Show("Админ, ты добавляешь уже существующий логин");
            }
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
