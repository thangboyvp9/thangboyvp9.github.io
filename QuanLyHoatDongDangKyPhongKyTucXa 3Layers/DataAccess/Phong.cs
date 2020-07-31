using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class Phong
    {
        private string maPhong,maNhanVien, tenPhong, trangVatTu, tinhTrang,tinhChatPhong;
        private int soTang, sucChua, soLuongSinhVienHienCo;

        public Phong() { }
        public Phong(string maPhong, string maNhanVien, string tenPhong, int soTang, string trangVatTu, string tinhTrang, string tinhChatPhong, int sucChua, int soLuongSinhVienHienCo)
        {
            this.maPhong = maPhong;
            this.maNhanVien = maNhanVien;
            this.tenPhong = tenPhong;
            this.trangVatTu = trangVatTu;
            this.tinhTrang = tinhTrang;
            this.tinhChatPhong = tinhChatPhong;
            this.soTang = soTang;
            this.sucChua = sucChua;
            this.soLuongSinhVienHienCo = soLuongSinhVienHienCo;
        }

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string TrangVatTu { get => trangVatTu; set => trangVatTu = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string TinhChatPhong { get => tinhChatPhong; set => tinhChatPhong = value; }
        public int SoTang { get => soTang; set => soTang = value; }
        public int SucChua { get => sucChua; set => sucChua = value; }
        public int SoLuongSinhVienHienCo { get => soLuongSinhVienHienCo; set => soLuongSinhVienHienCo = value; }

        public void Nhap()
        {
            Console.InputEncoding = Encoding.UTF8;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng: ");
                        MaPhong = Console.ReadLine();
                        if (KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã nhân viên: ");
                        MaNhanVien = Console.ReadLine();
                        if (KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập tên phòng: ");
                        TenPhong = Console.ReadLine();
                        if (!(isNumber(TenPhong) && TenPhong.Length == 3))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại tên phòng gồm 3 ký tự .......!!!");
                        }
                    } while (!(isNumber(TenPhong) && TenPhong.Length == 3));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại tên phòng gồm 3 ký tự .......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số tầng: ");
                        SoTang = int.Parse(Console.ReadLine());
                        if (SoTang < 1 || SoTang > 5)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại số tầng không quá 5......!!!");
                        }
                    } while (SoTang < 1 || SoTang > 5);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập trang vật tư thiết bị: ");
                TrangVatTu = Console.ReadLine();
                if (TrangVatTu.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (TrangVatTu.Length == 0);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập tình trạng phòng: ");
                TinhTrang = Console.ReadLine();
                if (TinhTrang.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (TinhTrang.Length == 0);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập sức chứa sinh viên trong phòng: ");
                        SucChua = int.Parse(Console.ReadLine());
                        if (SucChua < 1 || SucChua > 10)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại phòng có sức chứa không quá 10 sinh viên.....!!!");
                        }
                    } while (SucChua < 1 || SucChua > 10);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số lượng sinh viên hiện có trong phòng: ");
                        SoLuongSinhVienHienCo = int.Parse(Console.ReadLine());
                        if (SoLuongSinhVienHienCo < 1 || SoLuongSinhVienHienCo > 10)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại số lượng sinh viên không quá 10......!!!");
                        }
                    } while (SoLuongSinhVienHienCo < 1 || SoLuongSinhVienHienCo > 10);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập tính chất phòng: ");
                TinhChatPhong = Console.ReadLine();
                if (ktTinhChatPhong(TinhChatPhong) == false)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại tính chất phòng phải là Nam/Nu.........!!!");
                }
            } while (ktTinhChatPhong(TinhChatPhong) == false);
        }
        public void Nhap1()
        {

            Console.InputEncoding = Encoding.UTF8;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã nhân viên: ");
                        MaNhanVien = Console.ReadLine();
                        if (KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập tên phòng: ");
                        TenPhong = Console.ReadLine();
                        if (!(isNumber(TenPhong) && TenPhong.Length == 3))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại tên phòng gồm 3 ký tự số.......!!!");
                        }
                    } while (!(isNumber(TenPhong) && TenPhong.Length == 3));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại tên phòng gồm 3 ký tự số.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số tầng: ");
                        SoTang = int.Parse(Console.ReadLine());
                        if (SoTang < 1 || SoTang > 6)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại số tầng không quá 6......!!!");
                        }
                    } while (SoTang < 1 || SoTang > 6);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập trang vật tư thiết bị: ");
                TrangVatTu = Console.ReadLine();
                if (TrangVatTu.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (TrangVatTu.Length == 0);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập tình trạng phòng:");
                TinhTrang = Console.ReadLine();
                if (TinhTrang.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (TinhTrang.Length == 0);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập sức chứa sinh viên trong phòng:");
                        SucChua = int.Parse(Console.ReadLine());
                        if (SucChua < 1 || SucChua > 10)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại phòng có sức chứa không quá 10 sinh viên.....!!!");
                        }
                    } while (SucChua < 1 || SucChua > 10);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số lượng sinh viên hiện có trong phòng:");
                        SoLuongSinhVienHienCo = int.Parse(Console.ReadLine());
                        if (SoLuongSinhVienHienCo < 1 ||SoLuongSinhVienHienCo >10)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại......!!!");
                        }
                    } while (SoLuongSinhVienHienCo < 1 || SoLuongSinhVienHienCo > 10);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập tính chất phòng:");
                TinhChatPhong = Console.ReadLine();
                if (ktTinhChatPhong(TinhChatPhong) == false)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại tính chất phòng phải là Nam/Nu.........!!!");
                }
            } while (ktTinhChatPhong(TinhChatPhong) == false);
            
        }
        public bool KiemTraKiTuDacBiet(string chuoi)
        {
            Boolean valid = true;
            for (int i = 0; i < chuoi.Length; i++)
            {
                var kytu = chuoi.Substring(i, 1);
                if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&" || kytu == "*")
                {
                    return false;
                }
            }
            return valid;
        }
        public bool isNumber(string tmp)
        {
            foreach (Char c in tmp)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool ktTinhChatPhong(string TinhChatPhong)
        {
            Boolean valid = true;
            if (TinhChatPhong.ToLower() != "nam" && TinhChatPhong.ToLower() != "nu")
            {
                valid = false;
            }
            return valid;
        }
        public string toString()
        {
            return MaPhong + "#" + MaNhanVien + "#" + TenPhong + "#" + SoTang + "#" + TrangVatTu + "#" + TinhTrang + "#" + TinhChatPhong + "#" + SucChua + "#" + SoLuongSinhVienHienCo;
        }
        public void Hien(int stt)
        {
            Console.WriteLine("\t║ {0,-4}║ {1,-9}║ {2,-13}║ {3,-10}║    {4,-4}║ {5,-44}║ {6,-17}║ {7,-16}║ {8,-19}║ {9,-27}║", stt, MaPhong,MaNhanVien, TenPhong, SoTang, TrangVatTu, TinhTrang,TinhChatPhong, SucChua,SoLuongSinhVienHienCo);
        }
        public void Hien()
        {
            Console.WriteLine("\t║ {0,-9}║ {1,-13}║ {2,-10}║ {3,-7}║ {4,-44}║ {5,-17}║ {6,-16}║ {7,-19}║ {8,-27}║", MaPhong,MaNhanVien, TenPhong, SoTang, TrangVatTu, TinhTrang,TinhChatPhong,SucChua,SoLuongSinhVienHienCo);
        }
    }
}
