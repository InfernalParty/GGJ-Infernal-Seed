using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Rotacion. 0 = Recto | 1 = Derecha | 2 = Izquierda
    public int rotacion;
    private Vector3 Atlas;
    public Vector3 Suelo;
    public float velocidad = 30;
    public Object camino;
    private bool caminoCreado;
    private BoxCollider Colisiones;
    public bool interseccion;
    // Start is called before the first frame update
    void Start()
    {
        rotacion = Random.Range(0,3);
        Colisiones = GetComponent<BoxCollider>();
        caminoCreado = false;
        transform.parent = null;
        Suelo = this.transform.position;
        Atlas = GameObject.Find("Atlas").transform.position;
        this.transform.position = Suelo;
        int cruz = Random.Range(0,2);
        if(cruz == 1)
            interseccion = true;
        else
            interseccion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("Atlas").GetComponent<EstadoAtlas>().girando)
            Suelo = new Vector3(Suelo.x, Suelo.y, Suelo.z-velocidad * Time.deltaTime);
        this.transform.position = Suelo;
        //TODO
        //Arreglar el giro
        if(!caminoCreado && Mathf.Abs(Suelo.z - Atlas.z) <= Colisiones.size.z )
        {
            /*//rotar
            if(!interseccion && GameObject.Find("Atlas").GetComponent<EstadoAtlas>().Encrucijada){
                //Es encruzijada
                GameObject.Find("Atlas").GetComponent<EstadoAtlas>().Encrucijada = false;
                GameObject.Find("Atlas").GetComponent<EstadoAtlas>().girando = true;
                rotacion = GameObject.Find("Atlas").GetComponent<EstadoAtlas>().rotacion;
                switch(rotacion){
                    case 1:
                        //Derecha
                        //rotar hacia izquierda centrado en Atlas
                        for(float i = 0; i <= 90; i = i + Time.deltaTime)
                            GameObject.Find("Atlas").transform.Rotate(0,1,0);
                    break;
                    case 2:
                        //Izquierda
                        //Rotar hacia derecha centrado en Atlas
                        for(float i = 0; i <= 90; i = i + Time.deltaTime)
                            GameObject.Find("Atlas").transform.Rotate(0,-1,0);
                    break;
                }
                GameObject.Find("Atlas").GetComponent<EstadoAtlas>().girando = false;
            }*/
            //Crear camino
            caminoCreado = true;
            if(Mathf.Abs(Suelo.x - Atlas.x) <= 1){
                Debug.Log("Debajo");
                //Delante 2 de distancia
                Instantiate(camino, new Vector3(Suelo.x,
                                                Suelo.y,
                                                Suelo.z + Colisiones.size.z * 2),
                                                this.transform.rotation,
                                                GameObject.Find("Atlas").transform);
                //Derecha
                Instantiate(camino, new Vector3(Suelo.x + Colisiones.size.x,
                                                Suelo.y,
                                                Suelo.z + Colisiones.size.z),
                                                this.transform.rotation,
                                                GameObject.Find("Atlas").transform);
                //Izquierda
                Instantiate(camino, new Vector3(Suelo.x - Colisiones.size.x,
                                                Suelo.y,
                                                Suelo.z + Colisiones.size.z),
                                                this.transform.rotation,
                                                GameObject.Find("Atlas").transform); 
            }
        }
        if(caminoCreado && Mathf.Abs(Suelo.z - Atlas.z) > Colisiones.size.z)
            Destroy(this.gameObject);
    }
}
