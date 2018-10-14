﻿using System.Diagnostics;
using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace SharpAudio.ALBinding
{
    public static unsafe partial class AlNative
    {
        private static readonly NativeLibrary m_alLibrary = LoadOpenAL();
        private static NativeLibrary LoadOpenAL()
        {
            string[] names;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                names = new[] { "OpenAL32.dll" };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                names = new[] 
                {
                    "libopenal.so",
                    "libopenal.so.1"
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                names = new[] { "libopenal.dylib" };
            }
            else
            {
                Debug.WriteLine("Unknown OpenAL platform. Attempting to load \"openal\"");
                names = new[] { "openal" };
            }

            Debug.WriteLine("Test");

            NativeLibrary lib = new NativeLibrary(names);
            return lib;
        }

        private static T LoadFunction<T>(string name)
        {
            return m_alLibrary.LoadFunction<T>(name);
        }
    }
}
