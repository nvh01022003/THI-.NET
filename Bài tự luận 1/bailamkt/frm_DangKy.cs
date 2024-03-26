using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bailamkt
{
    public partial class frm_DangKy : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_DangKy()
        {
            InitializeComponent();
        }

        public void LoadKH()
        {
            string sql = "Select * from KHACHHANG";
            dt_KhachHang.DataSource = lopchung.LoadDL(sql);
        }
        private void frm_DangKy_Load(object sender, EventArgs e)
        {
            LoadKH();
            string sql = "select * from GIAOVIEN";
            cb_TenGV.DataSource = lopchung.LoadDL(sql);
            cb_TenGV.ValueMember = "MSGVHD";
            cb_TenGV.DisplayMember = "TENGVHD";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị không null và không trống
                if (string.IsNullOrEmpty(txt_MaKH.Text) || string.IsNullOrEmpty(txt_HoTen.Text) || string.IsNullOrEmpty(txt_DiaChi.Text) || string.IsNullOrEmpty(dp_NgaySinh.Text) || cb_TenGV.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo");
                    return;
                }
                string sql = "insert into KHACHHANG values ('" + txt_MaKH.Text + "','" + txt_DiaChi.Text + "','" + txt_HoTen.Text + "',convert(datetime,'" + dp_NgaySinh.Text + "',103),'" + cb_TenGV.SelectedValue + "')";
                int kq = lopchung.ThemXoaSua(sql);
                if (kq >= 1) MessageBox.Show("Them thanh cong !");
                else MessageBox.Show("Them that bai !");
                LoadKH();
            }
            catch
            {
                MessageBox.Show("Ma khach hang da ton tai !");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaKH.Text))
            {
                MessageBox.Show("Vui lòng điền vào mã số sinh viên cần sửa !");
                return;
            }   
            string sql = "Update KHACHHANG set MSKH = '"+txt_MaKH.Text+ "',DIACHI = N'" + txt_DiaChi .Text + "',HOTEN = N'" + txt_HoTen.Text + "',NGAYSINH = convert(datetime,'" + dp_NgaySinh.Text + "',103),MSGVHD = '" + cb_TenGV.SelectedValue + "' where MSKH = '"+txt_MaKH.Text+"'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Sua thanh cong !");
            else MessageBox.Show("Sua that bai !");
            LoadKH();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "delete KHACHHANG where MSKH = '"+txt_MaKH.Text+"'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Xoa thanh cong !");
            else MessageBox.Show("Xoa that bai !");
            LoadKH();
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dt_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaKH.Text = dt_KhachHang.CurrentRow.Cells["MSKH"].Value.ToString();
            txt_HoTen.Text = dt_KhachHang.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_DiaChi.Text = dt_KhachHang.CurrentRow.Cells["DIACHI"].Value.ToString();
            dp_NgaySinh.Text = dt_KhachHang.CurrentRow.Cells["NGAYSINH"].Value.ToString();
            cb_TenGV.SelectedValue = dt_KhachHang.CurrentRow.Cells["MSGVHD"].Value.ToString();
        }

        
    }
}
