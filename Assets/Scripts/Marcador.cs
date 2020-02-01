using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI; 


public class Marcador : MonoBehaviour
{
    
    public int timerMeta;
    public int timerMuerte;
    private int contador;

    //private Text texto;

    void Start(){
        //texto = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        timerMeta--;
        timerMuerte--;
        contador++;
        //hub.

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
