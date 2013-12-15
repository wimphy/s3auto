using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace s3auto
{
    public class WinAPI
    {
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x209;
        public const int MK_LBUTTON = 0x0001;
        public const int MK_RBUTTON = 0x0002;
        public const int MK_SHIFT = 0x0004;
        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_MOVE = 0x1;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int KEYEVENTF_KEYUP = 2;
        public const byte VK_SHIFT = 16;
        public const byte VK_SPACE = 32;
        public delegate bool CallBack(IntPtr hwnd, IntPtr lParam);

        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rectangle ToRectangle()
            {
                return new Rectangle(Left, Top, Right - Left, Bottom - Top);
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr EnumChildWindows(IntPtr hWndParent, CallBack lpfn, IntPtr lParam); 

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll ", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern IntPtr GetWindowText(IntPtr wnd, StringBuilder text, int len);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder ClassName, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern IntPtr mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll ", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, uint lParam);

        [DllImport("user32.dll ", EntryPoint = "PostMessage")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, uint lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern IntPtr GetCursorPos(out Point p);

        [DllImport("user32.dll")]
        public static extern IntPtr ClientToScreen(IntPtr hWnd, out Rect rect);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(
            byte bVk,
            byte bScan,
            int dwFlags,  //这里是整数类型  0 为按下，2为释放
            int dwExtraInfo  //这里是整数类型 一般情况下设成为 0
        );

        [DllImport("kernel32.dll ", EntryPoint = "GetLastError")]
        public static extern IntPtr GetLastError();

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(
         string lpszDriver,        // driver name驱动名
           string lpszDevice,        // device name设备名
         string lpszOutput,        // not used; should be NULL
         IntPtr lpInitData  // optional printer data
         );
        [DllImport("gdi32.dll")]
        public static extern int BitBlt(
         IntPtr hdcDest, // handle to destination DC目标设备的句柄
         int nXDest,  // x-coord of destination upper-left corner目标对象的左上角的X坐标
         int nYDest,  // y-coord of destination upper-left corner目标对象的左上角的Y坐标
         int nWidth,  // width of destination rectangle目标对象的矩形宽度
         int nHeight, // height of destination rectangle目标对象的矩形长度
         IntPtr hdcSrc,  // handle to source DC源设备的句柄
         int nXSrc,   // x-coordinate of source upper-left corner源对象的左上角的X坐标
         int nYSrc,   // y-coordinate of source upper-left corner源对象的左上角的Y坐标
         UInt32 dwRop  // raster operation code光栅的操作值
         );

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(
         IntPtr hdc // handle to DC
         );

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(
         IntPtr hdc,        // handle to DC
         int nWidth,     // width of bitmap, in pixels
         int nHeight     // height of bitmap, in pixels
         );

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(
         IntPtr hdc,          // handle to DC
         IntPtr hgdiobj   // handle to object
         );

        [DllImport("gdi32.dll")]
        public static extern int DeleteDC(
         IntPtr hdc          // handle to DC
             );

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(
         IntPtr hwnd,               // Window to copy,Handle to the window that will be copied. 
         IntPtr hdcBlt,             // HDC to print into,Handle to the device context. 
         UInt32 nFlags              // Optional flags,Specifies the drawing options. It can be one of the following values. 
         );

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(
         IntPtr hwnd
         );

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hwnd, bool fAltTab);

        [DllImport("user32", EntryPoint = "VkKeyScanEx")]
        public static extern int VkKeyScanEx(
                char ch,
                int dwhkl
        );

        public static uint MAKELONG(ushort x, ushort y)
        {
            return ((((uint)x) << 16) | y);
        }

        public static Bitmap GetWindow(IntPtr hWnd)
        {
            IntPtr hscrdc = GetWindowDC(hWnd);
            Control control = Control.FromHandle(hWnd);
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, control.Width, control.Height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);//删除用过的对象
            DeleteDC(hmemdc);//删除用过的对象
            return bmp;
        }

        public static Bitmap GetPart(int left, int top, int width = 30, int height = 16)
        {
            Bitmap bmp = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = GetColor(left - width / 2 + i, top - height / 2 + j);
                    bmp.SetPixel(i, j, c);
                }
            }
            bmp.Save(DateTime.Now.ToString("yyyyMMddhhhmmss") + ".bmp");
            return bmp;
        }

        public static void Click(int x, int y, bool doubleClick = false, int ms = 2000)
        {
            WinAPI.SetCursorPos(x, y);
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTDOWN | WinAPI.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            if(doubleClick)
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTDOWN | WinAPI.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            System.Threading.Thread.Sleep(ms);
        }

        public static Color GetColor(int x, int y)
        {
            IntPtr hdc = GetWindowDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            DeleteDC(hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        /// <summary>
        /// 模拟输入
        /// </summary>
        /// <param name="str"></param>
        public static void KeyPress(string str)
        {
            for (int i = 0; i < str.Length; i++)//每一个字符分别转成ASCII
            {
                char key = str[i];
                if (key == ' ')
                {
                    keybd_event(VK_SPACE, 0, 0, 0);
                    keybd_event(VK_SPACE, 0, KEYEVENTF_KEYUP, 0);
                }
                else if (key >= '0' && key <= '9')
                {
                    keybd_event((byte)VkKeyScanEx(key, 0), 0, 0, 0);
                    keybd_event((byte)VkKeyScanEx(key, 0), 0, KEYEVENTF_KEYUP, 0);
                }
                else if (key >= 'A' && key <= 'Z')
                {
                    keybd_event(VK_SHIFT, 0, 0, 0);
                    keybd_event((byte)VkKeyScanEx(key, 0), 0, 0, 0);
                    keybd_event((byte)VkKeyScanEx(key, 0), 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                }
                else if (key >= 'a' && key <= 'z')
                {
                    keybd_event((byte)VkKeyScanEx(key, 0), 0, 0, 0);
                    keybd_event((byte)VkKeyScanEx(key, 0), 0, KEYEVENTF_KEYUP, 0);
                }
                else if (key == '\t')
                {
                    keybd_event((byte)Keys.Tab, 0, 0, 0);
                    keybd_event((byte)Keys.Tab, 0, KEYEVENTF_KEYUP, 0);
                }
                else
                {
                    switch (key)
                    {
                        #region keys
                        case '\t':
                            keybd_event((byte)Keys.Tab, 0, 0, 0);
                            keybd_event((byte)Keys.Tab, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case ',':
                            keybd_event((byte)188, 0, 0, 0);
                            keybd_event((byte)188, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '<':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)188, 0, 0, 0);
                            keybd_event((byte)188, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '.':
                            keybd_event((byte)190, 0, 0, 0);
                            keybd_event((byte)190, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '>':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)190, 0, 0, 0);
                            keybd_event((byte)190, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '/':
                            keybd_event((byte)191, 0, 0, 0);
                            keybd_event((byte)191, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '?':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)191, 0, 0, 0);
                            keybd_event((byte)191, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '\\':
                            keybd_event((byte)220, 0, 0, 0);
                            keybd_event((byte)220, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '|':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)220, 0, 0, 0);
                            keybd_event((byte)220, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case ';':
                            keybd_event((byte)186, 0, 0, 0);
                            keybd_event((byte)186, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case ':':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)186, 0, 0, 0);
                            keybd_event((byte)186, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '\'':
                            keybd_event((byte)222, 0, 0, 0);
                            keybd_event((byte)222, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '"':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)222, 0, 0, 0);
                            keybd_event((byte)222, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '[':
                            keybd_event((byte)219, 0, 0, 0);
                            keybd_event((byte)219, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '{':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)219, 0, 0, 0);
                            keybd_event((byte)219, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case ']':
                            keybd_event((byte)219, 0, 0, 0);
                            keybd_event((byte)219, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case ' ':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)221, 0, 0, 0);
                            keybd_event((byte)221, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '-':
                            keybd_event((byte)189, 0, 0, 0);
                            keybd_event((byte)189, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '_':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)189, 0, 0, 0);
                            keybd_event((byte)189, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '=':
                            keybd_event((byte)187, 0, 0, 0);
                            keybd_event((byte)187, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '+':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)187, 0, 0, 0);
                            keybd_event((byte)187, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '`':
                            keybd_event((byte)192, 0, 0, 0);
                            keybd_event((byte)192, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '~':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)192, 0, 0, 0);
                            keybd_event((byte)192, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '!':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)49, 0, 0, 0);
                            keybd_event((byte)49, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '@':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)50, 0, 0, 0);
                            keybd_event((byte)50, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '#':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)51, 0, 0, 0);
                            keybd_event((byte)51, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '$':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)52, 0, 0, 0);
                            keybd_event((byte)52, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '%':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)53, 0, 0, 0);
                            keybd_event((byte)53, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '^':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)54, 0, 0, 0);
                            keybd_event((byte)54, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '&':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)55, 0, 0, 0);
                            keybd_event((byte)55, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '*':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)56, 0, 0, 0);
                            keybd_event((byte)56, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case '(':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)57, 0, 0, 0);
                            keybd_event((byte)57, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case ')':
                            keybd_event(VK_SHIFT, 0, 0, 0);
                            keybd_event((byte)48, 0, 0, 0);
                            keybd_event((byte)48, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        #endregion
                    }
                }
            }
        }
    }
}
