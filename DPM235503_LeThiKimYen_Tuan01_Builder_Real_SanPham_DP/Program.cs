using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Builder_Real_HoaDon_DP
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public List<string> DanhSachSanPham { get; set; } = new List<string>();
        public double TienHang { get; set; }
        public double ChiPhiVanChuyen { get; set; }
        public double ChiPhiDichVuPhu { get; set; }
        public double ChietKhauGiamGia { get; set; }

        public double TongTien => TienHang + ChiPhiVanChuyen + ChiPhiDichVuPhu - ChietKhauGiamGia;

        public void InHoaDon()
        {
            Console.WriteLine($"\n--- HÓA ĐƠN BÁN HÀNG NÔNG DƯỢC [{MaHoaDon}] ---");
            Console.WriteLine($"Sản phẩm: {string.Join(", ", DanhSachSanPham)}");
            Console.WriteLine($"Tiền hàng: {TienHang:N0} VNĐ");
            Console.WriteLine($"Phí vận chuyển: {ChiPhiVanChuyen:N0} VNĐ");
            Console.WriteLine($"Phí dịch vụ phụ: {ChiPhiDichVuPhu:N0} VNĐ");
            Console.WriteLine($"Chiết khấu/Giảm giá: -{ChietKhauGiamGia:N0} VNĐ");
            Console.WriteLine($"==> TỔNG THANH TOÁN: {TongTien:N0} VNĐ");
        }
    }

    public interface IHoaDonBuilder
    {
        void BuildMaHoaDon(string ma);
        void BuildTienHang(List<string> ds, double tienHang);
        void BuildChiPhiVanChuyen(double phiVC);
        void BuildDichVuPhu(double phiDV);
        void BuildChietKhau(double chietKhau);
        HoaDon GetHoaDon();
    }

    public class HoaDonBanHangBuilder : IHoaDonBuilder
    {
        private HoaDon _hoaDon = new HoaDon();

        public void BuildMaHoaDon(string ma) => _hoaDon.MaHoaDon = ma;
        public void BuildTienHang(List<string> ds, double tienHang)
        {
            _hoaDon.DanhSachSanPham = ds;
            _hoaDon.TienHang = tienHang;
        }
        public void BuildChiPhiVanChuyen(double phiVC) => _hoaDon.ChiPhiVanChuyen = phiVC;
        public void BuildDichVuPhu(double phiDV) => _hoaDon.ChiPhiDichVuPhu = phiDV;
        public void BuildChietKhau(double chietKhau) => _hoaDon.ChietKhauGiamGia = chietKhau;

        public HoaDon GetHoaDon()
        {
            HoaDon result = _hoaDon;
            _hoaDon = new HoaDon();
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== LẬP HÓA ĐƠN BÁN HÀNG TẠI CÔNG TY NÔNG DƯỢC AN GIANG ===");
            HoaDonBanHangBuilder builder = new HoaDonBanHangBuilder();

            // Hóa đơn đầy đủ các loại chi phí theo yêu cầu đề bài
            builder.BuildMaHoaDon("HD001");
            builder.BuildTienHang(new List<string> { "Phân bón NPK (Bao 50kg)", "Thuốc diệt cỏ An Giang" }, 2500000);
            builder.BuildChiPhiVanChuyen(150000);
            builder.BuildDichVuPhu(50000);
            builder.BuildChietKhau(200000);

            HoaDon hd = builder.GetHoaDon();
            hd.InHoaDon();

            Console.ReadKey();
        }
    }
}