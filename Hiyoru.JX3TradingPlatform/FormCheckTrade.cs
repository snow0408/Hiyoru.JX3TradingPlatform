using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.Interface;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
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
    public partial class FormCheckTrade : Form
    {
        private readonly int _id;
        private readonly string _account;
        private readonly string _type;
        public FormCheckTrade(string account, int id, string type)
        {
            _account = account;
            _id = id;
            _type = type;

            InitializeComponent();

            Display();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (checkUser() == false)
            {
                MessageBox.Show("尚未完整填寫會員資料，需填寫完成才可新增交易。");
                return;
            }
            if (CheckPassword() == false)
            {
                MessageBox.Show("密碼輸入錯誤");
                return;
            }

            var service = new ProductService(GetProductRepo());

            ProductDto dto = new ProductDto() { ID = _id };

            if (_type == "販售")
            {
                dto.BuyerID = _account;
                dto.SellerID = this.labelSeller.Text;
            }
            if (_type == "購買")
            {
                dto.SellerID = _account;
                dto.BuyerID = this.labelSeller.Text;
            }
            dto.Price=int.Parse(this.labelPrice.Text);
            dto.Status = 1;

            service.Update(dto);
            MessageBox.Show($"新增交易成功，請至[我的交易]進行確認。");

            var container = this.Owner as IUpdateOrDeleteContainer;

            if (container != null)
            {
                container.DisplayWantProduct();
                container.DisplayMyProduct();
            }
            else
            {
                MessageBox.Show("Owner表單未實作 MainDataContainer, 請檢查後再試一次");
            }

            this.Close();
        }

        private void Display()
        {
            var tradeData = GetTrade();

            this.labelProductName.Text = tradeData.SkinName;
            this.labelPrice.Text = tradeData.Price.ToString();
            this.labelAddDate.Text = tradeData.AddDate.ToString("yyyy/MM/dd");
            this.labelSeller.Text = tradeData.SellerID;
            this.Text = "確認購買";

            if (_type == "購買")
            {
                this.Text = "確認出售";
                this.label2.Text = "發布日期";
                this.label4.Text = "求購者";
                this.labelSeller.Text = tradeData.BuyerID;
                this.buttonCheck.Text = "我要出售";
            }
        }
        private ProductDto GetTrade()
        {
            var service = new ProductService(GetProductRepo());
            var data = service.Get(_id);

            return data;
        }
        private IProductRepostory GetProductRepo()
        {
            return new ProductEFRepostory();
        }
        private bool checkUser()
        {
            string id = _account;
            var service = new UserService(GetUserRepo());
            var data = service.Search(id).Where(x => x.Id == id).First();

            if (String.IsNullOrEmpty(data.PhoneNumber)
                || String.IsNullOrEmpty(data.Email)
                || String.IsNullOrEmpty(data.BankAccount))
            {
                return false;
            }
            else { return true; }
        }
        private bool CheckPassword()
        {
            var service = new UserService(GetUserRepo());
            var tradeData = service.Get(_account);

            if (this.textBoxPassword.Text == tradeData.Password) return true;

            return false;
        }
        private IUserRepostory GetUserRepo()
        {
            return new UserDapperRepostory();
        }
    }
}
