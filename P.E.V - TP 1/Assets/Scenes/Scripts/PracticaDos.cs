using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

}
