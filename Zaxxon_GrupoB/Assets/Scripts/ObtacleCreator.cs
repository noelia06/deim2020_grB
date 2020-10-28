using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleCreator : MonoBehaviour
{
    [SerializeField] GameObject Columna;
    [SerializeField] Transform InitPos;
    private float randomNumber;
    Vector3 RandomPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CrearColumna();
        }
    }
    void CrearColumna()
    {
        randomNumber = Random.Range(0f, 20f);
        RandomPos = new Vector3(randomNumber, 0, 0);
        print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }


}
