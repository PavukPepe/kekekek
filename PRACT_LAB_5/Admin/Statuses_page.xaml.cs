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
    /// Логика взаимодействия для Statuses_page.xaml
    /// </summary>
    public partial class Statuses_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Statuses_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Cart_statuses.ToList();
        }
    }
}
