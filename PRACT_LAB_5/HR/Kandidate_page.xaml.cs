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
    /// Логика взаимодействия для Kandidate_page.xaml
    /// </summary>
    public partial class Kandidate_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Kandidate_page()
        {
            InitializeComponent();
            try
            {
                table_grid.ItemsSource = DB.Users.ToList().Where(item => item.ID_Role == DB.Roles.ToList().Where(iten => iten.ID_post == DB.Posts.ToList().Where(i => i.Post_name == "Кандидат").First().Post_id).First().Role_id);
            }
            catch 
            {
                MessageBox.Show("Для коррекной работы этого раздела необходимо создать роль с должностью Покупатель и Кандидат");
            }

            roles.ItemsSource = DB.Roles.ToList().Where(item => item.Posts.Post_name != "Покупатель");
            roles.DisplayMemberPath = "Role_name";
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                (table_grid.SelectedItem as Users).Roles = roles.SelectedItem as Roles;
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                (table_grid.SelectedItem as Users).Roles = roles.SelectedItem as Roles;
                DB.Users.Remove(table_grid.SelectedItem as Users);
                DB.Authorizations.Remove((table_grid.SelectedItem as Users).Authorizations);
            }
            Reload();
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
                roles.SelectedItem = (table_grid.SelectedItem as Users).Roles;
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Users.ToList().Where(item => item.ID_Role == DB.Roles.ToList().Where(iten => iten.ID_post == DB.Posts.ToList().Where(i => i.Post_name == "Кандидат").First().Post_id).First().Role_id);
        }
    }
}
