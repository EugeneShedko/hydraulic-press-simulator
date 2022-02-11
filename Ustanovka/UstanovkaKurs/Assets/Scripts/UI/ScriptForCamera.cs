using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScriptForCamera : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 100f;
    [SerializeField]
    private float x;
    private float y;
    [SerializeField]
    Transform targetPos;
    public float currentposX;
    public float newposX;
    public float currentposY;
    public float currentposZ;
    int sensivity = 3;
    private Vector3 offset;
    private float Y;
    public float value;


    public void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal"); // кнопки A D
        y = Input.GetAxis("Vertical"); // кнопки W S
        if (x != 0)
        {

            Vector3 newpos = (transform.TransformDirection(new Vector3(x, 0, 0)) + Vector3.up * y) * sensivity;
            Vector3 pos = targetPos.position;
            currentposX = newpos.x;
            if ((ControlDistance(newpos.x, -480, 490, pos.x)) && (ControlDistance(newpos.z, -480, 471, pos.z)))
                transform.position = newpos;
        }
        if (y != 0)
        {
            Vector3 newpos = transform.position + (transform.TransformDirection(new Vector3(x, 0, 0)) + Vector3.up * y) * sensivity;
            Vector3 pos = targetPos.position;
            if (ControlDistance(newpos.y, -150, 336, pos.y))
                transform.position = newpos;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newpos = transform.position + (Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
            Vector3 pos = targetPos.position;
            if ((ControlDistance(newpos.x, -480, 490, pos.x)) && (ControlDistance(newpos.z, -480, 471, pos.z)))
                transform.position = newpos;
        }

        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(targetPos.position, Vector3.up, Input.GetAxis("Mouse X") * sensivity );
           // Y += Input.GetAxis("Mouse Y") * sensivity * 1.2f; // Новая позиция Y
            //Y = Mathf.Clamp(Y, -50, 15); // Ограничение, чтобы не вылететь за пределы
            //transform.localEulerAngles = new Vector3(-Y, transform.localEulerAngles.y, 0); // Установка поворота 
        }
    }

    public bool ControlDistance(float cz, int minValue, int maxValue, float nz)
    {
        value = cz - nz;
        if ((cz - nz > minValue) && (cz - nz < maxValue))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
