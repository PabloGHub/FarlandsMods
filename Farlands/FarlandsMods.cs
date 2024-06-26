using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace FarlandsMods
{
    public class FarlandsMods
    {
        public static void StaticInitMethod()
        {
            new Thread(() =>
            {
                new FarlandsMods().LoadMods();

                ConsoleHelper.InitializeConsole();
                Thread.Sleep(2000);
                Console.WriteLine("FarlandsMods Iniciado");
            }).Start();
        }


        void LoadMods()
        {
            //alerta("FarlandsMods", "FarlandsMods se ah iniciado");

            // Define la ruta al archivo assemblies.txt
            string _DirecTXT = Path.Combine(UnityEngine.Application.dataPath, "../assemblies.txt");

            if (File.Exists(_DirecTXT))
            {
                // Lee todas las líneas del archivo
                string[] _txt = File.ReadAllLines(_DirecTXT);
                List<string> _mods = new List<string>();


                // Obtener los nombres de los archivos .dll en la carpeta mods
                string _direcMods = Path.Combine(UnityEngine.Application.dataPath, "../mods");
                string[] _dll = Directory.GetFiles(_direcMods, "*.dll");

                foreach (string dllFile in _dll)
                {
                    string modName = Path.GetFileNameWithoutExtension(dllFile);
                    _mods.Add(modName);
                    //UnityEngine.Application.OpenURL("www.google.com/" + "modName en CARPETA: "+modName);
                }


                if (_txt.Length != _dll.Length)
                {
                    reacer(_DirecTXT, _mods);
                    return;
                }


                // Comprueba que cada línea del archivo sea correcta
                // Si no, pararlo y reacer el archivo assemblies.txt
                int _i = 0;
                foreach (string _linea in _txt)
                {
                    String _com = "mods\\\\"+ _mods[_i] +".dll=FarlandsMods." + _mods[_i] + ":StaticInitMethod";

                    if (_linea != _com)
                    {
                        reacer(_DirecTXT, _mods);
                        return;
                    }
                    _i++;
                }

            }
            else
            {
                UnityEngine.Application.OpenURL("www.google.com/" + "No se encontró el archivo assemblies.txt");
            }
        }


        //borar y reacer assemblies.txt 
        void reacer(String _DirecTXT, List<String> _mods)
        {
            String _datos = "";

            foreach (String _mod in _mods)
            {
                _datos += "mods\\\\" + _mod + ".dll=FarlandsMods." + _mod + ":StaticInitMethod\n";
            }

            File.WriteAllText(_DirecTXT, _datos);
            
            Process.Start("Farlands Demo.exe");
            UnityEngine.Application.Quit();
        }



        public ConsoleHelper getConsoleHelper => new ConsoleHelper();
        public class ConsoleHelper
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool AllocConsole();

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool AttachConsole(int dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetConsoleWindow();

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool FreeConsole();

            private const int ATTACH_PARENT_PROCESS = -1;

            public static void InitializeConsole()
            {
                // Intenta adjuntar a la consola del proceso padre (si existe, por ejemplo, si se ejecuta desde CMD)
                if (!AttachConsole(ATTACH_PARENT_PROCESS))
                {
                    // Si no hay una consola para adjuntar, crea una nueva
                    AllocConsole();
                }
            }

            public static void ReleaseConsole()
            {
                // Libera la consola asociada
                FreeConsole();
            }
        }

    }

}

// Define la ruta al archivo assemblies.txt
//string _Ruta = Path.Combine(UnityEngine.Application.dataPath, "../assemblies.txt");


// ConsoleHelper.ReleaseConsole(); // Libera la consola asociada


// ----------------------------------------
/*

 public static void StaticInitMethod()
{
    new Thread(() =>
    {
        ConsoleHelper.InitializeConsole();
        Thread.Sleep(2000);
        Console.WriteLine("FarlandsMods Iniciado");



                
    }).Start();
}

*/


 //mods\\FarlandsMods.dll=FarlandsMods.FarlandsMods:StaticInitMethod
