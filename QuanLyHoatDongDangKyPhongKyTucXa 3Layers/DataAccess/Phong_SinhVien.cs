using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class Phong_SinhVien
    {
        private string maSinhVien, maPhong;
        private DateTime ngayDangKy, ngayKetThuc;

        public Phong_SinhVien(string maSinhVien, string maPhong, DateTime ngayDangKy, DateTime ngayKetThuc)
        {
            this.maSinhVien = maSinhVien;
            this.maPhong = maPhong;
            this.ngayDangKy = ngayDangKy;
            this.ngayKetThuc = ngayKetThuc;
        }
        public Phong_SinhVien() { }
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public DateTime NgayDangKy { get => ngayDangKy; set => ngayDangKy = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }

        public bool isNumber(string tmp)
        {
            foreach (Char c in tmp)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool KiemTraKiTuDacBiet(string chuoi)
        {
            Boolean valid = true;
            for (int i = 0; i < chuoi.Length; i++)
            {
                var kytu = chuoi.Substring(i, 1);
                if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&" || kytu == "*")
                {
                    return false;
                }
            }
            return valid;
        }
        public string toString()
        {
            return  MaSinhVien + "#" + MaPhong + "#" + NgayDangKy + "#" + NgayKetThuc;
        }
        public void Hien(int stt)
        {
            Console.WriteLine("\t\t\t\t\t\t\t║ {0,-4}║ {1,-13}║      {2,-9}║    {3,-14}║      {4,-15}║", stt,MaSinhVien,MaPhong,NgayDangKy.ToString("dd/MM/yyyy"),NgayKetThuc.ToString("dd/MM/yyyy"));
        }
        public void Hien()
        {
            Console.WriteLine("\t\t\t\t\t\t\t║ {0,-13}║      {1,-9}║    {2,-14}║      {3,-15}║",MaSinhVien, MaPhong, NgayDangKy.ToString("dd/MM/yyyy"), NgayKetThuc.ToString("dd/MM/yyyy"));
        }
    }

}
