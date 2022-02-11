using Assets.Scripts.Ection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActivDisactivButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject smallWorkWindow;

    private Material originalMaterial;
    public Material newMaterial;

    public Text smallWorkWindowText;

    private int flag = 0;
    public static bool isActive = false;
    private string message1 = ". Поднимайте/опускайте рычаг перемещения поршня, пока предмет, \n расположенный на платформе не будет деформирован";
    public void Activ()
    {
        originalMaterial = gameObject.GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material = newMaterial;
        isActive = true;
    }

    public void Disactiv()
    {
        gameObject.GetComponent<Renderer>().material = originalMaterial;
        isActive = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(flag == 0 && StateVariables.canEnableUstanovka)
        {
            Activ();
            flag = 1;
            StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1);
            StateVariables.canPressElement = true;
            StateVariables.canEnableUstanovka = false;
        }
        if(flag == 1 && StateVariables.canEnableUstanovka)
        {
            Disactiv();
            flag = 0;
            StateVariables.canEnableUstanovka = false;
        }
    }
}
