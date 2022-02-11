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
		Close(); //  Закрываем всплывающее окно в момент начала игры. 
	}

	public void OnOpenSettings()
	{
		Open(); //  Заменяем отладочный текст методом всплывающего окна. 
				//message_t.text = "Привет"; 
	}

	public void Open()
	{
		gameObject.SetActive(true); //   Активировать объект, чтобы открыть окно.  
	}
	public void Close()
	{
		gameObject.SetActive(false); // Деактивировать объект, чтобы закрыть окно.  
	}
}

