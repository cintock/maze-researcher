using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace MazeResearcherWpf
{
    // todo: про этот момент надо основательно подумать
    internal class BitmapImageConverter 
    {
        byte[] image;
        public BitmapImageConverter(byte[] bitmap)
        {
            image = bitmap;
        }

        public BitmapImage Image()
        {
            BitmapImage convertedImage = new BitmapImage();
            using (MemoryStream memoryStream = new MemoryStream(image))
            {
                convertedImage.BeginInit();
                convertedImage.StreamSource = memoryStream;
                convertedImage.CacheOption = BitmapCacheOption.OnLoad;
                convertedImage.EndInit();
            }
            return convertedImage;
        }
    }
}
