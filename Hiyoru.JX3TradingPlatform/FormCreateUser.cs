using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Repostories;
using Hiyoru.JX3TradingPlatform.Models.Service;
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
    public partial class FormCreateUser : Form
    {
        public FormCreateUser()
        {
            InitializeComponent();

            this.Text = ("會員註冊");
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPassword.Text) || String.IsNullOrEmpty(textBoxAccount.Text) || String.IsNullOrEmpty(textBoxUserName.Text))
            {
                MessageBox.Show("請完整填寫資料");
            }
            else if (textBoxPassword.Text != textBoxCheckPassword.Text)
            {
                MessageBox.Show("第二次密碼輸入錯誤");
            }

            else
            {
                UserDto dto = new UserDto
                {
                    UserName = textBoxUserName.Text,
                    Id = textBoxAccount.Text,
                    Password = textBoxPassword.Text
                };

                var repo = new UserDapperRepostory();

                bool isExists = repo.Search(dto.Id).Any(x => x.Id == dto.Id);

                if (isExists) { MessageBox.Show($"帳號已存在"); }
                else
                {
                    new UserService(repo).Create(dto);
                    MessageBox.Show($"帳號新建成功");

                    this.Close();
                }

            }
        }
    }
}
