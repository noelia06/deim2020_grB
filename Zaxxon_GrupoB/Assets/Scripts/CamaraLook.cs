using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    
    [SerializeField] Transform playerPosition;
    [SerializeField] float smoothVelocity = 0.3F;
    private Vector3 camaraVelocity = Vector3.zero;
    
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Tarjet);
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.5f, playerPosition.position.z -3f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);

    }
}
