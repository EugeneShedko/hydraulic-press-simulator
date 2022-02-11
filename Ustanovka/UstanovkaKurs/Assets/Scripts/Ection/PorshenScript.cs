using Assets.Scripts.Ection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PorshenScript : MonoBehaviour
{
    public GameObject smallWorkWindow;
    public Text smallWorkWindowText;
    public static string namePressElement;
    private string message1 = ". ��������� ������ ����������� ������������ ���������";
    private string message2 = ". ��������� ���� ���� ������ ��������";

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "TreePressElement")
        {
            if (StateVariables.canMovePressElement)
            {
                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1);
            }
            StateVariables.canMovePressElement= false;
            StateVariables.canOpenStopor = true;
            StateVariables.canCloseStopor = false;
            //������� �� ���������, ������� �������������� ���������
        }
        if((other.name == "MedPressElement") || (other.name == "AluminiyPressElement") || (other.name == "ZolotoPressElement"))
        {
            if (StateVariables.canMovePressElement)
            {
                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message2);
            }
            StateVariables.canCloseUzel = true;
            StateVariables.canMovePressElement = false;
        }
        namePressElement = other.name;
    }
}

//������� ����������, ��� ��������� ���������� � ��������� �� � �������
