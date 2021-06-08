using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacaoCamera : MonoBehaviour
{
    public float sensibilidadeMouse = 400f; //sense
    public float anguloMin = -90f, anguloMax = 90f;
    
    public Transform transformPlayer;

    float rotacao = 0f;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
    }


    void Update()

    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        rotacao -= mouseY;
        rotacao = Mathf.Clamp(rotacao, anguloMin, anguloMax); // clamp trava o angulo para q ele n passe -90 e 90 com o  angulomin angulomax
        transform.localRotation = Quaternion.Euler(rotacao, 0, 0);

        transformPlayer.Rotate(Vector3.up * mouseX);
        transformPlayer.Rotate(Vector3.up * mouseY);
    }
}
