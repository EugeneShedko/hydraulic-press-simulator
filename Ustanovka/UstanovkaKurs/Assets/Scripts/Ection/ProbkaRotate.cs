using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.Ection;

public class ProbkaRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smallWorkWindow;

    public Camera camera;

    public Text smallWorkWindowText;

    Quaternion originalRotation;
    
    public float mouseX;
    private float mouseSens = 40;
    private string message1 = "2. Закройте крышку емкости с маслом.";
    private string message2 = ". Положите на сдавливающую платформу деревянный предмет.";
    private bool isOpen = false;

    public void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (StateVariables.canProbkaRotate)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "Krishka")
                    {
                        mouseX += Input.GetAxis("Mouse X") * mouseSens;
                        mouseX = Mathf.Clamp(mouseX, -134, -2);
                        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.forward);
                        transform.rotation = originalRotation * rotationY;
                        if (mouseX == -134)
                        {
                            StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, message1);
                            StateVariables.canMovePressElement = true;
                            isOpen = true;
                        }
                        if((mouseX == -2) && isOpen)
                        {
                            StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, (StateVariables.actionNumber +=2) + message2);
                            StateVariables.canProbkaRotate = false;
                        }

                    }
                }
            }
        }
    }
}
