using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Singleton_Real_DangNhap_DP
{
    public sealed class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        public string TenDangNhap { get; private set; }
        public string HoTen { get; private set; }
        public string QuyenHan { get; private set; }
        public bool IsLoggedIn { get; private set; }

        private UserSession() => IsLoggedIn = false;

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool Login(string username, string password)
        {
            if (username == "kimyen" && password == "123456")
            {
                TenDangNhap = username;
                HoTen = "Lê Thị Kim Yến";
                QuyenHan = "NhanVienBanHang";
                IsLoggedIn = true;
                Console.WriteLine($"[ĐĂNG NHẬP THÀNH CÔNG] Xin chào: {HoTen} (Quyền: {QuyenHan})");
                return true;
            }
            Console.WriteLine("[ĐĂNG NHẬP THẤT BẠI] Sai tài khoản hoặc mật khẩu!");
            return false;
        }

        public void Logout()
        {
            if (IsLoggedIn)
            {
                Console.WriteLine($"[ĐĂNG XUẤT] Người dùng {HoTen} đã đăng xuất.");
                IsLoggedIn = false;
            }
        }

        public bool KiemTraQuyen(string quyenYeuCau)
        {
            if (!IsLoggedIn)
            {
                Console.WriteLine(" -> LỖI: Bạn chưa đăng nhập!");
                return false;
            }
            if (QuyenHan == "Admin" || QuyenHan == quyenYeuCau) return true;

            Console.WriteLine($" -> KHÔNG CÓ QUYỀN: Yêu cầu quyền '{quyenYeuCau}'.");
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== NÔNG DƯỢC AN GIANG - QUẢN LÝ ĐĂNG NHẬP & PHÂN QUYỀN ===");

            Console.WriteLine("\n--- KIỂM TRA TRƯỚC KHI ĐĂNG NHẬP ---");
            UserSession.Instance.KiemTraQuyen("NhanVienBanHang");

            Console.WriteLine("\n--- ĐĂNG NHẬP ---");
            UserSession.Instance.Login("kimyen", "123456");

            Console.WriteLine("\n--- KIỂM TRA QUYỀN BÁN HÀNG ---");
            if (UserSession.Instance.KiemTraQuyen("NhanVienBanHang"))
            {
                Console.WriteLine(" -> [SUCCESS] Đã mở giao diện Bán hàng.");
            }

            Console.WriteLine("\n--- ĐĂNG XUẤT ---");
            UserSession.Instance.Logout();

            Console.ReadKey();
        }
    }
}