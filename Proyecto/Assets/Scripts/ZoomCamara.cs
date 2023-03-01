using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamara : MonoBehaviour
{
    private float Tamano = 3f;
    private bool Desplazar;
    private float Xmover;
    private float Ymover;
    private Vector3 mousePosition;
    public float VelocidaddelZoom = 0.1f;

    void Start()
    {
        Camera.main.orthographicSize = Tamano;
        Tamano = Camera.main.orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Tamano -= VelocidaddelZoom;
            if(Tamano < 2f || Tamano > 7f) //Limite inferior
            {
                Tamano = 2f;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            Tamano += VelocidaddelZoom;
            if (Tamano < 1 || Tamano > 5f) //Limite superiór
            {
                Tamano = 5f;
            }
        }
        Camera.main.orthographicSize = Tamano;
        if (Input.GetMouseButtonDown(2))
        {
            Xmover = mousePosition.x;
            Ymover = mousePosition.y;
            Desplazar = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            Desplazar = false;
        }
        if (Desplazar)
        {

            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - mousePosition.x + Xmover, Camera.main.transform.position.y - mousePosition.y + Ymover, Camera.main.transform.position.z);
        }
    }
}