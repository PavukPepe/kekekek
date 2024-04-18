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
    /// Логика взаимодействия для PVZs_page.xaml
    /// </summary>
    public partial class PVZs_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public PVZs_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Pvzs.ToList();
        }

        private void Add_but_Click(object sender, RoutedEventArgs e)
        {
            if (package_name.Text != "")
            {
                Pvzs pvzs = new Pvzs();
                pvzs.Pvz_address = package_name.Text;
                DB.Pvzs.Add(pvzs);
                Reload();
                package_name.Text = "";
            }
        }

        void Reload()
        {
            try
            {
                DB.SaveChanges();
                table_grid.ItemsSource = DB.Pvzs.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                MessageBox.Show("Невозможно удалить так как на него ссылаются из других таблиц");
            }

        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                package_name.Text = (table_grid.SelectedItem as Pvzs).Pvz_address;
            }
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && package_name.Text != "")
            {
                (table_grid.SelectedItem as Pvzs).Pvz_address = package_name.Text;
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                DB.Pvzs.Remove(table_grid.SelectedItem as Pvzs);
                Reload();
            }
        }

        private void package_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
