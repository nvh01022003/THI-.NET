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
    public partial class frm_DangNhap : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from TAIKHOAN where TENDANGNHAP = '"+txt_TenDangNhap.Text+"' AND MATKHAU = '"+txt_MatKhau.Text+"'";
            int kq = (int)lopchung.LayGT(sql);
            if(kq >= 1)
            {
                MessageBox.Show("Đăng nhập thành công !");
                frm_QLNV n = new frm_QLNV();
                n.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai, xin mời nhập lại !");
            }
        }
    }
}
