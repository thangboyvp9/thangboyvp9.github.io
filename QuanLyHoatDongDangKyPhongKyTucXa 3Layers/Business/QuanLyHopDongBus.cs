using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business
{
    class QuanLyHopDongBus
    {
        HopDongDAO hopDongDAO = new HopDongDAO();
        List<HopDong> ds = new List<HopDong>();
        public List<HopDong> DocHopDong()
        {
            return hopDongDAO.DocHopDong();
        }
        public Boolean KiemTraTrung(string maHopDong)
        {
            return hopDongDAO.KiemTraTrung(maHopDong);
        }
        public Boolean KiemTraTrungSV(string maSinhVien)
        {
            return hopDongDAO.KiemTraTrungSV(maSinhVien);
        }
        public Boolean KiemTraTontai(string maHopDong)
        {
            return hopDongDAO.KiemTraTontai(maHopDong);
        }
        public void ThemHopDong(List<HopDong> ds)
        {
            hopDongDAO.ThemHopDong(ds);
        }
        public void CapNhatHopDong(HopDong h)
        {
            hopDongDAO.CapNhatHopDong(h);
        }
        public void XoaHopDong(string maHopDong)
        {
            hopDongDAO.XoaHopDong(maHopDong);
        }
        public void HienHopDong()
        {
            hopDongDAO.HienHopDong();
        }
        public void TimKiemHopDongTheoMa(string MaHopDong)
        {
            hopDongDAO.TimKiemTheoMaHopDong(MaHopDong);
        }
        public void TimKiemHopDongTheoMaPhong(string MaPhong)
        {
            hopDongDAO.TimKiemTheoMaPhong(MaPhong);
        }
        public void TimKiemHopDongTheoMaSinhVien(string MaSinhVien)
        {
            hopDongDAO.TimKiemTheoMaSinhVien(MaSinhVien);
        }
        public void TimKiemHopDongTheoMaNhanVien(string MaNhanVien)
        {
            hopDongDAO.TimKiemTheoMaNhanVien(MaNhanVien);
        }
    }
}
