﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encrucijada : MonoBehaviour
{
    //0 delante | 1 derecha | 2 izquierda
    public int rotacion;
    public bool random = false;
    // Start is called before the first frame update
    void Start()
    {
        if(random)
            rotacion = Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
