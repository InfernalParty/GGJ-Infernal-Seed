using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarJuego : MonoBehaviour
{


    public void EmpezarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void CerrarJuego(){
        Application.Quit();
        Debug.log("Salir");
    }
}
