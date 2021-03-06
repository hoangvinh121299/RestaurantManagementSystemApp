﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace RestaurantManagementSystem
{
    public partial class UC_warehouse : UserControl
    {
        public UC_warehouse()
        {
            InitializeComponent();
            nguyenLieu_BUS = new BUS_NguyenLieu();
            
        }
        public int idnguyenlieu;
        public string tennguyenlieu;
        
        public int soluongnguyenlieu;

        public bool isUsingInsert = false;
        public bool isUsinngUpdate = false;
        BUS_NguyenLieu nguyenLieu_BUS;
        public void showData()
        {
            dgv_danhSachMonAn.DataSource = nguyenLieu_BUS.Get().Tables[0];
        }
        private void UC_warehouse_Load(object sender, EventArgs e)
        {
            disableTextBox();
            hideSavenCancel();
            
            dgv_danhSachMonAn.AutoResizeColumns();
            showData();
        }
        public void loadForm()
        {
            disableTextBox();
            hideSavenCancel();
        }
        public void set_Variable()
        {
            tennguyenlieu = tenmonan_txtbox.Text;
            
            soluongnguyenlieu = int.Parse(soLuong_txtb.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(isUsingInsert)
            {
                try
                {
                    set_Variable();
                    nguyenLieu_BUS.Add(tennguyenlieu, soluongnguyenlieu);
                    showData();
                    return;
                }
                catch (Exception)
                {

                }
            }
            else if(isUsinngUpdate)
            {
                setVariable();
                nguyenLieu_BUS.Update(idnguyenlieu, tennguyenlieu, soluongnguyenlieu);
                showData();
                return;
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show
              ("Bạn có chắc chắn muốn xóa thông tin này, dữ liệu có thể sẽ không được khôi phục",
               "Thông báo",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {

                nguyenLieu_BUS.Delete(idnguyenlieu);
                showData();
            }
        }

        private void dgv_danhSachMonAn_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
                int numrow;
                numrow = e.RowIndex;
                if (numrow >= 0)
                {
                    idnguyenlieu = int.Parse(string.Copy(dgv_danhSachMonAn.Rows[numrow].Cells[0].Value.ToString()));
                    tenmonan_txtbox.Text = dgv_danhSachMonAn.Rows[numrow].Cells[1].Value.ToString();
                    soLuong_txtb.Text = dgv_danhSachMonAn.Rows[numrow].Cells[2].Value.ToString();
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            isUsingInsert = true;
            isUsinngUpdate = false;
            clearTextBox();
            enableTextBox();
            hideFunctionPanel();
            appearSavenCancel();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            isUsingInsert = false;
            isUsinngUpdate = true;
            enableTextBox();
            hideFunctionPanel();
            appearSavenCancel();
        }
        //Gán các giá trị trong textbox vào các biến
        public void setVariable()
        {
            tennguyenlieu = tenmonan_txtbox.Text;
            soluongnguyenlieu = int.Parse(soLuong_txtb.Text);
        }

        public void disableTextBox()
        {
            panel1.Enabled = false;
        }
        public void enableTextBox()
        {
            panel1.Enabled = true;
        }
        public void hideSavenCancel()
        {
            panel3.Visible = false;
        }
        public void appearSavenCancel()
        {
            panel3.Visible = true;
        }

        public void hideFunctionPanel()
        {
            func_panel.Visible = false;
        }
        public void appearFunctionPanel()
        {
            func_panel.Visible = true;
        }
        public void clearTextBox()
        {
            tenmonan_txtbox.Clear();
            soLuong_txtb.Clear();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy bỏ thao tác đang thực hiện", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                loadForm();
                appearFunctionPanel();
            }
        }

        private void func_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
