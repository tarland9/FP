﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class PasswordHasher
    {
        public static string Encrypt(string password)
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        public static string Decrypt(string hashedPassword)
        {
            Encoding encoding = new UTF8Encoding();
            Decoder utf8Decode = encoding.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(hashedPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new string(decoded_char);
            return result;
        }
    }
}