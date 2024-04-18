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
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormShip : Form
    {
        private readonly int _pk;
        private readonly string _account;
        public FormShip(int pk, string account)
        {
            _pk = pk;
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
            var data = service.Get(_pk);

            return data;
        }

        private void Display()//顯示頁面資訊
        {
            var tradeData = GetPro();

            this.labelProductName.Text = tradeData.SkinName;
            this.labelPrice.Text = tradeData.Price.ToString();
            this.labelBuyer.Text = tradeData.BuyerID;
            this.labelRecipient.Text=tradeData.Recipient;
            this.labelTransAccount.Text = tradeData.TransAccount;
            this.labelTransDate.Text = tradeData.TransDate.Value.ToString("yyyy/MM/dd");

            this.Text = "確認出貨";
        }

        private void buttonShip_Click(object sender, EventArgs e)
        {
            var service = new ProductService(GetProductRepo());
            ProductDto dto = new ProductDto()
            {
                ID = _pk,
                Price = int.Parse(this.labelPrice.Text),
                SellerID = _account,
                BuyerID = this.labelBuyer.Text,
                Status = 3,
                TransDate = DateTime.Now,
                TransAccount = this.labelTransAccount.Text,
                Recipient = this.labelRecipient.Text
            };

            new ProductService(GetProductRepo()).Update(dto);
            MessageBox.Show($"已送出");

            var container = this.Owner as MainDataContainer;

            if (container != null)
            {
                container.DisplayShipProduct();
                container.DisplayPickProduct();
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
