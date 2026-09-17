using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Abstract_Real_GiaoDien_DP
{
    public interface IButton { void Render(); }
    public interface ITextBox { void Render(); }

    public class LightButton : IButton { public void Render() => Console.WriteLine("[Nút bấm Sáng] Viền xám, nền trắng, chữ đen."); }
    public class DarkButton : IButton { public void Render() => Console.WriteLine("[Nút bấm Tối] Viền xanh, nền đen, chữ trắng."); }

    public class LightTextBox : ITextBox { public void Render() => Console.WriteLine("[Ô nhập Sáng] Nền trắng, chữ đen."); }
    public class DarkTextBox : ITextBox { public void Render() => Console.WriteLine("[Ô nhập Tối] Nền xám đậm, chữ trắng."); }

    public interface IUIFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }

    public class LightThemeFactory : IUIFactory
    {
        public IButton CreateButton() => new LightButton();
        public ITextBox CreateTextBox() => new LightTextBox();
    }

    public class DarkThemeFactory : IUIFactory
    {
        public IButton CreateButton() => new DarkButton();
        public ITextBox CreateTextBox() => new DarkTextBox();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== HỆ THỐNG GIAO DIỆN PHẦN MỀM NÔNG DƯỢC AN GIANG ===");

            Console.WriteLine("\n--- Giao diện Chế độ Sáng (Light Theme) ---");
            IUIFactory lightFactory = new LightThemeFactory();
            lightFactory.CreateButton().Render();
            lightFactory.CreateTextBox().Render();

            Console.WriteLine("\n--- Giao diện Chế độ Tối (Dark Theme) ---");
            IUIFactory darkFactory = new DarkThemeFactory();
            darkFactory.CreateButton().Render();
            darkFactory.CreateTextBox().Render();

            Console.ReadKey();
        }
    }
}
