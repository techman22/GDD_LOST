using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{

    public GameObject Text;
    Animator anim;
    float delay = 3;
    bool timer = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Text.SetActive(false);
        anim.Play("SlimeBoi");
       
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == true)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.SetActive(true);
            timer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.SetActive(false);
            timer = false;
        }
    }
}
