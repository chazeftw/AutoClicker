using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AutoClicker
{
    // Class code credit to: http://stackoverflow.com/questions/2416748/how-to-simulate-mouse-click-in-c

    public class MouseOperations
    {
        /// <summary>
        /// Enums for hex codes of mouse flag events
        /// </summary>
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        /// <summary>
        /// Import DLL that contains function for setting cursor position
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// Import DLL that contains function for getting cursor position
        /// </summary>
        /// <param name="lpMousePoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        /// <summary>
        /// Import DLL that contains function to call specified event
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dwData"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// Implementation of DLL imported function
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public static void SetCursorPosition(int X, int Y)
        {
            SetCursorPos(X, Y);
        }

        /// <summary>
        /// Implementation of DLL imported function
        /// </summary>
        /// <param name="point"></param>
        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        /// <summary>
        /// Implementation of DLL imported function
        /// </summary>
        /// <returns></returns>
        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        /// <summary>
        /// Implementation of DLL imported function that can inflict a mouse event
        /// </summary>
        /// <param name="value"></param>
        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        /// <summary>
        /// Struct used for 2D point of mouse
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }

        }

    }
}

