using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace NeuraNet.FormsApp
{
    internal class InputDigit
    {
        public int Value { get; private set; }
        public int[] Pixels { get; private set; }
        public Bitmap Image { get; private set; }

        private InputDigit()
        {
        }

        public static InputDigit FromInvertedPixels(int value, int[] pixels)
        {
            return new InputDigit
            {
                Value = value,
                Pixels = pixels,
                Image = Invert(CreateImage(pixels))
            };
        }

        public static InputDigit FromImage(int value, Bitmap image)
        {
            return new InputDigit()
            {
                Value = value,
                Image = image,
                Pixels = CreatePixels(Invert(image))
            };
        }

        private static Bitmap CreateImage(int[] invertedPixels)
        {
            int size = (int)Math.Sqrt(invertedPixels.Length);
            var image = new Bitmap(size, size, PixelFormat.Format32bppArgb);
            int currentPixel = 0;

            ForEachPixel(image, (img, x, y) =>
            {
                int value = invertedPixels[currentPixel++];
                img.SetPixel(x, y, Color.FromArgb(value, value, value));
            });

            return image;
        }

        private static Bitmap Invert(Bitmap digitImage)
        {
            Bitmap invertedImage = new Bitmap(digitImage.Width, digitImage.Height);
            ForEachPixel(digitImage, (img, x, y) =>
            {
                Color pixel = img.GetPixel(x, y);
                invertedImage.SetPixel(x, y, Color.FromArgb(255, (255 - pixel.R), (255 - pixel.G), (255 - pixel.B)));
            });

            return invertedImage;
        }

        private static int[] CreatePixels(Bitmap image)
        {
            int[] pixels = new int[image.Width * image.Height];
            int currentPixel = 0;

            ForEachPixel(image, (img, x, y) =>
            {
                Color pixelColor = img.GetPixel(x, y);
                int grayScale = (int)((pixelColor.R * .3) + (pixelColor.G * .59) + (pixelColor.B * .11));
                pixels[currentPixel++] = grayScale;
            });

            return pixels;
        }

        private static void ForEachPixel(Bitmap image, Action<Bitmap, int, int> action)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    action(image, x, y);
                }
            }
        }
    }
}
