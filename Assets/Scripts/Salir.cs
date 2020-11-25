using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    private bool pausedd=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // Abre y cierra el menu con Escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Conexion No Establecida");
            Application.Quit();
        }
    }
}
