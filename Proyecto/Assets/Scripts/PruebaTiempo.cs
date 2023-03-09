using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaTiempo : MonoBehaviour
{
    public int dias = 0;
    public int dia = 0;
    public bool tiempo = true;
    public float tiempoRestante = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        tiempo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempo)
        {
            if (tiempo)
            {
                if(tiempoRestante < 10)
                {
                    tiempoRestante += Time.deltaTime;
                }
                else
                {
                    dia += 1;
                    tiempoRestante = 0;
                    GetComponent<MovimientoJugador>().velocidad -= 1;
                    if(GetComponent<MovimientoJugador>().velocidad == 0)
                    {
                        GetComponent<MovimientoJugador>().enabled = false;
                        GetComponent<Animator>().enabled = false;
                        Debug.Log("TAS MUERTO DE SUEÑO");
                    }

                }
            }
        }
    }

}
