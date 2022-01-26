using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMove : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    private Transform turretBody;
    // Start is called before the first frame update
    void Start()
    {
        turretBody = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseRegister();
    }

    void MouseRegister()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        turretBody.Rotate(Vector3.forward * mouseY);
        turretBody.Rotate(Vector3.right * mouseX);
    }
}
