using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movAtlasHugo : MonoBehaviour
{
    public KeyCode moverIzq;
    public KeyCode moverDer;
    
    public float VelHorizontal = 0;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
           GetComponent<Rigidbody> ().velocity = new Vector3(VelHorizontal,0,4);
        if (Input.GetKeyDown(moverIzq))
        {
            VelHorizontal = -2;
            StartCoroutine(pararMov());
        }    
        if (Input.GetKeyDown(moverDer))
        {
            VelHorizontal = 2;
            StartCoroutine(pararMov());
        } 
    }
    IEnumerator pararMov()
    {
        yield return new WaitForSeconds(.5f);
        VelHorizontal = 0;
    }
}
