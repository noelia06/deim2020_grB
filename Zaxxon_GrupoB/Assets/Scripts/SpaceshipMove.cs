using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipMove : MonoBehaviour
{
    float speed = 3f;

    //Capturo el texto de la velocidad
    [SerializeField] Text TextDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
    }

    //Corrutina que hace cambiar el texto de velocidad
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        for(int n = 0; ; n += 10)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n; 
            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(1f);
        }
        
    }



    void MoverNave()
    {
        /*
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        float desplX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * Time.deltaTime * speed * desplX);

        float desplY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);

        print(Input.GetAxis("Horizontal"));
    }
}
