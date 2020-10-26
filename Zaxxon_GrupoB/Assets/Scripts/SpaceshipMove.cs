using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMove : MonoBehaviour
{
    float speed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }

        float desplX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * Time.deltaTime * speed * desplX);


        print(Input.GetAxis("Horizontal"));
    }
}
