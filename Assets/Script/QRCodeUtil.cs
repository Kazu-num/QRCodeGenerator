using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace QRCodeGenerator
{
    public static class QRCodeUtil
    {
        public static Texture2D Generate(string str, int width = 256, int height = 256)
        {
            var qrTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
            
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = width,
                    Height = height,
                },
            };

            var color32 = writer.Write(str);

            qrTex.SetPixels32(color32);
            qrTex.Apply();

            return qrTex;
        }

        public static string Read(Texture2D texture)
        {
            var reader = new BarcodeReader();
            var color32 = texture.GetPixels32();
            var width = texture.width;
            var height = texture.height;
            return reader.Decode(color32, width, height).Text;
        }
    }
}
