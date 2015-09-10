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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace HashStudentIDSample
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2 || string.Equals(args[0], "-h", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Syntax: HashStudentIdSample <studentId> <hashKeyPassPhrase>");
            }
            else
            {
                Console.WriteLine("Alternate student ID is:");
                StudentIdHasher hasher = new StudentIdHasher(args[1]);
                Console.WriteLine(hasher.HashStudentId(args[0]));
            }

            // If running outside of a command-line shell, let the user see the output before closing.
            if (ConsoleHelper.IsSoleConsoleOwner)
            {
                Console.WriteLine();
                Console.Write("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }

    static class ConsoleHelper
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint GetConsoleProcessList(
            uint[] ProcessList,
            uint ProcessCount
            );

        public static bool IsSoleConsoleOwner
        {
            get
            {
                uint[] procIds = new uint[4];
                uint count = GetConsoleProcessList(procIds, (uint)procIds.Length);
                return count <= 1;
            }
        }
    }
}
