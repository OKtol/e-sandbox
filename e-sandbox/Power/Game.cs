using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Power
{
    internal class Game : GameWindow
    {
        private int _vertexBufferObject;

        public Game(int width, int height, string title) : base(
            GameWindowSettings.Default,
            new NativeWindowSettings() { Size = (width, height), Title = title })
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            float[] vertices = {
                -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                 0.5f, -0.5f, 0.0f, //Bottom-right vertex
                 0.0f,  0.5f, 0.0f  //Top vertex
            };

            GL.BufferData(BufferTarget.ArrayBuffer,
                vertices.Length * sizeof(float), vertices,
                BufferUsageHint.StaticDraw);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}
