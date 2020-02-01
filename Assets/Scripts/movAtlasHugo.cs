using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movAtlasHugo : MonoBehaviour
{
    public KeyCode moverIzq;
    public KeyCode moverDer;
    public int numCamino = 2;
    public string bloqueControl = "n";
    public float VelHorizontal = 0;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3(VelHorizontal,0,4);

        if ((Input.GetKeyDown(moverIzq)) && (numCamino > 1) && (bloqueControl == "n"))
        {
            VelHorizontal = -2;
            StartCoroutine(pararMov());
            numCamino -= 1;
        }    

        if ((Input.GetKeyDown(moverDer)) && (numCamino < 3) && (bloqueControl == "n"))
        {
            VelHorizontal = 2;
            StartCoroutine(pararMov());
            numCamino += 1 ;
        } 
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Daño")
        {
            Destroy (gameObject);
        }
    }
    IEnumerator pararMov()
    {
        yield return new WaitForSeconds(.5f);
        VelHorizontal = 0;
    }
}
