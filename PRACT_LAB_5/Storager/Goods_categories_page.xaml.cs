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
    /// Логика взаимодействия для Goods_categories_page.xaml
    /// </summary>
    public partial class Goods_categories_page : Page
    {

        OzonEntities1 DB = new OzonEntities1();
        public Goods_categories_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Goods_categories.ToList();
            pack_types.ItemsSource = DB.Package_types.ToList();
            pack_types.DisplayMemberPath = "Pack_type_name";
        }

        private void Add_but_Click(object sender, RoutedEventArgs e)
        {
            if (category_name.Text != "" && pack_types.SelectedItem != null)
            {
                Goods_categories pack = new Goods_categories();
                pack.Good_category_name = category_name.Text;
                pack.ID_Pack_type = (pack_types.SelectedItem as Package_types).Pack_type_id;
                DB.Goods_categories.Add(pack);
                Reload();
                category_name.Text = "";
            }
        }

        void Reload()
        {
            try
            {
                DB.SaveChanges();
                table_grid.ItemsSource = DB.Goods_categories.ToList();
            }
            catch
            {
                MessageBox.Show("Невозможно удалить так как на него ссылаются из других таблиц");
            }
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                var pack = table_grid.SelectedItem as Goods_categories;
                pack_types.SelectedItem = pack.Package_types;
                category_name.Text = (table_grid.SelectedItem as Goods_categories).Good_category_name;
            }
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && category_name.Text != "")
            {
                var pack = table_grid.SelectedItem as Goods_categories;
                pack.Good_category_name = category_name.Text;
                pack.Package_types = pack_types.SelectedItem as Package_types;
            }
            Reload();
        }

        private void Del_bat_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                DB.Goods_categories.Remove(table_grid.SelectedItem as Goods_categories);
                Reload();
            }
        }

        private void pack_types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void category_name_TextChanged(object sender, TextChangedEventArgs e)
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
