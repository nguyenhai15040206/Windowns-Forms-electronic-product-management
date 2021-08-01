
namespace QLSanPhamDienTu
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPhanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPayCart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInvoiceManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCustomerManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewsManager = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpXuấtKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProductManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGoodsRevriveNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSupplierManager = new System.Windows.Forms.ToolStripMenuItem();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.nhậpXuấtKhoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1294, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangePass,
            this.menuItemPhanQuyen,
            this.menuItemLogout,
            this.menuItemExit});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // menuItemChangePass
            // 
            this.menuItemChangePass.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemChangePass.Name = "menuItemChangePass";
            this.menuItemChangePass.Size = new System.Drawing.Size(228, 24);
            this.menuItemChangePass.Tag = "1";
            this.menuItemChangePass.Text = "Đổi mật khẩu";
            // 
            // menuItemPhanQuyen
            // 
            this.menuItemPhanQuyen.Name = "menuItemPhanQuyen";
            this.menuItemPhanQuyen.Size = new System.Drawing.Size(228, 24);
            this.menuItemPhanQuyen.Tag = "2";
            this.menuItemPhanQuyen.Text = "Tài khoản && Phân quyền";
            this.menuItemPhanQuyen.Click += new System.EventHandler(this.menuItemPhanQuyen_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(228, 24);
            this.menuItemLogout.Tag = "3";
            this.menuItemLogout.Text = "Đăng xuất";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(228, 24);
            this.menuItemExit.Tag = "4";
            this.menuItemExit.Text = "Thoát";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPayCart,
            this.menuItemInvoiceManager,
            this.menuItemCustomerManager,
            this.menuItemNewsManager});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(82, 23);
            this.danhMụcToolStripMenuItem.Tag = "";
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // menuItemPayCart
            // 
            this.menuItemPayCart.Name = "menuItemPayCart";
            this.menuItemPayCart.Size = new System.Drawing.Size(198, 24);
            this.menuItemPayCart.Tag = "5";
            this.menuItemPayCart.Text = "Thanh toán hóa đơn";
            this.menuItemPayCart.Click += new System.EventHandler(this.menuItemPayCart_Click);
            // 
            // menuItemInvoiceManager
            // 
            this.menuItemInvoiceManager.Name = "menuItemInvoiceManager";
            this.menuItemInvoiceManager.Size = new System.Drawing.Size(198, 24);
            this.menuItemInvoiceManager.Tag = "6";
            this.menuItemInvoiceManager.Text = "Quản lý hóa đơn";
            this.menuItemInvoiceManager.Click += new System.EventHandler(this.menuItemInvoiceManager_Click);
            // 
            // menuItemCustomerManager
            // 
            this.menuItemCustomerManager.Name = "menuItemCustomerManager";
            this.menuItemCustomerManager.Size = new System.Drawing.Size(198, 24);
            this.menuItemCustomerManager.Tag = "7";
            this.menuItemCustomerManager.Text = "Quản lý khách hàng";
            this.menuItemCustomerManager.Click += new System.EventHandler(this.menuItemCustomerManager_Click);
            // 
            // menuItemNewsManager
            // 
            this.menuItemNewsManager.Name = "menuItemNewsManager";
            this.menuItemNewsManager.Size = new System.Drawing.Size(198, 24);
            this.menuItemNewsManager.Tag = "8";
            this.menuItemNewsManager.Text = "Quản lý tin tức";
            this.menuItemNewsManager.Click += new System.EventHandler(this.menuItemNewsManager_Click);
            // 
            // nhậpXuấtKhoToolStripMenuItem
            // 
            this.nhậpXuấtKhoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProductManager,
            this.menuItemGoodsRevriveNote,
            this.menuItemSupplierManager});
            this.nhậpXuấtKhoToolStripMenuItem.Name = "nhậpXuấtKhoToolStripMenuItem";
            this.nhậpXuấtKhoToolStripMenuItem.Size = new System.Drawing.Size(82, 23);
            this.nhậpXuấtKhoToolStripMenuItem.Text = "Nhập kho";
            // 
            // menuItemProductManager
            // 
            this.menuItemProductManager.Name = "menuItemProductManager";
            this.menuItemProductManager.Size = new System.Drawing.Size(267, 24);
            this.menuItemProductManager.Tag = "9";
            this.menuItemProductManager.Text = "Quản lý sản phẩm";
            this.menuItemProductManager.Click += new System.EventHandler(this.menuItemProductManager_Click);
            // 
            // menuItemGoodsRevriveNote
            // 
            this.menuItemGoodsRevriveNote.Name = "menuItemGoodsRevriveNote";
            this.menuItemGoodsRevriveNote.Size = new System.Drawing.Size(267, 24);
            this.menuItemGoodsRevriveNote.Tag = "10";
            this.menuItemGoodsRevriveNote.Text = "Nhập hàng";
            this.menuItemGoodsRevriveNote.Click += new System.EventHandler(this.menuItemGoodsRevriveNote_Click);
            // 
            // menuItemSupplierManager
            // 
            this.menuItemSupplierManager.Name = "menuItemSupplierManager";
            this.menuItemSupplierManager.Size = new System.Drawing.Size(267, 24);
            this.menuItemSupplierManager.Tag = "11";
            this.menuItemSupplierManager.Text = "QL Nhà cung cấp && Danh mục";
            this.menuItemSupplierManager.Click += new System.EventHandler(this.menuItemSupplierManager_Click);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLSanPhamDienTu.Properties.Resources.network_mesh_wire_digital_technology_background_1017_27428;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1294, 671);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangePass;
        private System.Windows.Forms.ToolStripMenuItem menuItemPhanQuyen;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemPayCart;
        private System.Windows.Forms.ToolStripMenuItem menuItemInvoiceManager;
        private System.Windows.Forms.ToolStripMenuItem menuItemCustomerManager;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewsManager;
        private System.Windows.Forms.ToolStripMenuItem nhậpXuấtKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemProductManager;
        private System.Windows.Forms.ToolStripMenuItem menuItemGoodsRevriveNote;
        private System.Windows.Forms.ToolStripMenuItem menuItemSupplierManager;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
    }
}