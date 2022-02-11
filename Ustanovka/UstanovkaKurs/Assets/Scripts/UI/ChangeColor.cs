using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Material originalMaterial;
    public Material newMaterial;


    public void ChangCol()
    {
        originalMaterial = gameObject.GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material = newMaterial;
    }

    public void ChangCol1()
    {
        gameObject.GetComponent<Renderer>().material = originalMaterial;
    }
}

