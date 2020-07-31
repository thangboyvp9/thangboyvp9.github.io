using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class HopDongDAO
    {
        public List<HopDong> dsHopDong = new List<HopDong>();
        public List<HopDong> DocHopDong()
        {
            if (!File.Exists("HopDong.txt")) 
            {
                File.Create("HopDong.txt");
            }
            else
            {
                string file = "HopDong.txt";
                dsHopDong = new List<HopDong>();
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] sc = lines[i].Split('#');
                    dsHopDong.Add(new HopDong(sc[0],sc[1],sc[2],sc[3],DateTime.Parse(sc[4]),DateTime.Parse(sc[5]),DateTime.Parse(sc[6])));
                }
            }
            return dsHopDong;
        }
        public void GhiHopDong(List<HopDong> dsHopDong)
        {
            StreamWriter sr = new StreamWriter("HopDong.txt",false);
            foreach (HopDong x in dsHopDong)
            {
                sr.WriteLine(x.toString());
            }
            sr.Close();
        }
        public Boolean KiemTraTrung(String maHopDong)
        {
            List<HopDong> dsHopDong = DocHopDong();
            bool kt = false;
            for (int i = 0; i < dsHopDong.Count; i++)
            {
                if (dsHopDong[i].MaHopDong.Equals(maHopDong))
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
        public Boolean KiemTraTrungSV(String maSinhVien)
        {
            List<HopDong> ds = DocHopDong();
            bool kt = false;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSinhVien.Equals(maSinhVien))
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
        public void ThemHopDong(List<HopDong> dsHopDong)
        {
            StreamWriter w = new StreamWriter("HopDong.txt",true);
            foreach (HopDong h in dsHopDong)
            {
                string s = h.toString();
                w.WriteLine(s);
            }
            w.Close();
        }
        public bool KiemTraTontai(string maHopDong)
        {
            Boolean valid = false;
            foreach (HopDong hd in dsHopDong)
            {
                if (maHopDong == hd.MaHopDong)
                    valid = true;
            }
            return valid;
        }
        public void HienHopDong()
        {
            for (int i = 0; i < dsHopDong.Count; i++)
            {
                dsHopDong[i].Hien(i + 1);
                Console.WriteLine("\t\t\t╠═════╬═════════════╬════════════════╬═══════════════╬═════════════════╬═════════════════════╬════════════════════╬════════════════════╣");
            }
        }
        public void CapNhatHopDong(HopDong h)
        {
            bool ok = false;
            for (int i = 0; i < dsHopDong.Count; i++)
            {
                if (dsHopDong[i].MaHopDong.Equals(h.MaHopDong))
                {
                    ok = true;
                    Console.WriteLine("\t\t\t\t\t\t Nhập thông tin hợp đồng cần cập nhật");
                    do
                    {
                        try
                        {
                            do
                            {
                                Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                                h.MaSinhVien = Console.ReadLine();
                                if (!(h.MaSinhVien.Length == 8))
                                {
                                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự.......!!!");
                                }
                            } while (!(h.MaSinhVien.Length == 8));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Write("\t\t\t\t\t\t");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự.......!!!");
                        }
                    } while (true);
                    h.Nhap1();
                    dsHopDong[i] = h;
                    Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công hợp đồng có mã {0} ", h.MaHopDong);
                    GhiHopDong(dsHopDong);
                    break;
                }
            }
            if (!ok)
            {
                Console.WriteLine("\t\t\t\t\t\t Không có mã hợp đồng {0} cần cập nhật", h.MaHopDong);
            }
        }
        public void XoaHopDong(string maHopDong)
        {
            for (int i = 0; i < dsHopDong.Count; i++)
            {
                if (dsHopDong[i].MaHopDong== maHopDong)
                {
                    dsHopDong.RemoveAt(i);
                    break;
                }
            }
            GhiHopDong(dsHopDong);
        }
        public void TimKiemTheoMaHopDong(string maHopDong)
        {
            bool flag = false;
            foreach (HopDong h in dsHopDong)
                if (h.MaHopDong.IndexOf(maHopDong) >= 0)
                {
                    Console.WriteLine("\t\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t║                                               Thông tin hợp đồng vừa tìm                                                          ║");
                    Console.WriteLine("\t\t\t╠═════════════╦════════════════╦═══════════════╦═════════════════════╦═══════════════════╦═════════════════════╦════════════════════╣");
                    Console.WriteLine("\t\t\t║ Mã hợp đồng ║  Mã sinh viên  ║    Mã phòng   ║     Mã nhân viên    ║     Ngày lập      ║    Ngày bắt đầu     ║    Ngày kết thúc   ║");
                    Console.WriteLine("\t\t\t╠═════════════╬════════════════╬═══════════════╬═════════════════════╬═══════════════════╬═════════════════════╬════════════════════╣");
                    h.Hien();
                    Console.WriteLine("\t\t\t╚═════════════╩════════════════╩═══════════════╩═════════════════════╩═══════════════════╩═════════════════════╩════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\t Không tìm thấy hợp đồng có mã {0} !!!",maHopDong);
        }
        public void TimKiemTheoMaPhong(string maPhong)
        {
            bool flag = false;
            Console.WriteLine("\t\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║                                               Thông tin hợp đồng vừa tìm                                                          ║");
            Console.WriteLine("\t\t\t╠═════════════╦════════════════╦═══════════════╦═════════════════════╦═══════════════════╦═════════════════════╦════════════════════╣");
            Console.WriteLine("\t\t\t║ Mã hợp đồng ║  Mã sinh viên  ║    Mã phòng   ║     Mã nhân viên    ║     Ngày lập      ║    Ngày bắt đầu     ║    Ngày kết thúc   ║");
            Console.WriteLine("\t\t\t╠═════════════╬════════════════╬═══════════════╬═════════════════════╬═══════════════════╬═════════════════════╬════════════════════╣");
            foreach (HopDong h in dsHopDong)
                if (h.MaPhong.IndexOf(maPhong) >= 0)
                {
                    h.Hien();
                    Console.WriteLine("\t\t\t╚═════════════╩════════════════╩═══════════════╩═════════════════════╩═══════════════════╩═════════════════════╩════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\t Không tìm thấy thông tin hợp đồng có mã phòng {0} !!!", maPhong);
        }
        public void TimKiemTheoMaSinhVien(string maSinhVien)
        {
            bool flag = false;
            Console.WriteLine("\t\t\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════v═════════════╗");
            Console.WriteLine("\t\t\t║                                               Thông tin hợp đồng vừa tìm                                                          ║");
            Console.WriteLine("\t\t\t╠═════════════╦════════════════╦═══════════════╦═════════════════════╦═══════════════════╦═════════════════════╦════════════════════╣");
            Console.WriteLine("\t\t\t║ Mã hợp đồng ║  Mã sinh viên  ║    Mã phòng   ║     Mã nhân viên    ║     Ngày lập      ║    Ngày bắt đầu     ║    Ngày kết thúc   ║");
            Console.WriteLine("\t\t\t╠═════════════╬════════════════╬═══════════════╬═════════════════════╬═══════════════════╬═════════════════════╬════════════════════╣");
            foreach (HopDong h in dsHopDong)
                if (h.MaSinhVien.IndexOf(maSinhVien) >= 0)
                {
                    h.Hien();
                    Console.WriteLine("\t\t\t╚═════════════╩════════════════╩═══════════════╩═════════════════════╩═══════════════════╩═════════════════════╩════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\t Không tìm thấy thông tin hợp đồng có mã sinh viên {0} !!!", maSinhVien);
        }
        public void TimKiemTheoMaNhanVien(string maNhanVien)
        {
            bool flag = false;
            Console.WriteLine("\t\t\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════v═════════════╗");
            Console.WriteLine("\t\t\t║                                               Thông tin hợp đồng vừa tìm                                                          ║");
            Console.WriteLine("\t\t\t╠═════════════╦════════════════╦═══════════════╦═════════════════════╦═══════════════════╦═════════════════════╦════════════════════╣");
            Console.WriteLine("\t\t\t║ Mã hợp đồng ║  Mã sinh viên  ║    Mã phòng   ║     Mã nhân viên    ║     Ngày lập      ║    Ngày bắt đầu     ║    Ngày kết thúc   ║");
            Console.WriteLine("\t\t\t╠═════════════╬════════════════╬═══════════════╬═════════════════════╬═══════════════════╬═════════════════════╬════════════════════╣");
            foreach (HopDong h in dsHopDong)
                if (h.MaNhanVien.IndexOf(maNhanVien) >= 0)
                {
                    h.Hien();
                    Console.WriteLine("\t\t\t╚═════════════╩════════════════╩═══════════════╩═════════════════════╩═══════════════════╩═════════════════════╩════════════════════╝");
                    flag = true;
                }
            if (flag == false)
                Console.WriteLine("\t\t\t\t\t\t Không tìm thấy thông tin hợp đồng có mã nhân viên {0} !!!", maNhanVien);
        }
    }
}
