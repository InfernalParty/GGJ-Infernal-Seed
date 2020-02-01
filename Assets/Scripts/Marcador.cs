using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    
    public int timerMeta;
    public int timerMuerte;
    private int contador;

    public GameObject atlas;
    public GameObject obstaculo;

    public CapsuleCollider aCC;
    public CapsuleCollider oCC;

    // Update is called once per frame
    void Update()
    {
        timerMeta--;
        timerMuerte--;
        contador++;

        if(aCC.OnCollisionEnter()){
            timerMuerte-=10;
            contador = 0;
        }

        if(contador == 20)
        {
            timerMuerte += 10;
            contador = 0;
        }

        if(timerMeta == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if( timerMuerte == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
