using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.Interface;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using Hiyoru.JX3TradingPlatform.Models.Repostories;
using Hiyoru.JX3TradingPlatform.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormToPay : Form
    {
        private readonly int _id;
        private readonly string _sellerId;
        private readonly string _account;
        public FormToPay(int id, string sellerId, string account)
        {
            _id = id;
            _sellerId = sellerId;
            _account = account;

            InitializeComponent();

            Display();
        }

        private IUserRepostory GetUserRepo()//如何獲取用戶資料
        {
            return new UserDapperRepostory();
        }
        private IProductRepostory GetProductRepo()//如何取得商品資料
        {
            return new ProductEFRepostory();
        }
        private ProductDto GetPro()//取得商品資料
        {
            var service = new ProductService(GetProductRepo());
            var data = service.Get(_id);

            return data;
        }
        private UserDto GetSeller()//取得賣家訊息
        {
            var seller = new UserService(GetUserRepo());
            var sellerdata = seller.Get(_sellerId);

            return sellerdata;
        }

        private void Display()//顯示頁面資訊
        {
            var tradeData = GetPro();
            var sellerData = GetSeller();

            this.labelProductName.Text = tradeData.SkinName;
            this.labelPrice.Text = tradeData.Price.ToString();
            this.labelSeller.Text = sellerData.Id;
            this.labelBankAccount.Text = sellerData.BankAccount;

            this.Text = "確認付款";
        }


        private void buttonCheck_Click(object sender, EventArgs e)
        {
            var service = new ProductService(GetProductRepo());
            ProductDto dto = new ProductDto()
            {
                ID = _id,
                Price = int.Parse(this.labelPrice.Text),
                BuyerID = _account,
                SellerID = _sellerId,
                Status = 2,
                TransDate = DateTime.Now
            };

            if (String.IsNullOrEmpty(this.textBoxLast5.Text) || this.textBoxLast5.Text.Length < 5)
            {
                MessageBox.Show("請正確輸入匯款帳號末5碼");
                return;
            }
            else { dto.TransAccount = this.textBoxLast5.Text; }

            if (String.IsNullOrEmpty(this.textBoxRecipientID.Text))
            {
                MessageBox.Show("收件人ID未填寫");
                return;
            }
            else { dto.Recipient = this.textBoxRecipientID.Text; }


            new ProductService(GetProductRepo()).Update(dto);
            MessageBox.Show($"已送出");

            var container = this.Owner as MainDataContainer;

            if (container != null)
            {
                container.DisplayBuyProduct();
                container.DisplayToteProduct();
            }
            else
            {
                MessageBox.Show("Owner表單未實作 MainDataContainer, 請檢查後再試一次");
            }

            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new FormCustomerService();
            form.ShowDialog();
        }
    }
}

