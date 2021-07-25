
namespace QLSanPhamDienTu
{
    partial class frmInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridControlHD = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnMaHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnmaND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGIamGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gridContrrolCTHD = new DevExpress.XtraGrid.GridControl();
            this.gridViewHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXoaPN = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dateTimePickerNgayDat = new System.Windows.Forms.DateTimePicker();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContrrolCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaPN)).BeginInit();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1294, 58);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1275, 6);
            this.label3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "QUẢN LÝ THÔNG TIN CHI TIẾT HÓA ĐƠN";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1294, 603);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1294, 603);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gridControlHD);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 297);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1294, 306);
            this.panel5.TabIndex = 1;
            // 
            // gridControlHD
            // 
            this.gridControlHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlHD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlHD.Location = new System.Drawing.Point(0, 0);
            this.gridControlHD.MainView = this.gridView2;
            this.gridControlHD.Name = "gridControlHD";
            this.gridControlHD.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControlHD.Size = new System.Drawing.Size(1294, 306);
            this.gridControlHD.TabIndex = 2;
            this.gridControlHD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.VertLine.Options.UseFont = true;
            this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumnMaHD,
            this.gridColumnTinhTrang,
            this.gridColumnNgayLap,
            this.gridColumnTenKH,
            this.gridColumnSDT,
            this.gridColumnmaND,
            this.gridColumnGIamGia,
            this.gridColumnTongTien});
            this.gridView2.DetailHeight = 333;
            this.gridView2.GridControl = this.gridControlHD;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.FindNullPrompt = "Nhập thông tin cần tìm kiếm";
            this.gridView2.OptionsHint.ShowCellHints = false;
            this.gridView2.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView2_RowClick);
            this.gridView2.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView2_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn1.MinWidth = 18;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 44;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumnMaHD
            // 
            this.gridColumnMaHD.Caption = "Mã HĐ";
            this.gridColumnMaHD.FieldName = "MaHoaDon";
            this.gridColumnMaHD.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumnMaHD.MinWidth = 18;
            this.gridColumnMaHD.Name = "gridColumnMaHD";
            this.gridColumnMaHD.Visible = true;
            this.gridColumnMaHD.VisibleIndex = 1;
            this.gridColumnMaHD.Width = 68;
            // 
            // gridColumnTinhTrang
            // 
            this.gridColumnTinhTrang.Caption = "Tình trạng";
            this.gridColumnTinhTrang.FieldName = "TinhTrang";
            this.gridColumnTinhTrang.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumnTinhTrang.MinWidth = 18;
            this.gridColumnTinhTrang.Name = "gridColumnTinhTrang";
            this.gridColumnTinhTrang.Visible = true;
            this.gridColumnTinhTrang.VisibleIndex = 2;
            this.gridColumnTinhTrang.Width = 70;
            // 
            // gridColumnNgayLap
            // 
            this.gridColumnNgayLap.Caption = "Ngày lập";
            this.gridColumnNgayLap.FieldName = "NgayBan";
            this.gridColumnNgayLap.MinWidth = 18;
            this.gridColumnNgayLap.Name = "gridColumnNgayLap";
            this.gridColumnNgayLap.Visible = true;
            this.gridColumnNgayLap.VisibleIndex = 3;
            this.gridColumnNgayLap.Width = 125;
            // 
            // gridColumnTenKH
            // 
            this.gridColumnTenKH.Caption = "Tên khách hàng";
            this.gridColumnTenKH.FieldName = "TenKhachHang";
            this.gridColumnTenKH.MinWidth = 18;
            this.gridColumnTenKH.Name = "gridColumnTenKH";
            this.gridColumnTenKH.Visible = true;
            this.gridColumnTenKH.VisibleIndex = 4;
            this.gridColumnTenKH.Width = 150;
            // 
            // gridColumnSDT
            // 
            this.gridColumnSDT.Caption = "SĐT khách hàng";
            this.gridColumnSDT.FieldName = "SoDienThoai";
            this.gridColumnSDT.MinWidth = 18;
            this.gridColumnSDT.Name = "gridColumnSDT";
            this.gridColumnSDT.Visible = true;
            this.gridColumnSDT.VisibleIndex = 5;
            this.gridColumnSDT.Width = 158;
            // 
            // gridColumnmaND
            // 
            this.gridColumnmaND.Caption = "Mã ND";
            this.gridColumnmaND.FieldName = "MaNguoiDung";
            this.gridColumnmaND.MinWidth = 18;
            this.gridColumnmaND.Name = "gridColumnmaND";
            this.gridColumnmaND.Visible = true;
            this.gridColumnmaND.VisibleIndex = 6;
            this.gridColumnmaND.Width = 61;
            // 
            // gridColumnGIamGia
            // 
            this.gridColumnGIamGia.Caption = "Giảm giá";
            this.gridColumnGIamGia.DisplayFormat.FormatString = "{0:0,0} vnđ";
            this.gridColumnGIamGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnGIamGia.FieldName = "GiamGia";
            this.gridColumnGIamGia.MinWidth = 18;
            this.gridColumnGIamGia.Name = "gridColumnGIamGia";
            this.gridColumnGIamGia.Visible = true;
            this.gridColumnGIamGia.VisibleIndex = 7;
            this.gridColumnGIamGia.Width = 103;
            // 
            // gridColumnTongTien
            // 
            this.gridColumnTongTien.Caption = "Tổng tiền";
            this.gridColumnTongTien.DisplayFormat.FormatString = "{0:0,0} vnđ";
            this.gridColumnTongTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTongTien.FieldName = "TongTien";
            this.gridColumnTongTien.MinWidth = 18;
            this.gridColumnTongTien.Name = "gridColumnTongTien";
            this.gridColumnTongTien.Visible = true;
            this.gridColumnTongTien.VisibleIndex = 8;
            this.gridColumnTongTien.Width = 124;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gridContrrolCTHD);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1294, 297);
            this.panel4.TabIndex = 0;
            // 
            // gridContrrolCTHD
            // 
            this.gridContrrolCTHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContrrolCTHD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContrrolCTHD.Location = new System.Drawing.Point(437, 0);
            this.gridContrrolCTHD.MainView = this.gridViewHD;
            this.gridContrrolCTHD.Name = "gridContrrolCTHD";
            this.gridContrrolCTHD.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnXoaPN});
            this.gridContrrolCTHD.Size = new System.Drawing.Size(857, 297);
            this.gridContrrolCTHD.TabIndex = 28;
            this.gridContrrolCTHD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHD});
            // 
            // gridViewHD
            // 
            this.gridViewHD.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridViewHD.Appearance.FilterPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.FilterPanel.Options.UseFont = true;
            this.gridViewHD.Appearance.FocusedCell.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewHD.Appearance.FocusedRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewHD.Appearance.GroupPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.GroupPanel.Options.UseFont = true;
            this.gridViewHD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewHD.Appearance.OddRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.OddRow.Options.UseFont = true;
            this.gridViewHD.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.Row.Options.UseFont = true;
            this.gridViewHD.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewHD.Appearance.VertLine.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.VertLine.Options.UseFont = true;
            this.gridViewHD.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewHD.Appearance.ViewCaption.Options.UseFont = true;
            this.gridViewHD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gridViewHD.DetailHeight = 333;
            this.gridViewHD.GridControl = this.gridContrrolCTHD;
            this.gridViewHD.Name = "gridViewHD";
            this.gridViewHD.OptionsBehavior.Editable = false;
            this.gridViewHD.OptionsFind.AlwaysVisible = true;
            this.gridViewHD.OptionsFind.FindNullPrompt = "Nhập thông tin cần tìm kiếm";
            this.gridViewHD.OptionsHint.ShowCellHints = false;
            this.gridViewHD.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã sản phẩm";
            this.gridColumn4.FieldName = "MasanPham";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên sản phẩm";
            this.gridColumn2.FieldName = "TenSanPham";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 178;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số lượng";
            this.gridColumn3.FieldName = "SoLuong";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 84;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Đơn giá";
            this.gridColumn14.FieldName = "DonGia";
            this.gridColumn14.MinWidth = 22;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 133;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Giảm giá";
            this.gridColumn15.FieldName = "GiamGia";
            this.gridColumn15.MinWidth = 22;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            this.gridColumn15.Width = 133;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Thành tiền";
            this.gridColumn16.FieldName = "ThanhTien";
            this.gridColumn16.MinWidth = 22;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            this.gridColumn16.Width = 133;
            // 
            // btnXoaPN
            // 
            this.btnXoaPN.AutoHeight = false;
            this.btnXoaPN.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.btnXoaPN.Name = "btnXoaPN";
            this.btnXoaPN.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(437, 297);
            this.panel6.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.dateTimePickerNgayDat);
            this.groupBox1.Controls.Add(this.checkBox);
            this.groupBox1.Controls.Add(this.txtGiamGia);
            this.groupBox1.Controls.Add(this.txtThanhTien);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 297);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(24, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 21);
            this.label16.TabIndex = 59;
            this.label16.Text = "Tổng cộng:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 21);
            this.label12.TabIndex = 58;
            this.label12.Text = "Giảm giá:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 21);
            this.label6.TabIndex = 55;
            this.label6.Text = "Số điện thoại:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 21);
            this.label7.TabIndex = 54;
            this.label7.Text = "Ngày đặt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "Tên khách hàng:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 257);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(431, 37);
            this.toolStrip1.TabIndex = 53;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::QLSanPhamDienTu.Properties.Resources.z2525335187690_01de74b6b6234fce8c62460120cb2841_removebg_preview;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(114, 34);
            this.toolStripButton2.Text = "In hóa đơn";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // dateTimePickerNgayDat
            // 
            this.dateTimePickerNgayDat.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgayDat.Location = new System.Drawing.Point(162, 104);
            this.dateTimePickerNgayDat.Name = "dateTimePickerNgayDat";
            this.dateTimePickerNgayDat.Size = new System.Drawing.Size(235, 24);
            this.dateTimePickerNgayDat.TabIndex = 52;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(162, 202);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(89, 22);
            this.checkBox.TabIndex = 50;
            this.checkBox.Text = "Khả dụng";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(162, 137);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(235, 24);
            this.txtGiamGia.TabIndex = 42;
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(162, 172);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(235, 24);
            this.txtThanhTien.TabIndex = 43;
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(162, 71);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(235, 24);
            this.txtSDT.TabIndex = 41;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(162, 37);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(235, 24);
            this.txtTenKH.TabIndex = 39;
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1294, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoice";
            this.Text = "Quản lý thông tin hóa đơn";
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContrrolCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaPN)).EndInit();
            this.panel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayDat;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenKH;
        private DevExpress.XtraGrid.GridControl gridContrrolCTHD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnXoaPN;
        private DevExpress.XtraGrid.GridControl gridControlHD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMaHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTenKH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSDT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnmaND;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGIamGia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTongTien;
    }
}