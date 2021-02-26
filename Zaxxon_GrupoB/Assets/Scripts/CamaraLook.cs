using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    
    [SerializeField] Transform playerPosition;
<<<<<<< HEAD
    [SerializeField] float smoothVelocity;
    [SerializeField] private Vector3 camaraVelocity = Vector3.zero;
=======
    [SerializeField] float smoothVelocity = 0.3F;
    private Vector3 camaraVelocity = Vector3.zero;
>>>>>>> 7954d0d475c6c9a160c25651dfa7c616affb6736
    
 
    // Start is called before the first frame update
    void Start()
    {
        smoothVelocity = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Tarjet);
<<<<<<< HEAD
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
=======
        Vector3 targetPosition = new Vector3(transform.position.x, playerPosition.position.y, transform.position.z);
>>>>>>> 7954d0d475c6c9a160c25651dfa7c616affb6736
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);

    }
}
