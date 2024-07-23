# FarlandsMods
[How To Install](https://youtu.be/Gpo-QAMXKro)
>Repositorio Oficial de FarlandsMods el "Inyector" para el juego Farlands  
>Official Repository of FarlandsMods the "Injector" for the game Farlands
---
>Para crear un mod solo tenies que hacer algo parecido y FarlandsMods ara el resto para que el Inyector lo introduzca  
>To create a mod you just had to do something similar and FarlandsMods plow the rest for the Injector to insert
```csharp
namespace FarlandsMods
{
    public class Nombre_Del_Archivo // Mismo Nombre Exacto
    {
        public static void StaticInitMethod()
        {
            new Thread(() =>
            {
                Thread.Sleep(2000); 
                // Código a ejecutar

            }).Start();
        }
    }
}
```
---
El Mod FarlandsMods esta en la Rama [master](https://github.com/PabloGHub/FarlandsMods/tree/master)  
The FarlandsMods Mod is in the [master](https://github.com/PabloGHub/FarlandsMods/tree/master) Branch
## Cosas ah añadir
* Sistema de Debug para que se pueda poner Console.writer
* Sistema para poder utilizar `Start` o `Update` de unity o parecido
* Sistema para poder añadir un script a un objeto
>Muchos de estos problemas no se si es por mi falta de experiencia o por estar encriptado el juego
## Original:
https://github.com/avail/UnityAssemblyInjector/blob/vrcmod/README.markdown
