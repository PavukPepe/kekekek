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
    /// Логика взаимодействия для Posts_page.xaml
    /// </summary>
    public partial class Posts_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Posts_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Posts.ToList();
        }

        private void Alt_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null &&  decimal.TryParse(post_salary.Text, out _))
            {
                (table_grid.SelectedItem as Posts).Post_salary = decimal.Parse(post_salary.Text);
            }
            else
            {
                MessageBox.Show("Циферками ЗП писать нада");
            }
            Reload();
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            post_salary.Text = (table_grid.SelectedItem as Posts).Post_salary.ToString();
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Posts.ToList();
        }

        private void post_salary_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    if (c != ',')
                    {
                        textBox.Text = text.Remove(text.Length - 1);
                        textBox.SelectionStart = textBox.Text.Length; return;
                    }
                }
            }
        }
    }
}
