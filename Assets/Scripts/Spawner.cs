using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Valores de enemigos generados aleatoriamente:
//0=Columna Alta
//1=Columna Rota
//2=Lanza
//3=Tridente
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPrefab;
    [SerializeField]
    private GameObject characterPrefab2;
    [SerializeField]
    private GameObject characterPrefab3;
    [SerializeField]
    private GameObject characterPrefab4;
    [SerializeField]
    public float tiempoSpawn=5f;
    public float tiempoSiguiente=2;
    public int ObstaculoSeleccionado;

    void Update()
    {
        if(Time.time>= tiempoSpawn)
        {
            ObstaculoSeleccionado = Random.Range(0, 4);
            switch(ObstaculoSeleccionado)
            {  
                case 0:
                    GameObject.Instantiate(characterPrefab, transform.position,transform.rotation);
                    break;
                case 1:
                    GameObject.Instantiate(characterPrefab2, transform.position, transform.rotation);
                    break;
                case 2:
                    GameObject.Instantiate(characterPrefab3, transform.position, transform.rotation);
                    break;
                case 3:
                    GameObject.Instantiate(characterPrefab4, transform.position, transform.rotation);
                    break;


                default:
                    break;
            }

            tiempoSiguiente = Time.time + Random.Range(2, 5);
            tiempoSpawn = tiempoSiguiente;
        }
    }
    
}
