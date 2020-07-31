using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class SinhVienDAO
    {
        public List<SinhVien> dsSinhVien = new List<SinhVien>();
        public List<SinhVien> DocSinhvien()
        {
            if (!File.Exists("SinhVien.txt"))
            {
                File.Create("SinhVien.txt");
            }
            else
            {
                string file = "SinhVien.txt";
                dsSinhVien = new List<SinhVien>();
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] sc = lines[i].Split('#');
                    dsSinhVien.Add(new SinhVien(sc[0], sc[1], sc[2], DateTime.Parse(sc[3]), sc[4], sc[5], sc[6], sc[7]));
                }
            }
            return dsSinhVien;
        }
        public SinhVien LaySinhVienTheoMa(string maSinhVien)
        {
            List<SinhVien> dsSinhVien = DocSinhvien();
            foreach (SinhVien sv in dsSinhVien)
            {
                if (sv.MaSinhVien== maSinhVien)
                {
                    return sv;
                }
            }
            return null;
        }
        public void GhiSinhVien(List<SinhVien> dsSinhVien)
        {
            StreamWriter sr = new StreamWriter("SinhVien.txt", false);
            foreach (SinhVien x in dsSinhVien)
            {
                sr.WriteLine(x.toString());
            }
            sr.Close();
        }
        public Boolean KiemTraTrung(string MaSinhVien)
        {
            List<SinhVien> dsSinhVien = DocSinhvien();
            bool kt = false;
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                if (dsSinhVien[i].MaSinhVien.Equals(MaSinhVien))
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
        public void ThemSinhVien(List<SinhVien> ds)
        {
            StreamWriter w = new StreamWriter("SinhVien.txt", true);
            foreach (SinhVien sv in ds)
            {
                string s = sv.toString();
                w.WriteLine(s);
            }
            w.Close();
        }

        public bool KiemTraTonTai(string maSinhVien)
        {
            Boolean valid = false;
            foreach (SinhVien sv in dsSinhVien)
            {
                if (sv.MaSinhVien == maSinhVien)
                    valid = true;
            }
            return valid;
        }
        public void HienSinhVien()
        {
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                dsSinhVien[i].Hien(i + 1);
                Console.WriteLine("\t╠═════╬════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            }
        }
        public void CapNhatSinhVien(SinhVien sv)
        {
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                if (dsSinhVien[i].MaSinhVien.Equals(sv.MaSinhVien))
                {
                    sv.Nhap1();
                    dsSinhVien[i] = sv;
                    break;
                }
            }
            GhiSinhVien(dsSinhVien);
        }
        public void XoaSinhVien(string maSinhVien)
        {
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                if (dsSinhVien[i].MaSinhVien == maSinhVien)
                {
                    dsSinhVien.RemoveAt(i);
                    break;
                }
            }
            GhiSinhVien(dsSinhVien);
        }
        public SinhVien KTNgaySinh(int a, int b, int c)
        {
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                if (dsSinhVien[i].NgaySinh.Day == a && dsSinhVien[i].NgaySinh.Month == b && dsSinhVien[i].NgaySinh.Year == c)
                {
                    return dsSinhVien[i];
                }
            }
            return null;
        }
        public void TimKiemSinhVienTheoMa(string maSinhVien)
        {
            bool flag = false;
            foreach (SinhVien sv in dsSinhVien)
                if (sv.MaSinhVien.IndexOf(maSinhVien) >= 0)
                {
                    Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t║                                                                          Danh Sách Sinh Viên Vừa Tìm                                                                        ║");
                    Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
                    Console.WriteLine("\t║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
                    Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
                    sv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy sinh viên có mã {0} !!!", maSinhVien);
        }
        public void TimKiemSinhVienTheoTen(string hoTen)
        {
            bool flag = false;
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                          Danh Sách Sinh Viên Vừa Tìm                                                                        ║");
            Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            foreach (SinhVien sv in dsSinhVien)
                if (sv.HoTen.IndexOf(hoTen) >= 0)
                {
                    sv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy sinh viên có mã {0} !!!", hoTen);
        }
        public void TimKiemSinhVienTheoNgaySinh(int dd, int mm, int yyyy)
        {
            SinhVien s = new SinhVien();
            bool flag = false;
            s.NgaySinh = new DateTime(day: dd, month: mm, year: yyyy);
            SinhVien ktt = KTNgaySinh(s.NgaySinh.Day, s.NgaySinh.Month, s.NgaySinh.Year);
            if (ktt != null)
            {
                Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t║                                                                          Danh Sách Sinh Viên Vừa Tìm                                                                        ║");
                Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
                Console.WriteLine("\t║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
                Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
                foreach (SinhVien sv in dsSinhVien)
                {
                    if (sv.NgaySinh.Day == dd && sv.NgaySinh.Month == mm && sv.NgaySinh.Year == yyyy)
                    {
                        
                        sv.Hien();
                        Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                        flag = true;
                    }
                }
            }
            if (!flag)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm nhân viên có ngày sinh vào {0}/{1}/{2} !!!", s.NgaySinh.Day, s.NgaySinh.Month, s.NgaySinh.Year);
        }
        public void TimKiemSinhVienTheoLop(string lop)
        {
            bool flag = false;
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                          Danh Sách Sinh Viên Vừa Tìm                                                                        ║");
            Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            foreach (SinhVien sv in dsSinhVien)
                if (sv.Lop.IndexOf(lop) >= 0)
                {
                    sv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy sinh viên có lớp {0} !!!", lop);
        }
        public void TimKiemSinhVienTheoQueQuan(string queQuan)
        {
            bool flag = false;
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                          Danh Sách Sinh Viên Vừa Tìm                                                                        ║");
            Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            foreach (SinhVien sv in dsSinhVien)
                if (sv.QueQuan.IndexOf(queQuan) >= 0)
                {
                    sv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy sinh viên có quê quán: {0} !!!", queQuan);
        }
    }
}
