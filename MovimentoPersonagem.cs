using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace souto
{
    public class MovimentoPersonagem : MonoBehaviour
    {
        public CharacterController controle;
        public float velocidade = 3f;
        public float alturaPulo = 3f;
        public float gravidade = -20f;
        public float andarZ = 0;
        public float andarX = 0;

        public bool estaAndando;

        Animator anim;

        public Transform checaChao; // objeto que verifica se esta pisando no chao
        public float raioEsfera = 0.4f; // Raio da esfera do Raycast
        public LayerMask chaoMask;         // atraves dessa layer da pra saber onde o personagem esta pisando neve,barro,madeira,etc
        public bool estaNochao; // verificador q devolve true ou false se ele esta no chao

        Vector3 velocidadeCai;

        //public Transform cameraTransform;
        public bool estaAbaixado;
        public bool levantarBloqueado;
        public float alturaLevantado, alturaAbaixado, posicaoCameraPe, posicaoCameraAbaixado;
        RaycastHit hit;
        void Start()
        {
            estaAndando = false;
            anim = GetComponent<Animator>();
            controle = GetComponent<CharacterController>();
            //estaAbaixado = false;
            //cameraTransform = Camera.main.transform;
        }

        void Update()
        {
            //andarZ = Input.GetAxis("Vertical");
            andarFrenteTras();
            andarLados();

        }
        void andarFrenteTras()
        {
            if (!estaAndando)
            {

                if (Input.GetKeyDown(KeyCode.W))
                {
                    andarZ += 1;


                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    andarZ = 0;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    andarZ += -1;


                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    andarZ = 0;
                }

                Vector3 move = transform.forward * andarZ;
                controle.Move(move * velocidade * Time.deltaTime);
                anim.SetFloat("AndarZ", andarZ);



            }

        }

        void andarLados()
        {
            if (!estaAndando)
            {

                if (Input.GetKeyDown(KeyCode.A))
                {
                    andarX += -1;


                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    andarX = 0;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    andarX += 1;


                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    andarX = 0;
                }

                Vector3 move = transform.right * andarX;
                controle.Move(move * velocidade * Time.deltaTime);
                anim.SetFloat("AndarX", andarX);

            }
        }
    }
}
/*
            float X = Input.GetAxis("Horizontal");
            float Z = Input.GetAxis("Vertical");
            estaNochao = Physics.CheckSphere(checaChao.position, raioEsfera, chaoMask); // cria uma esfera que idenfica a layer e se caso ele estiver em contato true se nao false

            if (estaNochao && velocidadeCai.y < 0)
            {
                velocidadeCai.y = -2f;
            }
            // manda o componente para esquerda ou direita ou pra cima ou para baixo
            // faz a movimentação do personagem time.deltatime consegue conta o tempo




            
            if (Input.GetKey(KeyCode.S))
            {

                Vector3 move = (transform.forward * Z).normalized; // manda o componente para esquerda ou direita ou pra cima ou para baixo

                controle.Move(move * velocidade * Time.deltaTime); // faz a movimentação do personagem time.deltatime consegue conta o tempo
            }
            if (Input.GetKey(KeyCode.A))
            {

                Vector3 move = (transform.right * X).normalized; // manda o componente para esquerda ou direita ou pra cima ou para baixo

                controle.Move(move * velocidade * Time.deltaTime); // faz a movimentação do personagem time.deltatime consegue conta o tempo
            }     
            
            if (Input.GetKey(KeyCode.D))
            {

                Vector3 move = (transform.right * X).normalized; // manda o componente para esquerda ou direita ou pra cima ou para baixo

                controle.Move(move * velocidade * Time.deltaTime); // faz a movimentação do personagem time.deltatime consegue conta o tempo
            }

         

        }

        private void OnDrawGizmosSelected() // usado para criar a bola amarela que toca no chao para verificar 
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(checaChao.position, raioEsfera);
        }

    }
}
            
            
   
      
            
            /*if (Input.GetButtonDown("Jump") && estaNochao)
            {
                velocidadeCai.y = Mathf.Sqrt(alturaPulo * -2f * gravidade);
            }

            velocidadeCai.y += gravidade * Time.deltaTime;

            controle.Move(velocidadeCai * Time.deltaTime);

            if (estaAbaixado)
            {
                //checaBloqueioAbaixado();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                //Abaixa();

            }

    }
      /*  void checaBloqueioAbaixado()
        {
            Debug.DrawRay(cameraTransform.position, Vector3.up * 1.1f, Color.red);
            if (Physics.Raycast(cameraTransform.position,Vector3.up, out hit, 1.1f))
            {
                levantarBloqueado = true;
            }
            else
            {
                levantarBloqueado = false;
            }

        }

       /* void Abaixa() 
        {
            if (levantarBloqueado || estaNochao == false)
                return;

            estaAbaixado = !estaAbaixado;
            if (estaAbaixado)
            {
                controle.height = alturaAbaixado;
                cameraTransform.localEulerAngles = new Vector3(0, posicaoCameraAbaixado, 0);// abaixa
            }
            else
            {
                controle.height = alturaLevantado;
                cameraTransform.localPosition = new Vector3(0, posicaoCameraPe, 0); // volta para a posicao inicial
            }

        }
       */

