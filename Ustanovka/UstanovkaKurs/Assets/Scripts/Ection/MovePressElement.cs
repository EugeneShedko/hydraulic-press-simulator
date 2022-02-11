using Assets.Scripts.Ection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovePressElement : MonoBehaviour, IPointerClickHandler
{
	public GameObject smallWorkWindow;
    public Transform emptyObject;

	public Text smallWorkWindowText;

	private Vector3 startPosition;
	private Vector3 needPosition;
	private Vector3 originalPosition;
	private Quaternion startRotation;
	private Quaternion needRotaton;
	private Quaternion originalRotation;

	float speed = 0.03f;
	private int flag = 0;
	bool move = false;
	float offset = 0;
	private string message1 = ". �������� �� ������������ ��������� ";
	private string message2 = " �������.";
	private string message3 = ". ��������� ������ �������� ���������";

	public void Start()
	{
		originalPosition = gameObject.transform.position;
		originalRotation = gameObject.transform.rotation;
	}

	public void Move1()
	{
		move = true;
		startPosition = transform.position;
		startRotation = transform.rotation;
		needPosition = emptyObject.position;
		needRotaton = emptyObject.rotation;
	}

	public void Move0()
    {
		move = true;
		startPosition = transform.position;
		startRotation = transform.rotation;
		needPosition = new Vector3(originalPosition.x, originalPosition.y - 10, originalPosition.z);
		needRotaton = originalRotation;
	}

	public void FixedUpdate()
	{

		if (move)
		{
			offset += speed;
			transform.position = Vector3.Lerp(startPosition, needPosition, offset);
			transform.rotation = Quaternion.Lerp(startRotation, needRotaton, offset);



			if (offset >= 1)
			{
				move = false;
				offset = 0;
			}
		}
	}
	public void OnPointerClick(PointerEventData eventData)
    {
		if (gameObject.name == StateVariables.elementOnPressPlatform)
		{
			if (flag == 0 && StateVariables.canMovePressElement)
			{
				Move1();
				flag = 1;
				return;
			} 

			if(flag == 1 && StateVariables.canMovePressElement)
			{
				Move0();
				InsertText();
				return;
			}
		}
    }

	public void InsertText()
	{
		switch (StateVariables.elementOnPressPlatform)
		{
			case "TreePressElement": InsertText("������", "MedPressElement"); break;
			case "MedPressElement": InsertText("����������", "AluminiyPressElement"); break;
			case "AluminiyPressElement": InsertText("�������", "ZolotoPressElement"); break;
			case "ZolotoPressElement": StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message3); StateVariables.canEnableUstanovka = true; break;
		}
	}

	private void InsertText(string text, string pressElement)
    {
		StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1 + text + message2);
		StateVariables.elementOnPressPlatform = pressElement;
	}

}
