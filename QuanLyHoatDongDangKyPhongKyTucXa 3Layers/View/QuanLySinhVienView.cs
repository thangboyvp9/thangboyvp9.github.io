using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.View
{
    class QuanLySinhVienView
    {
        QuanLySinhVienBus sinhVienBus = new QuanLySinhVienBus();
        public void DocSinhVien()
        {
            sinhVienBus.DocSinhVien();
        }
        public void NhapSinhVien()
        {
            Console.InputEncoding = Encoding.UTF8;
            List<SinhVien> dsSinhVien = new List<SinhVien>();
            ConsoleKeyInfo kt;
            do
            {
                SinhVien sv = new SinhVien();
                do
                {
                    do
                    {
                        try
                        {
                            do
                            {
                                Console.Write("\n\t\t\t\t\t\t Nhập mã sinh viên: ");
                                sv.MaSinhVien = Console.ReadLine();
                                if (!(sv.isNumber(sv.MaSinhVien) && sv.MaSinhVien.Length == 8))
                                {
                                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                                }
                            } while (!(sv.isNumber(sv.MaSinhVien) && sv.MaSinhVien.Length == 8));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Write("\t\t\t\t\t\t");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (true);
                    if (sinhVienBus.KiemTraTrung(sv.MaSinhVien) == false)
                    {
                        sv.MaSinhVien = sv.MaSinhVien;
                        sv.Nhap1();
                        dsSinhVien.Add(sv);
                        Console.WriteLine("\n Đã thêm sinh viên thành công!");
                        Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t║                                                                          Thông tin sinh viên vừa nhập                                                                       ║");
                        Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
                        Console.WriteLine("\t║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
                        Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
                        sv.Hien();
                        Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                        break;
                    }
                    else
                        Console.WriteLine("\t\t\t\t\t\t Mã sinh viên {0} đã tồn tại không thêm được", sv.MaSinhVien);
                } while (true);
                Console.Write("\n\t\t\t\t\t\t Bạn có nhập tiếp không (C/K)?");
                kt = Console.ReadKey();
            } while ((kt.KeyChar == 'c') || (kt.KeyChar == 'C'));
            sinhVienBus.ThemSinhVien(dsSinhVien);
            Console.WriteLine("\n Đã thêm sinh viên thành công!");
        }
        public void HienSinhVien()
        {
            Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                          Danh Sách Sinh Viên                                                                                      ║");
            Console.WriteLine("\t╠═════╦════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║ stt ║  Mã sinh viên  ║       Tên sinh viên     ║  Giới tính ║    Ngày sinh     ║      Lớp      ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠═════╬════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            sinhVienBus.HienSinhVien();
            Console.WriteLine("\t╚═════╩════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
        }
        
        public void CapNhatSinhVien()
        {
            Console.WriteLine("\t\t\t\t\t\t Cập nhật thông tin sinh viên");
            Console.WriteLine("\t\t\t\t\t\t Nhập thông tin sinh viên cần cập nhật");
            SinhVien sv = new SinhVien();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên cần cập nhật: ");
                        sv.MaSinhVien = Console.ReadLine();
                        if (!(sv.isNumber(sv.MaSinhVien) && sv.MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (!(sv.isNumber(sv.MaSinhVien) && sv.MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                }
            } while (true);
            if (sinhVienBus.KiemTraTonTai(sv.MaSinhVien) == true)
            {
                sinhVienBus.CapNhatSinhVien(sv);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công sinh viên có mã {0}", sv.MaSinhVien);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại sinh viên có mã {0} trong danh sách", sv.MaSinhVien);
        }

        public void XoaSinhVien()
        {
            Console.WriteLine("\t\t\t\t\t\t Xóa thông tin sinh viên");
            SinhVien sv = new SinhVien();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên cần xóa: ");
                        sv.MaSinhVien = Console.ReadLine();
                        if (!(sv.isNumber(sv.MaSinhVien) && sv.MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (!(sv.isNumber(sv.MaSinhVien) && sv.MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                }
            } while (true);
            if (sinhVienBus.KiemTraTonTai(sv.MaSinhVien) == true)
            {
                sinhVienBus.XoaSinhVien(sv.MaSinhVien);
                Console.WriteLine("\t\t\t\t\t\t Đã xóa thành công sinh viên có mã {0}", sv.MaSinhVien);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại sinh viên có mã {0} trong danh sách", sv.MaSinhVien);
        }
        public void TimKiemSinhVienTheoMa()
        {
            SinhVien sv = new SinhVien();
            string MaSinhVien;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                        MaSinhVien = Console.ReadLine();
                        if (!(sv.isNumber(MaSinhVien) && MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (!(sv.isNumber(MaSinhVien) && MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                }
            } while (true);
            sinhVienBus.TimKiemSinhVienTheoMa(MaSinhVien);
        }
        public void TimKiemSinhVienTheoTen()
        {
            SinhVien sv = new SinhVien();
            string HoTen;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập họ tên sinh viên: ");
                        HoTen = Console.ReadLine();
                        if (sv.KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập có kí tự đặc biệt mời nhập lại.....!!!");
                        }
                    } while (sv.KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập vào không đúng định dạng. Mời nhập lại.......!!!");
                }
            } while (true);
            sinhVienBus.TimKiemSinhVienTheoTen(HoTen);
        }
        public void TimKiemSinhVienTheoNgaySinh()
        {
            int dd, mm, yyyy;
            DateTime NgaySinh;
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
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
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
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
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
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            NgaySinh = new DateTime(day: dd, month: mm, year: yyyy);
            sinhVienBus.TimKiemSinhVienTheoNgaySinh(dd, mm, yyyy);
        }
        public void TimKiemSinhVienTheoLop()
        {
            string Lop;
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập lớp: ");
                Lop = Console.ReadLine();
                if (Lop.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (Lop.Length == 0);
            sinhVienBus.TimKiemSinhVienTheoLop(Lop);
        }
        public void TimKiemSinhVienTheoQueQuan()
        {
            string QueQuan;
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập quê quán: ");
                QueQuan = Console.ReadLine();
                if (QueQuan.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (QueQuan.Length == 0);
            sinhVienBus.TimKiemSinhVienTheoQueQuan(QueQuan);
        }
        public void MenuTimKiem()
        {
            bool end = false;
            while (!end)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t║                -*- CHƯƠNG TRÌNH XÂY DỰNG ỨNG DỤNG QUẢN LÝ HOẠT ĐỘNG ĐĂNG KÝ PHÒNG KÝ TÚC XÁ  -*-             ║");
                Console.WriteLine("\t\t\t\t\t║                            -*-  TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN  -*-                                ║");
                Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("\t\t\t\t\t║ *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ║");
                Console.WriteLine("\t\t\t\t\t║ * ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔═══════════════════════════════════════╗                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        MENU TÌM KIẾM SINH VIÊN        ║                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═══════════════════════════════════════╝                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Tìm kiếm sinh viên theo mã sinh viên                         ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Tìm kiếm sinh viên theo họ tên                               ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Tìm kiếm sinh viên theo ngày sinh                            ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Tìm kiếm sinh viên theo lớp                                  ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Tìm kiếm sinh viên theo quê quán                             ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     6      ║               Quay lại                                                     ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     0      ║               Thoát khỏi chương trình                                      ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝ * ║");
                Console.WriteLine("\t\t\t\t\t║ *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ║");
                Console.WriteLine("\t\t\t\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                int s;
                do
                {
                    try
                    {
                        do
                        {
                            Console.Write("\n\t\t\t\t\t\t\t\t Mời chọn chức năng: ");
                            s = int.Parse(Console.ReadLine());
                            if (s < 0 || s > 6)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t\t Mời nhập lại chức năng !!!: ");
                            }
                        } while (s < 0 || s > 6);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t Dữ liệu không đúng, mời nhập lại !!!: ");
                    }
                } while (true);
                
                switch (s)
                {
                    case 1:
                        DocSinhVien();
                        TimKiemSinhVienTheoMa(); Console.ReadKey(); break;
                    case 2:
                        DocSinhVien();
                        TimKiemSinhVienTheoTen(); Console.ReadKey();
                        break;
                    case 3:
                        DocSinhVien();
                        TimKiemSinhVienTheoNgaySinh();
                        Console.ReadKey();
                        break;
                    case 4:
                        DocSinhVien();
                        TimKiemSinhVienTheoLop();
                        Console.ReadKey(); break;
                    case 5:
                        DocSinhVien();
                        TimKiemSinhVienTheoQueQuan();
                        Console.ReadKey(); break;
                    case 6: end = true; break;
                    case 0:
                        Environment.Exit(0);
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void HienMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.Clear(); //xóa màn hình
                Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t║              -*-  CHƯƠNG TRÌNH XÂY DỰNG ỨNG DỤNG QUẢN LÝ HOẠT ĐỘNG ĐĂNG KÝ PHÒNG KÝ TÚC XÁ  -*-              ║");
                Console.WriteLine("\t\t\t\t\t║                          -*-  TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN   -*-                                 ║");
                Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("\t\t\t\t\t║ *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ║");
                Console.WriteLine("\t\t\t\t\t║ * ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔═════════════════════════════════╗                                    ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        QUẢN LÝ SINH VIÊN        ║                                    ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═════════════════════════════════╝                                    ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Hiển thị thông tin sinh viên                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Thêm thông tin sinh viên                               ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Cập nhật thông tin sinh viên                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Xóa thông tin sinh viên                                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Menu tìm kiếm sinh viên                                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     0      ║               Quay lại menu                                          ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝ * ║");
                Console.WriteLine("\t\t\t\t\t║ *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ║");
                Console.WriteLine("\t\t\t\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                int s;
                do
                {
                    try
                    {
                        do
                        {
                            Console.Write("\n\t\t\t\t\t\t\t\tMời chọn chức năng: ");
                            s = int.Parse(Console.ReadLine());
                            if (s < 0 || s > 5)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t\tMời nhập lại chức năng !!!: ");
                            }
                        } while (s < 0 || s > 5);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\tDữ liệu không đúng, mời nhập lại !!!: ");
                    }
                } while (true);
                Console.Clear();
                switch (s)
                {
                    
                    case 1:
                        DocSinhVien();
                        HienSinhVien(); Console.ReadKey(); break;
                    case 2:
                        DocSinhVien();
                        HienSinhVien();
                        NhapSinhVien(); Console.ReadKey(); break;
                    case 3:
                        DocSinhVien();
                        HienSinhVien();
                        CapNhatSinhVien(); Console.ReadKey(); break;
                    case 4:
                        DocSinhVien();
                        HienSinhVien();
                        XoaSinhVien(); Console.ReadKey(); break;
                    case 5: MenuTimKiem(); break;
                    case 0:
                        end = true;
                        break;
                }
            }
        }
    }
}
