//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Valve.VR.Extras
{
    [RequireComponent(typeof(SteamVR_TrackedObject))]
    public class SteamVR_TestThrow : MonoBehaviour
    {
        public GameObject prefab;
        public Rigidbody attachPoint;

        public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

        SteamVR_Behaviour_Pose trackedObj;
        FixedJoint joint;

        // Adicione essa variável no início da classe para contar o número de bolas lançadas.
        int ballCount = 0;
        int ballCountReducao = 5;

        private bool scorePrinted = false;

        private float p1_score = 0;
        private float med = 0;
        public Text pontosText;
        public Text bolasRestantes;

        private GameObject[] clones;

        private void Awake()
        {
            trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        }
        
        void reloadScene()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SceneManager.LoadScene("ForestStage"); 
                Cursor.lockState = CursorLockMode.None;           
            }
        }

        private void FixedUpdate()
        {
            // Verifica se o jogador lançou menos de cinco bolas e se pode lançar uma nova bola.
            if (ballCount < 5 && joint == null && spawn.GetStateDown(trackedObj.inputSource))
            {
                GameObject go = GameObject.Instantiate(prefab);
                go.transform.position = attachPoint.transform.position;

                joint = go.AddComponent<FixedJoint>();
                joint.connectedBody = attachPoint;

                // Atualiza a variável de contagem de bolas.
                ballCount++;
                ballCountReducao--;
                bolasRestantes.text = "Restam: " + ballCountReducao.ToString("#.") + " bolas";
                if(ballCountReducao == 0) {
                    bolasRestantes.text = "Restam: 0 bolas";
                }
                Debug.Log(ballCount);
            }

            else if (joint != null && spawn.GetStateUp(trackedObj.inputSource))
            {
                GameObject go = joint.gameObject;
                Rigidbody rigidbody = go.GetComponent<Rigidbody>();
                Object.DestroyImmediate(joint);
                joint = null;
                //Object.Destroy(go, 15.0f);

                // We should probably apply the offset between trackedObj.transform.position
                // and device.transform.pos to insert into the physics sim at the correct
                // location, however, we would then want to predict ahead the visual representation
                // by the same amount we are predicting our render poses.

                Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
                if (origin != null)
                {
                    //alterado para 2f aumentando a velocidade
                    rigidbody.velocity = origin.TransformVector(trackedObj.GetVelocity()) * 2f;
                    rigidbody.angularVelocity = origin.TransformVector(trackedObj.GetAngularVelocity());
                }
                else
                {
                    rigidbody.velocity = trackedObj.GetVelocity();
                    rigidbody.angularVelocity = trackedObj.GetAngularVelocity();
                }

                rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
            }

            if(ballCount == 5 && !scorePrinted) //Caso a quantidade de jogadas acabe
            {
                //unir todos as bochas instanciadas em um array de objetos
                clones = GameObject.FindGameObjectsWithTag("BallTag");

                    p1_score = 0;

                    //Leitura dos valores de distancia de cada bocha e o bolim
                    for(int i=0; i<5; i++)
                    {
                        BallScript ball = clones[i].GetComponent<BallScript>();
                        p1_score += ball.distanceB;
                        if(!ball.isStopped) {
                            return;
                        }
                    }

                    //Cálculo da pontuação
                    med = p1_score/5;
                    float final_score = med * 100;
                    Debug.Log("final score: " + final_score + " cm");
                    pontosText.text = "Pontuação: " + final_score.ToString("#.") + " cm";

                    //Envio do valor da pontuação para o Canvas
                    //canvas_score_1.text = final_score.ToString("#.") + " cm";

                    scorePrinted = true;

                    //ideia: se a position nao mudar em 5sec fazer o calculo de pontuação
            }
        }
    }
}