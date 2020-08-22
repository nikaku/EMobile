﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EMobile.BL
{
    public class Helper
    {
        public static string ReturnUniqueValue(DateTime date, string ID)
        {
            var result = default(byte[]);

            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    writer.Write(date.Ticks);
                    writer.Write(ID);
                }

                stream.Position = 0;

                using (var hash = SHA256.Create())
                {
                    result = hash.ComputeHash(stream);
                }
            }

            var text = new string[20];

            for (var i = 0; i < text.Length; i++)
            {
                text[i] = result[i].ToString("x2");
            }

            return string.Concat(text);
        }

        public static byte[] Base64StringToByteArray(string Base64Image)
        {
            byte[] bytes = System.Convert.FromBase64String(Base64Image);
             
            return bytes;
        }
    }
}
