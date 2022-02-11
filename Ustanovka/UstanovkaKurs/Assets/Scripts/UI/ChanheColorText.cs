using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanheColorText : MonoBehaviour
{
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Text>().color;
    }

    public void MouseIn()
    {
        gameObject.GetComponent<Text>().color = new Color(1f, 0.5f, 0f);
    }

    public void MouseOut()
    {
        gameObject.GetComponent<Text>().color = originalColor;
    }
}
