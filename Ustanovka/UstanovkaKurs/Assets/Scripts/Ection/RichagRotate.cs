using Assets.Scripts.Ection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichagRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;

    private float mouseSens = 10;
    public float mouseY;
    private float pred;
  
    private Quaternion originalRotation;
    
    public GameObject smallPorhsen;
    public GameObject clapan1;
    public GameObject clapan2;
    public GameObject largePorshen;

    private float minYposPorshen;
    private float maxYposPorshen = 40;
    private float minrotationZRichag;
    private float maxrotationZRichag = 32;
    private float deltaRichag;
    private float kPorschenAndClapan;

    public float minYposClapan1;
    private float maxYposClapan1 = 39f;
    private float kClapan1;

    private float minYposClapan2;
    private float maxYposClapan2 = 46.7f;
    private float kClapan2;

    public static bool canMoveLargePorshen = false;
    public void Start()
    {
        originalRotation = transform.rotation;

        minYposPorshen = smallPorhsen.transform.position.y;
        minrotationZRichag = 360 - transform.rotation.eulerAngles.z;
        kPorschenAndClapan = (maxrotationZRichag - minrotationZRichag) / (maxYposPorshen - minYposPorshen);

        minYposClapan1 = clapan1.transform.position.y;
        kClapan1 = (maxrotationZRichag - minrotationZRichag) / (maxYposClapan1 - minYposClapan1);

        minYposClapan2 = clapan2.transform.position.y;
        kClapan2 = (maxrotationZRichag - minrotationZRichag) / (maxYposClapan2 - minYposClapan2);
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
                if ((hit.collider.name == gameObject.name) && StateVariables.canPressElement)
                {
                    mouseY += Input.GetAxis("Mouse Y") * mouseSens;
                    if (mouseY != 0)
                    {
                        mouseY = Mathf.Clamp(mouseY, 0, 24);
                        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.forward);
                        pred = 360 - transform.rotation.eulerAngles.z;
                        transform.rotation = originalRotation * rotationX;
                        deltaRichag = 360 - transform.rotation.eulerAngles.z - minrotationZRichag;

                        //Перемещение малого поршня
                        smallPorhsen.transform.position = new Vector3(smallPorhsen.transform.position.x, minYposPorshen + (deltaRichag / kPorschenAndClapan), smallPorhsen.transform.position.z);

                        //Перемещение клапанов
                        if (pred < 360 - transform.rotation.eulerAngles.z)
                        {
                            clapan1.transform.position = new Vector3(clapan1.transform.position.x, minYposClapan1 + (deltaRichag / kClapan1) - 1, clapan1.transform.position.z);
                        }
                        if (pred > 360 - transform.rotation.eulerAngles.z)
                        {
                            clapan2.transform.position = new Vector3(clapan2.transform.position.x, maxYposClapan2 - (deltaRichag / kClapan2), clapan2.transform.position.z);
                            canMoveLargePorshen = true;
                        }
                        else
                        {
                            canMoveLargePorshen = false;
                        }
                    }
                }
            }
        }
        //Возвращение клапанов в исходное состояние
        if (clapan2.transform.position.y > minYposClapan2)
        {
            clapan2.transform.position = new Vector3(clapan2.transform.position.x, clapan2.transform.position.y - 0.02f, clapan2.transform.position.z);
        }
        if(clapan1.transform.position.y > minYposClapan1)
        {
            clapan1.transform.position = new Vector3(clapan1.transform.position.x, clapan1.transform.position.y - 0.03f, clapan1.transform.position.z);
        }
    }
}
