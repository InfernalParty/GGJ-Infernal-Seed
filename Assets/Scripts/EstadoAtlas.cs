using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtlas : MonoBehaviour
{
    public bool girando = false;
   
   public float velocidad = 30;
   public Vector3 Movimiento;
   public CapsuleCollider colisionador;
   private CharacterController controles;
    // Start is called before the first frame update
    void Start()
    {
        colisionador= GetComponent<CapsuleCollider>();
        controles = gameObject.GetComponent<CharacterController>();
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

                //Moverse
        controles.Move(Movimiento);
    }
        void OnCollisionEnter(Collision col){
        GameObject.Find("Atlas").GetComponent<Marcador>().timerMuerte -= 10;
    }
}