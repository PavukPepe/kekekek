using PRACT_LAB_5.Admin;
using PRACT_LAB_5.PVZ;
using PRACT_LAB_5.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PRACT_LAB_5.ViewModels
{
    internal class WorkerViewModel : BindingHelper
    {
        OzonEntities1 DB = new OzonEntities1();

        public Page page { get; set; }

        int Get_post_of_role(string role_name)
        {
            return DB.Roles.ToList().Where(item => item.ID_post == DB.Posts.ToList().Where(iten => iten.Post_name == role_name).First().Post_id).First().Role_id;
        }

        public WorkerViewModel(Users user)
        {
            Roles role = user.Roles;
            ;
            if (role.Role_id == Get_post_of_role("HR"))
            {
                page = new HR_page();
            }
            else if (role.Role_id == Get_post_of_role("Кладовщик"))
            {
                page = new Storager_page();
            }
            else if (role.Role_id == Get_post_of_role("Покупатель") || role.Role_id == Get_post_of_role("Кандидат"))
            {
                page = new Customer_page(user);
            }
            else if (role.Role_id == Get_post_of_role("Работник ПВЗ"))
            {
                page = new PVZ_page(user);
            }
            else if (role.Role_id == Get_post_of_role("Администратор"))
            {
                page = new Admin_page();
            }
        }

    }
}
