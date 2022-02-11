using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorButton : MonoBehaviour
{
    Image buttonImage;
    public Sprite mouseInImage;
    //public Sprite mouseOutImage;
    private Color originColor;

    public void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
        originColor = buttonImage.color;
    }

    public void MouseIn()
    {
        buttonImage.color = new Color(1,1,0);
    }
    public void MouseOut()
    {
        buttonImage.color = originColor;
    }
}
