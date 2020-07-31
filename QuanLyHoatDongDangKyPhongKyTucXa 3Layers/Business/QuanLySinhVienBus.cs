using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business
{
    class QuanLySinhVienBus
    {
        SinhVienDAO sinhvienDAO = new SinhVienDAO();
        List<SinhVien> dsSinhVien = new List<SinhVien>();
        public List<SinhVien> DocSinhVien()
        {
           return sinhvienDAO.DocSinhvien();
        }
        public Boolean KiemTraTrung(string maSinhVien)
        {
            return sinhvienDAO.KiemTraTrung(maSinhVien);
        }
        public Boolean KiemTraTonTai(string maSinhVien)
        {
            return sinhvienDAO.KiemTraTonTai(maSinhVien);
        }
        public void ThemSinhVien(List<SinhVien> ds)
        {
            sinhvienDAO.ThemSinhVien(ds);
        }
        public void HienSinhVien()
        {
            sinhvienDAO.HienSinhVien();
        }
        public void CapNhatSinhVien(SinhVien sv)
        {
            sinhvienDAO.CapNhatSinhVien(sv);
        }
        public void XoaSinhVien(string maSinhVien)
        {
            sinhvienDAO.XoaSinhVien(maSinhVien);
        }
        public void TimKiemSinhVienTheoMa(string MaSinhVien)
        {
            sinhvienDAO.TimKiemSinhVienTheoMa(MaSinhVien);
        }
        public void TimKiemSinhVienTheoTen(string HoTen)
        {
            sinhvienDAO.TimKiemSinhVienTheoTen(HoTen);
        }
        public void TimKiemSinhVienTheoNgaySinh(int dd,int MM,int yyyy)
        {
            sinhvienDAO.TimKiemSinhVienTheoNgaySinh(dd,MM,yyyy);
        }
        public void TimKiemSinhVienTheoLop(string lop)
        {
            sinhvienDAO.TimKiemSinhVienTheoLop(lop);
        }
        public void TimKiemSinhVienTheoQueQuan(string queQuan)
        {
            sinhvienDAO.TimKiemSinhVienTheoQueQuan(queQuan);
        }
    }
}
