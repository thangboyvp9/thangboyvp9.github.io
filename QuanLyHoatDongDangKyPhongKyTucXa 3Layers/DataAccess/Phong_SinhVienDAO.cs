using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class Phong_SinhVienDAO
    {
        public List<Phong_SinhVien> dsPhong_SV = new List<Phong_SinhVien>();
        public List<Phong_SinhVien> DocPhong_SinhVien()
        {
            if (!File.Exists("Phong_SinhVien.txt"))
            {
                File.Create("Phong_SinhVien.txt");
            }
            else
            {
                string file = "Phong_SinhVien.txt";
                dsPhong_SV = new List<Phong_SinhVien>();
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] sc = lines[i].Split('#');
                    dsPhong_SV.Add(new Phong_SinhVien(sc[0], sc[1], DateTime.Parse(sc[2]), DateTime.Parse(sc[3])));
                }
            }
            return dsPhong_SV;
        }
        public void GhiPhong_SV(List<Phong_SinhVien> ds)
        {
            StreamWriter sr = new StreamWriter("Phong_SinhVien.txt", false);
            foreach (Phong_SinhVien p_sv in dsPhong_SV)
            {
                sr.WriteLine(p_sv.toString());
            }
            sr.Close();
        }
        public bool KiemTraTontai(string maSinhVien)
        {
            Boolean valid = false;
            foreach (Phong_SinhVien psv in dsPhong_SV)
            {
                if (maSinhVien == psv.MaSinhVien)
                    valid = true;
            }
            return valid;
        }
        public void ThemTTPhong_SV(Phong_SinhVien p_SV)
        {
            StreamWriter sw = new StreamWriter("Phong_Sinhvien.txt",true);
            string st = p_SV.toString();
            sw.WriteLine(st);
            sw.Close();
        }
        public void HienPhong_SinhVien()
        {
            for (int i = 0; i < dsPhong_SV.Count; i++)
            {
                dsPhong_SV[i].Hien(i + 1);
                Console.WriteLine("\t\t\t\t\t\t\t╠═════╬══════════════╬═══════════════╬══════════════════╬═════════════════════╣");
            }
        }
        public void XoaSinhVienDangKy(string maSinhVien)
        {
            dsPhong_SV = DocPhong_SinhVien();
            for(int i = 0; i < dsPhong_SV.Count; i++)
            {
                if(dsPhong_SV[i].MaSinhVien == maSinhVien)
                {
                    dsPhong_SV.RemoveAt(i);
                    break;
                }
            }
            GhiPhong_SV(dsPhong_SV);
            
        }
        public void TimKiemSinhVienTheoMaPhong(string maPhong)
        {
            bool flag = false;
            Console.WriteLine("\t\t\t\t\t\t\t╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t\t║                   Danh sách sinh viên đã đăng ký                      ║");
            Console.WriteLine("\t\t\t\t\t\t\t╠══════════════╦═══════════════╦══════════════════╦═════════════════════╣");
            Console.WriteLine("\t\t\t\t\t\t\t║ Mã sinh viên ║    Mã phòng   ║   Ngày bắt đầu   ║    Ngày kết thúc    ║");
            Console.WriteLine("\t\t\t\t\t\t\t╠══════════════╬═══════════════╬══════════════════╬═════════════════════╣");
            foreach (Phong_SinhVien psv in dsPhong_SV)
                if (psv.MaPhong.IndexOf(maPhong) >= 0)
                {
                    psv.Hien();
                    Console.WriteLine("\t\t\t\t\t\t\t╚══════════════╩═══════════════╩══════════════════╩═════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\t Không không tồn tại phòng có mã {0} trong danh sách !!!", maPhong);
        }
        public void TimKiemPhongTheoMaSinhVien(string maSinhVien)
        {
            bool flag = false;
            foreach (Phong_SinhVien psv in dsPhong_SV)
                if (psv.MaSinhVien.IndexOf(maSinhVien) >= 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t\t╔═══════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t\t\t║                   Danh sách sinh viên đã đăng ký                      ║");
                    Console.WriteLine("\t\t\t\t\t\t\t╠══════════════╦═══════════════╦══════════════════╦═════════════════════╣");
                    Console.WriteLine("\t\t\t\t\t\t\t║ Mã sinh viên ║    Mã phòng   ║   Ngày bắt đầu   ║    Ngày kết thúc    ║");
                    Console.WriteLine("\t\t\t\t\t\t\t╠══════════════╬═══════════════╬══════════════════╬═════════════════════╣");
                    psv.Hien();
                    Console.WriteLine("\t\t\t\t\t\t\t╚══════════════╩═══════════════╩══════════════════╩═════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\t Không không tồn tại mã sinh viên {0} trong danh sách !!!", maSinhVien);
        }
        public void TongSoLuongSinhVienDangKy()
        {
            dsPhong_SV = DocPhong_SinhVien();
            int tong = 0;
            for(int i = 0; i < dsPhong_SV.Count; i++)
            {
                tong = tong + 1;
            }
            Console.WriteLine(tong);
        }
        public void TongSoLuongSinhVienDangKyTheoNgay(int ngay,int thang,int nam)
        {
            dsPhong_SV = DocPhong_SinhVien();
            int tong = 0;
            foreach (Phong_SinhVien psv in dsPhong_SV)
            {
                if (psv.NgayDangKy.Day == ngay && psv.NgayDangKy.Month == thang && psv.NgayDangKy.Year == nam)
                {
                    tong = tong + 1;
                }
            }
            Console.WriteLine(tong);
        }
        public void TongSoLuongSinhVienDangKyTheoThang(int thang , int nam)
        {
            dsPhong_SV = DocPhong_SinhVien();
            int tong = 0;
            foreach (Phong_SinhVien psv in dsPhong_SV)
            {
                if (psv.NgayDangKy.Month == thang && psv.NgayDangKy.Year == nam)
                {
                    tong = tong + 1;
                }
            }
            Console.WriteLine(tong);
        }
        public void TongSoLuongSinhVienDangKyTheoNam(int nam)
        {
            dsPhong_SV = DocPhong_SinhVien();
            int tong = 0;
            foreach(Phong_SinhVien psv in dsPhong_SV)
            {
                if(psv.NgayDangKy.Year == nam)
                {
                    tong = tong + 1;
                }
            }
            Console.WriteLine(tong);
        }
    }
}
    