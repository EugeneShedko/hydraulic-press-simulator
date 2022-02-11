using Assets.Scripts.Ection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LargePorshen : MonoBehaviour
{
    public GameObject treePressElement;
    public GameObject medPressElement;
    public GameObject aluminiyPressElement;
    public GameObject zolotoPressElement;
    public GameObject strelkaManometr;
    public GameObject originalPositionPressElementBeforePress;
    public GameObject fixedPressPlatform;
    public GameObject smallWorkWindow;
    public GameObject oilCylinder;
    public GameObject oilContainer;
    public GameObject stru;

    public Camera camera;
    public Text smallWorkWindowText;
    private Vector3 originalPorshenPosition;
    private Quaternion originalStrelkaRotation;
    private const float angleRotateManometrStrelkaWithTree = 0.5f;
    private const float angleRotateManometrStrelkaWithMed = 1.4f;
    private const float angleRotateManometrStrelkaWithAluminiy = 0.9f;
    private const float angleRotateManometrStrelkaWithZoloto = 1.8f;
    private float angleRotateManometrStrelka = 0;
    public static bool canSetMessageIntoSmallWorkWindow = false;
    private float porshenSpeed = 9;
    private float oilSpeed = 0.1f;
    private string message1 = ". Снимите показание манометра и занесите \n соответствующее значение в таблицу";
    public float value;
    public Vector3 originalStruScale;
    //private string message2 = ". Уберите сдавленный предмет с платформы";
    // Start is called before the first frame update
    public void Start()
    {
        originalPorshenPosition = gameObject.transform.position;
        originalStrelkaRotation = strelkaManometr.transform.rotation;
        originalStruScale = stru.transform.localScale;
    }

    // Update is called once per frame
    public void Update()
    {
        if (RichagRotate.canMoveLargePorshen)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if ((hit.collider.name == "Capsule011") && StateVariables.canPressElement)
                    {
                        MoveUpPressPlatform(porshenSpeed, oilSpeed);
                        switch(PorshenScript.namePressElement)
                        {
                            case "TreePressElement": Action(treePressElement, angleRotateManometrStrelkaWithTree); break;
                            case "MedPressElement": Action(medPressElement, angleRotateManometrStrelkaWithMed); break;
                            case "AluminiyPressElement": Action(aluminiyPressElement, angleRotateManometrStrelkaWithAluminiy); break;
                            case "ZolotoPressElement": Action(zolotoPressElement, angleRotateManometrStrelkaWithZoloto); break;
                        }
                    }
                }
            }
        }

        if(StateVariables.canResetPressuare)
        {
            if (gameObject.transform.position.y > originalPorshenPosition.y)
            {
                gameObject.transform.position -= gameObject.transform.up / 20;
                oilCylinder.transform.localScale = new Vector3(oilCylinder.transform.localScale.x, oilCylinder.transform.localScale.y - oilSpeed, oilCylinder.transform.localScale.z);
                oilContainer.transform.localScale = new Vector3(oilContainer.transform.localScale.x, oilContainer.transform.localScale.y + 0.18f, oilContainer.transform.localScale.z);
                if (stru.transform.localScale.y < 24)
                {
                    stru.transform.localScale = new Vector3(stru.transform.localScale.x, stru.transform.localScale.y + 1, stru.transform.localScale.z);
                }
             }
            else
            {
                porshenSpeed = 10;
                oilSpeed = 0.1f;
                //StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message2);
                StateVariables.canMovePressElement = true;
                StateVariables.canResetPressuare = false;
            }
            angleRotateManometrStrelka = Mathf.Clamp(angleRotateManometrStrelka, 0, 360);
            if (angleRotateManometrStrelka > 0)
            {
                Quaternion rotationZ = Quaternion.AngleAxis(angleRotateManometrStrelka -= 1f, Vector3.forward);
                strelkaManometr.transform.rotation = originalStrelkaRotation * rotationZ;
            }
            switch(PorshenScript.namePressElement)
            {
                case "TreePressElement": TreeResetPosition(); break;
                case "MedPressElement": MedResetPosition(); break;
                case "AluminiyPressElement": AlminiyResetPosition(); break;
                case "ZolotoPressElement": ZolotoReserPosition(); break;
            }
        }
    }

    private void TreeResetPosition()
    {
        treePressElement.transform.position -= treePressElement.transform.up / 17;
    }
    private void MedResetPosition()
    {
        medPressElement.transform.position -= medPressElement.transform.up / 15;
    }
    private void AlminiyResetPosition()
    {
        aluminiyPressElement.transform.position -= aluminiyPressElement.transform.up / 15;
    }
    private void ZolotoReserPosition()
    {
        zolotoPressElement.transform.position -= zolotoPressElement.transform.up / 15;
    }

    private void ScalePressElement(GameObject pressElement, float angleRotateManometrStrelka)
    {
        pressElement.transform.localScale = new Vector3(pressElement.transform.localScale.x, pressElement.transform.localScale.y - 0.05f, pressElement.transform.localScale.z);
        RoteteManometrStrelka(angleRotateManometrStrelka);
    }
    //Не совсем хорошо, что я передаю угол поворота определенного предмета в действие, пока что будет так
    private void Action(GameObject pressElement, float angleRotateManometrStrelka)
    {
        if(pressElement.transform.localScale.y > 4.3)
        {
            //Перенести переменную в класс StateVariables
            if(MoveFixedPlatform.canScalePressElement)
            {
                porshenSpeed = 20;
                oilSpeed = 0.05f;
                ScalePressElement(pressElement, angleRotateManometrStrelka);
            }
            else
            {
                MoveUpPressElement(pressElement);
            }
        }
        else
        {
            StateVariables.InsertText(smallWorkWindow, smallWorkWindowText, ++StateVariables.actionNumber + message1);
            StateVariables.canInterectWithTable = true;
            StateVariables.canPressElement = false;
        }
    }
    private void RoteteManometrStrelka(float angleRotate)
    {
        Quaternion rotationZ = Quaternion.AngleAxis(angleRotateManometrStrelka += angleRotate, Vector3.forward);
        strelkaManometr.transform.rotation = originalStrelkaRotation * rotationZ;
    }
    private void MoveUpPressPlatform(float moveSpeed, float oilSpeed)
    {
        if (gameObject.transform.position.y + 46 < fixedPressPlatform.transform.position.y)
        {
            gameObject.transform.position += gameObject.transform.up / moveSpeed;
            oilCylinder.transform.localScale = new Vector3(oilCylinder.transform.localScale.x, oilCylinder.transform.localScale.y + oilSpeed, oilCylinder.transform.localScale.z);
            oilContainer.transform.localScale = new Vector3(oilContainer.transform.localScale.x, oilContainer.transform.localScale.y - 0.2f, oilContainer.transform.localScale.z);
        }
    }
    private void MoveUpPressElement(GameObject pressElement)
    {
        pressElement.transform.position += pressElement.transform.up / 10;
    }
}
