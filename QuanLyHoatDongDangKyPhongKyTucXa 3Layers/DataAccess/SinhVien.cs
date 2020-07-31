﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class SinhVien
    {
        private string maSinhVien, hoTen, gioiTinh, lop, queQuan, soDienThoai, soCMND;
        private DateTime ngaySinh;
        int dd, mm, yyyy;

        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Lop { get => lop; set => lop = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        public SinhVien() { }
        public SinhVien(string maSinhVien, string hoTen, string gioiTinh, DateTime ngaySinh, string lop, string queQuan, string soDienThoai, string soCMND)
        {
            this.MaSinhVien = maSinhVien;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.Lop = lop;
            this.QueQuan = queQuan;
            this.SoDienThoai = soDienThoai;
            this.SoCMND = soCMND;
            this.NgaySinh = ngaySinh;
        }

        public void Nhap()
        {
            Console.InputEncoding = Encoding.UTF8;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                        MaSinhVien = Console.ReadLine();
                        if (!(isNumber(MaSinhVien) && MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (!(isNumber(MaSinhVien) && MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập họ tên sinh viên: ");
                        HoTen = Console.ReadLine();
                        if (KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập có kí tự đặc biệt mời nhập lại.....!!!");
                        }
                    } while (KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập vào không đúng định dạng. Mời nhập lại.......!!!");
                }
            } while (true);

            do
            {
                Console.Write("\t\t\t\t\t\t Nhập giới tính :");
                GioiTinh = Console.ReadLine();
                if (KiemTraGioiTinh(GioiTinh) == false)
                {
                    Console.WriteLine("\t\t\t\t\t\tDữ liệu nhập vào không đúng định dạng. Mời nhập lại .........!!!");
                }
            } while (KiemTraGioiTinh(GioiTinh) == false);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày sinh :");
                        dd = int.Parse(Console.ReadLine());
                        if (!(dd >= 1 && dd <= 30))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(dd >= 1 && dd <= 30));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập tháng sinh :");
                        mm = int.Parse(Console.ReadLine());
                        if (!(mm >= 1 && mm <= 12))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(mm >= 1 && mm <= 12));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập năm sinh :");
                        yyyy = int.Parse(Console.ReadLine());
                        if (!(yyyy >= 1900 && yyyy <= 2099))
                        {
                            Console.WriteLine("\t\t\t\t\t\tMời nhập lại.......!!!");
                        }
                    } while (!(yyyy >= 1900 && yyyy <= 2099));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            NgaySinh = new DateTime(day: dd, month: mm, year: yyyy);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập lớp: ");
                Lop = Console.ReadLine();
                if (Lop.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (Lop.Length == 0);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập quê quán: ");
                QueQuan = Console.ReadLine();
                if (QueQuan.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (QueQuan.Length == 0);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số điện thoại: ");
                        SoDienThoai = Console.ReadLine();
                        if (!(isNumber(SoDienThoai) && SoDienThoai.Length == 10 && SoDienThoai.StartsWith("0")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số điện thoại gồm 10 chữ số và bắt đầu bằng '0'.....!!!");
                        }
                    } while (!(isNumber(SoDienThoai) && SoDienThoai.Length == 10 && SoDienThoai.StartsWith("0")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số điện thoại gồm 10 chữ số và bắt đầu bằng '0'.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số CMND:");
                        SoCMND = Console.ReadLine();
                        if (!isNumber(SoCMND) && !(SoCMND.Length == 12 || SoCMND.Length == 9))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số CMND gồm 9 hoặc 12 chữ số.....!!!");
                        }
                    } while (!isNumber(SoCMND) &&!(SoCMND.Length == 12 || SoCMND.Length == 9));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số CMND gồm 9 hoặc 12 chữ số.......!!!");
                }
            } while (true);
        }

        public void Nhap1()
        {
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập họ tên sinh viên: ");
                        HoTen = Console.ReadLine();
                        if (KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập có kí tự đặc biệt mời nhập lại.....!!!");
                        }
                    } while (KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50);
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
                Console.Write("\t\t\t\t\t\t Nhập giới tính :");
                GioiTinh = Console.ReadLine();
                if (KiemTraGioiTinh(GioiTinh) == false)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại .........!!!");
                }
            } while (KiemTraGioiTinh(GioiTinh) == false);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày sinh :");
                        dd = int.Parse(Console.ReadLine());
                        if (!(dd >= 1 && dd <= 30))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(dd >= 1 && dd <= 30));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập tháng sinh :");
                        mm = int.Parse(Console.ReadLine());
                        if (!(mm >= 1 && mm <= 12))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(mm >= 1 && mm <= 12));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập năm sinh :");
                        yyyy = int.Parse(Console.ReadLine());
                        if (!(yyyy >= 1900 && yyyy <= 2099))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(yyyy >= 1900 && yyyy <= 2099));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            NgaySinh = new DateTime(day: dd, month: mm, year: yyyy);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập lớp: ");
                Lop = Console.ReadLine();
                if (Lop.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (Lop.Length == 0);
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập quê quán: ");
                QueQuan = Console.ReadLine();
                if (QueQuan.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (QueQuan.Length == 0);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số điện thoại: ");
                        SoDienThoai = Console.ReadLine();
                        if (!(isNumber(SoDienThoai) && SoDienThoai.Length == 10 && SoDienThoai.StartsWith("0")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số điện thoại gồm 10 chữ số và bắt đầu chữ số '0'.......!!!");
                        }
                    } while (!(isNumber(SoDienThoai) && SoDienThoai.Length == 10 && SoDienThoai.StartsWith("0")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số điện thoại gồm 10 chữ số và bắt đầu chữ số '0'.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập số CMND :");
                        SoCMND = Console.ReadLine();
                        if (!isNumber(SoCMND) && !(SoCMND.Length == 12 || SoCMND.Length == 9))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số CMND gồm 9 hoặc 12 chữ số.......!!!");
                        }
                    } while (!isNumber(SoCMND) && !(SoCMND.Length == 12 || SoCMND.Length == 9));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại số CMND gồm 9 hoặc 12 chữ số.......!!!");
                }
            } while (true);
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
        public bool KiemTraGioiTinh(string gioitinh)
        {
            Boolean valid = true;
            if (gioitinh.ToLower() != "nam" && gioitinh.ToLower() != "nu")
            {
                valid = false;
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
        public static string chuCaiInHoa(string str)
        {
            str = str.ToLower();
            char[] charArr = str.ToCharArray();
            charArr[0] = Char.ToUpper(charArr[0]);
            foreach (Match m in Regex.Matches(str, @"(\s\S)"))
            {
                charArr[m.Index + 1] = m.Value.ToUpper().Trim()[0];
            }
            return new String(charArr);
        }
        public string toString()
        {
            return MaSinhVien + "#" +chuCaiInHoa(HoTen) + "#" +chuCaiInHoa(GioiTinh) + "#" + NgaySinh + "#" +chuCaiInHoa(Lop) + "#" +chuCaiInHoa(QueQuan) + "#" + SoDienThoai + "#" + SoCMND;
        }
        public void Hien(int stt)
        {
            Console.WriteLine("\t║ {0,-4}║ {1,-15}║ {2,-24}║ {3,-11}║ {4,-17}║ {5,-14}║ {6,-37}║ {7,-18}║ {8,-22}║", stt, MaSinhVien,chuCaiInHoa(HoTen),chuCaiInHoa(GioiTinh), NgaySinh.ToString("dd/MM/yyyy"),chuCaiInHoa(Lop), chuCaiInHoa(QueQuan), SoDienThoai, SoCMND);
        }
        public void Hien()
        {
            Console.WriteLine("\t║ {0,-15}║ {1,-24}║ {2,-11}║ {3,-17}║ {4,-14}║ {5,-37}║ {6,-18}║ {7,-22}║", MaSinhVien,chuCaiInHoa(HoTen),chuCaiInHoa(GioiTinh), NgaySinh.ToString("dd/MM/yyyy"),chuCaiInHoa(Lop), chuCaiInHoa(QueQuan), SoDienThoai, SoCMND);
        }

    }
}
