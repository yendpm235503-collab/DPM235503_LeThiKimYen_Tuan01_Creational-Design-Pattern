using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Factory_Real_NhanVien_DP
{
    public abstract class NhanVien
    {
        public string HoTen { get; set; }
        public abstract void TinhLuong();
    }

    public class NhanVienBanHang : NhanVien
    {
        public override void TinhLuong() => Console.WriteLine($"[BÁN HÀNG] NV {HoTen}: Lương cơ bản + Doanh số bán thuốc nông dược.");
    }

    public class NhanVienKho : NhanVien
    {
        public override void TinhLuong() => Console.WriteLine($"[KHO] NV {HoTen}: Lương cơ bản + Phụ cấp độc hại & bốc xếp.");
    }

    public abstract class NhanVienFactory
    {
        public abstract NhanVien TaoNhanVien(string hoTen);
    }

    public class BanHangFactory : NhanVienFactory
    {
        public override NhanVien TaoNhanVien(string hoTen) => new NhanVienBanHang { HoTen = hoTen };
    }

    public class KhoFactory : NhanVienFactory
    {
        public override NhanVien TaoNhanVien(string hoTen) => new NhanVienKho { HoTen = hoTen };
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== CÔNG TY NÔNG DƯỢC AN GIANG - QUẢN LÝ NHÂN VIÊN ===");

            NhanVienFactory f1 = new BanHangFactory();
            NhanVien nv1 = f1.TaoNhanVien("Lê Thị Kim Yến");
            nv1.TinhLuong();

            NhanVienFactory f2 = new KhoFactory();
            NhanVien nv2 = f2.TaoNhanVien("Nguyen Van A");
            nv2.TinhLuong();

            Console.ReadKey();
        }
    }
}
