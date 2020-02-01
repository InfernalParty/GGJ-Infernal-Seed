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
   private RaycastHit tocado;

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

        //Girar
        Physics.Raycast(transform.position,Vector3.down, out tocado);
        if(tocado.transform.gameObject != null){
            if(tocado.transform.gameObject.tag == "Cruce"){
                    int rotar = tocado.transform.gameObject.GetComponent<Encrucijada>().rotacion;
                    girando = true;
                    switch(rotar){
                        case 1:
                            //Rotar Derecha
                            cuerpo.angularVelocity = new Vector3(0,Mathf.PI/2,0);
                        break;
                        case 2:
                            //Rotar Izquierda
                            cuerpo.angularVelocity = new Vector3(0,-Mathf.PI/2,0);
                        break;
                    }
            }
            else{
                girando = false;
                cuerpo.angularVelocity = Vector3.zero;
                if(cuerpo.rotation.y <= 45 && cuerpo.rotation.y > -45)
                    cuerpo.rotation = new Quaternion(cuerpo.rotation.x, 0, cuerpo.rotation.z, cuerpo.rotation.w);
                else if(cuerpo.rotation.y > 45 && cuerpo.rotation.y <= 135)
                    cuerpo.rotation = new Quaternion(cuerpo.rotation.x, 90, cuerpo.rotation.z, cuerpo.rotation.w);
                else if(cuerpo.rotation.y > -135 && cuerpo.rotation.y <= -45)
                    cuerpo.rotation = new Quaternion(cuerpo.rotation.x, -90, cuerpo.rotation.z, cuerpo.rotation.w);
                else
                    cuerpo.rotation = new Quaternion(cuerpo.rotation.x, 180, cuerpo.rotation.z, cuerpo.rotation.w);
            }
        }




                //Moverse
        cuerpo.velocity = new Vector3(transform.forward.x * velocidad, cuerpo.velocity.y, transform.forward.z * velocidad);
    }
        void OnCollisionEnter(Collision col){
        GameObject.Find("Atlas").GetComponent<Marcador>().timerMuerte -= 10;
    }
}