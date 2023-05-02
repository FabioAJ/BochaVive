using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralController : MonoBehaviour
{
    /*//Variáveis Globais

    public GameObject BallPrefab;
    private GameObject[] clones;

    //----------------------------------
    
    private float p1_score = 0;
    private float med = 0;
    
    //----------------------------------

    public Text canvas_score_1;
    public Text canvas_playCount_1;

    //----------------------------------

    private int PlayCount_Single = 5, aux1 = 5, aux2 = 5;
    private bool playerFlag = false;
    private bool ballState = false;

    //----------------------------------

    //public GameObject fs_menu;

    //----------------------------------

    void Start()
    {
        //Definição da contagem inicial de bochas para cada jogador no Canvas
        canvas_playCount_1.text = 5.ToString();
    }
    
    private void single_controller() //Função para o singleplayer
    {
        if(PlayCount_Single > 0) //Caso ainda existam jogadas disponíveis:
        {
            if (Input.GetKeyDown(KeyCode.Space) && ballState == false) //Caso o botão 'espaço' seja pressionado e a bola não tenha sido instanciada: 
            {
                //Instaciar uma bocha
                Instantiate(BallPrefab, transform.position, Quaternion.identity);   
                //Flag da instacia
                ballState = true; 
            } 
            if (Input.GetMouseButtonDown(0) && ballState == true) //Caso o botão esquerdo do mouse seja pressionado e a bola não tenha instanciada:
            {
                //Flag negativo da instância
                ballState = false;
                //Diminiur a quantidade de jogadas restantes
                PlayCount_Single--;
                //Enviar o valor atualizado de jogadas ao Canvas
                canvas_playCount_1.text = PlayCount_Single.ToString();
            } 
        }

        if(PlayCount_Single == 0) //Caso a quantidade de jogadas acabe
        {
            //unir todos as bochas instanciadas em um array de objetos
            clones = GameObject.FindGameObjectsWithTag("BallTag");
            //Inicializar a pontuação do jogador
            p1_score = 0;
            //Leitura dos valores de distancia de cada bocha e o bolim
            for(int i=0; i<5; i++)
            {
                p1_score += clones[i].GetComponent<BallScript>().distanceB;
            }
            //Cálculo da pontuação
            med = p1_score/5;
            float final_score = med * 100;
            //Envio do valor da pontuação para o Canvas
            canvas_score_1.text = final_score.ToString("#.") + " cm";
        }
    }

    void reloadScene()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("ForestStage"); 
            Cursor.lockState = CursorLockMode.None;           
        }
    }

    /*
    void final_Result()
    {
        if(PlayCount_Multi == 0)
        {
            fs_menu.SetActive(true);

        }
    }
    */

    /*
    void Update()
    {
        //----------------------------------
        
        single_controller();
        reloadScene();       

        //----------------------------------
    }

    */
}
