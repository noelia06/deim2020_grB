using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed = 3f;
    [SerializeField] MeshRenderer myMesh;
    public GameObject ExplosionParticulas;
    Vector3 pos;
    public GameObject SonidoExplosion;
    

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;
    //Variable que determina si estoy en los márgenes
    private bool inMarginMoveX = true;
    private bool inMarginMoveY = true;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] Text TextTime;
    float tiempo;
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
        Tiempo();

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
            
         StartCoroutine("Choque");
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
        

        float posX = transform.position.x;
        float posY = transform.position.y;
        
        if (posX < 3.5 && posX > -4.5 || posX < -4.5 && desplX > 0 || posX > 3.5 && desplX < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);

        }

        if (posY < 3 && posY > 1 || posY < 1 && desplY > 0 || posY > 3 && desplY < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);
        }

    }


   void Tiempo()
   {

       tiempo+=Time.deltaTime;
       float segundos = (int)tiempo%60;
       float minutos = (int)((tiempo/60)%60);
       TextTime.text = "Tiempo: " + minutos.ToString("00") + ":" + segundos.ToString("00");
   }

    IEnumerator Choque()
    {
      myMesh.enabled = false;
            speed = 0;
             Instantiate(ExplosionParticulas, pos, Quaternion.identity);
             Instantiate(SonidoExplosion);
             yield return new WaitForSeconds(2f);
             SceneManager.LoadScene("GameOver");
    }
}
