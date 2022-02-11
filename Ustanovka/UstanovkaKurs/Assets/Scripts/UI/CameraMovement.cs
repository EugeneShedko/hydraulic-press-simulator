using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	bool move = false;
	Vector3 startPosition;
	Vector3 needPosition;
	Vector3 originalPosition;
	float speed = 0.01f;
	float offset = 0;
	Quaternion startRotation;
	Quaternion needRotaton;
	Quaternion originalRotation;
	public Transform camera;
	public Transform object1;
	public Transform object2;
	public Transform object3;
	public Transform object4;
	public Transform object5;
	public Transform object6;
	public Transform object7;
	public Transform object8;
	public Transform object9;
	public Transform object10;
	public Transform object11;
	public Transform object12;

	public void Start()
    {
		originalPosition = camera.position;
		originalRotation = camera.rotation;
	}

	public void Move1()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object1.position;
			needRotaton = object1.rotation;

		}

	}

	public void Move2()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object2.position;
			needRotaton = object2.rotation;

		}

	}

	public void Move3()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object3.position;
			needRotaton = object3.rotation;

		}

	}

	public void Move4()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object4.position;
			needRotaton = object4.rotation;

		}

	}

	public void Move5()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object5.position;
			needRotaton = object5.rotation;

		}

	}

	public void Move6()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object6.position;
			needRotaton = object6.rotation;

		}

	}

	public void Move7()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object7.position;
			needRotaton = object7.rotation;

		}

	}

	public void Move8()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object8.position;
			needRotaton = object8.rotation;

		}

	}

	public void Move9()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object9.position;
			needRotaton = object9.rotation;

		}

	}

	public void Move10()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object10.position;
			needRotaton = object10.rotation;

		}

	}

	public void Move11()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object11.position;
			needRotaton = object11.rotation;

		}

	}

	public void Move12()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = object12.position;
			needRotaton = object12.rotation;
		}
	}

	public void Move0()
	{
		if (!move)
		{
			move = true;
			startPosition = transform.position;
			startRotation = transform.rotation;
			needPosition = originalPosition;
			needRotaton = originalRotation;
		}
	}

	void FixedUpdate()
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
}