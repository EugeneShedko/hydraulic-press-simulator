using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.Ection;

public class RotateStopor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smallWorkWindow;

    public Camera camera;

    public Text smallWorkWindowText;

    private Quaternion originalRotation;

    private float angle;
    public float mouseX;
    private float predmouseX;
    private float mouseSens = 40;
    private float maxStop;
    private float minStop;
    public float value;
    public static bool canMovePlatform = false;
    private string message1 = ". Опустите неподвижно сдавливающую платформу на 3-5 см.";
    private string message2 = ". Включите установку";
    public void Start()
    {
        originalRotation = transform.rotation;
        maxStop = gameObject.transform.position.x / 1.6f;
        minStop = gameObject.transform.position.x;
    }

    // Update is called once per frame
    public void Update()
    {
        //Когда выводить сообщение?, должно выводиться, когда нельзя крутить
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.name == "Stopor"))
                {
                    mouseX += Input.GetAxis("Mouse X") * mouseSens;
                    if (mouseX != 0)
                    {
                        if ((mouseX > predmouseX) && StateVariables.canOpenStopor)
                        {
                            if (gameObject.transform.position.x < maxStop)
                            {
                                Quaternion rotationX = Quaternion.AngleAxis(-mouseX, Vector3.right);
                                transform.rotation = originalRotation * rotationX;
                                gameObject.transform.position -= gameObject.transform.right / 30;
                            }
                            else
                            {
                                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1);
                                StateVariables.canMoveFixedPlatform = true;
                                StateVariables.canOpenStopor = false;
                            }
                        }
                        if ((mouseX < predmouseX) && StateVariables.canCloseStopor)
                        {
                            if (gameObject.transform.position.x > minStop)
                            {
                                Quaternion rotationX = Quaternion.AngleAxis(mouseX, Vector3.right);
                                transform.rotation = originalRotation * rotationX;
                                gameObject.transform.position += gameObject.transform.right / 30;
                            }
                            else
                            {
                                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message2);
                                StateVariables.canEnableUstanovka = true;
                                StateVariables.canCloseStopor = false;
                            }
                        }
                    }
                    predmouseX = mouseX;
                }
            }
        }
    }
}