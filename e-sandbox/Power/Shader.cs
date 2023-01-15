using OpenTK.Compute.OpenCL;
using OpenTK.Graphics.OpenGL4;

namespace Power
{
    internal class Shader : IDisposable
    {
        private bool disposedValue = false;

        private readonly int Handle;




        public Shader(string vertexPath, string fragmentPath)
        {
            string vertexShaderSource = File.ReadAllText(vertexPath);
            string fragmentShaderSource = File.ReadAllText(fragmentPath);

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);

            GL.CompileShader(vertexShader);

            GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(vertexShader);
                Console.WriteLine(infoLog);
            }

            GL.CompileShader(fragmentShader);

            GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(fragmentShader);
                Console.WriteLine(infoLog);
            }

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);
            GL.LinkProgram(Handle);

            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(Handle);
                Console.WriteLine(infoLog);
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(Handle);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(Handle);

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }
    }
}
