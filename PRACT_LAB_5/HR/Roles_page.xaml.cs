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

namespace PRACT_LAB_5
{
    /// <summary>
    /// Логика взаимодействия для Roles_page.xaml
    /// </summary>
    public partial class Roles_page : Page
    {

        OzonEntities1 DB = new OzonEntities1();
        public Roles_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Roles.ToList();
            posts_types.ItemsSource = DB.Posts.ToList();
            posts_types.DisplayMemberPath = "Post_name";
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && role_name.Text != "" && (posts_types.SelectedItem as Posts) != null)
            {
                var role = table_grid.SelectedItem as Roles;
                role.Role_name = role_name.Text;
                role.Posts = posts_types.SelectedItem as Posts;
            }
            Reload();
        }

        private void Add_but_Click(object sender, RoutedEventArgs e)
        {
            if (role_name.Text != "" && (posts_types.SelectedItem as Posts) != null)
            {
                Roles role = new Roles();
                role.Role_name = role_name.Text;
                role.Posts = posts_types.SelectedItem as Posts;   
                DB.Roles.Add(role);
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                DB.Roles.Remove(table_grid.SelectedItem as Roles);
                Reload();
            }
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                Roles role = table_grid.SelectedItem as Roles;
                role_name.Text = role.Role_name;
                posts_types.SelectedItem = role.Posts;
            }
        }

        void Reload()
        {
            try
            {
                DB.SaveChanges();
                table_grid.ItemsSource = DB.Roles.ToList();
            }
            catch
            {
                MessageBox.Show("Невозможно удалить так как на него ссылаются из других таблиц");
            }
        }

        private void role_name_TextChanged(object sender, TextChangedEventArgs e)
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
