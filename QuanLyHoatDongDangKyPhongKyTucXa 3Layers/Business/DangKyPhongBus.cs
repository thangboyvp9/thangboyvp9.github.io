using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business
{
    class DangKyPhongBus
    {
        HopDongDAO hopDongDAO = new HopDongDAO();
        PhongDAO phongDAO = new PhongDAO();
        Phong_SinhVienDAO p_svDAO = new Phong_SinhVienDAO();
        List<Phong_SinhVien> ds = new List<Phong_SinhVien>();
        public List<Phong_SinhVien> DocPhong_SinhVien()
        {
            return p_svDAO.DocPhong_SinhVien();
        }
        public Boolean KiemTraTonTai(string maSinhVien)
        {
            return p_svDAO.KiemTraTontai(maSinhVien);
        }
        public void ThemTTPhong_SinhVien(Phong_SinhVien psv)
        {
            p_svDAO.ThemTTPhong_SV(psv);
        }
        public void LayDSPhongConThieuSV(string gioi)
        {
            List<Phong>  l= phongDAO.LayDSPhongConTrongTheoTinhChatPhong(gioi);
            phongDAO.HienThiPhongConThieuSV(gioi);
            //Hiển thị các phòng này ra màn hình 
        }
        public void HienDSPhongSV()
        {
            p_svDAO.HienPhong_SinhVien();
        }
        public void DangKyPhong(string maSinhVien,string maPhong,DateTime ngayBatDau,DateTime ngayKetThuc)
        {
            Phong_SinhVien psv = new Phong_SinhVien();
            psv.MaPhong = maPhong;
            psv.MaSinhVien = maSinhVien;
            psv.NgayDangKy = ngayBatDau;
            psv.NgayKetThuc = ngayKetThuc;
            p_svDAO.ThemTTPhong_SV(psv);
            phongDAO.SuaSoLuong(maPhong);
        }
        public SinhVien LaySinhVien(String maSinhVien)
        {
            SinhVienDAO sinhVienDAO = new SinhVienDAO();
            return sinhVienDAO.LaySinhVienTheoMa(maSinhVien);
        }
        public void XoaSinhVienDaDangKy(string maSinhVien)
        {
            p_svDAO.XoaSinhVienDangKy(maSinhVien);
        }
        public void TimKiemSinhVienTheoMaPhong(string maPhong)
        {
            p_svDAO.TimKiemSinhVienTheoMaPhong(maPhong);
        }
        public void TimKiemPhongTheoMaSinhVien(string maSinhVien)
        {
            p_svDAO.TimKiemPhongTheoMaSinhVien(maSinhVien);
        }
        public void TongSoLuongSinhVienDangKy()
        {
             p_svDAO.TongSoLuongSinhVienDangKy();
        }
        public void ThongKeSoLuongPhongConThieuSV()
        {
            phongDAO.ThongKeSoPhongConThieuSinhVien();
        }
        public void TongSoLuongSinhVienDangKyTheoNgay(int ngay,int thang,int nam)
        {
            p_svDAO.TongSoLuongSinhVienDangKyTheoNgay(ngay,thang,nam);
        }
        public void TongSoLuongSinhVienDangKyTheoThang(int thang,int nam)
        {
            p_svDAO.TongSoLuongSinhVienDangKyTheoThang(thang,nam);
        }
        public void TongSoLuongSinhVienDangKyTheoNam(int nam)
        {
            p_svDAO.TongSoLuongSinhVienDangKyTheoNam(nam);
        }

    }

}
