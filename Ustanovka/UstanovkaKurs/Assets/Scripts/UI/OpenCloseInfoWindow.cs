using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseInfoWindow : MonoBehaviour
{
	[SerializeField]
	//private Text message_t; 

	void Start()
	{
		Close(); //  ��������� ����������� ���� � ������ ������ ����. 
	}

	public void OnOpenSettings()
	{
		Open(); //  �������� ���������� ����� ������� ������������ ����. 
				//message_t.text = "������"; 
	}

	public void Open()
	{
		gameObject.SetActive(true); //   ������������ ������, ����� ������� ����.  
	}
	public void Close()
	{
		gameObject.SetActive(false); // �������������� ������, ����� ������� ����.  
	}
}

