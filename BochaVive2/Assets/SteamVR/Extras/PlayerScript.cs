using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /*
    //Variáveis globais

    public CharacterController controller;
    private float move_x, move_z, speed = 8f, gravity = -9.81f;
    Vector3 velocity; 

    //----------------------------------------------------------

    public float mouseSense;
    public Transform playerBody; 
    float mouseX, mouseY;
    float xRotation = 0f; 

    //----------------------------------------------------------

    void Start()
    {
        //Esconder o cursor do mouse
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Definição dos botões de movimentação
        move_x = Input.GetAxis("Horizontal");
        move_z = Input.GetAxis("Vertical");

        //Definição das dos comandos nos eixos X/Z
        Vector3 move = transform.right * move_x + transform.forward * move_z;

        //Definição de velocidade para as direções dos eixos X/Z
        controller.Move(move * speed * Time.deltaTime);
        
        //Definição de velocidade gravitacional constante para o eixo Y
        velocity.y += gravity * Time.deltaTime;
        
        //Definição de velocidade para as direções dos eixos Y
        controller.Move(velocity * Time.deltaTime);

        //----------------------------------------------------------

        //Definição dos eixos de movimentação do personagem, via mouse
        mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        //Definição dos limites e da função de rotação para o eixo X
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
    */
}