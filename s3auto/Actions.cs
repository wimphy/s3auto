using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace s3auto
{
    public class Actions
    {
        public void Start(IntPtr handle)
        {
            WinAPI.Rect rect = new WinAPI.Rect();
            WinAPI.GetWindowRect(handle, out rect);

            WinAPI.SetCursorPos(rect.Left, rect.Top);
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, 100, 13, 0, 0);
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTDOWN | WinAPI.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public void zhichi(int x, int y)
        {
            /*697,310
            791,334
            382,466
            382,533*/
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, x+697, y+310, 0, 0);
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTDOWN | WinAPI.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(1000);

            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, x+791, y+334, 0, 0);
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTDOWN | WinAPI.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(1000);

            for (int i = 0; i < 40; i++)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, x+382, y+466, 0, 0);
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTDOWN | WinAPI.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(30000);
            }

            for (int i = 0; i < 40; i++)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, x+382, y+533, 0, 0);
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTDOWN | WinAPI.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(30000);
            }
        }
    }
}
