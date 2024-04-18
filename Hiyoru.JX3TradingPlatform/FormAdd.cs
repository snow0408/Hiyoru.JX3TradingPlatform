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
    public partial class FormAdd : Form
    {
        private readonly string _account;
        private readonly string _skinName;
        private readonly string _type;
        public FormAdd(string account, string skinName, string type)
        {
            _account = account;
            _skinName = skinName;
            _type = type;

            InitializeComponent();

            if (type == "販售") { this.Text = "新增商品"; }
            if (type == "購買") { this.Text = "新增收購"; }
            this.labelUserID.Text = _account;
            this.labelProductName.Text = _skinName;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (checkUser() == false)
            {
                MessageBox.Show("尚未完整填寫會員資料，需填寫完成才可新增交易。");
                return;
            }

            ProductDto dto = new ProductDto
            {
                SkinName = _skinName,
                Price = int.TryParse(textBoxPrice.Text, out int value) ? value : 0,
                Status = 0,
                Type = _type,
                AddDate = DateTime.Now
            };
            if (_type == "販售") { dto.SellerID = _account; }
            else { dto.BuyerID = _account; }


            if (dto.Price == 0) { MessageBox.Show($"請確認輸入的價格"); }
            else
            {
                int newId = new ProductService(GetRepo()).Create(dto);


                MessageBox.Show($"紀錄已新增, new id={newId}");

                var container = this.Owner as IDataContainer;

                if (container != null)
                {
                    container.Display();
                }
                else
                {
                    MessageBox.Show("Owner表單未實作 IDataContainer, 請檢查後再試一次");
                }

                this.Close();
                
            }



        }
        private bool checkUser()
        {
            var repo = new UserDapperRepostory();

            string id = _account;
            var service = new UserService(repo);
            var data = service.Search(id).Where(x => x.Id == id).First();

            if (String.IsNullOrEmpty(data.PhoneNumber)
                || String.IsNullOrEmpty(data.Email)
                || String.IsNullOrEmpty(data.BankAccount))
            {
                return false;
            }
            else { return true; }
        }
        private IProductRepostory GetRepo()
        {
            return new ProductEFRepostory();
        }
    }
}
