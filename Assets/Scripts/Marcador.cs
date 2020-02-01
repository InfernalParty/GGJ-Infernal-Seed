using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class Marcador : MonoBehaviour
{
    
    public float timerMeta;
    public float timerMuerte;
    private float contador;

    public Text texto;
    private string setText;
    private string numPersonas;

    void Start(){
       setText= "Humanos: ";
    }

    void FixedUpdate()
    {
        timerMeta-=0.02f;
        timerMuerte-=0.02f;
        contador+=0.02f;
        numPersonas= timerMuerte.ToString();
        texto.text = setText + numPersonas;

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
