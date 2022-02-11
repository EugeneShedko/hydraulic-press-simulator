using Assets.Scripts.Ection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRemoveInfoIntoTable : MonoBehaviour
{
    public GameObject smallWorkWindow;

    private Text[] tableStaticValues;
    private Text[] tableDynamicValues;
    public Text value1;
    public Text value2;
    public Text value3;
    public Text value4;
    public Text value11;
    public Text value22;
    public Text value33;
    public Text value44;
    public Text smallWorkWindowText;
    public InputField insertValue;

    public string withoutDot;

    private static int i = 0;
    private const int porshenSquare = 15;
    private string message = ". Открутите кран узла сброса давления";
    // Start is called before the first frame update
    public void Start()
    {
        tableStaticValues = new Text[] { value1, value2, value3, value4 };
        tableDynamicValues = new Text[] { value11, value22, value33, value44 };
    }

    public void SetValueIntoTable()
    {
        if ((i < 4) && (insertValue.text != "") && StateVariables.canInterectWithTable)
        {
            tableStaticValues[i].text = insertValue.text;
            tableDynamicValues[i].text = Convert.ToString(Convert.ToDouble(tableStaticValues[i++].text.Replace(".", ",")) * porshenSquare);
            StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber +  message);
            StateVariables.canOpenUzel = true;
        }
        insertValue.text = string.Empty;
    }

    public void RemoveValueFromTable()
    {
        if((i > 0) && StateVariables.canInterectWithTable)
        {
            tableDynamicValues[--i].text = "-";
            tableStaticValues[i].text = "-";
        }
    }
}
