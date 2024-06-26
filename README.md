# FarlandsMods
>Repositorio Oficial de FarlandsMods el "Inyector" para el juego Farlands
---
>Para crear un mod solo tenies que hacer algo parecido y FarlandsMods ara el resto para que el Inyector lo introduzca
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
## Original:
https://github.com/avail/UnityAssemblyInjector/blob/vrcmod/README.markdown
