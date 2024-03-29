﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBoi : MonoBehaviour
{
    Animator anim;
    bool hiding;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hiding = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fire")
        {
            anim.Play("Hide");
            hiding = true;
        }

        //if (other.gameObject.tag == "Hurt")
        //{
        //    if (hiding == false)
        //    {
        //        anim.Play("ShadowAttack");
        //    }
        //    else
        //    {
        //        GetComponent<Collider>().enabled = false;
        //    }
        //}

        if(other.gameObject.tag == "Projectile")
        {
            anim.Play("Hide");
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fire")
        {
            anim.Play("PopShadow");
            hiding = false;
        }
    }
}
