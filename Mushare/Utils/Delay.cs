using System;
using System.Windows.Forms;

namespace Mushare
{
    public static class Delay
    {
        public static void Call(int delay, Action method)
        {
            var t = new Timer
            {
                Enabled = true,
                Interval = delay
            };
            t.Tick += (s, e) =>
            {
                method();
                t.Dispose();
                t = null;
            };
        }
    }
}
