using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.View
{
    class QuanLyNhanVienView
    {
        QuanLyNhanVienBus nhanvienBus = new QuanLyNhanVienBus();
        public void DocNhanVien()
        {
            nhanvienBus.DocNhanVien();
        }
        public void NhapNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            ConsoleKeyInfo kt;
            do
            {
                NhanVien nv = new NhanVien();
                do
                {
                    do
                    {
                        try
                        {
                            do
                            {
                                Console.Write("\n\t\t\t\t\t\t Nhập mã nhân viên: ");
                                nv.MaNhanVien = Console.ReadLine();
                                if (nv.KiemTraKiTuDacBiet(nv.MaNhanVien) == false || !(nv.MaNhanVien.Length == 6 && nv.MaNhanVien.StartsWith("NV")))
                                {
                                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                                }
                            } while (nv.KiemTraKiTuDacBiet(nv.MaNhanVien) == false || !(nv.MaNhanVien.Length == 6 && nv.MaNhanVien.StartsWith("NV")));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Write("\t\t\t\t\t\t");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                        }
                    } while (true);
                    if (nhanvienBus.KiemTraTrung(nv.MaNhanVien) == false)
                    {
                        nv.MaNhanVien = nv.MaNhanVien;
                        nv.Nhap1();
                        dsNhanVien.Add(nv);
                        Console.WriteLine("\n Đã thêm nhân viên thành công!");
                        Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t║                                                                           Thông tin Nhân Viên vừa thêm                                                                      ║");
                        Console.WriteLine("\t╠════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
                        Console.WriteLine("\t║  Mã nhân viên  ║       Tên nhân viên     ║  Giới tính ║    Ngày sinh     ║    Chức vụ    ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
                        Console.WriteLine("\t╠════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
                        nv.Hien();
                        Console.WriteLine("\t╚════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
                        break;
                    }
                    else
                        Console.WriteLine("\t\t\t\t\t\t Mã nhân viên {0} đã tồn tại không thêm được", nv.MaNhanVien);
                } while (true);
                Console.Write("\n\t\t\t\t\t\t Bạn có nhập tiếp không (C/K)?");
                kt = Console.ReadKey();
            } while ((kt.KeyChar == 'c') || (kt.KeyChar == 'C'));
            nhanvienBus.ThemNhanVien(dsNhanVien);
            Console.WriteLine("\n Đã thêm nhân viên thành công!");
        }
        public void HienNhanVien()
        {
            Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                            Danh Sách Nhân Viên                                                                                    ║");
            Console.WriteLine("\t╠═════╦════════════════╦═════════════════════════╦════════════╦══════════════════╦═══════════════╦══════════════════════════════════════╦═══════════════════╦═══════════════════════╣");
            Console.WriteLine("\t║ stt ║  Mã nhân viên  ║       Tên nhân viên     ║  Giới tính ║    Ngày sinh     ║    Chức vụ    ║              Quê quán                ║  Số điện thoại    ║        Số CMND        ║");
            Console.WriteLine("\t╠═════╬════════════════╬═════════════════════════╬════════════╬══════════════════╬═══════════════╬══════════════════════════════════════╬═══════════════════╬═══════════════════════╣");
            nhanvienBus.HienNhanVien();
            Console.WriteLine("\t╚═════╩════════════════╩═════════════════════════╩════════════╩══════════════════╩═══════════════╩══════════════════════════════════════╩═══════════════════╩═══════════════════════╝");
        }
        
        public void CapNhatNhanVien()
        {
            Console.WriteLine("\t\t\t\t\t\t Cập nhật thông tin nhân viên");
            Console.WriteLine("\t\t\t\t\t\t Nhập thông tin nhân viên cần cập nhật");
            NhanVien nv = new NhanVien();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã nhân viên cần cập nhật: ");
                        nv.MaNhanVien = Console.ReadLine();
                        if (nv.KiemTraKiTuDacBiet(nv.MaNhanVien) == false || !(nv.MaNhanVien.Length == 6 && nv.MaNhanVien.StartsWith("NV")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (nv.KiemTraKiTuDacBiet(nv.MaNhanVien) == false || !(nv.MaNhanVien.Length == 6 && nv.MaNhanVien.StartsWith("NV")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                }
            } while (true);
            if (nhanvienBus.KiemTraTonTai(nv.MaNhanVien) == true)
            {
                nhanvienBus.CapNhatNhanVien(nv);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công nhân viên có mã {0} !", nv.MaNhanVien);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại nhân viên có mã {0} trong danh sách",nv.MaNhanVien);
        }
        public void XoaNhanVien()
        {
            Console.WriteLine("\t\t\t\t\t\tXóa thông tin nhân viên");
            NhanVien nv = new NhanVien();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã nhân viên cần xóa: ");
                        nv.MaNhanVien = Console.ReadLine();
                        if (nv.KiemTraKiTuDacBiet(nv.MaNhanVien) == false || !(nv.MaNhanVien.Length == 6 && nv.MaNhanVien.StartsWith("NV")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (nv.KiemTraKiTuDacBiet(nv.MaNhanVien) == false || !(nv.MaNhanVien.Length == 6 && nv.MaNhanVien.StartsWith("NV")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                }
            } while (true);
            if (nhanvienBus.KiemTraTonTai(nv.MaNhanVien) == true)
            {
                nhanvienBus.XoaNhanVien(nv.MaNhanVien);
                Console.WriteLine("\t\t\t\t\t\t Đã xóa thành công nhân viên có mã {0} !", nv.MaNhanVien);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại nhân viên có mã {0} trong danh sách", nv.MaNhanVien);
        }
        public void TimKiemNhanVienTheoMa()
        {
            NhanVien nv = new NhanVien();
            string MaNhanVien;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã nhân viên cần tìm: ");
                        MaNhanVien = Console.ReadLine();
                        if (nv.KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (nv.KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                }
            } while (true);
            nhanvienBus.TimKiemNhanVienTheoMa(MaNhanVien);
        }
        public void TimKiemNhanVienTheoTen()
        {
            NhanVien nv = new NhanVien();
            string HoTen;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập họ tên nhân viên: ");
                        HoTen = Console.ReadLine();
                        if (nv.KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50)
                        {
                            Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập có kí tự đặc biệt mời nhập lại.....!!!");
                        }
                    } while (nv.KiemTraKiTuDacBiet(HoTen) == false || HoTen.Length == 0 && HoTen.Length > 50);
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            nhanvienBus.TimKiemNhanVienTheoTen(HoTen);
        }
        public void TimKiemNhanVienTheoChucVu()
        {
            string ChucVu;
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập chức vụ: ");
                ChucVu = Console.ReadLine();
                if (ChucVu.Length == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                }
            } while (ChucVu.Length == 0);
            nhanvienBus.TimKiemNhanVienTheoChucVu(ChucVu);
        }
        public void TimKiemNhanVienTheoQueQuan()
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
            nhanvienBus.TimKiemNhanVienTheoQueQuan(QueQuan);
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        MENU TÌM KIẾM NHÂN VIÊN        ║                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═══════════════════════════════════════╝                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Tìm kiếm nhân viên theo mã nhân viên                         ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Tìm kiếm nhân viên theo họ tên                               ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Tìm kiếm nhân viên theo chức vụ                              ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Tìm kiếm nhân viên theo quê quán                             ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Quay lại                                                     ║        ║ * ║");
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
                            if (s < 0 || s > 5)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t\t Mời nhập lại chức năng !!!: ");
                            }
                        } while (s < 0 || s > 5);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t Dữ liệu không đúng, mời nhập lại !!!: ");
                    }
                } while (true);
                //Console.Clear();
                switch (s)
                {
                    case 1:
                        DocNhanVien();
                        TimKiemNhanVienTheoMa(); Console.ReadKey(); break;
                    case 2:
                        DocNhanVien();
                        TimKiemNhanVienTheoTen(); Console.ReadKey();
                        break;
                    case 3:
                        DocNhanVien();
                        TimKiemNhanVienTheoChucVu();
                        Console.ReadKey(); break;
                    case 4:
                        DocNhanVien();
                        TimKiemNhanVienTheoQueQuan();
                        Console.ReadKey(); break;
                    case 5: end = true; break;
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        QUẢN LÝ NHÂN VIÊN        ║                                    ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═════════════════════════════════╝                                    ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Hiển thị thông tin nhân viên                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Thêm thông tin nhân viên                               ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Cập nhật thông tin nhân viên                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Xóa thông tin nhân viên                                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Menu tìm kiếm nhân viên                                ║              ║ * ║");
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
                        DocNhanVien();
                        HienNhanVien(); Console.ReadKey(); break;
                    case 2:
                        DocNhanVien();
                        HienNhanVien();
                        NhapNhanVien(); Console.ReadKey(); break;
                    case 3:
                        DocNhanVien();
                        HienNhanVien();
                        CapNhatNhanVien(); Console.ReadKey(); break;
                    case 4:
                        DocNhanVien();
                        HienNhanVien();
                        XoaNhanVien(); Console.ReadKey(); break;
                    case 5:
                        MenuTimKiem();
                        break;
                    case 0:
                        end = true;
                        break;
                }
            }
        }
    }
}
