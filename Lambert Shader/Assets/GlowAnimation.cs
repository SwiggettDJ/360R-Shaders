using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlowAnimation : MonoBehaviour
{
    private Material mat;
    private Animator anim;
    private float animTime;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        anim = GetComponentInParent<Animator>();
    }
    
    void Update()
    {
        animTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (mat.name == "Energy (Instance)" && animTime < 1)
        {
            mat.SetFloat("_ThicknessControl", animTime);
        }
        else
        {
            mat.SetFloat("_ThicknessControl",0f);
        }
        
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Shoot");
        }
    }
}
