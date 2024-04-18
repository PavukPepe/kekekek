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
    /// Логика взаимодействия для Package_types_page.xaml
    /// </summary>
    public partial class Package_types_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Package_types_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Package_types.ToList();
        }

        private void Add_but_Click(object sender, RoutedEventArgs e)
        {
            if (package_name.Text != "")
            {
                Package_types pack = new Package_types();
                pack.Pack_type_name = package_name.Text;
                DB.Package_types.Add(pack);
                Reload();
                package_name.Text = "";
            }
        }

        void Reload()
        {
            try
            {
                DB.SaveChanges();
                table_grid.ItemsSource = DB.Package_types.ToList();
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
                package_name.Text = (table_grid.SelectedItem as Package_types).Pack_type_name;
            }           
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && package_name.Text != "")
            {
                (table_grid.SelectedItem as Package_types).Pack_type_name = package_name.Text;
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                DB.Package_types.Remove(table_grid.SelectedItem as Package_types);
                Reload();
            }
        }

        private void package_name_TextChanged(object sender, TextChangedEventArgs e)
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
