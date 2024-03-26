using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_tự_luận_2
{
    public partial class frm_QLNV : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_QLNV()
        {
            InitializeComponent();
        }

        private void frm_QLNV_Load(object sender, EventArgs e)
        {
            LoadNV();
            string sql = "select * from PHONGBAN";
            cb_TenPhongBan.DataSource = lopchung.LoadDL(sql);
            cb_TenPhongBan.ValueMember = "MAPB";
            cb_TenPhongBan.DisplayMember = "TENPB";
        }
        public void LoadNV()
        {
            string sql = "select * from NHANVIEN";
            dt_NhanVien.DataSource = lopchung.LoadDL(sql);
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into NHANVIEN values (MSNV,HOTEN,THAMNIEN,MAPB,NGAYVAOLAM) ('" + txt_MSNV.Text + "','" + txt_HoTen.Text + "','" + txt_ThamNien.Text + "','" + cb_TenPhongBan.SelectedValue + "',convert(datetime,'" + dp_NgayVaoLam.Text + "',103))";
                int kq = lopchung.ThemXoaSua(sql);
                if (kq >= 1) MessageBox.Show("Thêm thành công !");
                else MessageBox.Show("Thêm thất bại !");
                LoadNV();
            }
            catch
            {
                MessageBox.Show("Mã nhân viên đã tồn tại !");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "delete NHANVIEN where MSNV = '"+txt_MSNV.Text+"'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Xóa thành công !");
            else MessageBox.Show("Xóa thất bại !");
            LoadNV();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string sql = "update NHANVIEN set HOTEN = N'" + txt_HoTen.Text + "', THAMNIEN = '" + txt_ThamNien.Text + "',NGAYVAOLAM = convert(datetime,'" + dp_NgayVaoLam.Text + "',103)   ,MAPB = '" + cb_TenPhongBan.SelectedValue + "' where MSNV = '" + txt_MSNV.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Cập nhật thành công !");
            else MessageBox.Show("Cập nhật thất bại !");
            LoadNV();
        }

        private void btn_Dem_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from NHANVIEN";
            int sonv = (int)lopchung.LayGT(sql);
            txt_Dem.Text = sonv.ToString();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into NHANVIEN values (MSNV,HOTEN,THAMNIEN,MAPB,NGAYVAOLAM) ('" + txt_MSNV.Text + "','" + txt_HoTen.Text + "','" + txt_ThamNien.Text + "','" + cb_TenPhongBan.SelectedValue + "',convert(datetime,'" + dp_NgayVaoLam.Text + "',103))";
                int kq = lopchung.ThemXoaSua(sql);
                if (kq >= 1) MessageBox.Show("Thêm thành công !");
                else MessageBox.Show("Thêm thất bại !");
                LoadNV();
            }
            catch
            {
                MessageBox.Show("Mã nhân viên đã tồn tại !");
            }
        }

        private void dt_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_HoTen.Text = dt_NhanVien.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_MSNV.Text = dt_NhanVien.CurrentRow.Cells["MSNV"].Value.ToString();
            txt_ThamNien.Text = dt_NhanVien.CurrentRow.Cells["THAMNIEN"].Value.ToString();
            cb_TenPhongBan.SelectedValue = dt_NhanVien.CurrentRow.Cells["MAPB"].Value.ToString();
            dp_NgayVaoLam.Text = dt_NhanVien.CurrentRow.Cells["NGAYVAOLAM"].Value.ToString();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "delete NHANVIEN where MSNV = '" + txt_MSNV.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Xóa thành công !");
            else MessageBox.Show("Xóa thất bại !");
            LoadNV();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "update NHANVIEN set HOTEN = N'" + txt_HoTen.Text + "', THAMNIEN = '" + txt_ThamNien.Text + "',NGAYVAOLAM = convert(datetime,'" + dp_NgayVaoLam.Text + "',103)   ,MAPB = '" + cb_TenPhongBan.SelectedValue + "' where MSNV = '" + txt_MSNV.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Cập nhật thành công !");
            else MessageBox.Show("Cập nhật thất bại !");
            LoadNV();
        }
    }
}
