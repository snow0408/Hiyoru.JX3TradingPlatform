using Dapper;
using Hiyoru.JX3TradingPlatform.Models.Categories;
using Hiyoru.JX3TradingPlatform.Models.Repostories;
using Hiyoru.JX3TradingPlatform.Models.Service;
using SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormLogIn : System.Windows.Forms.Form
    {
        public FormLogIn()
        {
            InitializeComponent();

            this.Text = ("登入");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var user = UserCheck();

            if (String.IsNullOrEmpty(user)) { MessageBox.Show("帳號或密碼錯誤"); }
            else
            {
                var form = new FormMainMenu(user);
                form.Owner = this;
                form.Show();

                textBoxAccount.Text = "";
                textBoxPassword.Text = "";
                this.Hide();
                
                //若帳號密碼正確, 顯示FormMain(傳帳號過去), 清空自己的textbox, 並隱藏自己(不可關閉自己)
            }

        }

        /// <summary>
        /// 判斷帳密是否正確
        /// </summary>
        /// <returns></returns>
        public string UserCheck()
        {
            string id = textBoxAccount.Text;
            string password = textBoxPassword.Text;

            var repo = new UserDapperRepostory();
            var service = new UserService(repo);
            bool isExiets = service.Search(id).Any(x => x.Id == id && x.Password == password);
            if (isExiets) { return id; }

            return "";
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var form = new FormCreateUser();
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
