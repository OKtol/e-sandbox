using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power
{
    internal class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(
            GameWindowSettings.Default,
            new NativeWindowSettings() { Size = (width, height), Title = title })
        {

        }
    }
}
