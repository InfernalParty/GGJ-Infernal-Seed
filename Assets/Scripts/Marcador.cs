using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI; 


public class Marcador : MonoBehaviour
{
    
    public float timerMeta;
    public float timerMuerte;
    private float contador;

    //private Text texto;

    void Start(){
<<<<<<< HEAD
        //texto = GetComponent<Text>();
=======
       // texto= GetComponent<Text>();
>>>>>>> origin/master
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        timerMeta--;
        timerMuerte--;
        contador++;
        //hub.
=======
        
    }
    void FixedUpdate()
    {
        timerMeta-=0.02f;
        timerMuerte-=0.02f;
        contador+=0.02f;

>>>>>>> origin/master

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
