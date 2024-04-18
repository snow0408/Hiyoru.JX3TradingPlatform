using Hiyoru.JX3TradingPlatform.Models.Categories;
using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Interface;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormMemberCenter : Form
    {
        private readonly string _account;
        public FormMemberCenter(string account)
        {
            _account = account;

            InitializeComponent();
            this.Text = ("會員中心");

            this.textBoxAccount.Text = _account;
            GetData();
        }
        public void GetData()
        {
            string id = _account;
            var service = new UserService(GetRepo());
            var data = service.Search(id).Where(x => x.Id == id).First();

            this.textBoxUserName.Text = data.UserName.ToString();
            this.textBoxPassword.Text = data.Password.ToString();
            if (data.Email != null) { this.textBoxEmail.Text = data.Email.ToString(); }
            if (data.PhoneNumber != null) { this.textBoxPhoneNumber.Text = data.PhoneNumber.ToString(); }
            if (data.BankAccount != null) { this.textBoxBankAccount.Text = data.BankAccount.ToString(); }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var service = new UserService(GetRepo());

            UserDto dto = new UserDto
            {
                Id = _account
            };

            if (!String.IsNullOrEmpty(textBoxUserName.Text.ToString()))
            {
                dto.UserName = textBoxUserName.Text;
            }
            else 
            {
                MessageBox.Show("使用者名稱不可為空白");
                return;
            }
            if (!String.IsNullOrEmpty(textBoxPassword.Text.ToString()))
            {
                dto.Password = textBoxPassword.Text;
            }
            else
            {
                MessageBox.Show("密碼不可為空白");
                return;
            }

            if (!String.IsNullOrEmpty(textBoxEmail.Text.ToString()))
            {
                dto.Email = textBoxEmail.Text;
            }
            if (!String.IsNullOrEmpty(textBoxPhoneNumber.Text.ToString()))
            {
                dto.PhoneNumber = textBoxPhoneNumber.Text;
            }
            if (!String.IsNullOrEmpty(textBoxBankAccount.Text.ToString()))
            {
                dto.BankAccount = textBoxBankAccount.Text;
            }

            service.Update(dto);
            MessageBox.Show($"紀錄已更新");
        }

        private IUserRepostory GetRepo()
        {
            return new UserDapperRepostory();
        }
    }
}
