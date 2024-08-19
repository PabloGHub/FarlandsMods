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


/*
 * uso una consola de codigo abierto:
 * https://github.com/stillwwater/command_terminal/tree/master
 * 
 * uso un inyector de dll de codigo abierto:
 * https://github.com/avail/UnityAssemblyInjector
 * 
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
                fmod.LoadMods();
                fmod.crearTerminal();


                Terminal.Log("FarlandsMods Iniciado");

            }).Start();

        }


        void LoadMods()
        {

            string _DirecFCMinstalado = Path.Combine(Application.dataPath, "../BepInEx/plugins/FarlandsCoreMod.dll");
            string _DirecFCM = Path.Combine(Application.dataPath, "../BepInEx/plugins/FarlandsCoreMod.dll");

            if (!File.Exists(_DirecFCMinstalado))
            {
                if (File.Exists(_DirecFCM))
                {
                    File.Move(_DirecFCM, _DirecFCMinstalado);
                    UnityEngine.Debug.Log("FarlandsCoreMod movido a carpeta");

                    if (Process.Start("Farlands.exe") == null)
                    {
                        Process.Start("Farlands Demo.exe");
                    }
                    UnityEngine.Application.Quit();
                }
                else
                {
                    UnityEngine.Debug.Log("FarlandsCoreMod no detectado");
                }
            }
            else
            {
                UnityEngine.Debug.Log("No primera inicializacion detectada");
            }

        }
        




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


        [RegisterCommand(Help = "Carga la escena indicada por nombre")]
        static void Commandtp(CommandArg[] args)
        {
            string _nombreEscena = args[0].String;
            SceneManager.LoadScene(_nombreEscena);
            Terminal.Log("Cargando escena: " + _nombreEscena);
        }


        [RegisterCommand(Help = "Carga la escena indicada por indice")]
        static void Commandtpi(CommandArg[] args)
        {
            int _indiceEscena = args[0].Int;
            SceneManager.LoadScene(_indiceEscena);
            Terminal.Log("Cargando escena: " + _indiceEscena);
        }


        /*
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
        */
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