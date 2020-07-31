using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class PhongDAO
    {
        Phong p = new Phong();
        public List<Phong> dsPhong = new List<Phong>();
        public List<Phong> LayDSPhongConTrongTheoTinhChatPhong(string gioi)
        {
            List<Phong> dsPhong = DocPhong();
            List<Phong> l = new List<Phong>();
            foreach(Phong p in dsPhong)
            {
                if ((p.SoLuongSinhVienHienCo < p.SucChua) && (p.TinhChatPhong.ToLower()==gioi.ToLower()))
                {
                    l.Add(p);
                }
            }
            return l;
        }
        public List<Phong> DocPhong()
        {
            if (!File.Exists("Phong.txt"))
            {
                File.Create("Phong.txt");
            }
            else
            {
                string file = "Phong.txt";
                dsPhong = new List<Phong>();
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] sc = lines[i].Split('#');
                    dsPhong.Add(new Phong(sc[0], sc[1],sc[2], int.Parse(sc[3]), sc[4], sc[5], sc[6], int.Parse(sc[7]), int.Parse(sc[8])));
                }
            }
            return dsPhong;
        }
        public void GhiPhong(List<Phong> dsPhong)
        {
            StreamWriter sr = new StreamWriter("Phong.txt", false);
            foreach (Phong p in dsPhong)
            {
                sr.WriteLine(p.toString());
            }
            sr.Close();
        }
        public Boolean KiemTraTrung(string maPhong)
        {
            List<Phong> ds = DocPhong();
            bool kt = false;
            for (int i = 0; i < dsPhong.Count; i++)
            {
                if (dsPhong[i].MaPhong.Equals(maPhong))
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
        public void ThemPhong(List<Phong> dsPhong)
        {
            StreamWriter w = new StreamWriter("Phong.txt", true);
            foreach (Phong p in dsPhong)
            {
                string s = p.toString();
                w.WriteLine(s);
            }
            w.Close();
        }
        public bool KiemTraTonTai(string maPhong)
        {
            Boolean valid = false;
            foreach (Phong p in dsPhong)
            {
                if (p.MaPhong == maPhong)
                    valid = true;
            }
            return valid;
        }
        public void HienPhong()
        {
            for (int i = 0; i < dsPhong.Count; i++)
            {
                dsPhong[i].Hien(i + 1);
                Console.WriteLine("\t╠═════╬══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
            }
        }
        public void HienThiPhongConThieuSV(string gioi)
        {
            List<Phong> l = LayDSPhongConTrongTheoTinhChatPhong(gioi);
            Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                       Danh sách phòng còn thiếu sinh viên                                                                         ║");
            Console.WriteLine("\t╠══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
            Console.WriteLine("\t║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
            Console.WriteLine("\t╠══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
            for (int i = 0; i < l.Count; i++)
            {
                l[i].Hien();
                Console.WriteLine("\t╚══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
            }
        }
        public void CapNhatPhong(Phong p)
        {
            List<Phong> dsPhong = DocPhong();
            for (int i = 0; i < dsPhong.Count; i++)
            {
                if (dsPhong[i].MaPhong == p.MaPhong)
                {
                    p.Nhap1();
                    dsPhong[i] = p;
                    break;
                }
            }
            GhiPhong(dsPhong);
        }
        public void CapNhatTinhTrang(string maPhong, string tinhTrang)
        {
            List<Phong> ds = DocPhong();
            foreach (Phong p in ds)
            {
                if (p.MaPhong == maPhong)
                {
                    p.TinhTrang = tinhTrang;
                    break;
                }
            }
            GhiPhong(ds);
        }
        public void CapNhatTrangVatTu(string maPhong, string trangVatTu)
        {
            List<Phong> ds = DocPhong();
            foreach (Phong p in ds)
            {
                if (p.MaPhong == maPhong)
                {
                    p.TrangVatTu = trangVatTu;
                    break;
                }
            }
            GhiPhong(ds);
        }
        public void CapNhatTinhChatPhong(string maPhong, string tinhChat)
        {
            List<Phong> ds = DocPhong();
            foreach (Phong p in ds)
            {
                if (p.MaPhong == maPhong)
                {
                    p.TinhChatPhong = tinhChat;
                    break;
                }
            }
            GhiPhong(ds);
        }
        public void CapNhatSoLuongSinhVienHienCo(string maPhong,int soLuongSinhVienHienCo)
        {
            List<Phong> ds = DocPhong();
            foreach(Phong p in ds)
            {
                if (p.MaPhong == maPhong)
                {
                    p.SoLuongSinhVienHienCo = soLuongSinhVienHienCo;
                    break;
                }
            }
            GhiPhong(ds);
        }
        public void CapNhatSucChua(string maPhong, int sucChua)
        {
            List<Phong> ds = DocPhong();
            foreach (Phong p in ds)
            {
                if (p.MaPhong == maPhong)
                {
                    p.SucChua = sucChua;
                    break;
                }
            }
            GhiPhong(ds);
        }
        public void XoaPhong(string maPhong)
        {
            for (int i = 0; i < dsPhong.Count; i++)
            {
                if (dsPhong[i].MaPhong == maPhong)
                {
                    dsPhong.RemoveAt(i);
                    break;
                }
            }
            GhiPhong(dsPhong);
        }
        public void TimKiemTheoMaPhong(string maPhong)
        {
            bool flag = false;
            foreach (Phong p in dsPhong)
            {
                if (p.MaPhong.IndexOf(maPhong) >= 0)
                {
                    Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t║                                                                      Thông tin phòng vừa tìm                                                                                      ║");
                    Console.WriteLine("\t╠══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
                    Console.WriteLine("\t║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
                    Console.WriteLine("\t╠══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
                    p.Hien();
                    Console.WriteLine("\t╚══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
                    flag = true;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("Không tìm thấy phòng có mã {0}", maPhong);
            }
        }
        public void TimKiemTheoTenPhong(string tenPhong)
        {
            bool flag = false;
            foreach (Phong p in dsPhong)
                if (p.TenPhong.IndexOf(tenPhong) >= 0)
                {
                    Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t║                                                                      Thông tin phòng vừa tìm                                                                                      ║");
                    Console.WriteLine("\t╠══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
                    Console.WriteLine("\t║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
                    Console.WriteLine("\t╠══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
                    p.Hien();
                    Console.WriteLine("\t╚══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
                    flag = true;
                }
            if (flag == false)
            {
                Console.WriteLine("Không tìm thấy phòng có tên {0}", tenPhong);
            }
        }
        public void TimKiemTheoTinhTrangPhong(string tinhTrang)
        {
            bool flag = false;
            Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                      Thông tin phòng vừa tìm                                                                                      ║");
            Console.WriteLine("\t╠══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
            Console.WriteLine("\t║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
            Console.WriteLine("\t╠══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
            foreach (Phong p in dsPhong)
            {
                if (p.TinhTrang.IndexOf(tinhTrang) >= 0)
                {
                    p.Hien();
                    Console.WriteLine("\t╚══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Không tìm thấy phòng có tình trạng {0}", tinhTrang);
            }
        }
        public void TimKiemTheoTinhChatPhong(string tinhChatPhong)
        {
            bool flag = false;
            Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                      Thông tin phòng vừa tìm                                                                                      ║");
            Console.WriteLine("\t╠══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
            Console.WriteLine("\t║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
            Console.WriteLine("\t╠══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
            foreach (Phong p in dsPhong)
            {
                if (p.TinhChatPhong.IndexOf(tinhChatPhong) >= 0)
                {
                    p.Hien();
                    Console.WriteLine("\t╚══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Không tìm thấy phòng có tính chất là {0}", tinhChatPhong);
            }
        }
        public void SuaSoLuong(string maPhong)
        {
            List<Phong> ds = DocPhong();
            foreach(Phong p in ds)
            {
                if (p.MaPhong.Trim().ToLower() == maPhong.Trim().ToLower())
                {
                    p.SoLuongSinhVienHienCo = p.SoLuongSinhVienHienCo + 1;
                }
            }
            GhiPhong(ds);
        }
        public List<Phong> LayDSPhongConThieuSinhVien()
        {
            List<Phong> dsPhong = DocPhong();
            List<Phong> ds = new List<Phong>();
            foreach (Phong p in dsPhong)
            {
                if ((p.SoLuongSinhVienHienCo < p.SucChua))
                {
                    ds.Add(p);
                }
            }
            return ds;
        }
        public void ThongKeSoPhongConThieuSinhVien()
        {
            List<Phong> ds = LayDSPhongConThieuSinhVien();
            int soLuong = 0;
            for (int i = 0; i < ds.Count; i++)
            {
                soLuong++;
            }
            Console.WriteLine(soLuong);
        }
    }
}
