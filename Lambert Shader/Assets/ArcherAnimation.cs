using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimation : MonoBehaviour
{
    public GameObject displayArrow;
    public GameObject prefabArrow;
    private Animator anim;
    private bool shouldFire;
    private Material mat;
    void Start()
    {
        anim = GetComponent<Animator>();
        mat = GetComponentInChildren<Renderer>().material;
    }
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Shoot");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("OverDraw"))
        {
            foreach (SkinnedMeshRenderer skin in displayArrow.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                skin.enabled = true;
                shouldFire = true;
            }
        }
        else
        {
            foreach (SkinnedMeshRenderer skin in displayArrow.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                skin.enabled = false;
            }

            if (shouldFire)
            {
                
                GameObject newArrow = Instantiate(prefabArrow, displayArrow.transform.position, displayArrow.transform.rotation);
                newArrow.GetComponentInChildren<Renderer>().material.SetFloat("_ThicknessControl", 1f);
                foreach (Animator item in newArrow.GetComponentsInChildren<Animator>())
                {
                    item.speed = 0;
                    item.Play("ArrowAnim",0,1f);
                }
                shouldFire = false;
            }
        }
    }
}
