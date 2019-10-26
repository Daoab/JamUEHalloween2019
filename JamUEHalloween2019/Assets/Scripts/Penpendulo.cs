using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penpendulo : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetBool("meneo", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
