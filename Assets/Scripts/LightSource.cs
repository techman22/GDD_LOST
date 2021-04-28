using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LightSource : MonoBehaviour
{
    GameObject playerFire;
    Light2D TheLight;
    //public Transform flamePosition;
    //public GameObject projectile;
    //public float projectileSpeed;
    //private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerFire = GameObject.FindWithTag("Fire");
        TheLight = playerFire.GetComponent<Light2D>();
       FindObjectOfType<AudioManager>().Play("Fire");
        //rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.velocity = transform.right * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (TheLight.pointLightOuterRadius >= 2)
        {
            TheLight.pointLightOuterRadius -= .0009f;
            GetComponent<CircleCollider2D>().radius -= .0009f;
        }
        else
        {
            TheLight.pointLightOuterRadius -= .0002f;
            GetComponent<CircleCollider2D>().radius -= .0002f;
        }
        if (TheLight.pointLightOuterRadius <= 0f)
        {
            Destroy(playerFire);
            if (SceneManager.GetActiveScene().buildIndex <= 1)
                SceneManager.LoadScene("Tutorial");
            else
            {
                SceneManager.LoadScene(5);
            }
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Instantiate(projectile, flamePosition.position, flamePosition.rotation);

        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // if(collision.tag == "Ground")
    //    {
    //        // Instantiate(impactEffect, transform.position, Quaternion.identity);
    //        // Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}
