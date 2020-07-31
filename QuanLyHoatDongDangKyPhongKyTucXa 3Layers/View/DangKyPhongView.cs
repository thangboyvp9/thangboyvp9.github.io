using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.Business;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers.View
{
    class DangKyPhongView
    {
        DangKyPhongBus dangkybus = new DangKyPhongBus();
        List<Phong_SinhVien> ds = new List<Phong_SinhVien>();
        int dd;
        int mm;
        int yyyy;
        public void DocPhong_SinhVien()
        {
            dangkybus.DocPhong_SinhVien();
        }
        public void DangKyPhong()
        {
            SinhVien sv;
            do
            {
                Console.Write("\n\n\t\t\t\t\t\t Nhập vào mã sinh viên cần đăng ký: ");
                string ma = Console.ReadLine();
                sv = dangkybus.LaySinhVien(ma);
                if (sv == null)
                {
                    Console.WriteLine("\t\t\t\t\t\t Sinh viên chưa nhập, đề nghị nhập thông tin sinh viên trước");
                }
                else
                { break; }
            }
            while (true);
            dangkybus.LayDSPhongConThieuSV(sv.GioiTinh);
            Console.Write("\t\t\t\t\t\t Nhập mã phòng đăng ký: ");
            string maphong = Console.ReadLine();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày đăng ký: ");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng đăng ký: ");
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
                        Console.Write("\t\t\t\t\t\t Nhập năm đăng ký: ");
                        yyyy = int.Parse(Console.ReadLine());
                        if (!(yyyy >= 2015 && yyyy <= 2099))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(yyyy >= 2015 && yyyy <= 2099));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            DateTime ngayBatDau = new DateTime(day: dd, month: mm, year: yyyy);
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày kết thúc đăng ký: ");
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng kết thúc đăng ký: ");
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
                        Console.Write("\t\t\t\t\t\t Nhập năm kết thúc đăng ký: ");
                        yyyy = int.Parse(Console.ReadLine());
                        if (!(yyyy >= 2015 && yyyy <= 2019))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(yyyy >= 2015 && yyyy <= 2019));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            DateTime ngayKetThuc = new DateTime(day: dd, month: mm, year: yyyy);
            dangkybus.DangKyPhong(sv.MaSinhVien, maphong, ngayBatDau, ngayKetThuc);
            Console.WriteLine("\t\t\t\t\t\t Xác nhận đăng ký thành công!");
            ; }
        public void HienDSSinhVienDangKy()
        {
            Console.WriteLine("\t\t\t\t\t\t\t╔═════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t\t║                       Danh sách sinh viên đã đăng ký                        ║");
            Console.WriteLine("\t\t\t\t\t\t\t╠═════╦══════════════╦═══════════════╦══════════════════╦═════════════════════╣");
            Console.WriteLine("\t\t\t\t\t\t\t║ STT ║ Mã sinh viên ║    Mã phòng   ║   Ngày bắt đầu   ║    Ngày kết thúc    ║");
            Console.WriteLine("\t\t\t\t\t\t\t╠═════╬══════════════╬═══════════════╬══════════════════╬═════════════════════╣");
            dangkybus.HienDSPhongSV();
            Console.WriteLine("\t\t\t\t\t\t\t╚═════╩══════════════╩═══════════════╩══════════════════╩═════════════════════╝");
        }

        public void XoaSinhVienDaDangKy()
        {
            Phong_SinhVien psv = new Phong_SinhVien();
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                        psv.MaSinhVien = Console.ReadLine();
                        if (!(psv.isNumber(psv.MaSinhVien) && psv.MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                        }
                    } while (!(psv.isNumber(psv.MaSinhVien) && psv.MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự số.......!!!");
                }
            } while (true);
            if (dangkybus.KiemTraTonTai(psv.MaSinhVien) == true)
            {
                dangkybus.XoaSinhVienDaDangKy(psv.MaSinhVien);
                Console.WriteLine("\t\t\t\t\t\t Đã xóa thành công sinh viên có mã {0}", psv.MaSinhVien);
            }
            else
                Console.WriteLine("\t\t\t\t\t\t Không tồn tại mã sinh viên {0} trong danh sách", psv.MaSinhVien);
        } 
        public void TimKiemSinhVienTheoMaPhong()
        {
            Phong_SinhVien psv = new Phong_SinhVien();
            string MaPhong;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã phòng: ");
                        MaPhong = Console.ReadLine();
                        if (psv.KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự, bắt đầu 'P' và không chứa ký tự đặc biệt.......!!!");
                        }
                    } while (psv.KiemTraKiTuDacBiet(MaPhong) == false || !(MaPhong.Length == 4 && MaPhong.StartsWith("P")));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại phòng gồm 4 ký tự và bắt đầu 'P'.......!!!");
                }
            } while (true);
            dangkybus.TimKiemSinhVienTheoMaPhong(MaPhong);
        }
        public void TimKiemPhongTheoMaSinhVien()
        {
            Phong_SinhVien psv = new Phong_SinhVien();
            string MaSinhVien;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập mã sinh viên: ");
                        MaSinhVien = Console.ReadLine();
                        if (!(psv.isNumber(MaSinhVien) && MaSinhVien.Length == 8))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự.......!!!");
                        }
                    } while (!(psv.isNumber(MaSinhVien) && MaSinhVien.Length == 8));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời bạn nhập lại mã sinh viên gồm 8 ký tự.......!!!");
                }
            } while (true);
            dangkybus.TimKiemPhongTheoMaSinhVien(MaSinhVien);
        }
        public void TongSoSinhVienDangKy()
        {
            Console.Write("\t\t\t\t\t\t Tổng số lượng sinh viên đã đăng ký: ");
            dangkybus.TongSoLuongSinhVienDangKy();
        }
        public void ThongKeSoLuongPhongConThieuSV()
        {
            Console.Write("\t\t\t\t\t\t Số lượng phòng còn thiếu sinh viên: ");
            dangkybus.ThongKeSoLuongPhongConThieuSV();
        }
        public void TongSoSinhVienDangKyTheoNgay()
        {
            int ngay, thang, nam;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập ngày kết thúc đăng ký: ");
                        ngay = int.Parse(Console.ReadLine());
                        if (!(ngay >= 1 && ngay <= 30))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(ngay >= 1 && ngay <= 30));
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
                        Console.Write("\t\t\t\t\t\t Nhập tháng kết thúc đăng ký: ");
                        thang = int.Parse(Console.ReadLine());
                        if (!(thang >= 1 && thang <= 12))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(thang >= 1 && thang <= 12));
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
                        Console.Write("\t\t\t\t\t\t Nhập năm đăng ký: ");
                        nam = int.Parse(Console.ReadLine());
                        if (!(nam >= 2000 && nam <= 2099))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(nam >= 2000 && nam <= 2099));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            Console.Write("\t\t\t\t\t\t Tổng số lượng sinh viên đăng ký trong ngày {0}/{1}/{2} là: ", ngay, thang, nam);
            dangkybus.TongSoLuongSinhVienDangKyTheoNam(nam);
        }
        public void TongSoSinhVienDangKyTheoThang()
        {
            int thang;
            int nam;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập tháng đăng ký: ");
                        thang = int.Parse(Console.ReadLine());
                        if (!(thang >= 1 && thang <= 12))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(thang >= 1 && thang <= 12));
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
                        Console.Write("\t\t\t\t\t\t Nhập năm đăng ký: ");
                        nam = int.Parse(Console.ReadLine());
                        if (!(nam >= 2015 && nam <= 2099))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(nam >= 2015 && nam <= 2099));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Dữ liệu nhập không đúng. Mời nhập lại.......!!!");
                }
            } while (true);
            Console.Write("\t\t\t\t\t\t Tổng số lượng sinh viên đăng ký trong tháng {0}/{1} là: ", thang, nam);
            dangkybus.TongSoLuongSinhVienDangKyTheoThang(thang, nam);
        }
        public void TongSoSinhVienDangKyTheoNam()
        {
            int namDangKy;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\t\t\t\t\t\t Nhập năm đăng ký: ");
                        namDangKy = int.Parse(Console.ReadLine());
                        if (!(namDangKy >= 2000 && namDangKy <= 2099))
                        {
                            Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                        }
                    } while (!(namDangKy >= 2000 && namDangKy <= 2099));
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("\t\t\t\t\t\t");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\t\t\t\t\t\t Mời nhập lại.......!!!");
                }
            } while (true);
            Console.Write("\t\t\t\t\t\t Tổng số lượng sinh viên đăng ký trong năm {0} là: ", namDangKy);
            dangkybus.TongSoLuongSinhVienDangKyTheoNam(namDangKy);
        }
        public void MenuThongKe()
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║         MENU THỐNG KÊ BÁO CÁO         ║                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚═══════════════════════════════════════╝                              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Tổng số lượng sinh viên đã đăng ký phòng                     ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Thống kê số lượng phòng còn thiếu sinh viên                  ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Thống kê số lượng sinh viên đăng ký phòng theo ngày          ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Thống kê số lượng sinh viên đăng ký phòng theo tháng         ║        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩════════════════════════════════════════════════════════════════════════════╝        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦════════════════════════════════════════════════════════════════════════════╗        ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Thống kê số lượng sinh viên đăng ký phòng theo năm           ║        ║ * ║");
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
                        TongSoSinhVienDangKy();
                        Console.ReadKey(); break;
                    case 2:
                        ThongKeSoLuongPhongConThieuSV();
                        Console.ReadKey();
                        break;
                    case 3:
                        TongSoSinhVienDangKyTheoNgay();
                        Console.ReadKey(); break;
                    case 4:
                        TongSoSinhVienDangKyTheoThang();
                        Console.ReadKey(); break;
                    case 5:
                        TongSoSinhVienDangKyTheoNam();
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
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔════════════════════════════════╗                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║          ĐĂNG KÝ PHÒNG         ║                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚════════════════════════════════╝                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║               Đăng ký phòng                                          ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║               Hiển thị danh sách sinh viên đã đăng ký                ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║               Xóa sinh viên đã đăng ký phòng                         ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║               Tìm kiếm sinh viên theo mã phòng                       ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║               Tìm kiếm phòng theo mã sinh viên                       ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     6      ║               Menu báo cáo thống kê                                  ║              ║ * ║");
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
                            if (s < 0 || s > 6)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t\tMời nhập lại chức năng !!!: ");
                            }
                        } while (s < 0 || s > 6);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\tDữ liệu không đúng, mời nhập lại !!!: ");
                    }
                } while (true);
                //Console.Clear();
                switch (s)
                {

                    case 1:
                        DocPhong_SinhVien();
                        DangKyPhong(); Console.ReadKey(); break;
                    case 2:
                        DocPhong_SinhVien();
                        HienDSSinhVienDangKy(); Console.ReadKey(); break;
                    case 3:
                        DocPhong_SinhVien();
                        XoaSinhVienDaDangKy(); 
                        Console.ReadKey(); break;
                    case 4:
                        DocPhong_SinhVien();
                        TimKiemSinhVienTheoMaPhong();
                        Console.ReadKey(); break;
                    case 5:
                        DocPhong_SinhVien();
                        TimKiemPhongTheoMaSinhVien();
                        Console.ReadKey(); break;
                    case 6:
                        MenuThongKe();
                        break;
                    case 0:
                        end = true;
                        break;
                }
            }
        }
    }
}
