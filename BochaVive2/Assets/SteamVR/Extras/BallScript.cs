using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public float distanceB;
    public bool isStopped = false;
    
    private bool isOnGround = false;

    //Variáveis Globais
    private GameObject BallTarget;

    /*public float ballThrowForce;
    private bool holdingState = true;
    private float distOffset = 1f;*/

    private GameObject centerBall;
    private Rigidbody rb;

    private void ball_Distance()
    {
        distanceB = Vector3.Distance(this.gameObject.transform.position, centerBall.transform.position);
    }

    /*


    //--------------------------------------------------------------------------------------------------------------

    private void ballPhysics()
    {
        if (holdingState) //Caso o jogador esteja sob posse da bola:
        {
            //Copiar a posição do bocha para o player 
            gameObject.transform.position = BallTarget.transform.position + (BallTarget.transform.forward*distOffset);

            if (Input.GetMouseButtonDown(0)) //Caso o botão esquerdo do mouse seja pressionado:
            {   
                holdingState = false;
                
                //Inserir gravidade ao bocha
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                //Realizar o arremesso da bola por meio da adição de uma força no sentido frontal
                gameObject.GetComponent<Rigidbody>().AddForce(BallTarget.transform.forward * ballThrowForce);
                //Ligar o componente renderizador do bocha
                gameObject.GetComponent<MeshRenderer>().enabled = true;     
            }
        }
    }

    //--------------------------------------------------------------------------------------------------------------
*/

    void Start()
    {      
        /*//Inicialmente o bocha não deve ter influencia gravitacional
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        //Inicialmente o componente renderizador do bocha deve estar desativado
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        
        if(BallTarget == null) //Caso a mira da bola (para a camera a auxiliar) estiver vazia:
        {
            //Preencher o objeto vazio com a posição da Camera
            BallTarget = GameObject.FindWithTag("MainCamera");
        }*/

        //Definir a posição do bolim com o objeto da bola de referencia
        centerBall = GameObject.Find("BallRef");
        rb = this.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //ballPhysics();
        ball_Distance();
        if(isOnGround == true && rb.velocity == Vector3.zero) {
            isStopped = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("GroundTag"))
        {
            isOnGround = true;
        }
    }
    
}