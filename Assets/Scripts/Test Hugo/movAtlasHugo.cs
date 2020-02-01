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
        GetComponent<Rigidbody>().velocity = new Vector3(VelHorizontal, GM.vertVel, 4);

        if ((Input.GetKeyDown(moverIzq)) && (numCamino > 1) && (bloqueControl == "n"))
        {
            VelHorizontal = -2;
            StartCoroutine(pararMov());
            numCamino -= 1;
            //bloqueControl = "y";
        }    

        if ((Input.GetKeyDown(moverDer)) && (numCamino < 3) && (bloqueControl == "n"))
        {
            VelHorizontal = 2;
            StartCoroutine(pararMov());
            numCamino += 1 ;
            //bloqueControl = "y";
        } 
        
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Daño")
        {
            Destroy (gameObject);
        }
        if (other.gameObject.name == "Power_Up")
        {
            Destroy (other.gameObject);
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name == "triggerRampB")
        {
            GM.vertVel = 2;
        }
        if (other.gameObject.name == "triggerRampA")
        {
            GM.vertVel = 0;
        }
    }
    IEnumerator pararMov()
    {
        yield return new WaitForSeconds(.5f);
        VelHorizontal = 0;
    }
}
