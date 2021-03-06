﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
   public class DAL_danhSachMonAn
    {
        public DataSet GetData()
        {
            DataSet data = new DataSet();
            string Select_all = "select * from monAn";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(Select_all, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public DataSet GetDanhmuc()
        {
            DataSet data = new DataSet();
            string Select_all = "select distinct danhmuc from monAn";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(Select_all, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public void Delete(int idmonan)
        {
            string Delete_from = "DELETE FROM monAn WHERE IDmonAn=@idmonan";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                try
                {
                    connection.Open();
                    SqlCommand cmdInsert = new SqlCommand(Delete_from, connection);
                    cmdInsert.Parameters.Add("@idmonan", SqlDbType.Int).Value = idmonan;
                    cmdInsert.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Xoá thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xoá thông tin , xin vui lòng thử lại!", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        public void InsertData(string tenmonan, float giamoan, int soluong, int iddanhmuc)
        {
            string Insert_into = "INSERT INTO monAn VALUES (@tenmonan,@giamonan,@soluongmonan,@iddanhmuc)";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdSetDateFormat = new SqlCommand("SET DATEFORMAT DMY", connection);
                    cmdSetDateFormat.ExecuteNonQuery();
                    SqlCommand cmdInsert = new SqlCommand(Insert_into, connection);
                    cmdInsert.Parameters.Add("@tenmonan", SqlDbType.NVarChar).Value = tenmonan;
                    cmdInsert.Parameters.Add("@giamonan", SqlDbType.Float).Value = giamoan;
                    cmdInsert.Parameters.Add("@soluongmonan", SqlDbType.Int).Value = soluong;
                    cmdInsert.Parameters.Add("@iddanhmuc", SqlDbType.NVarChar).Value = iddanhmuc;
                    cmdInsert.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Thêm dữ liệu thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm thông tin cơ sở vật chất, xin vui lòng thử lại!", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateData(int idmonan, string tenmonan, float giamoan, int soluong, int iddanhmuc)
        {
            string Update_set = "UPDATE monAn SET tenMonAn=@tenmonan," +
                "giaMonAn=@giamonan," +
                "soLuongMonAn=@soluongmonan," +
                "IDdanhmuc=@IDdanhmuc WHERE IDmonAn=@idmonan";
            
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdSetDateFormat = new SqlCommand("SET DATEFORMAT DMY", connection);
                    cmdSetDateFormat.ExecuteNonQuery();
                    SqlCommand cmdInsert = new SqlCommand(Update_set, connection);
                    cmdInsert.Parameters.Add("@idmonan", SqlDbType.Int).Value = idmonan;
                    cmdInsert.Parameters.Add("@tenmonan", SqlDbType.NVarChar).Value = tenmonan;
                    cmdInsert.Parameters.Add("@giamonan", SqlDbType.Float).Value = giamoan;
                    cmdInsert.Parameters.Add("@soluongmonan", SqlDbType.Int).Value = soluong;
                    cmdInsert.Parameters.Add("@iddanhmuc", SqlDbType.NVarChar).Value = iddanhmuc;
                    cmdInsert.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Sửa dữ liệu thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thay đổi thông tin , xin vui lòng thử lại!", "Đã có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
