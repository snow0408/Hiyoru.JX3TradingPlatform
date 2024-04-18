using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.EFmodels;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using Hiyoru.JX3TradingPlatform.Models.Repostories;
using Hiyoru.JX3TradingPlatform.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormMainMenu : System.Windows.Forms.Form, MainDataContainer, IUpdateOrDeleteContainer
    {
        private readonly string _account;
        public FormMainMenu(string account)
        {
            _account = account;

            InitializeComponent();

            this.Text = ("JX3交易平台");

            this.Load += FormMainMenu_Load;

            this.dataGridViewSearchSkin.CellClick += DataGridViewSearchSkin_CellClick;

            this.dataGridViewOnShelves.CellClick += DataGridViewOnShelves_CellClick;
            this.dataGridViewShip.CellClick += DataGridViewShip_CellClick;
            this.dataGridViewTrade.CellClick += DataGridViewTrade_CellClick;

            this.dataGridViewWantBuy.CellClick += DataGridViewWantBuy_CellClick;
            this.dataGridViewToPay.CellClick += DataGridViewToPay_CellClick;
            this.dataGridViewTotePro.CellClick += DataGridViewTotePro_CellClick;
            this.dataGridViewTakeBuy.CellClick += DataGridViewTakeBuy_CellClick;

            this.dataGridViewSearchSkin.AutoGenerateColumns = false;
            this.dataGridViewOnShelves.AutoGenerateColumns = false;
        }







        //載入
        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            DisplayPicture();

            this.panelLibrary.Hide();
            this.panelMyTarde.Hide();
            this.panelBuyerCenter.Hide();
            this.panelHistory.Hide();
        }
        //圖片顯示
        private void DisplayPicture()
        {
            string logoImagePath = Application.StartupPath + @"\..\..\..\Picture\jx3logo.jpg";
            if (File.Exists(logoImagePath)) { pictureBoxLogo.Image = Image.FromFile(logoImagePath); }

            string backgroundImagePath = Application.StartupPath + @"\..\..\..\Picture\jellyfish.png";
            if (File.Exists(backgroundImagePath)) { this.BackgroundImage = Image.FromFile(backgroundImagePath); }
        }


        //主選單控制項
        private void buttonToUser_Click(object sender, EventArgs e)//會員中心
        {
            var form = new FormMemberCenter(_account);
            form.ShowDialog();
        }
        private void buttonToLibrary_Click(object sender, EventArgs e)//外觀搜尋
        {
            this.panelBuyerCenter.Hide();
            this.panelLibrary.Show();
            this.panelMyTarde.Hide();
            this.panelHistory.Hide();

            DisplaySkinSearch();
            SetComboBox();
        }
        private void buttonToBuy_Click(object sender, EventArgs e)//買家中心
        {
            this.panelBuyerCenter.Show();
            this.panelLibrary.Hide();
            this.panelMyTarde.Hide();
            this.panelHistory.Hide();

            DisplayWantProduct();
            DisplayBuyProduct();
            DisplayToteProduct();
            DisplayTakeProduct();
        }
        private void buttonToTrade_Click(object sender, EventArgs e)//賣家中心
        {
            this.panelMyTarde.Show();
            this.panelLibrary.Hide();
            this.panelBuyerCenter.Hide();
            this.panelHistory.Hide();

            DisplayMyProduct();
            DisplayTradeProduct();
            DisplayShipProduct();
            DisplayPickProduct();
        }
        private void buttonToHistory_Click(object sender, EventArgs e)//歷史紀錄
        {
            this.panelHistory.Show();
            this.panelLibrary.Hide();
            this.panelMyTarde.Hide();
            this.panelBuyerCenter.Hide();

            DisplayHistorySell();
            DisplayHistoryBuy();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)//LOGO
        {
            this.panelLibrary.Hide();
            this.panelMyTarde.Hide();
            this.panelBuyerCenter.Hide();
            this.panelHistory.Hide();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)//關閉視窗
        {
            this.Owner.Show();
        }


        //外觀搜尋頁面
        private ISkinRepostory GetSkinRepo()
        {
            return new SkinEFRepostory();
        }
        private void AddSkinInDataGridView(List<SkinDto> skins)//上架中商品
        {
            foreach (var skin in skins)
            {
                dataGridViewSearchSkin.Rows.Add(skin.ID, skin.Name, skin.EName, skin.LaunchDate, skin.CategoryName);
            }
        }
        public void DisplaySkinSearch()
        {
            dataGridViewSearchSkin.Rows.Clear();

            var mySkinService = new SkinService(GetSkinRepo());

            var skins = mySkinService.Search(textBoxSkinName.Text, comboBoxCategory.Text);

            AddSkinInDataGridView(skins);
        }
        private void SetComboBox() 
        {
            var repo = new CategoryEFRepostory();

            var categoryService=new CategoryService(repo);
            var categoryList = categoryService.GetAllCategory();

            var firstItem = new CategoryDto { ID = -1, Name = "" };
            categoryList.Insert(0, firstItem);

            comboBoxCategory.DataSource = categoryList;
            comboBoxCategory.ValueMember = "ID";
            comboBoxCategory.DisplayMember = "Name";
        }
        private void comboBoxCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            DisplaySkinSearch();
        }

        private void buttonSearchLib_Click(object sender, EventArgs e)
        {
            DisplaySkinSearch();
        }
        private void DataGridViewSearchSkin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<SkinDto> skins = dataGridViewSearchSkin.DataSource as List<SkinDto>;//三層式架構

            //int pk = skins[e.RowIndex].ID;//找出哪一筆
            DataGridViewRow selectedRow = dataGridViewSearchSkin.Rows[e.RowIndex];
            int pk = Convert.ToInt32(selectedRow.Cells["ColumnID"].Value);

            var form = new FormSkinDescription(_account, pk);
            form.Owner = this;
            form.ShowDialog();
        }



        //賣家中心
        private IProductRepostory GetProductRepo()
        {
            return new ProductEFRepostory();
        }

        private void AddMyProductInDataGridView(List<ProductDto> products)//上架中商品
        {
            foreach (var product in products)
            {
                dataGridViewOnShelves.Rows.Add(product.ID, product.SkinName, product.Price, product.AddDate);
            }
        }
        public void DisplayMyProduct()//顯示上架中商品
        {
            dataGridViewOnShelves.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsOnShelves = myProductService.SearchUserSellProduct(_account, 0);

            AddMyProductInDataGridView(productsOnShelves);
        }
        private void DataGridViewOnShelves_CellClick(object sender, DataGridViewCellEventArgs e)//更新上架中商品
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> Pro = dataGridViewOnShelves.DataSource as List<ProductDto>;//三層式架構

            DataGridViewRow selectedRow = dataGridViewOnShelves.Rows[e.RowIndex];
            int pk = Convert.ToInt32(selectedRow.Cells["MyProductID"].Value);

            var form = new FormUpdateOrDelete(_account, pk, "販售");
            form.Owner = this;
            form.ShowDialog();
        }

        private void AddTradeProductInDataGridView(List<ProductDto> products)//待付款商品
        {
            foreach (var product in products)
            {
                dataGridViewTrade.Rows.Add(product.ID, product.SkinName, product.Price, product.BuyerID);
            }
        }
        public void DisplayTradeProduct()//顯示待付款商品
        {
            dataGridViewTrade.Rows.Clear();//清空

            var myProductService = new ProductService(GetProductRepo());

            var productsTradeSell = myProductService.SearchUserSellProduct(_account, 1);

            AddTradeProductInDataGridView(productsTradeSell);
        }
        private void DataGridViewTrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            var form = new FormCustomerService();
            form.ShowDialog();
        }

        private void AddShipProductInDataGridView(List<ProductDto> products)//待出貨商品
        {
            foreach (var product in products)
            {
                dataGridViewShip.Rows.Add(product.ID, product.SkinName, product.Price, product.TransDate, product.BuyerID);
            }
        }
        public void DisplayShipProduct()//顯示待出貨商品
        {
            dataGridViewShip.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsTradeSell = myProductService.SearchUserSellProduct(_account, 2);

            AddShipProductInDataGridView(productsTradeSell);
        }
        private void DataGridViewShip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> Pro = dataGridViewShip.DataSource as List<ProductDto>;//三層式架構

            DataGridViewRow selectedRow = dataGridViewShip.Rows[e.RowIndex];
            int pk = Convert.ToInt32(selectedRow.Cells["ShipID"].Value);
            string buyer = Convert.ToString(selectedRow.Cells["BuyerID"].Value);

            var form = new FormShip(pk, _account);
            form.Owner = this;
            form.ShowDialog();
        }

        private void AddPickProductInDataGridView(List<ProductDto> products)//待取貨商品
        {
            foreach (var product in products)
            {
                dataGridViewWaitToPick.Rows.Add(product.ID, product.SkinName, product.Price, product.TransDate, product.BuyerID);
            }
        }
        public void DisplayPickProduct()//顯示待取貨商品
        {
            dataGridViewWaitToPick.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsPickUp = myProductService.SearchUserSellProduct(_account, 3);

            AddPickProductInDataGridView(productsPickUp);
        }


        //買家中心
        private void AddWantProductInDataGridView(List<ProductDto> products)//收購商品
        {
            foreach (var product in products)
            {
                dataGridViewWantBuy.Rows.Add(product.ID, product.SkinName, product.Price, product.AddDate);
            }
        }
        public void DisplayWantProduct()//顯示收購中商品
        {
            dataGridViewWantBuy.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsWantBuy = myProductService.SearchUserBuyerProduct(_account, 0);

            AddWantProductInDataGridView(productsWantBuy);
        }
        private void DataGridViewWantBuy_CellClick(object sender, DataGridViewCellEventArgs e)//更新收購商品
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> Pro = dataGridViewWantBuy.DataSource as List<ProductDto>;//三層式架構

            DataGridViewRow selectedRow = dataGridViewWantBuy.Rows[e.RowIndex];
            int pk = Convert.ToInt32(selectedRow.Cells["WantBuyID"].Value);

            var form = new FormUpdateOrDelete(_account, pk, "購買");
            form.Owner = this;
            form.ShowDialog();
        }


        private void AddBuyProductInDataGridView(List<ProductDto> products)//待付款商品
        {
            foreach (var product in products)
            {
                dataGridViewToPay.Rows.Add(product.ID, product.SkinName, product.Price, product.SellerID);
            }
        }
        public void DisplayBuyProduct()//顯示待付款商品
        {
            dataGridViewToPay.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsToPay = myProductService.SearchUserBuyerProduct(_account, 1);

            AddBuyProductInDataGridView(productsToPay);
        }
        private void DataGridViewToPay_CellClick(object sender, DataGridViewCellEventArgs e)//付款
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> Pro = dataGridViewToPay.DataSource as List<ProductDto>;//三層式架構

            DataGridViewRow selectedRow = dataGridViewToPay.Rows[e.RowIndex];
            int pk = Convert.ToInt32(selectedRow.Cells["ToPayID"].Value);
            string sellerId = Convert.ToString(selectedRow.Cells["SellerID"].Value);

            var form = new FormToPay(pk, sellerId, _account);
            form.Owner = this;
            form.ShowDialog();
        }


        private void AddToteProductInDataGridView(List<ProductDto> products)//待出貨商品
        {
            foreach (var product in products)
            {
                dataGridViewTotePro.Rows.Add(product.ID, product.SkinName, product.Price, product.TransDate, product.SellerID);
            }
        }
        public void DisplayToteProduct()//顯示待出貨商品
        {
            dataGridViewTotePro.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsTote = myProductService.SearchUserBuyerProduct(_account, 2);

            AddToteProductInDataGridView(productsTote);
        }
        private void DataGridViewTotePro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            var form = new FormCustomerService();
            form.ShowDialog();
        }

        private void AddTakeProductInDataGridView(List<ProductDto> products)//待取貨商品
        {
            foreach (var product in products)
            {
                dataGridViewTakeBuy.Rows.Add(product.ID, product.SkinName, product.Price, product.TransDate, product.SellerID);
            }
        }
        public void DisplayTakeProduct()//顯示待取貨商品
        {
            dataGridViewTakeBuy.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsTote = myProductService.SearchUserBuyerProduct(_account, 3);

            AddTakeProductInDataGridView(productsTote);
        }
        private void DataGridViewTakeBuy_CellClick(object sender, DataGridViewCellEventArgs e)//取貨
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> Pro = dataGridViewTakeBuy.DataSource as List<ProductDto>;//三層式架構

            DataGridViewRow selectedRow = dataGridViewTakeBuy.Rows[e.RowIndex];
            int pk = Convert.ToInt32(selectedRow.Cells["TakeID"].Value);

            var form = new FormTakePro(pk, _account);
            form.Owner = this;
            form.ShowDialog();
        }


        //歷史紀錄
        private void AddSHistorySellInDataGridView(List<ProductDto> products)//顯示歷史銷售
        {
            foreach (var product in products)
            {
                dataGridViewHistorySell.Rows.Add(product.ID, product.SkinName, product.Price, product.TransDate, product.BuyerID);
            }
        }
        private void DisplayHistorySell() //歷史銷售紀錄
        {
            dataGridViewHistorySell.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsHistorySell = myProductService.SearchUserSellProduct(_account, 4);

            AddSHistorySellInDataGridView(productsHistorySell);
        }

        private void AddSHistoryBuyInDataGridView(List<ProductDto> products)//顯示歷史購買
        {
            foreach (var product in products)
            {
                dataGridViewHistoryBuy.Rows.Add(product.ID, product.SkinName, product.Price, product.TransDate, product.SellerID);
            }
        }
        private void DisplayHistoryBuy() //歷史購買紀錄
        {
            dataGridViewHistoryBuy.Rows.Clear();

            var myProductService = new ProductService(GetProductRepo());

            var productsHistoryBuy = myProductService.SearchUserBuyerProduct(_account, 4);

            AddSHistoryBuyInDataGridView(productsHistoryBuy);
        }

    }
}
