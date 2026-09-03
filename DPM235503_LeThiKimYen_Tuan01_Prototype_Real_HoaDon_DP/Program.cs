using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Prototype_Real_GiamGia_DP
{
    public class ChuongTrinhGiamGia
    {
        public string MaChuongTrinh { get; set; }
        public string TenChuongTrinh { get; set; }
        public double TileGiamGia { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public ChuongTrinhGiamGia Clone() => (ChuongTrinhGiamGia)this.MemberwiseClone();

        public void HienThi()
        {
            Console.WriteLine($"[{MaChuongTrinh}] {TenChuongTrinh} | Giảm: {TileGiamGia}% | Từ {NgayBatDau:dd/MM/yyyy} đến {NgayKetThuc:dd/MM/yyyy}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== QỦAN LÝ CHƯƠNG TRÌNH GIẢM GIÁ NÔNG DƯỢC ===");

            ChuongTrinhGiamGia mauGiamGia = new ChuongTrinhGiamGia
            {
                MaChuongTrinh = "KM_VUAMUA_2026",
                TenChuongTrinh = "Khuyến mãi Mùa Vụ Thu Đông",
                TileGiamGia = 10,
                NgayBatDau = new DateTime(2026, 9, 1),
                NgayKetThuc = new DateTime(2026, 9, 30)
            };

            Console.WriteLine("Chương trình giảm giá gốc:");
            mauGiamGia.HienThi();

            // Nhân bản và tùy chỉnh cho đối tượng Đại lý VIP
            ChuongTrinhGiamGia giamGiaDaiLy = mauGiamGia.Clone();
            giamGiaDaiLy.MaChuongTrinh = "KM_DAILY_VIP";
            giamGiaDaiLy.TenChuongTrinh = "Khuyến mãi VIP dành cho Đại Lý";
            giamGiaDaiLy.TileGiamGia = 20;

            Console.WriteLine("\nChương trình giảm giá sau khi nhân bản:");
            giamGiaDaiLy.HienThi();

            Console.ReadKey();
        }
    }
}