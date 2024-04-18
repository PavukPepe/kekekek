using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using PRACT_LAB_5.ViewModels.Helpers;

namespace PRACT_LAB_5.ViewModels
{
    internal class RegViewModel : BindingHelper
    {

        OzonEntities1 DB = new OzonEntities1();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Pass { get; set; }
        public string Pass_pass { get; set; }
        public string login { get; set; }
        public bool is_worker { get; set; }

        public Pvzs selected_pvz { get; set; }

        public List<Pvzs> pvzs { get; set; }

        public CommandHelper reg {  get; set; }

        private void registration()
        {

            if (login != "" && Pass != "" && Pass_pass != "" && Pass != "" && Name != "" && Surname != "" && selected_pvz != null)
            {
                if (Pass_pass != Pass)
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
                if (Pass_pass.Length < 8)
                {
                    MessageBox.Show("Минимальная длина пароля 8 символов");
                    return;
                }
                try
                {
                    Authorizations auth = new Authorizations();
                    Users user = new Users();
                    auth.Auth_login = login;
                    auth.Auth_pass = Pass;
                    DB.Authorizations.Add(auth);
                    DB.SaveChanges();
                    user.User__name = Name;
                    user.User__surname = Surname;
                    user.User__middlename = Middlename;
                    user.ID_pvz = selected_pvz.Pvz_id;
                    if (is_worker == true)
                    {
                        user.ID_Role = DB.Roles.ToList().First(i => i.ID_post == DB.Posts.ToList().First(iten => iten.Post_name == "Кандидат").Post_id).Role_id;
                    }
                    else
                    {
                        user.ID_Role = DB.Roles.ToList().First(i => i.ID_post == DB.Posts.ToList().First(iten => iten.Post_name == "Покупатель").Post_id).Role_id;
                    }
                    user.Authorizations = auth;
                    DB.Users.Add(user);
                    DB.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались");
                }
                catch
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
        }

        public RegViewModel() 
        {
            is_worker = false;
            pvzs = DB.Pvzs.ToList();
            reg = new CommandHelper(_ => registration());
        }
    }
}
