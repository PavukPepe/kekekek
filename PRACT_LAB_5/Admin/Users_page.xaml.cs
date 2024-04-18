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
    /// Логика взаимодействия для Users_page.xaml
    /// </summary>
    public partial class Users_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Users_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Users.ToList();
            address.ItemsSource = DB.Pvzs.ToList();
            address.DisplayMemberPath = "Pvz_address";
            roles.ItemsSource = DB.Roles.ToList();
            roles.DisplayMemberPath = "Role_name";
            login.ItemsSource = DB.Authorizations.ToList().Where(item => !DB.Users.ToList().Any(iten => iten.Authorizations == item));
            login.DisplayMemberPath = "Auth_login";
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                var u = table_grid.SelectedItem as Users;
                u.User__name = nam_usr.Text;
                u.User__surname = sur_usr.Text;
                u.User__middlename = mid_usr.Text;
                u.Roles = roles.SelectedItem as Roles;
                u.Pvzs = address.SelectedItem as Pvzs;
                u.Authorizations = login.SelectedItem as Authorizations;
                if (login.SelectedItem != null)
                {
                    u.Authorizations = login.SelectedItem as Authorizations;
                }
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                var a = (table_grid.SelectedItem as Users);
                var b = a.Authorizations;
                DB.Users.Remove(a);
                DB.Authorizations.Remove(b);
            }
            Reload();
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                var u = table_grid.SelectedItem as Users;
                nam_usr.Text = u.User__name;
                sur_usr.Text = u.User__surname;
                mid_usr.Text = u.User__middlename;
                roles.SelectedItem = DB.Roles.First(item => item.Role_id == u.ID_Role);
                address.SelectedItem = u.Pvzs;
                login.ItemsSource = DB.Authorizations.ToList().Where(item => !DB.Users.ToList().Any(iten => iten.Authorizations == item) || u.Authorizations == item);
                login.SelectedItem = u.Authorizations;
            }
            
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Users.ToList();
            login.ItemsSource = DB.Authorizations.ToList().Where(item => !DB.Users.ToList().Any(iten => iten.Authorizations == item));
        }

        private void Add_bat_Click(object sender, RoutedEventArgs e)
        {
            if (nam_usr.Text != "" && sur_usr.Text != "" && mid_usr.Text != "" && roles.SelectedItem != null && address.SelectedItem != null && login.SelectedItem != null)
            {
                Users u = new Users();
                u.User__name = nam_usr.Text;
                u.User__surname = sur_usr.Text;
                u.User__middlename = mid_usr.Text;
                u.Roles = roles.SelectedItem as Roles;
                u.Pvzs = address.SelectedItem as Pvzs;
                u.Authorizations = login.SelectedItem as Authorizations;
                DB.Users.Add(u);
            }
            Reload();
        }

        private void sur_usr_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length; return;
                }
            }
        }

        private void nam_usr_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length; return;
                }
            }
        }

        private void mid_usr_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length; return;
                }
            }
        }
    }
}
