using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "Pipec",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            using var window = new Window(GameWindowSettings.Default, nativeWindowSettings);
            window.Run();
        }
    }
}
