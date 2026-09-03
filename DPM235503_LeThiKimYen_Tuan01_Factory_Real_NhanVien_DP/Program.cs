using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Factory_Real_CacPhuongThucThanhToan_DP
{
    public interface IPhuongThucThanhToan
    {
        void ThanhToan(double soTien);
    }

    public class ThanhToanTienMat : IPhuongThucThanhToan
    {
        public void ThanhToan(double soTien) => Console.WriteLine($"[TIỀN MẶT] Thu tiền trực tiếp: {soTien:N0} VNĐ");
    }

    public class ThanhToanChuyenKhoan : IPhuongThucThanhToan
    {
        public void ThanhToan(double soTien) => Console.WriteLine($"[CHUYỂN KHOẢN BANK] Tạo mã QR ngân hàng: {soTien:N0} VNĐ");
    }

    public class ThanhToanGhiNo : IPhuongThucThanhToan
    {
        public void ThanhToan(double soTien) => Console.WriteLine($"[GHI NỢ / TRẢ CHẬM] Ghi sổ công nợ đại lý: {soTien:N0} VNĐ");
    }

    public abstract class ThanhToanFactory
    {
        public abstract IPhuongThucThanhToan TaoPhuongThucThanhToan();

        public void XuLyThanhToan(double soTien)
        {
            IPhuongThucThanhToan pttt = TaoPhuongThucThanhToan();
            pttt.ThanhToan(soTien);
        }
    }

    public class TienMatFactory : ThanhToanFactory
    {
        public override IPhuongThucThanhToan TaoPhuongThucThanhToan() => new ThanhToanTienMat();
    }

    public class ChuyenKhoanFactory : ThanhToanFactory
    {
        public override IPhuongThucThanhToan TaoPhuongThucThanhToan() => new ThanhToanChuyenKhoan();
    }

    public class GhiNoFactory : ThanhToanFactory
    {
        public override IPhuongThucThanhToan TaoPhuongThucThanhToan() => new ThanhToanGhiNo();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== QUẢN LÝ CÁC PHƯƠNG THỨC THANH TOÁN BÁN HÀNG NÔNG DƯỢC ===");

            ThanhToanFactory factory1 = new TienMatFactory();
            factory1.XuLyThanhToan(450000);

            ThanhToanFactory factory2 = new ChuyenKhoanFactory();
            factory2.XuLyThanhToan(1200000);

            ThanhToanFactory factory3 = new GhiNoFactory();
            factory3.XuLyThanhToan(15000000);

            Console.ReadKey();
        }
    }
}