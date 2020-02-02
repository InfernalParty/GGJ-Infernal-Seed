using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movAtlasIgnacio : MonoBehaviour
{
    public KeyCode moverIzq;
    public KeyCode moverDer;
    private int numCamino = 2;
    private float VelHorizontal = 0;
    private RaycastHit tocado;
    private RaycastHit delante;
    private RaycastHit derecha;
    private RaycastHit izquierda;
    private int rotar;
    //0 = Recto | 1 = Derecha | 2 = izquierda
    private bool girando;
    public int contadorGiro;
    private Rigidbody cuerpo;
    public int velocidad = 4;
    public float distanciaRecogida = 1;
    public float longitudCanal = 1.5f;
    private int layerMask;
    private bool moviendoDer;
    private bool moviendoIzq;
    private bool choqueIzq;
    private bool choqueDer;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
        layerMask = ~(1 << 8);
    }

    // Update is called once per frame
    void Update()
    {
         if ((Input.GetKeyDown(moverIzq)) && numCamino > 1)
        {
            moviendoIzq = true;
            VelHorizontal = -2;
            //bloqueControl = "y";
        }    

        if ((Input.GetKeyDown(moverDer)) && numCamino < 3)
        {
            moviendoDer = true;
            VelHorizontal = 2;
            //bloqueControl = "y"
        } 
        if(numCamino == 2)
            longitudCanal = 0.5f;
        else
            longitudCanal = 1.5f;
            
            choqueDer = Physics.Raycast(new Vector3(transform.position.x, transform.position.y-0.35f, transform.position.z),transform.right, out derecha,longitudCanal, layerMask);
            choqueIzq = Physics.Raycast(new Vector3(transform.position.x, transform.position.y-0.35f, transform.position.z),-transform.right, out izquierda,longitudCanal, layerMask);
        if((numCamino == 3 && choqueIzq) || (numCamino == 1 && choqueDer)){
            numCamino = 2;
            moviendoIzq = false;
            moviendoDer = false;
            VelHorizontal = 0;
        }
        else if(moviendoDer && choqueDer){
            numCamino = 3;
            moviendoDer = false;
            VelHorizontal = 0;
        }
        else if(moviendoIzq && choqueIzq){
            numCamino = 1;
            moviendoIzq = false;
            VelHorizontal = 0;
        }   
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y-0.35f, transform.position.z),transform.right,Color.red);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y-0.35f, transform.position.z),-transform.right,Color.red);
    }

    void FixedUpdate()
    {
        //Mover la bola
        cuerpo.velocity = transform.right * VelHorizontal + Vector3.up*cuerpo.velocity.y + transform.forward * velocidad;

        //Girar
        if(Physics.Raycast(transform.position,Vector3.down, out tocado)){
            if(tocado.transform.gameObject.tag == "Cruce"){
                rotar = tocado.transform.gameObject.GetComponent<Encrucijada>().rotacion;
                if(!girando)
                    contadorGiro = 50;
            }
        }
        if(contadorGiro > 0){
        girando = true;
        switch(rotar){
            case 1:
                //Rotar Derecha
                cuerpo.angularVelocity = new Vector3(0,Mathf.PI,0);
            break;
            case 2:
                //Rotar Izquierda
                cuerpo.angularVelocity = new Vector3(0,-Mathf.PI,0);
            break;
            }
            contadorGiro--;
        }
        else
            cuerpo.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other) 
    {
        GetComponentInParent<Marcador>().timerMuerte -= 10;
    }
}
