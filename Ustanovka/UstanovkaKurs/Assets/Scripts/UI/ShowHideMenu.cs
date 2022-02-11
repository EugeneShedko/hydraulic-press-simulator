using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject Elements;
    public void Start()
    {
        Elements.SetActive(false);
    }

    public void OnPointerClick()
    {
        Elements.SetActive(true);
    }
    public void OnPointerEnter()
    {
        Elements.SetActive(false);
    }
}
