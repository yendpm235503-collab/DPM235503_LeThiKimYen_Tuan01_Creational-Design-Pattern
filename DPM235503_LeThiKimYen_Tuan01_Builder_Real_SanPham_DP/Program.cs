using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Builder_Real_SanPham_DP
{
    public class SanPhamNongDuoc
    {
        public string TenSanPham { get; set; }
        public string HoatChatChinh { get; set; }
        public string DungTichQuyCach { get; set; }
        public string HuongDanSuDung { get; set; }
        public bool CoTemChongHangGia { get; set; }

        public void HienThiThongTin()
        {
            Console.WriteLine($"\n--- SẢN PHẨM NÔNG DƯỢC: {TenSanPham} ---");
            Console.WriteLine($"Hoạt chất: {HoatChatChinh}");
            Console.WriteLine($"Quy cách: {DungTichQuyCach}");
            Console.WriteLine($"Hướng dẫn: {HuongDanSuDung}");
            Console.WriteLine($"Tem chống hàng giả: {(CoTemChongHangGia ? "Đã dán tem QR" : "Chưa dán")}");
        }
    }

    public interface ISanPhamBuilder
    {
        void SetTen(string ten);
        void SetHoatChat(string hoatChat);
        void SetQuyCach(string quyCach);
        void SetHuongDan(string huongDan);
        void AttachTemChongHangGia();
        SanPhamNongDuoc GetSanPham();
    }

    public class SanPhamNongDuocBuilder : ISanPhamBuilder
    {
        private SanPhamNongDuoc _sp = new SanPhamNongDuoc();

        public void SetTen(string ten) => _sp.TenSanPham = ten;
        public void SetHoatChat(string hoatChat) => _sp.HoatChatChinh = hoatChat;
        public void SetQuyCach(string quyCach) => _sp.DungTichQuyCach = quyCach;
        public void SetHuongDan(string huongDan) => _sp.HuongDanSuDung = huongDan;
        public void AttachTemChongHangGia() => _sp.CoTemChongHangGia = true;

        public SanPhamNongDuoc GetSanPham()
        {
            SanPhamNongDuoc result = _sp;
            _sp = new SanPhamNongDuoc();
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== TẠO SẢN PHẨM NÔNG DƯỢC VỚI BUILDER PATTERN ===");

            SanPhamNongDuocBuilder builder = new SanPhamNongDuocBuilder();
            builder.SetTen("Thuốc Diệt Cỏ An Giang 500ml");
            builder.SetHoatChat("Glyphosate Acid 480g/l");
            builder.SetQuyCach("Chai nhựa 500ml - Tỷ lệ pha 1:500");
            builder.SetHuongDan("Pha 50ml chế phẩm cho bình 25 lít nước, phun đều mặt lá.");
            builder.AttachTemChongHangGia();

            SanPhamNongDuoc sp = builder.GetSanPham();
            sp.HienThiThongTin();

            Console.ReadKey();
        }
    }
}
