using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using RestSharp;
using System.IO;
using System.Net;

namespace QLSanPhamDienTu
{
    public partial class frmNewsAndBannerManager : Form
    {
        public frmNewsAndBannerManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewsBUS.Instance.loadDataToComBoBox(cboKindOfNews);
            NewsBUS.Instance.loadDataToGirdView(gvNews, isChecked);

            // Banner
            BannerBUS.Instance.loadBannerToGirdView(gvBanner);
        }
        private bool isChecked = true;
        private bool isActiveBanenr = true;
        private string fileNameNews = string.Empty;
        private string fileNameBanner = string.Empty;
        private int NewsID = 0;
        private int BannerID = 0;
        public void resetData()
        {
            txtNewsName.Text = "";
            txtNewsDescrip.Text = "";
            dateTimePickerDate.Value = DateTime.Now.Date;
            txtNote.Text = "";
            txtImg.Text = "";
            fileNameNews = "";
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            resetData();
            btnInsert.Enabled = true;
            btnCapNhat.Enabled = false;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtNewsName.Text.Trim().Length > 0 && txtNewsDescrip.Text.Trim().Length > 0)
            {
                if (txtImg.Text.Trim().Length > 0)
                {
                    if (NewsBUS.Instance.insertNews(txtNewsName.Text, txtNewsDescrip.Text, txtImg.Text, isChecked, txtNote.Text, int.Parse(cboKindOfNews.SelectedValue.ToString())))
                    {
                        if (!isChecked)
                        {
                            XtraMessageBox.Show("Thêm thành công, Bạn cần kích hoạt cho tin này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm tin tức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        NewsBUS.Instance.loadDataByKindOfNewsID(gvNews, int.Parse(cboKindOfNews.SelectedValue.ToString()), isChecked);
                        if (!string.IsNullOrEmpty(fileNameNews))
                        {
                            try
                            {
                                using (var fileStream = File.Open(fileNameNews, FileMode.Open))
                                {
                                    var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/TinTuc");
                                    var request = new RestRequest();
                                    request.Method = Method.POST;
                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        await fileStream.CopyToAsync(memoryStream);
                                        request.AddFile("file", memoryStream.ToArray(), fileNameNews);
                                        request.AlwaysMultipartFormData = true;
                                        var response = await client.ExecuteAsync(request);
                                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                        {
                                            Console.WriteLine("Upload Images to server is Success!");
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("" + ex);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn ảnh cho tin này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmNewsAndBannerManager_Load(object sender, EventArgs e)
        {
            NewsBUS.Instance.loadDataToComBoBox(cboKindOfNews);
            NewsBUS.Instance.loadDataToGirdView(gvNews, isChecked);

            // Banner
            BannerBUS.Instance.loadBannerToGirdView(gvBanner);

        }

        private void ckbActive_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cboKindOfNews_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NewsBUS.Instance.loadDataByKindOfNewsID(gvNews, int.Parse(cboKindOfNews.SelectedValue.ToString()), true);
        }


        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtNewsName.Text.Trim().Length > 0 && txtNewsDescrip.Text.Trim().Length > 0)
            {
                if (txtImg.Text.Trim().Length > 0)
                {
                    if (NewsBUS.Instance.UpdateNews(txtNewsName.Text, txtNewsDescrip.Text, txtImg.Text, isChecked, txtNote.Text, int.Parse(cboKindOfNews.SelectedValue.ToString()), NewsID))
                    {
                        XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NewsBUS.Instance.loadDataByKindOfNewsID(gvNews, int.Parse(cboKindOfNews.SelectedValue.ToString()), isChecked);
                        if (!string.IsNullOrEmpty(fileNameNews))
                        {
                            try
                            {
                                using (var fileStream = File.Open(fileNameNews, FileMode.Open))
                                {
                                    var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/TinTuc");
                                    var request = new RestRequest();
                                    request.Method = Method.POST;
                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        await fileStream.CopyToAsync(memoryStream);
                                        request.AddFile("file", memoryStream.ToArray(), fileNameNews);
                                        request.AlwaysMultipartFormData = true;
                                        var response = await client.ExecuteAsync(request);
                                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                        {
                                            Console.WriteLine("Upload Images to server is Success!");
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("" + ex);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn ảnh cho tin này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                NewsID = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaTin).ToString());
                cboKindOfNews.SelectedValue = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnLoaiTin).ToString());
                txtNewsName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnTenTin).ToString();
                txtNewsDescrip.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnND).ToString();
                dateTimePickerDate.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnNgayDang).ToString();
                txtImg.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnHinh).ToString();
                ckbActive.Checked = bool.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnActive).ToString());
                btnInsert.Enabled = false;
                btnCapNhat.Enabled = true;
                try
                {
                    var request = WebRequest.Create("http://192.168.1.5:5000/TinTuc/" + txtImg.Text);
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            pictureBox1.Image = Bitmap.FromStream(stream);
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1")
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa tin tức này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NewsBUS.Instance.deleteNews(int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColumnMaTin).ToString())))
                    {
                        XtraMessageBox.Show("Tin này đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NewsBUS.Instance.loadDataByKindOfNewsID(gvNews, int.Parse(cboKindOfNews.SelectedValue.ToString()), true);
                    }

                }
            }
        }

