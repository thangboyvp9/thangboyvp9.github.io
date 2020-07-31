using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.View
{
    class QuanLyHopDongView
    {
        HopDongDAO hopdongDAO = new HopDongDAO();
        QuanLyHopDongBus hopDongBus = new QuanLyHopDongBus();
        public void DocHopDong()
        {
            hopDongBus.DocHopDong();
        }
        public void NhapHopDong()
        {
            List<HopDong> ds = new List<HopDong>();
            ConsoleKeyInfo kt;
            do
            {
                HopDong h = new HopDong();
                do
                {
                    do
                    {
                        try
                        {
                            do
                            {
                                Console.Write("\n\t\t\t\t\t\t Nhập mã hợp đồng: ");
                                h.MaHopDong = Console.ReadLine();
                                if (h.KiemTraKiTuDacBiet(h.MaHopDong) == false || !(h.MaHopDong.Length == 6 && h.MaHopDong.StartsWith("HD")))
                                {
                                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự, bắt đầu 'HD' và không chứa ký tự đặc biệt .......!!!");
                                }
                            } while (h.KiemTraKiTuDacBiet(h.MaHopDong) == false || !(h.MaHopDong.Length == 6 && h.MaHopDong.StartsWith("HD")));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Write("\t\t\t\t\t\t");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự và bắt đầu 'HD'.......!!!");
                        }
                    } while (true);

                    if (hopDongBus.KiemTraTrung(h.MaHopDong) == false)
                    {
                        h.MaHopDong = h.MaHopDong;
                        do
                        {
                            try
                            {
                                do
                                {
                                    Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                                    h.MaSinhVien = Console.ReadLine();
                                    if (!(h.isNumber(h.MaSinhVien) && h.MaSinhVien.Length == 8))
                                    {
                                        Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                                    }
                                } while (!(h.isNumber(h.MaSinhVien) && h.MaSinhVien.Length == 8));
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.Write("\t\t\t\t\t\t");
                                Console.WriteLine(e.Message);
                                Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                            }
                        } while (true);
                        if (hopDongBus.KiemTraTrungSV(h.MaSinhVien) == false)
                        {
                            h.MaSinhVien = h.MaSinhVien;
                            h.Nhap1();
                            ds.Add(h);
                            Console.WriteLine("\n\t\t\t\t Đã thêm hợp đồng thành công!");
                            Console.WriteLine("\t\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t\t║                                               Thông tin hợp đồng vừa nhập                                                         ║");
                            Console.WriteLine("\t\t\t╠═════════════╦════════════════╦═══════════════╦═════════════════════╦═══════════════════╦═════════════════════╦════════════════════╣");
                            Console.WriteLine("\t\t\t║ Mã hợp đồng ║  Mã sinh viên  ║    Mã phòng   ║     Mã nhân viên    ║     Ngày lập      ║    Ngày bắt đầu     ║    Ngày kết thúc   ║");
                            Console.WriteLine("\t\t\t╠═════════════╬════════════════╬═══════════════╬═════════════════════╬═══════════════════╬═════════════════════╬════════════════════╣");
                            h.Hien();
                            Console.WriteLine("\t\t\t╚═════════════╩════════════════╩═══════════════╩═════════════════════╩═══════════════════╩═════════════════════╩════════════════════╝");
                            break;
                        }
                        else
                            Console.WriteLine("\t\t\t\t\t\t Mã sinh viên {0} đã tồn tại không thêm được", h.MaSinhVien);
                    }
                    else
                        Console.WriteLine("\t\t\t\t\t\t Mã hợp đồng {0} đã tồn tại không thêm được", h.MaHopDong);
                } while (true);
                Console.Write("\n\t\t\t\t\t\t Bạn có nhập tiếp không (C/K)?");
                kt = Console.ReadKey();
            } while ((kt.KeyChar == 'c') || (kt.KeyChar == 'C'));
            hopDongBus.ThemHopDong(ds);
            Console.WriteLine("\n Đã thêm hợp đồng thành công!");
        }
        public void HienHopDong()
        {
            Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║                                                        Danh sách hợp đồng                                                            ║");
            Console.WriteLine("\t\t\t╠═════╦═════════════╦════════════════╦═══════════════╦═════════════════╦═════════════════════╦════════════════════╦════════════════════╣");
            Console.WriteLine("\t\t\t║ STT ║ Mã hợp đồng ║  Mã sinh viên  ║    Mã phòng   ║   Mã nhân viên  ║      Ngày lập       ║    Ngày bắt đầu    ║    Ngày kết thúc   ║");
            Console.WriteLine("\t\t\t╠═════╬═════════════╬════════════════╬═══════════════╬═════════════════╬═════════════════════╬════════════════════╬════════════════════╣");
            hopDongBus.HienHopDong();
            Console.WriteLine("\t\t\t╚═════╩═════════════╩════════════════╩═══════════════╩═════════════════╩═════════════════════╩════════════════════╩════════════════════╝");
        }
        public void CapNhatHopDong()
        {
            Console.WriteLine("\t\t\t\t\t\t Cập nhật thông tin hợp đồng");
            HopDong h = new HopDong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\n\t\t\t\t\t\t Nhập mã hợp đồng cần sửa: ");
                        h.MaHopDong = Console.ReadLine();
                        if (h.KiemTraKiTuDacBiet(h.MaHopDong) == false || !(h.MaHopDong.Length == 6 && h.MaHopDong.StartsWith("HD")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự, bắt đầu 'HD' và không chứa ký tự đặc biệt .......!!!");
                        }
                    } while (h.KiemTraKiTuDacBiet(h.MaHopDong) == false || !(h.MaHopDong.Length == 6 && h.MaHopDong.StartsWith("HD")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự và bắt đầu 'HD'.......!!!");
                }
            } while (true);
            hopDongBus.CapNhatHopDong(h);
            
        }
        public void XoaHopDong()
        {
            Console.WriteLine("\t\t\t\t\t\t Xóa thông tin hợp đồng");
            HopDong h = new HopDong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\n\t\t\t\t\t\t Nhập mã hợp đồng cần xóa: ");
                        h.MaHopDong = Console.ReadLine();
                        if (h.KiemTraKiTuDacBiet(h.MaHopDong) == false || !(h.MaHopDong.Length == 6 && h.MaHopDong.StartsWith("HD")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự, bắt đầu 'HD' và không chứa ký tự đặc biệt .......!!!");
                        }
                    } while (h.KiemTraKiTuDacBiet(h.MaHopDong) == false || !(h.MaHopDong.Length == 6 && h.MaHopDong.StartsWith("HD")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự và bắt đầu 'HD'.......!!!");
                }
            } while (true);
            if (hopDongBus.KiemTraTontai(h.MaHopDong) == true)
            {
                hopDongBus.XoaHopDong(h.MaHopDong);
                Console.WriteLine("\t\t\t\t\t\t Đã xóa thành công hợp đồng có mã {0}", h.MaHopDong);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại hợp đồng có mã {0} trong danh sách", h.MaHopDong);
        }
        public void TimKiemHopDongTheoMa()
        {
            HopDong h = new HopDong();
            string MaHopDong;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\n\t\t\t\t\t\t Nhập mã hợp đồng cần tìm: ");
                        MaHopDong = Console.ReadLine();
                        if (h.KiemTraKiTuDacBiet(MaHopDong) == false || !(MaHopDong.Length == 6 && MaHopDong.StartsWith("HD")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự, bắt đầu 'HD' và không chứa ký tự đặc biệt .......!!!");
                        }
                    } while (h.KiemTraKiTuDacBiet(MaHopDong) == false || !(MaHopDong.Length == 6 && MaHopDong.StartsWith("HD")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã hợp đồng gồm 6 ký tự và bắt đầu 'HD'.......!!!");
                }
            } while (true);
            hopDongBus.TimKiemHopDongTheoMa(MaHopDong);
        }
        public void TimKiemHopDongTheoMaPhong()
        {
            HopDong h = new HopDong();
            string MaPhong;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng: ");
                        MaPhong = Console.ReadLine();
                        if (h.KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (h.KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            hopDongBus.TimKiemHopDongTheoMaPhong(MaPhong);
        }
        public void TimKiemHopDongTheoMaSinhVien()
        {
            HopDong h = new HopDong();
            string MaSinhVien;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                        MaSinhVien = Console.ReadLine();
                        if (!(h.isNumber(MaSinhVien) && MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (!(h.isNumber(MaSinhVien) && MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                }
            } while (true);
            hopDongBus.TimKiemHopDongTheoMaSinhVien(MaSinhVien);
        }
        public void TimKiemHopDongTheoMaNhanVien()
        {
            HopDong h = new HopDong();
            string MaNhanVien;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã nhân viên: ");
                        MaNhanVien = Console.ReadLine();
                        if (h.KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự, bắt đầu 'NV' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (h.KiemTraKiTuDacBiet(MaNhanVien) == false || !(MaNhanVien.Length == 6 && MaNhanVien.StartsWith("NV")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã nhân viên gồm 6 ký tự và bắt đầu 'NV'.......!!!");
                }
            } while (true);
            hopDongBus.TimKiemHopDongTheoMaNhanVien(MaNhanVien);
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔══════════════════════════════════════╗                               ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        MENU TÌM KIẾM HỢP ĐỒNG        ║                               ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚══════════════════════════════════════╝                               ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Tìm kiếm hợp đồng theo mã hợp đồng                           ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Tìm kiếm hợp đồng theo mã phòng                              ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Tìm kiếm hợp đồng theo mã sinh viên                          ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Tìm kiếm hợp đồng theo mã nhân viên                          ║        ║ * ║");
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
                        DocHopDong();
                        TimKiemHopDongTheoMa(); Console.ReadKey(); break;
                    case 2:
                        DocHopDong();
                        TimKiemHopDongTheoMaPhong(); Console.ReadKey();
                        break;
                    case 3:
                        DocHopDong();
                        TimKiemHopDongTheoMaSinhVien();
                        Console.ReadKey(); break;
                    case 4:
                        DocHopDong();
                        TimKiemHopDongTheoMaNhanVien();
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔════════════════════════════════╗                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        QUẢN LÝ HỢP ĐỒNG        ║                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚════════════════════════════════╝                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Hiển thị thông tin hợp đồng                            ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Thêm thông tin hợp đồng                                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Cập nhật thông tin hợp đồng                            ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Xóa thông tin hợp đồng                                 ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Menu tìm kiếm hợp đồng                                 ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     0      ║               Quay lại menu                                          ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
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
                        DocHopDong();
                        HienHopDong(); Console.ReadKey(); break;
                    case 2:
                        DocHopDong();
                        HienHopDong();
                        NhapHopDong(); Console.ReadKey(); break;
                    case 3:
                        DocHopDong();
                        HienHopDong();
                        CapNhatHopDong(); Console.ReadKey(); break;
                    case 4:
                        DocHopDong();
                        HienHopDong();
                        XoaHopDong(); Console.ReadKey(); break;
                    case 5:
                        MenuTimKiem();
                        break;
                    case 0: end = true; break;
                }
            }
        }

    }
}
