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
        // no se si era optimo o si lo vimos

        if (timer >= tiempoLimite)
        {
            ModificacionDeArrays();
        }
    }

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

    public void ModificacionDeArrays()
    {

        // Este arreglo podría tener un scope más global, lo dejé acá simplemente para no toparme con él apenas ingreso al código 
        // así quedaban más separadas las funciones y actividades 
        // pero si su uso fuese más general a lo largo del script 
        // (como por ej, valores dinámicos para dar sensación de aleatoriedad o correspondencia) lo pondría más arriba

        int[] arreglo = { 97, -64, -3, -58, -15, 58, 51, 38, -31, -37 };

        // Evite gpt así que sume que imprima por cada elemento del arreglo, me hubiese gustado imprimir el arreglo completo 
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
