using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TestPhantomJS
{
    public class Program
    {
        private static readonly string BinDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static void Main(string[] args)
        {        
            var targetFile = "test.pdf";
            var outputFile = "Output.html";
            var exeFile = Path.Combine(BinDir, "phantomjs.exe");
            var rasterizeFile = "customRasterize.js";
            var command = $"{rasterizeFile } { outputFile} {targetFile}";
           
            var prg = new Program();
            prg.ExecuteCommandAsync(exeFile, command).Wait();
        }

        /// <summary>
        /// Execute the command Asynchronously.
        /// </summary>
        public async Task ExecuteCommandAsync(string exeFile, string commandArgs)
        {  
            try
            {
                var procStartInfo = new ProcessStartInfo(exeFile,  commandArgs)
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (var process = new Process())
                {               
                    process.StartInfo = procStartInfo;
                    await process.RunAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
            }
        }
    }

    public static class ProcessExtensions
    {
        public static Task RunAsync(this Process process)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();

            process.EnableRaisingEvents = true;

            process.Exited += (s, e) => taskCompletionSource.TrySetResult(null);
       
            if (!process.Start())
                taskCompletionSource.SetException(new Exception($"Failed to start {process.StartInfo.FileName}."));

            return taskCompletionSource.Task;
        }
    }
}
