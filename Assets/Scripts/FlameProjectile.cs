using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlameProjectile : MonoBehaviour
{
    public Transform flamePosition;
    public GameObject projectile;
    GameObject playerFire;
    Light2D TheLight;
    //SpriteRenderer sprite;

    private float timeBtwShots;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    private void Start()
    {
        playerFire = GameObject.FindWithTag("Fire");
        TheLight = playerFire.GetComponent<Light2D>();
       // sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TheLight.pointLightOuterRadius -= .1f;
                Instantiate(projectile, flamePosition.position, flamePosition.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
            timeBtwShots -= Time.deltaTime;
    }
}


