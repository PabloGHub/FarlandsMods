using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;
using UnityEngine.SceneManagement;
using CommandTerminal;
using HarmonyLib;


/*
 * uso una consola de codigo abierto:
 * https://github.com/stillwwater/command_terminal/tree/master
 * 
 * uso un inyector de dll de codigo abierto:
 * https://github.com/avail/UnityAssemblyInjector
 * 
 * usa:
 * https://github.com/BepInEx/HarmonyX
 */


namespace FarlandsMods
{
    public class FarlandsMods : MonoBehaviour
    {
        public static void StaticInitMethod()
        {
            new Thread(() =>
            {
                FarlandsMods fmod = new FarlandsMods();

                Thread.Sleep(1000);
                fmod.LoadMods();

                SceneManager.LoadScene("MainMenu");
                fmod.crearTerminal();

                Terminal.Log("FarlandsMods Iniciado");

                var _harmony = new Harmony("farlandsmods");
                _harmony.PatchAll();

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



        // ---------------------------------------- Update y Start ---------------------------------------- //





        // ---------------------------------------- TERMINAL ---------------------------------------- //
        void crearTerminal()
        {
            Thread.Sleep(1000);

            GameObject _terminal = new GameObject();
            _terminal.AddComponent<CommandTerminal.Terminal>();

            // buscar el GameManager y añadirle como hijo _terminal
            GameObject _gameManager = GameObject.Find("(singleton) FarlandsGameManager");
            if (_gameManager != null)
            {
                _terminal.transform.SetParent(_gameManager.transform);
            }
            else
            {
                Terminal.Log("No se encontró el GameManager");
            }

            Terminal.Log("Terminal Creada 1");
            UnityEngine.Debug.Log("Terminal Creada 2");
            Console.WriteLine("Terminal Creada 3");
        }





        // --- Comandos Fmods --- //
        [RegisterCommand(Help = "Devuelve el nombre de la escena")]
        static void CommandEscen(CommandArg[] args)
        {
            Scene _escenaActiva = SceneManager.GetActiveScene();
            string _nombreEscena = _escenaActiva.name;
            Terminal.Log("Nombre escena activa: " + _nombreEscena);
        }




        [RegisterCommand(Help = "Devuelve el nombre de todos los objetos de la escena")]
        static void CommandObj(CommandArg[] args)
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject obj in allObjects)
            {
                Terminal.Log("Objeto en la escena: " + obj.name);
                UnityEngine.Application.OpenURL("www.google.com/" + "Objeto en la escena: " + obj.name);
            }
        }
    }

}

/*
    using System;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            // Ruta al archivo .dll
            string dllPath = @"ruta\a\tu\archivo.dll";

            // Cargar el ensamblado
            Assembly assembly = Assembly.LoadFrom(dllPath);

            // Obtener todos los tipos definidos en el ensamblado
            Type[] types = assembly.GetTypes();

            // Mostrar los namespaces de los tipos
            foreach (Type type in types)
            {
                Console.WriteLine($"Namespace: {type.Namespace}, Tipo: {type.Name}");
            }
        }
    }
 */


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


// Direccion al UnityEngine.dll
// C:\Program Files\Unity\Hub\Editor\2021.3.16f1\Editor\Data\Managed\UnityEngine