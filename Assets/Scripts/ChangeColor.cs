using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor",new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
