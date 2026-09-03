using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Abstract_Real_XuLyDonHang_DP
{
    public interface IHoaDon { void InHoaDon(); }
    public class HoaDonBanSi : IHoaDon
    {
        public void InHoaDon() => Console.WriteLine("[HÓA ĐƠN BÁN SỈ] Áp dụng chiết khấu đại lý & hỗ trợ phí vận chuyển.");
    }
    public class HoaDonBanLe : IHoaDon
    {
        public void InHoaDon() => Console.WriteLine("[HÓA ĐƠN BÁN LẺ] Tính theo giá niêm yết lẻ & kèm phí dịch vụ phụ.");
    }

    public interface IPhieuXuatKho { void InPhieuXuat(); }
    public class PhieuXuatKhoBanSi : IPhieuXuatKho
    {
        public void InPhieuXuat() => Console.WriteLine("[PHIẾU XUẤT SỈ] Xuất kho theo lô lớn / container.");
    }
    public class PhieuXuatKhoBanLe : IPhieuXuatKho
    {
        public void InPhieuXuat() => Console.WriteLine("[PHIẾU XUẤT LẺ] Xuất kho lẻ theo chai / gói.");
    }

    public interface IXuLyDonHangFactory
    {
        IHoaDon TaoHoaDon();
        IPhieuXuatKho TaoPhieuXuatKho();
    }

    public class BanSiFactory : IXuLyDonHangFactory
    {
        public IHoaDon TaoHoaDon() => new HoaDonBanSi();
        public IPhieuXuatKho TaoPhieuXuatKho() => new PhieuXuatKhoBanSi();
    }

    public class BanLeFactory : IXuLyDonHangFactory
    {
        public IHoaDon TaoHoaDon() => new HoaDonBanLe();
        public IPhieuXuatKho TaoPhieuXuatKho() => new PhieuXuatKhoBanLe();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== CÔNG TY NÔNG DƯỢC AN GIANG - XỬ LÝ ĐƠN HÀNG SỈ VÀ LẺ ===");

            Console.WriteLine("\n--- ĐƠN HÀNG BÁN SỈ ---");
            IXuLyDonHangFactory factorySi = new BanSiFactory();
            factorySi.TaoHoaDon().InHoaDon();
            factorySi.TaoPhieuXuatKho().InPhieuXuat();

            Console.WriteLine("\n--- ĐƠN HÀNG BÁN LẺ ---");
            IXuLyDonHangFactory factoryLe = new BanLeFactory();
            factoryLe.TaoHoaDon().InHoaDon();
            factoryLe.TaoPhieuXuatKho().InPhieuXuat();

            Console.ReadKey();
        }
    }
}