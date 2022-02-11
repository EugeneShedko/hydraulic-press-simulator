using Assets.Scripts.Ection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateUzel : MonoBehaviour
{
    public GameObject deformPorshen;
    public GameObject clapan3;
    public GameObject smallWorkWindow;
    public GameObject stru;

    public Camera camera;

    public Text smallWorkWindowText;

    private Quaternion originalRotation;
    
    public float mouseY;
    private float predmouseY;
    private float mouseSens = 40;
    public static bool canInsertText = false;
    public string value;
    public float value2 = 0;
    private string message1 = ". Уберите сдавленный предмет с платформы";
    private string message2 = ". Опускайте и поднимайте рычаг перемещения поршня, пока предмет,\n размещенный на платформе, не будет деформрован.";
    // Start is called before the first frame update
    public void Start()
    {
        originalRotation = transform.rotation;
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == gameObject.name)
                {
                    StateVariables.canInterectWithTable = false;
                    mouseY += Input.GetAxis("Mouse Y") * mouseSens;
                    if (mouseY != 0)
                    {
                        if ((mouseY > predmouseY) && StateVariables.canOpenUzel)
                        {
                            if (deformPorshen.transform.localScale.x > 0.5f)
                            {
                                Quaternion rotationX = Quaternion.AngleAxis(mouseY, Vector3.right);
                                transform.rotation = originalRotation * rotationX;
                                deformPorshen.transform.localScale = new Vector3(deformPorshen.transform.localScale.x - 0.005f, deformPorshen.transform.localScale.y, deformPorshen.transform.localScale.z);
                                clapan3.transform.position += clapan3.transform.right / 30;
                            }else
                            {
                                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1);
                                StateVariables.canResetPressuare = true;
                                StateVariables.canOpenUzel = false;
                            }
                        }
                        if ((mouseY < predmouseY) && StateVariables.canCloseUzel)
                        {
                            if (deformPorshen.transform.localScale.x < 1)
                            {
                                Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
                                transform.rotation = originalRotation * rotationX;
                                deformPorshen.transform.localScale = new Vector3(deformPorshen.transform.localScale.x + 0.005f, deformPorshen.transform.localScale.y, deformPorshen.transform.localScale.z);
                                clapan3.transform.position -= clapan3.transform.right / 30;
                            }
                            else
                            {
                                StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message2);
                                StateVariables.canPressElement = true;
                                StateVariables.canCloseUzel = false;
                                stru.transform.localScale = new Vector3(stru.transform.localScale.x, 0, stru.transform.localScale.z);
                            }
                        }
                    }
                    predmouseY = mouseY;
                }
            }
        }
    }
    // Update is called once per frame
}
