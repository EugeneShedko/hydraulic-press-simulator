using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.Ection;

public class MoveFixedPlatform : MonoBehaviour
{
    public GameObject smallWorkWindow;
    public Camera camera;

    public Text smallWorkWindowText;
    
    Quaternion originalRotation;
   
    float angle;
    public float mouseY;
    private float predmouseY;
    float mouseSens = 40;
    public float maxStop;
    public float minStop;
    public static bool canMoveElement = false;
    public static bool canScalePressElement = false;
    private string message1 = ". Закрутите стопор неподвижной сдавливающей платформы";

    public void Start()
    {
        originalRotation = transform.rotation;
        maxStop = gameObject.transform.position.y / 1.2f;
        minStop = gameObject.transform.position.y;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.name == "FixedPlatform") && StateVariables.canMoveFixedPlatform)
                {
                    mouseY += Input.GetAxis("Mouse Y") * mouseSens;
                    if (mouseY != 0)
                    {
                        if (mouseY < predmouseY)
                        {
                            if (gameObject.transform.position.y > maxStop)
                            {
                                gameObject.transform.position -= gameObject.transform.up;
                            }
                            else
                            {
                                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1);
                                StateVariables.canOpenStopor = false;
                                StateVariables.canCloseStopor = true;
                                StateVariables.canMoveFixedPlatform = false;
                                canMoveElement = true;
                            }
                        }
                        if (mouseY > predmouseY)
                        {
                            if (gameObject.transform.position.y < minStop)
                            {
                                gameObject.transform.position += gameObject.transform.up;
                            }
                        }
                    }
                }
                predmouseY = mouseY;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "TreePressElement" || other.name == "MedPressElement" || other.name == "ZolotoPressElement" || other.name == "AluminiyPressElement")
            canScalePressElement = true;
    }

    public void OnTriggerExit(Collider other)
    {
        canScalePressElement = false;
    }
}

