using System;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

class Program
{
    static void Main()
    {
        const string url = "HTTP://DOPISLADILOVI.INFO"; // Uppercase to force alphanumeric
        const string outputPath = @"C:\qr.png";

        var hints = new EncodingOptions
        {
            Height = 21,
            Width = 21,
            Margin = 0,
            PureBarcode = true,
            Hints =
            {
                { EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L },
                { EncodeHintType.CHARACTER_SET, "ISO-8859-1" },
                { EncodeHintType.QR_VERSION, 1 }
            }
        };

        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.QR_CODE,
            Options = hints
        };

        var pixelData = writer.Write(url);

        using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                         System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                         bitmap.PixelFormat);
        try
        {
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }

        bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);

        Console.WriteLine($"QR code successfully saved at {outputPath}");
    }
}