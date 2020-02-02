using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movMundo : MonoBehaviour
{
    private float VelHorizontal = 0;
    private RaycastHit tocado;
    private RaycastHit derecha;
    private RaycastHit izquierda;
    private int rotar;
    //0 = Recto | 1 = Derecha | 2 = izquierda
    private bool girando;
    public int contadorGiro;
    private Rigidbody cuerpo;
    public int velocidad = 4;
    public float longitudCanal = 1.5f;
    private int layerMask;
    private bool moviendoDer;
    private bool moviendoIzq;
    private bool choqueIzq;
    private bool choqueDer;
	private bool heGirado = false;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
        layerMask = ~(1 << 8);
    }

    // Update is called once per frame
    void Update()
    {
        longitudCanal = 1.5f;
            
        choqueDer = Physics.Raycast(new Vector3(transform.position.x, transform.position.y-0.7f, transform.position.z),transform.right, out derecha,longitudCanal, layerMask);
        choqueIzq = Physics.Raycast(new Vector3(transform.position.x, transform.position.y-0.7f, transform.position.z),-transform.right, out izquierda,longitudCanal, layerMask);
		if(choqueDer && !choqueIzq){
			//mover izq
			VelHorizontal = -2;
		}
		else if(choqueIzq && !choqueDer){
			//Mover der
			VelHorizontal = 2;
		}
        if(choqueIzq && choqueDer){
            moviendoIzq = false;
            moviendoDer = false;
            VelHorizontal = 0;
        }
    }

    void FixedUpdate()
    {
        //Mover la bola
        cuerpo.velocity = transform.right * VelHorizontal + Vector3.up*cuerpo.velocity.y + transform.forward * velocidad;

        //Girar
        if(Physics.Raycast(transform.position,Vector3.down, out tocado)){
            if(tocado.transform.gameObject.tag == "Cruce"){
				heGirado = true;
                rotar = tocado.transform.gameObject.GetComponent<Encrucijada>().rotacion;
                if(!girando)
                    contadorGiro = 25;
            }
			else if(tocado.transform.gameObject.tag != "Cruce")
				heGirado = false;
        }
        if(contadorGiro > 0){
			cuerpo.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        girando = true;
        switch(rotar){
            case 1:
                //Rotar Derecha
                cuerpo.angularVelocity = new Vector3(0,Mathf.PI,0);
                moviendoIzq = true;
            break;
            case 2:
                //Rotar Izquierda
                cuerpo.angularVelocity = new Vector3(0,-Mathf.PI,0);
                moviendoDer = true;
            break;
            }
            contadorGiro--;
        }
        else{
			cuerpo.constraints = RigidbodyConstraints.FreezeRotation;
            cuerpo.angularVelocity = Vector3.zero;
    	}
	}
}
