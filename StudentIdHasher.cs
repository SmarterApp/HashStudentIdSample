/*
 * This sample demonstrates securely hashing a student ID into an alternate
 * student ID that is suitable for de-identified test results. It uses the
 * HMAC-SHA1 keyed-hash algorithm. The technique is appropriate for other
 * digital signature applications.
 * 
 * Written by Brandt Redd
 * Released under a Creative Commons CC0 Dedication
 * http://creativecommons.org/publicdomain/zero/1.0/
 * To the extent possible under law, Brandt Redd has waived all copyright
 * and related or neighboring rights to Hash Student ID Sample. This work
 * is published from: United States
 */
using System;
using System.Text;
using System.Security.Cryptography;

namespace HashStudentIDSample
{
    class StudentIdHasher
    {
        static readonly UTF8Encoding s_UTF8NoByteOrderMark = new UTF8Encoding(false);

        byte[] m_hashKey;

        public StudentIdHasher(string passPhrase)
        {
            // Use SHA1 to generate a hash key from the passphrase
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] pfb = s_UTF8NoByteOrderMark.GetBytes(passPhrase.Trim());
            m_hashKey = sha.ComputeHash(pfb);
        }

        public string HashStudentId(string studentId)
        {
            // Use HMAC to calculate the hash
            HMACSHA1 hmac = new HMACSHA1(m_hashKey);
            byte[] bid = s_UTF8NoByteOrderMark.GetBytes(studentId.Trim());
            byte[] hash = hmac.ComputeHash(bid);
            return ByteArrayToHexString(hash);
        }

        static string ByteArrayToHexString(byte[] inputArray)
        {
            if (inputArray == null) return null;
            StringBuilder o = new StringBuilder();
            for (int i = 0; i < inputArray.Length; i++) o.Append(inputArray[i].ToString("X2"));
            return o.ToString();
        }
    }
}
