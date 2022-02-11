using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageInfoButton : MonoBehaviour
{
    Image buttonImage;
    public Sprite mouseInImage;
    //public Sprite mouseOutImage;
    private Sprite originImage;

    public void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
        originImage = buttonImage.sprite;
    }

    public void MouseIn()
    {
        buttonImage.sprite = mouseInImage;
    }
    public void MouseOut()
    {
        buttonImage.sprite = originImage;
    }
}
