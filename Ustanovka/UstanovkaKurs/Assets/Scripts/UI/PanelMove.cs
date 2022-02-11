using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelMove : MonoBehaviour
{
    [SerializeField]
    public GameObject secondMenuPosistion;
    private Vector3 originalPosition;
    float speed = 0.01f;
    float offset = 0;
    bool open=false;
    // Start is called before the first frame update
    public void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if(open)
        {
            if(offset<1)offset += speed;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, secondMenuPosistion.transform.position, offset);
        }
        else
        {
            if (offset < 1) offset += speed;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, originalPosition , offset);
        }
    }
    public void OnPointerEnter()
    {
         offset=0;
        open = true;
            
            
    }

    public void OnPointerExit()
    {
         offset = 0;
        open = false;

    }
}
