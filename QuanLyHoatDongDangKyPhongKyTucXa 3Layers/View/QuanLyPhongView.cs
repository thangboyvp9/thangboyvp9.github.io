using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.View
{
    class QuanLyPhongView
    {
        QuanLyPhongBus phongBus = new QuanLyPhongBus();
        public void DocPhong()
        {
            phongBus.DocPhong();
        }
        public void NhapPhong()
        {
            List<Phong> dsPhong = new List<Phong>();
            ConsoleKeyInfo kt;
            do
            {
                Phong p = new Phong();
                do
                {
                    do
                    {
                        try
                        {
                            do
                            {
                                Console.Write("\n\t\t\t\t\t\t Nhập mã phòng: ");
                                p.MaPhong = Console.ReadLine();
                                if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                                {
                                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                                }
                            } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Write("\t\t\t\t\t\t");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                        }
                    } while (true);
                    if (phongBus.KiemTraTrung(p.MaPhong) == false)
                    {
                        p.MaPhong = p.MaPhong;
                        p.Nhap1();
                        dsPhong.Add(p);
                        Console.WriteLine("\n Đã thêm phòng thành công!");
                        Console.WriteLine("\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t║                                                                      Thông tin phòng vừa nhập                                                                                     ║");
                        Console.WriteLine("\t╠══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
                        Console.WriteLine("\t║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
                        Console.WriteLine("\t╠══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
                        p.Hien();
                        Console.WriteLine("\t╚══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
                        break;
                    }
                    else
                        Console.WriteLine("\t\t\t\t\t\t Mã phòng {0} đã tồn tại không thêm được", p.MaPhong);
                } while (true);
                Console.Write("\n\t\t\t\t\t\t Bạn có nhập tiếp không (C/K)?");
                kt = Console.ReadKey();
            } while ((kt.KeyChar == 'c') || (kt.KeyChar == 'C'));
            phongBus.ThemPhong(dsPhong);
            Console.WriteLine("\n Đã thêm phòng thành công!");

        }
        public void HienPhong()
        {
            Console.WriteLine("\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║                                                                               Danh sách thông tin phòng                                                                                 ║");
            Console.WriteLine("\t╠═════╦══════════╦══════════════╦═══════════╦════════╦═════════════════════════════════════════════╦══════════════════╦═════════════════╦════════════════════╦════════════════════════════╣");
            Console.WriteLine("\t║ STT ║ Mã phòng ║ Mã nhân viên ║ Tên phòng ║  Tầng  ║             Trang vật tư thiết bị           ║ Tình trạng phòng ║ Tính chất phòng ║ Sức chứa sinh viên ║ Số lượng sinh viên hiện có ║");
            Console.WriteLine("\t╠═════╬══════════╬══════════════╬═══════════╬════════╬═════════════════════════════════════════════╬══════════════════╬═════════════════╬════════════════════╬════════════════════════════╣");
            phongBus.HienPhong();
            Console.WriteLine("\t╚═════╩══════════╩══════════════╩═══════════╩════════╩═════════════════════════════════════════════╩══════════════════╩═════════════════╩════════════════════╩════════════════════════════╝");
        }
        public void CapNhatPhong()
        {
            Console.WriteLine("\t\t\t\t\t\t\t Cập nhật thông tin phòng");
            Console.WriteLine("\t\t\t\t\t\t\t Nhập thông tin phòng cần cập nhật");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần cập nhật: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                phongBus.CapNhatPhong(p);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công phòng có mã {0}", p.MaPhong);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
        }
        public void CapNhatTinhTrang()
        {
            Console.WriteLine("\t\t\t\t\t\t\t Cập nhật tình trạng phòng");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần cập nhật: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                do
                {
                    Console.Write("\t\t\t\t\t\t Nhập tình trạng phòng: ");
                    p.TinhTrang = Console.ReadLine();
                    if (p.TinhTrang.Length == 0)
                    {
                        Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                    }
                } while (p.TinhTrang.Length == 0);
                phongBus.CapNhatTinhTrangPhong(p.MaPhong, p.TinhTrang);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công tình trạng phòng có mã {0}", p.MaPhong);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
        }
        public void CapNhatTrangVatTu()
        {
            Console.WriteLine("\t\t\t\t\t\t\t Cập nhật trang vật tư thiết bị phòng");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần cập nhật: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                do
                {
                    Console.Write("\t\t\t\t\t\t Nhập trang vật tư thiết bị: ");
                    p.TrangVatTu = Console.ReadLine();
                    if (p.TrangVatTu.Length == 0)
                    {
                        Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.....!!!");
                    }
                } while (p.TrangVatTu.Length == 0);
                phongBus.CapNhatTrangVatTu(p.MaPhong, p.TrangVatTu);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công trang vật tư thiết bị phòng có mã {0}", p.MaPhong);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
        }
        public void CapNhatTinhChatPhong()
        {
            Console.WriteLine("\t\t\t\t\t\t\t Cập nhật tính chất phòng");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần cập nhật: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                do
                {
                    Console.Write("\t\t\t\t\t\t Nhập tính chất phòng:");
                    p.TinhChatPhong = Console.ReadLine();
                    if (p.ktTinhChatPhong(p.TinhChatPhong) == false)
                    {
                        Console.WriteLine("\t\t\t\t\t\t Mời nhập lại tính chất phòng phải là Nam/Nu.........!!!");
                    }
                } while (p.ktTinhChatPhong(p.TinhChatPhong) == false);
                phongBus.CapNhatTinhChatPhong(p.MaPhong, p.TinhChatPhong);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công tính chất phòng có mã {0}", p.MaPhong);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
        }
        public void CapNhatSoLuongSinhVienHienCo()
        {
            Console.WriteLine("\t\t\t\t\t\t\t Cập nhật số lượng sinh viên hiện có trong phòng");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần cập nhật: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                do
                {
                    try
                    {
                        do
                        {
                            Console.Write("\t\t\t\t\t\t Nhập số lượng sinh viên hiện có trong phòng: ");
                            p.SoLuongSinhVienHienCo = int.Parse(Console.ReadLine());
                            if (p.SoLuongSinhVienHienCo < 1 || p.SoLuongSinhVienHienCo > 10)
                            {
                                Console.WriteLine("\t\t\t\t\t\t Mời nhập lại số lượng sinh viên không quá 10......!!!");
                            }
                        } while (p.SoLuongSinhVienHienCo < 1 || p.SoLuongSinhVienHienCo > 10);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Write("\t\t\t\t\t\t");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                    }
                } while (true);
                phongBus.CapNhatSoLuongSinhVienHienCo(p.MaPhong, p.SoLuongSinhVienHienCo);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công số lượng sinh viên hiện có trong phòng có mã {0}", p.MaPhong);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
            }
        }
        public void CapNhatSucChua()
        {
            Console.WriteLine("\t\t\t\t\t\t\t Cập nhật số lượng sinh viên hiện có trong phòng");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần cập nhật: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                do
                {
                    try
                    {
                        do
                        {
                            Console.Write("\t\t\t\t\t\t Nhập sức chứa sinh viên trong phòng: ");
                            p.SucChua = int.Parse(Console.ReadLine());
                            if (p.SucChua < 1 || p.SucChua > 10)
                            {
                                Console.WriteLine("\t\t\t\t\t\t Mời nhập lại phòng có sức chứa không quá 10 sinh viên.....!!!");
                            }
                        } while (p.SucChua < 1 || p.SucChua > 10);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Write("\t\t\t\t\t\t ");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                    }
                } while (true);
                phongBus.CapNhatSucChua(p.MaPhong, p.SucChua);
                Console.WriteLine("\t\t\t\t\t\t Đã cập nhật thành công sức chứa sinh viên phòng có mã {0}", p.MaPhong);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
            }
        }
        public void XoaPhong()
        {
            Console.WriteLine("\t\t\t\t\t\t Xóa thông tin phòng");
            Phong p = new Phong();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng cần xóa: ");
                        p.MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(p.MaPhong) == false || !(p.MaPhong.Length == 4 && p.MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            if (phongBus.KiemTraTonTai(p.MaPhong) == true)
            {
                phongBus.XoaPhong(p.MaPhong);
                Console.WriteLine("\t\t\t\t\t\t Đã xóa thành công phòng có mã {0} !", p.MaPhong);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại phòng có mã {0} trong danh sách", p.MaPhong);
        }
        public void TimKiemTheoMaPhong()
        {
            Phong p = new Phong();
            string MaPhong;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng: ");
                        MaPhong = Console.ReadLine();
                        if (p.KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (p.KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            phongBus.TimKiemTheoMaPhong(MaPhong);
        }
        public void TimKiemTheoTenPhong()
        {
            Phong p = new Phong();
            string TenPhong;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập tên phòng: ");
                        TenPhong = Console.ReadLine();
                        if (!(p.isNumber(TenPhong) && TenPhong.Length == 3))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại tên phòng gồm 3 ký tự số.......!!!");
                        }
                    } while (!(p.isNumber(TenPhong) && TenPhong.Length == 3));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại tên phòng gồm 3 ký tự só.......!!!");
                }
            } while (true);
            phongBus.TimKiemTheoTenPhong(TenPhong);
        }
        public void TimKiemTheoTinhTrangPhong()
        {
            string TinhTrang;
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập tình trạng phòng cần tìm: ");
                TinhTrang = Console.ReadLine();
                if (TinhTrang.Length == 0)
                {  
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (TinhTrang.Length == 0);
            phongBus.TimKiemTheoTinhTrangPhong(TinhTrang);
        }
        public void TimKiemTheoTinhChatPhong()
        {
            Phong p = new Phong();
            string TinhChatPhong;
            do
            {
                Console.Write("\t\t\t\t\t\t Nhập tính chất phòng: ");
                TinhChatPhong = Console.ReadLine();
                if (p.ktTinhChatPhong(TinhChatPhong) == false)
                {
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại tính chất phòng phải là Nam/Nu.........!!!");
                }
            } while (p.ktTinhChatPhong(TinhChatPhong) == false);
            phongBus.TimKiemTheoTinhChatPhong(TinhChatPhong);
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔═══════════════════════════════════╗                                  ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        MENU TÌM KIẾM PHÒNG        ║                                  ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═══════════════════════════════════╝                                  ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Tìm kiếm phòng theo mã phòng                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Tìm kiếm phòng theo tên phòng                          ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Tìm kiếm phòng theo tình trạng phòng                   ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Tìm kiếm phòng theo tính chất phòng                    ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Quay lại                                               ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     0      ║               Thoát khỏi chương trình                                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
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
                switch (s)
                {
                    case 1:
                        DocPhong();
                        TimKiemTheoMaPhong(); Console.ReadKey(); break;
                    case 2:
                        DocPhong();
                        TimKiemTheoTenPhong();
                        Console.ReadKey();
                        break;
                    case 3:
                        DocPhong();
                        TimKiemTheoTinhTrangPhong();
                        Console.ReadKey();
                        break;
                    case 4:
                        DocPhong();
                        TimKiemTheoTinhChatPhong();
                        Console.ReadKey();
                        break;
                    case 5: end = true; break;
                    case 0:
                        Environment.Exit(0);
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void MenuCapNhat()
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔═══════════════════════════════════╗                                  ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        MENU CẬP NHẬT PHÒNG        ║                                  ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═══════════════════════════════════╝                                  ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Cập nhật thông tin phòng                               ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Cập nhật lại trang vật tư thiết bị trong phòng         ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Cập nhật lại tình trạng phòng                          ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Cập nhật lại tính chất phòng                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Cập nhật lại số lượng sinh viên hiện có trong phòng    ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     6      ║               Cập nhật lại sức chứa sinh viên trong phòng            ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     7      ║               Quay lại                                               ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     0      ║               Thoát khỏi chương trình                                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
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
                            if (s < 0 || s > 7)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t\t Mời nhập lại chức năng !!!: ");
                            }
                        } while (s < 0 || s > 7);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t Dữ liệu không đúng, mời nhập lại !!!: ");
                    }
                } while (true);
                Console.Clear();
                switch (s)
                {
                    case 1:
                        DocPhong();
                        HienPhong();
                        CapNhatPhong(); Console.ReadKey(); break;
                    case 2:
                        DocPhong();
                        HienPhong();
                        CapNhatTrangVatTu();
                        Console.ReadKey();
                        break;
                    case 3:
                        DocPhong();
                        HienPhong();
                        CapNhatTinhTrang();
                        Console.ReadKey();
                        break;
                    case 4:
                        DocPhong();
                        HienPhong();
                        CapNhatTinhChatPhong(); 
                        Console.ReadKey();
                        break;
                    case 5:
                        DocPhong(); HienPhong();
                        CapNhatSoLuongSinhVienHienCo();
                        Console.ReadKey();
                        break;
                    case 6:
                        DocPhong(); HienPhong();
                        CapNhatSucChua();
                        Console.ReadKey();
                        break;
                    case 7: end = true; break;
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔═════════════════════════════╗                                        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║        QUẢN LÝ PHÒNG        ║                                        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═════════════════════════════╝                                        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");                   
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Hiển thị thông tin phòng                               ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Thêm thông tin phòng                                   ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Xóa thông tin phòng                                    ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Menu cập nhật thông tin phòng                          ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Menu tìm kiếm phòng                                    ║              ║ * ║");
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
                        DocPhong();
                        HienPhong(); Console.ReadKey(); break;
                    case 2:
                        DocPhong();
                        HienPhong();
                        NhapPhong(); Console.ReadKey(); break;
                    case 3:
                        DocPhong();
                        HienPhong();
                        XoaPhong(); Console.ReadKey(); break;
                    case 4:
                        DocPhong();
                        HienPhong();
                        MenuCapNhat(); break;
                    case 5:
                        MenuTimKiem();  break;
                    case 0: end = true; break;
                }
            }
        }

    }
}
