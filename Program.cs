using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

class Program
{
    static bool EsVocal(char letra)
    {
        return "aeiouáéíóú".Contains(char.ToLower(letra)); // verifico si la letra es una vocal o no con el metodo Contains.
    }

    static string TraducirPalabra(string palabra)
    {
        palabra = palabra.ToLower(); // convierte la palabra a minuscula.

        bool empiezaConVocal = EsVocal(palabra[0]); // usa la funcion para verificar si es vocal o no y se guarda como bool.


        // regla 2: Duplicar la primera vocal si la segunda letra no es una vocal.

        // verifica que cumpla con las 3 condiciones, si empieza con vocal, si la palabra es mayor a 2 y si la segunda letra no es una vocal.
        if (empiezaConVocal && palabra.Length >= 2 && !EsVocal(palabra[1])) 
        {
            palabra = palabra[0] + palabra + palabra.Substring(1); // tengo una subcadena desde la segunda letra hasta el final.
        }

        // regla 3: agregar "an" al principio si la palabra tiene mas de 6 letras.
        if (palabra.Length > 6)
        {
            palabra = "an" + palabra;
        }


        // regla 4: agregar "sten" al final, o "so" si la ultima letra es 'o'.

        char ultimaLetra = palabra.Last(); // usamos el metodo Last() para obtener la ultima letra de la palabra.

        if(ultimaLetra == 'n' || ultimaLetra == 's' || EsVocal(ultimaLetra))
        {
            if (ultimaLetra != 'o') // verifica si la palabra no termina en la vocal 'o'
            {
                palabra += "sten";
            }
            else
            {
                palabra += "so";
            }
        }

        return palabra;
    }

    static string TraducirFrase(string frase)
    {
        // dividir la frase en palabras separadas por espacio.
        string[] palabras = frase.Split(' ');

       // creamos una lista donde se van a guardar las palabras traducidas y la inicializamos vacia con ().
        List<string> palabrasTraducidas = new List<string>();

        foreach(string palabra in palabras)
        {
            palabrasTraducidas.Add(TraducirPalabra(palabra)); // usamos el metodo Add() para agregar un objeto al final de la Lista.
        }

        return string.Join(" ", palabrasTraducidas); // usamos el metodo Join() para concatenar un espacio con cada palabra traducida para retornarlo como string.
    }

    static void Main(string[] args)
    {
        // creamos una lista para guardar la frase a traducir y la inicializamos con la frase.
        List<string> fraseATraducir = new List<string>
        {
            "Hola que tal, aca iria la frase a traducir",
            "pueden ser varias y separadas por comas para que sea mas facil de leer"
        };


        // loop para ejecutar la funcion TraducirFrase por cada frase separada por coma, e imprimirla.
        foreach (string frase in fraseATraducir) 
        {
            string fraseTraducida = TraducirFrase(frase);
            Console.WriteLine(fraseTraducida);
        }
    }
}
