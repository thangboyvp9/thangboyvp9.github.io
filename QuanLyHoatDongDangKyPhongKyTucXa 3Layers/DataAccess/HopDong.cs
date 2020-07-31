using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess
{
    class HopDong
    {
        private string maHopDong, maSinhVien, maPhong, maNhanVien;
        private DateTime ngayLap, ngayBatDau, ngayKetThuc;
        int dd, mm, yyyy;

        public HopDong(string maHopDong, string maSinhVien, string maPhong, string maNhanVien, DateTime ngayLap, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.maHopDong = maHopDong;
            this.maSinhVien = maSinhVien;
            this.maPhong = maPhong;
            this.maNhanVien = maNhanVien;
            this.ngayLap = ngayLap;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
        public HopDong() { }
        public string MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }

        public void Nhap()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\n\t\t\t\t\t\t Nhập mã hợp đồng: ");
                        MaHopDong = Console.ReadLine();
                        if (KiemTraKiTuDacBiet(MaHopDong) == false || !(MaHopDong.Length == 6 && MaHopDong.StartsWith("HD")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự, bắt đầu 'HD' và không chứa ký tự đặc biệt .......!!!");
                        }
                    } while (KiemTraKiTuDacBiet(MaHopDong) == false || !(MaHopDong.Length == 6 && MaHopDong.StartsWith("HD")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự và bắt đầu 'HD'.......!!!");
                }
            } while (true);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                        MaSinhVien = Console.ReadLine();
                        if (!(isNumber(MaSinhVien) && MaSinhVien.Length == 8 ))
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
                    } while (KiemTraKiTuDacBiet(MaNhanVien) == false ||  !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")));
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
                        Console.Write("\t\t\t\t\t\t Nhập ngày lập :");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng lập :");
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
                        Console.Write("\t\t\t\t\t\t Nhập năm lập :");
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
            NgayLap = new DateTime(day: dd, month: mm, year: yyyy);
            
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày bắt đầu :");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng bắt đầu :");
                        mm = int.Parse(Console.ReadLine());
                        if (!(mm >= 1 && mm <= 12))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(mm>= 1 && mm <= 12));
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
                        Console.Write("\t\t\t\t\t\t Nhập năm bắt đầu :");
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
            NgayBatDau = new DateTime(day: dd, month: mm, year: yyyy);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày kết thúc :");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng kết thúc :");
                        mm = int.Parse(Console.ReadLine());
                        if (!(mm >= 1 &&mm <= 12))
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
                        Console.Write("\t\t\t\t\t\t Nhập năm kết thúc  :");
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
            NgayKetThuc = new DateTime(day: dd, month: mm, year: yyyy);
        }
        public void Nhap1()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
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
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại'.......!!!");
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
                        Console.Write("\t\t\t\t\t\t Nhập ngày lập :");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng lập :");
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
                        Console.Write("\t\t\t\t\t\t Nhập năm lập :");
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
            NgayLap = new DateTime(day: dd, month: mm, year: yyyy);

            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày bắt đầu :");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng bắt đầu :");
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
                        Console.Write("\t\t\t\t\t\t Nhập năm bắt đầu :");
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
            NgayBatDau = new DateTime(day: dd, month: mm, year: yyyy);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày kết thúc :");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng kết thúc :");
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
                        Console.Write("\t\t\t\t\t\t Nhập năm kết thúc  :");
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
            NgayKetThuc = new DateTime(day: dd, month: mm, year: yyyy);
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
        public string toString()
        {
            return MaHopDong + "#" + MaSinhVien + "#" + MaPhong +  "#" + MaNhanVien + "#" + NgayLap + "#" + NgayBatDau + "#" + NgayKetThuc;
        }
        public void Hien(int stt)
        {
            Console.WriteLine("\t\t\t║ {0,3} ║ {1,7}     ║ {2,9}      ║ {3,7}       ║ {4,10}      ║ {5,14}      ║ {6,14}     ║ {7,14}     ║", stt, MaHopDong, MaSinhVien, MaPhong,MaNhanVien, NgayLap.ToString("dd/MM/yyyy"), NgayBatDau.ToString("dd/MM/yyyy"), NgayKetThuc.ToString("dd/MM/yyyy"));
        }
        public void Hien()
        {
            Console.WriteLine("\t\t\t║ {0,7}     ║ {1,9}      ║ {2,7}       ║ {3,10}          ║ {4,14}    ║  {5,14}     ║ {6,14}     ║", MaHopDong, MaSinhVien, MaPhong,MaNhanVien, NgayLap.ToString("dd/MM/yyyy"), NgayBatDau.ToString("dd/MM/yyyy"), NgayKetThuc.ToString("dd/MM/yyyy"));
        } 
    }
}
