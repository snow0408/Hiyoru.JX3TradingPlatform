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
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormUpdateOrDelete : Form
    {
        private readonly int _id;
        private readonly string _account;
        private readonly string _type;
        public FormUpdateOrDelete(string account, int id, string type)
        {
            _account = account;
            _id = id;
            _type = type;

            InitializeComponent();
        }

        private void FormUpdateOrDelete_Load(object sender, EventArgs e)
        {
            Display();
        }


        private void Display()//顯示頁面資訊
        {
            var tradeData = GetTrade();
            ISkinRepostory skinRepo = new SkinEFRepostory();
            SkinDto skinModel = new SkinService(skinRepo).Search(tradeData.SkinName).First();

            this.labelProductName.Text = tradeData.SkinName;
            this.textBoxPrice.Text = tradeData.Price.ToString();
            this.labelAddDate.Text = tradeData.AddDate.ToString("yyyy/MM/dd");
            string ImagePath = Application.StartupPath + @"\..\..\..\Picture\" + skinModel.PicturePath;
            if (System.IO.File.Exists(ImagePath)) { pictureBoxPro.BackgroundImage = Image.FromFile(ImagePath); }

            this.Text = "更新/刪除商品";
        }
        private ProductDto GetTrade()//取得商品資料
        {
            var service = new ProductService(GetProductRepo());
            var data = service.Get(_id);

            return data;
        }
        private IProductRepostory GetProductRepo()//如何取得商品資料
        {
            return new ProductEFRepostory();
        }

        private bool CheckPassword()//確認密碼
        {
            var service = new UserService(GetUserRepo());
            var tradeData = service.Get(_account);

            if (this.textBoxPassword.Text == tradeData.Password) return true;

            return false;
        }
        private IUserRepostory GetUserRepo()//如何獲取用戶資料
        {
            return new UserDapperRepostory();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckPassword() == false)
            {
                MessageBox.Show("密碼輸入錯誤");
                return;
            }

            new ProductService(GetProductRepo()).Delete(_id);

            MessageBox.Show($"紀錄已刪除");

            var container = this.Owner as MainDataContainer;
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

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (CheckPassword() == false)
            {
                MessageBox.Show("密碼輸入錯誤");
                return;
            }

            var service = new ProductService(GetProductRepo());
            ProductDto dto = new ProductDto()
            {
                ID = _id,
                Price = int.TryParse(textBoxPrice.Text, out int value) ? value : 0,
                Status = 0
            };
            if (_type == "販售")
            {
                dto.SellerID = _account;
            }
            else
            {
                dto.BuyerID = _account;
            }

            if (dto.Price == 0)
            {
                MessageBox.Show("請確認輸入的價格是否正確");
            }
            else
            {
                new ProductService(GetProductRepo()).Update(dto);


                MessageBox.Show($"紀錄已更新");

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




        }


    }
}
