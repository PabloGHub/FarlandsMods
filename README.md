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
# Command in Terminal
```csharp
[RegisterCommand(Help = "Descipcion")]
static void CommandCOMANDO_A_ESPECIFICAR(CommandArg[] args)
{
// TODO
}
```
---
# Rules/Normas
* namespace -> FarlandsMods  
* public static main metod/function -> StaticInitMethod()
* name archive = name public class main
---
El Mod FarlandsMods esta en la Rama [master](https://github.com/PabloGHub/FarlandsMods/tree/master)  
The FarlandsMods Mod is in the [master](https://github.com/PabloGHub/FarlandsMods/tree/master) Branch
## Cosas ah añadir
* Sistema para poder utilizar `Start` o `Update` de unity o parecido
>Muchos de estos problemas no se si es por mi falta de experiencia o por estar encriptado el juego
## Original:
https://github.com/avail/UnityAssemblyInjector/blob/vrcmod/README.markdown
