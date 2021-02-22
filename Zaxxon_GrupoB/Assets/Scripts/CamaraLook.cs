using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    
    [SerializeField] Transform playerPosition;
    [SerializeField] float smoothVelocity;
    [SerializeField] private Vector3 camaraVelocity = Vector3.zero;
    
 
    // Start is called before the first frame update
    void Start()
    {
        smoothVelocity = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Tarjet);
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);

    }
}
