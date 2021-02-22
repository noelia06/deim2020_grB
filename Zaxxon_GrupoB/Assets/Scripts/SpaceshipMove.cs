﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed = 3f;
    [SerializeField] MeshRenderer myMesh;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;
    //Variable que determina si estoy en los márgenes
    private bool inMarginMoveX = true;
    private bool inMarginMoveY = true;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    public GameObject ObstacleMove;
    
    // Start is called before the first frame update
    void Start()
    {
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        //Velocidad del obstaculo relacionado con la nave.
        ObstacleMove = GameObject.Find("ObstacleMove");
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();

    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n += 10)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n * speed;
            
            {
               // speed += 3f;
            }

            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(1f);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;
            speed = 0;
        }
    }


    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        

        /*
        float myPosX = transform.position.x;
        float myPosY = transform.position.y;

        if (myPosX < -5 && desplX < 0) 
        {

            inMarginMoveX = false;
        }
        else if ( myPosX < -5 && desplX > 0)
            {
            inMarginMoveX = true;
        }
        else if (myPosX > 5 && desplX > 0)
        {
            inMarginMoveX = false;
        }

        else if (myPosX > 5 && desplX < 0)
        {
            inMarginMoveX = true;
        }

        if (myPosY < 0 && desplY < 0)
        {

            inMarginMoveY = false;
        }
        else if (myPosY < 0 && desplY > 0)
        {
            inMarginMoveY = true;
        }
        else if (myPosY > 5 && desplY > 0)
        {
            inMarginMoveY = false;
        }

        else if (myPosY > 5 && desplY < 0)
        {
            inMarginMoveY = true;
        }

        if (inMarginMoveX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
            
        }

        if (inMarginMoveY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);
        }
        */
        float posX = transform.position.x;
        float posY = transform.position.y;
        
        if (posX < 6 && posX > -3 || posX < -3 && desplX > 6 || posX > 6 && desplX < -3)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);

        }

        if (posY < 3 && posY > 0 || posY < 1 && desplY > 3 || posY > 3 && desplY < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);
        }

    }




}
