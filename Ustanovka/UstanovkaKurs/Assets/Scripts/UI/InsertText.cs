using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InsertText : MonoBehaviour
{
    public Text message;
    public string text;
    public void OnOpenSettings()
    {   //  �����, ���������� ������������� ������� �� ������ 
        message.text = text;
    }

}
