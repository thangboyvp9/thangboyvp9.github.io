using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class NhanVienDAO
    {
        public List<NhanVien> dsNhanVien = new List<NhanVien>();
        public List<NhanVien> DocNhanVien()
        {
            if (!File.Exists("NhanVien.txt"))
            {
                File.Create("NhanVien.txt");
            }
            else
            {
                string file = "NhanVien.txt";
                dsNhanVien = new List<NhanVien>();
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] sc = lines[i].Split('#');
                    dsNhanVien.Add(new NhanVien(sc[0], sc[1], sc[2], DateTime.Parse(sc[3]), sc[4], sc[5], sc[6], sc[7]));
                }
            }
            return dsNhanVien;
        }
        public NhanVien LayNhanVienTheoMa(string maNhanVien)
        {
            List<NhanVien> dsNhanVien = DocNhanVien();
            foreach (NhanVien nv in dsNhanVien)
            {
                if (nv.MaNhanVien == maNhanVien)
                {
                    return nv;
                }
            }
            return null;
        }
        public void GhiNhanVien(List<NhanVien> dsNhanVien)
        {
            StreamWriter sr = new StreamWriter("NhanVien.txt", false);
            foreach (NhanVien nv in dsNhanVien)
            {
                sr.WriteLine(nv.toString());
            }
            sr.Close();
        }
        public Boolean KiemTraTrung(string maNhanVien)
        {
            List<NhanVien> dsNhanVien = DocNhanVien();
            bool kt = false;
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                if (dsNhanVien[i].MaNhanVien.Equals(maNhanVien))
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
        public void ThemNhanVien(List<NhanVien> dsNhanVien)
        {
            StreamWriter w = new StreamWriter("NhanVien.txt", true);
            foreach (NhanVien nv in dsNhanVien)
            {
                string s = nv.toString();
                w.WriteLine(s);
            }
            w.Close();
        }

        public bool KiemTraTonTai(string maNhanVien)
        {
            Boolean valid = false;
            foreach (NhanVien nv in dsNhanVien)
            {
                if (nv.MaNhanVien==maNhanVien)
                    valid = true;
            }
            return valid;
        }
        public void HienNhanVien()
        {
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                dsNhanVien[i].Hien(i + 1);
                Console.WriteLine("\t╠═════╬════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            }
        }
        public void CapNhatNhanVien(NhanVien nv)
        {
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                if (dsNhanVien[i].MaNhanVien.Equals(nv.MaNhanVien))
                {
                    nv.Nhap1();
                    dsNhanVien[i] = nv;
                    break;
                }
            }
            GhiNhanVien(dsNhanVien);
        }
        public void XoaNhanVien(string maNhanVien)
        {
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                if (dsNhanVien[i].MaNhanVien == maNhanVien)
                {
                    dsNhanVien.RemoveAt(i);
                    break;
                }
            }
            GhiNhanVien(dsNhanVien);
        }
        public void TimKiemNhanVienTheoMa(string MaNhanVien)
        {
            bool flag = false;
            foreach (NhanVien nv in dsNhanVien)
                if (nv.MaNhanVien.IndexOf(MaNhanVien) >= 0)
                {
                    Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t║                                                                            Danh Sách Nhân Viên Vừa Tìm                                                                      ║");
                    Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
                    Console.WriteLine("\t║  Mã nhân viên  ║       Tên nhân viên     ║  Giới tính ║    Ngày sinh     ║    Chức vụ    ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
                    Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
                    nv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy nhân viên có mã {0} !!!", MaNhanVien);
        }
        public void TimKiemNhanVienTheoTen(string HoTen)
        {
            bool flag = false;
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                            Danh Sách Nhân Viên Vừa Tìm                                                                      ║");
            Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║  Mã nhân viên  ║       Tên nhân viên     ║  Giới tính ║    Ngày sinh     ║    Chức vụ    ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            foreach (NhanVien nv in dsNhanVien)
                if (nv.HoTen.IndexOf(HoTen) >= 0)
                {
                    nv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy nhân viên có mã {0} !!!", HoTen);
        }
        public void TimKiemNhanVienTheoChucVu(string chucVu)
        {
            bool flag = false;
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                            Danh Sách Nhân Viên Vừa Tìm                                                                      ║");
            Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║  Mã nhân viên  ║       Tên nhân viên     ║  Giới tính ║    Ngày sinh     ║    Chức vụ    ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            foreach (NhanVien nv in dsNhanVien)
                if (nv.ChucVu.IndexOf(chucVu) >= 0)
                {
                    nv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy nhân viên có mã {0} !!!", chucVu);
        }
        public void TimKiemNhanVienTheoQueQuan(string queQuan)
        {
            bool flag = false;
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                            Danh Sách Nhân Viên Vừa Tìm                                                                      ║");
            Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║  Mã nhân viên  ║       Tên nhân viên     ║  Giới tính ║    Ngày sinh     ║    Chức vụ    ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            foreach (NhanVien nv in dsNhanVien)
                if (nv.QueQuan.IndexOf(queQuan) >= 0)
                {
                    nv.Hien();
                    Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\tKhông tìm thấy nhân viên có mã {0} !!!", queQuan);
        }
    }
}
