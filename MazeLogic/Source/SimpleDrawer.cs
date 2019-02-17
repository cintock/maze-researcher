using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Logic
{
    class SimpleDrawer : IDisposable
    {
        private Image<Rgba32> image;

        public SimpleDrawer(int width, int height, uint color = 0xffffff)
        {
            Rgba32 internalColor = ConvertColor(color);
            image = new Image<Rgba32>(Configuration.Default, width, height, internalColor);
        }

        private Rgba32 ConvertColor(uint colorValue)
        {
            Rgba32 color = new Rgba32(
                (byte)((colorValue & 0xff0000) >> 16),
                (byte)((colorValue & 0xff00) >> 8),
                (byte)((colorValue & 0xff))            
                );
            return color;
        }

        public void DrawLine(int x1, int y1, int x2, int y2, 
            uint color = 0x000000, int thickness = 1)
        {
            image.Mutate(imageContext =>
            {
                imageContext.DrawLines(
                    ConvertColor(color),
                    thickness,
                    new PointF[] 
                    {
                        new Vector2(x1, y1),
                        new Vector2(x2, y2)
                    }
                );
            }
            );
        }

        public void DrawRect(int x, int y, int width, int height, 
            uint color = 0x000000)
        {
            image.Mutate(imageContext =>
            {
                imageContext.Fill(
                    ConvertColor(color), 
                    new Rectangle(x, y, width, height));
            }
            );
        }

        public byte[] ReadBmpImage()
        {
            byte[] bmpBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                image.SaveAsBmp(stream);
                bmpBytes = stream.ToArray();
            }
            return bmpBytes;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    image.Dispose();
                }

                disposedValue = true;
            }
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
        }
        #endregion
    }
}
