using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtlas : MonoBehaviour
{
    public bool girando = false;
   
   public float velocidad = 1;
   public Vector3 Movimiento;
   public CapsuleCollider colisionador;
   private Rigidbody cuerpo;
    // Start is called before the first frame update
    void Start()
    {
        colisionador= GetComponent<CapsuleCollider>();
        cuerpo = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        //Movimiento
        // Moverse entre carriles
        //Fusionar con hugo

        //Hacia delante
        Movimiento = (transform.forward * velocidad);

        //rotar
        //cuerpo.MoveRotation(new Quaternion(0, 90, 0, 1));
        //Rotar Derecha
        cuerpo.angularVelocity = new Vector3(0,Mathf.PI/2,0);
        //Rotar Izquierda
        cuerpo.angularVelocity = new Vector3(0,Mathf.PI/2,0);

                //Moverse
        cuerpo.velocity = new Vector3(transform.forward.x * velocidad, cuerpo.velocity.y, transform.forward.z * velocidad);
    }
        void OnCollisionEnter(Collision col){
        GameObject.Find("Atlas").GetComponent<Marcador>().timerMuerte -= 10;
    }
}