# FarlandsMods
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
El Mod FarlandsMods esta en la Rama `master`  
The FarlandsMods Mod is in the `master` Branch
## Original:
https://github.com/avail/UnityAssemblyInjector/blob/vrcmod/README.markdown
