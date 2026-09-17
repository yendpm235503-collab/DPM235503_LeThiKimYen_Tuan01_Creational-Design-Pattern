using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Prototype_Real_HoaDon_DP
{
    public class HoaDonMau
    {
        public string LoaiHoaDon { get; set; }
        public double ThueVAT { get; set; }
        public string ThongTinCongTy { get; set; }
        public string TenKhachHang { get; set; }
        public double TongTien { get; set; }

        public HoaDonMau Clone() => (HoaDonMau)this.MemberwiseClone();

        public void InHoaDon()
        {
            Console.WriteLine($"[{LoaiHoaDon}] {ThongTinCongTy} | Thuế: {ThueVAT}% | Khách: {TenKhachHang} | Tổng tiền: {TongTien:N0} VNĐ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== SAO CHÉP HÓA ĐƠN MẪU TẠI CÔNG TY NÔNG DƯỢC AN GIANG ===");

            HoaDonMau hdMau = new HoaDonMau
            {
                LoaiHoaDon = "HÓA ĐƠN BÁN LẺ",
                ThueVAT = 8,
                ThongTinCongTy = "Công Ty Nông Dược An Giang - Chi Nhánh Long Xuyên"
            };

            HoaDonMau hd1 = hdMau.Clone();
            hd1.TenKhachHang = "Nguyễn Văn Nông";
            hd1.TongTien = 1250000;
            hd1.InHoaDon();

            HoaDonMau hd2 = hdMau.Clone();
            hd2.TenKhachHang = "Trần Thị Ruộng";
            hd2.TongTien = 3400000;
            hd2.InHoaDon();

            Console.ReadKey();
        }
    }
}
