using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevelanza : MonoBehaviour
{
    public GameObject lanza;
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject instBullet = Instantiate(lanza, transform.position, Quaternion.identity) as GameObject;
        Rigidbody instBulletRIgidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRIgidbody.AddForce(Vector3.forward * speed);
    }
}
