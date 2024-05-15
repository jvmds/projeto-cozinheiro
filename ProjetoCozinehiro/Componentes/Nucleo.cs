using System.Runtime.InteropServices;

namespace ProjetoCozinheiro.Componentes;

public class Nucleo
{
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private const int SW_MAXIMIZE = 3;

    
    public static void Executar()
    {
        if (!(Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX))
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);
        }
    }
}