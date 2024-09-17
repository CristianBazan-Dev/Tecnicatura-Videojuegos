using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float timer = 0f;
    float tiempoLimite = 4.5f;
    void Start()
    {

        // Ejercicio 2: Usar la Función con Valores Aleatorios en Unity. 
        // Acá tuve que especificar que se trataba del Random de UnityEngine ya que el debugger me comentaba que podía ser también la del System.
        // Se aplica un rango con parámetros minimo/máximo para obtener el aleatorio entre ellos (discusión sobre la existencia de la aleatoriedad en programación aparte)

        float val1 = UnityEngine.Random.Range(-100.0f, 100.0f);
        float val2 = UnityEngine.Random.Range(-100.0f, 100.0f);
        float val3 = UnityEngine.Random.Range(-100.0f, 100.0f);

        // Dejo este por acá para testear la validación del mayor fuera de rango
        // float val3 = UnityEngine.Random.Range(-100.0f, 120.0f);

        string promedio = Promedio(val1, val2, val3);
        Debug.Log(promedio);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Habría preferido ir por == para que se ejecute una sola vez, 
        // pero eso tal vez suponia redondear tanto el timer como el tiempoLimite así que lo evite porque 
        // no se si era optimo, si lo vimos o si iba a salir bien.

        if (timer >= tiempoLimite)
        {
            ModificacionDeArrays();
        }
    }


    // Ejercicio 1: Buscando promedio mediante condicionales. 

    // En este caso, se opera con 3 variables de punto flotante para aprovechar la libreria Mathf, así se obtiene el valor máximo y mínimo. 
    // Una vez obtenidos ambos valores, se aplican condiciones sobre ellos para ver si cumplen con los requisitos solicitados. 
    // Las condiciones operan como validaciones, ya que retornaran una alerta antes de proceder con el verdadero retorno: la string que retorna el promedio entre ambos
    public string Promedio(float val1, float val2, float val3)
    {
        float minValue = Mathf.Min(val1, val2, val3);
        float maxValue = Mathf.Max(val1, val2, val3);

        if (maxValue > 100)
        {
            return "Mayor fuera de rango";
        }

        if (minValue < 0)
        {
            return "Menor fuera de rango";
        }

        // Acá podrían haber dos alternativas: 
        // o se pasan las validaciones debido al retorno de cada uno y se considera el retorno del promedio como el valor buscado (que es la opción por la que estoy yendo)
        // o se añade una tercera validación que incluya la superación previa de las condiciones dados sus contrarios (maxValue < 100 && minValue > 0) en caso de que el retorno final fuese otro

        float promedio = (minValue + maxValue) / 2;
        return $"El valor promedio es {promedio}";
    }

    // Ejercicio 3: Ciclo para Modificar un Array de 10 Campos con Temporizador Manual
    // Procede a operar con un arreglo inicial, de tipo int. Tomando la extensión (el length), se utiliza un ciclo for para aplicar una validación dónde se opere con los pares.
    // Esta validación toma en cuenta el resto de la división aplicando la lógica de los pares (dónde al dividir entre 2, su resto es 0)
    // Dado que va contando el indice en el acumulador i, aprovecho para modificar esa posición actual con su multiplicación * 2.
    // Ahora bien, el problema no dejaba en claro si se trataba de aplicar la multiplicación o de duplicar el elemento, en ese caso habría que utilizar algún método para utilizar el valor de dicha posición en su posición siguiente 
    // o algún método especifico de arrays (como el .push de js o el .append de python)

    public void ModificacionDeArrays()
    {

        // Este arreglo podría tener un scope más global, lo dejé acá simplemente para no toparme con él apenas ingreso al código 
        // así quedaban más separadas las funciones y actividades 
        // pero si su uso fuese más general a lo largo del script 
        // (como por ej, valores dinámicos para dar sensación de aleatoriedad o correspondencia) lo pondría más arriba

        int[] arreglo = { 97, -64, -3, -58, -15, 58, 51, 38, -31, -37 };

        // Evite gpt así que sumé que imprima por cada elemento del arreglo, me hubiese gustado imprimir el arreglo completo 
        // pero al hacerlo solo se mostraba el tipo.

        Debug.Log("Arreglo modificado: ");
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i] % 2 == 0)
            {
                arreglo[i] = arreglo[i] * 2;
            }

            Debug.Log(arreglo[i]);
        }

    }
}
