using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.DataAccess;
using QuanLyHoatDongDangKyPhongKyTucXa_3Layers.View;

namespace QuanLyHoatDongDangKyPhongKyTucXa_3Layers
{
    class Program
    {
        
        static void Bia()
        {

            Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║              -*-  CHƯƠNG TRÌNH XÂY DỰNG ỨNG DỤNG QUẢN LÝ HOẠT ĐỘNG ĐĂNG KÝ PHÒNG KÝ TÚC XÁ  -*-              ║");
            Console.WriteLine("\t\t\t\t\t║                          -*-  TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN   -*-                                 ║");
            Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║ *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ║");
            Console.WriteLine("\t\t\t\t\t║ * ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                      ***                                                             ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                       ***               ***                                          ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                              ****      ***             ***                                           ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                            **    **                   ***                                            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                          ***      ***                                                                ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║          ********           ******                ****         ***     **             ***            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║          **      **      ***      ***            **  **        ****    **          ******            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║          **        **   **          **          **    **       ** **   **        **   ***            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║        *****       **   **          **         **********      **  **  **             ***            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║          **        **   **          **        **        **     **   ** **             ***            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║          **      **      ***      ***        **          **    **    ****             ***            ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║          ********           ******          **            **   **     ***        *************       ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ╔══════════════════════════════════════════════════════════════╗               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ║    CHƯƠNG TRÌNH QUẢN LÝ HOẠT ĐỘNG ĐĂNG KÝ PHÒNG KÝ TÚC XÁ    ║               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ╠══════════════════════╦═══════════════════════════════════════╣               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ║ Giảng viên hướng dẫn ║          Chu Thị Minh Huệ             ║               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ╠══════════════════════╬═══════════════════════════════════════╣               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ║      Thực hiện       ║          Nguyễn Cư Sơn                ║               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                       ╚══════════════════════╩═══════════════════════════════════════╝               ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                  Nhấn Enter để vào menu chính                                        ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
            Console.WriteLine("\t\t\t\t\t║ * ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝ * ║");
            Console.WriteLine("\t\t\t\t\t║ *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ║");
            Console.WriteLine("\t\t\t\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        
        }
        static void Menu()
        {
            bool end = false;
            while (!end)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t║              -*-  CHƯƠNG TRÌNH XÂY DỰNG ỨNG DỤNG QUẢN LÝ HOẠT ĐỘNG ĐĂNG KÝ PHÒNG KÝ TÚC XÁ  -*-              ║");
                Console.WriteLine("\t\t\t\t\t║                          -*-  TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN   -*-                                 ║");
                Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("\t\t\t\t\t║ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ** ║");
                Console.WriteLine("\t\t\t\t\t║ * ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╔════════════════════════════════╗                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ║          MENU LỰA CHỌN         ║                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                               ╚════════════════════════════════╝                                     ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     1      ║              Quản lý hợp đồng                                        ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     2      ║              Quản lý sinh viên                                       ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     3      ║              Quản lý nhân viên                                       ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     4      ║              Quản lý phòng ký túc xá                                 ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     5      ║              Đăng ký phòng                                           ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╔════════════╦══════════════════════════════════════════════════════════════════════╗              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ║     0      ║              Thoát khỏi chương trình                                 ║              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║   ╚════════════╩══════════════════════════════════════════════════════════════════════╝              ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ║                                                                                                      ║ * ║");
                Console.WriteLine("\t\t\t\t\t║ * ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝ * ║");
                Console.WriteLine("\t\t\t\t\t║ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ** ║");
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
                        QuanLyHopDongView hopdong = new QuanLyHopDongView();
                        hopdong.HienMenu();
                        break;
                    case 2:
                        QuanLySinhVienView sinhvien = new QuanLySinhVienView();
                        sinhvien.HienMenu();
                        break;
                    case 3:
                        QuanLyNhanVienView nhanvien = new QuanLyNhanVienView();
                        nhanvien.HienMenu();
                        break;
                    case 4:
                        QuanLyPhongView phong = new QuanLyPhongView();
                        phong.HienMenu();
                        break;
                    case 5:
                        DangKyPhongView psvView = new DangKyPhongView();
                        psvView.HienMenu();
                        break;
                    case 0: end = true; break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo kt;
            Bia();
            kt = Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
