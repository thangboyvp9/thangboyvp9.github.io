using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business
{
    class QuanLyPhongBus
    {
        PhongDAO phongDAO = new PhongDAO();
        List<Phong> dsPhong = new List<Phong>();
        public List<Phong> DocPhong()
        {
           return phongDAO.DocPhong();
        }
        public bool KiemTraTrung(string maPhong)
        {
            return phongDAO.KiemTraTrung(maPhong);
        }
        public bool KiemTraTonTai(string maPhong)
        {
            return phongDAO.KiemTraTonTai(maPhong);
        }
        public void HienPhong()
        {
            phongDAO.HienPhong();
        }
        public void ThemPhong(List<Phong> dsPhong)
        {
            phongDAO.ThemPhong(dsPhong);
        }
        public void CapNhatPhong(Phong p)
        {
            phongDAO.CapNhatPhong(p);
        }
        public void CapNhatTinhTrangPhong(string maPhong,string tinhTrang)
        {
            phongDAO.CapNhatTinhTrang(maPhong,tinhTrang);
        }
        public void CapNhatTrangVatTu(string maPhong, string trangVatTu)
        {
            phongDAO.CapNhatTrangVatTu(maPhong, trangVatTu);
        }
        public void CapNhatTinhChatPhong(string maPhong, string tinhChatPhong)
        {
            phongDAO.CapNhatTinhChatPhong(maPhong, tinhChatPhong);
        }
        public void CapNhatSoLuongSinhVienHienCo(string maPhong, int soLuongSinhVienHienCo)
        {
            phongDAO.CapNhatSoLuongSinhVienHienCo(maPhong, soLuongSinhVienHienCo);
        }
        public void CapNhatSucChua(string maPhong,int sucChua)
        {
            phongDAO.CapNhatSucChua(maPhong, sucChua);
        }
        public void XoaPhong(string maPhong)
        {
            phongDAO.XoaPhong(maPhong);
        }
        public void TimKiemTheoMaPhong(string MaPhong)
        {
            phongDAO.TimKiemTheoMaPhong(MaPhong);
        }
        public void TimKiemTheoTenPhong(string TenPhong)
        {
            phongDAO.TimKiemTheoTenPhong(TenPhong);
        }
        public void TimKiemTheoTinhTrangPhong(string TinhTrang)
        {
            phongDAO.TimKiemTheoTinhTrangPhong(TinhTrang);
        }
        public void TimKiemTheoTinhChatPhong(string TinhChatPhong)
        {
            phongDAO.TimKiemTheoTinhChatPhong(TinhChatPhong);
        }
    }
}
