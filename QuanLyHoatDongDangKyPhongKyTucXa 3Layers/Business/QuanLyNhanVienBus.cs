using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business
{
    class QuanLyNhanVienBus
    {
        NhanVienDAO nhanvienDAO = new NhanVienDAO();
        List<NhanVien> dsNhanVien = new List<NhanVien>();
        public List<NhanVien> DocNhanVien()
        {
            return nhanvienDAO.DocNhanVien();
        }
        public Boolean KiemTraTrung(string maNhanVien)
        {
            return nhanvienDAO.KiemTraTrung(maNhanVien);
        }
        public Boolean KiemTraTonTai(string maNhanVien)
        {
            return nhanvienDAO.KiemTraTonTai(maNhanVien);
        }
        public void ThemNhanVien(List<NhanVien> ds)
        {
            nhanvienDAO.ThemNhanVien(ds);
        }
        public void CapNhatNhanVien(NhanVien nv)
        {
            nhanvienDAO.CapNhatNhanVien(nv);
        }
        public void XoaNhanVien(string maNhanVien)
        {
            nhanvienDAO.XoaNhanVien(maNhanVien);
        }
        public void HienNhanVien()
        {
            nhanvienDAO.HienNhanVien();
        }
        public void TimKiemNhanVienTheoMa(string MaNhanVien)
        {
            nhanvienDAO.TimKiemNhanVienTheoMa(MaNhanVien);
        }
        public void TimKiemNhanVienTheoTen(string HoTen)
        {
            nhanvienDAO.TimKiemNhanVienTheoTen(HoTen);
        }
        public void TimKiemNhanVienTheoChucVu(string chucVu)
        {
            nhanvienDAO.TimKiemNhanVienTheoChucVu(chucVu);
        }
        public void TimKiemNhanVienTheoQueQuan(string queQuan)
        {
            nhanvienDAO.TimKiemNhanVienTheoQueQuan(queQuan);
        }

    }
}
