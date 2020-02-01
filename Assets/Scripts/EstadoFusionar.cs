using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EstadoFusionar : MonoBehaviour
{
    public bool girando = false;
    public bool Encrucijada = false;
    public int rotacion;
    public GameObject suelo;
    private RaycastHit colision;

    public CapsuleCollider colisionador;
    // Start is called before the first frame update
    void Start()
    {
        colisionador= GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position,Vector3.down, out colision);
        Debug.DrawRay(transform.position,Vector3.down);
        if(colision.transform){
            suelo = colision.transform.gameObject;
        }
        if(suelo != null){
            if(suelo.GetComponent<Movimiento>().interseccion && !Encrucijada)
                Encrucijada = true;
                rotacion = suelo.GetComponent<Movimiento>().rotacion;
        }
    }

    void OnCollisionEnter(Collision col){
        GameObject.Find("Atlas").GetComponent<Marcador>().timerMuerte -= 10;
    }
}