        private void btnChoseImages_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] url = open.FileName.Trim().Split('\\');
                txtImg.Text = url.Last();
                pictureBox1.ImageLocation = open.FileName;
                fileNameNews = open.FileName;
            }
        }

        private void btnResetDataBanner_Click(object sender, EventArgs e)
        {
            txtFileBanner.Text = "";
            checkBox2.Checked = true;
            btnInssertBanner.Enabled = true;
            btnUpdateBanner.Enabled = false;
        }

        private async void btnInssertBanner_Click(object sender, EventArgs e)
        {
            if (txtFileBanner.Text.Trim().Length > 0)
            {
                if (BannerBUS.Instance.insertBanner(txtFileBanner.Text.Trim(), isActiveBanenr))
                {
                    XtraMessageBox.Show("Thêm Banner thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BannerBUS.Instance.loadBannerToGirdView(gvBanner);
                    try
                    {
                        using (var fileStream = File.Open(fileNameBanner, FileMode.Open))
                        {
                            var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/UploadBanner");
                            var request = new RestRequest();
                            request.Method = Method.POST;
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                await fileStream.CopyToAsync(memoryStream);
                                request.AddFile("file", memoryStream.ToArray(), fileNameBanner);
                                request.AlwaysMultipartFormData = true;
                                var response = await client.ExecuteAsync(request);
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    Console.WriteLine("Upload Images to server is Success!");
                                }
                            }

                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn hình ảnh cho banner này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnUpdateBanner_Click(object sender, EventArgs e)
        {
            if (txtFileBanner.Text.Trim().Length > 0)
            {
                if (BannerBUS.Instance.updateBanner(txtFileBanner.Text.Trim(), isActiveBanenr, BannerID))
                {
                    XtraMessageBox.Show("Cập nhật Banner thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BannerBUS.Instance.loadBannerToGirdView(gvBanner);
                    try
                    {
                        using (var fileStream = File.Open(fileNameBanner, FileMode.Open))
                        {
                            var client = new RestClient("http://192.168.1.5:5000/Home/Introduct/UploadBanner");
                            var request = new RestRequest();
                            request.Method = Method.POST;
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                await fileStream.CopyToAsync(memoryStream);
                                request.AddFile("file", memoryStream.ToArray(), fileNameBanner);
                                request.AlwaysMultipartFormData = true;
                                var response = await client.ExecuteAsync(request);
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    Console.WriteLine("Upload Images to server is Success!");
                                }
                            }

                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn hình ảnh cho banner này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                BannerID = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaBanner).ToString());
                txtFileBanner.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnFileBanner).ToString();
                checkBox2.Checked = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnKichHoatBanner).ToString());
                btnUpdateBanner.Enabled = true;
                btnInssertBanner.Enabled = false;
                try
                {
                    var request = WebRequest.Create("http://192.168.1.5:5000/Banner/" + txtFileBanner.Text);
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            pictureBox2.Image = Bitmap.FromStream(stream);
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn2")
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa banner này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BannerBUS.Instance.deleteBanner(BannerID))
                    {
                        XtraMessageBox.Show("Xóa banner quảng cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BannerBUS.Instance.loadBannerToGirdView(gvBanner);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] url = open.FileName.Trim().Split('\\');
                txtFileBanner.Text = url.Last();
                pictureBox2.ImageLocation = open.FileName;
                fileNameBanner = open.FileName;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                isActiveBanenr = true;
            }
            else
            {
                isActiveBanenr = false;
            }
        }
    }
}
