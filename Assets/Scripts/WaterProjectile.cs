using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WaterProjectile : MonoBehaviour
{
    Light2D TheLight;
    GameObject playerFire;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        playerFire = GameObject.FindWithTag("Fire");
        TheLight = playerFire.GetComponent<Light2D>();
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.CompareTag("Fire"))
        {
            TheLight.pointLightOuterRadius -= .01f;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
