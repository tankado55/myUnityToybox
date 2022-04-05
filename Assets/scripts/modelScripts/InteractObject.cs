using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    Material mat;
    void Start()
    {
        gameObject.layer = 8;
        mat = GetComponent<MeshRenderer>().material;
    }

    public void interact()
    {
        mat.color = Color.green;
    }

    
}
