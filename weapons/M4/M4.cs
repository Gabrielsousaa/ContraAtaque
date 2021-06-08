using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4 : MonoBehaviour
{

    Animator anim;
    bool estaAtirando;
    RaycastHit hit;
   
    
    void Start()
    {
        estaAtirando = false;
        anim = GetComponent<Animator>();
     
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!estaAtirando)
            {
                estaAtirando = true;
                StartCoroutine(Atirando());
            }

        }
    }

        IEnumerator Atirando()
        {
        float screenX = Screen.width / 2;
        float screenY = Screen.height / 2;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(screenX, screenY));
        anim.Play("Atira");

        if (Physics.SphereCast(ray, 0.1f, out hit))
        {
            if(hit.transform.tag == "objArrasta"){
                Vector3 direcaoBala = ray.direction;
                if (hit.rigidbody != null)
                {
                    
                }
            } 


        yield return new WaitForSeconds(0.1f);
        estaAtirando = false;
 

        }

    }

}



