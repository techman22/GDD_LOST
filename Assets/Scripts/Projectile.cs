using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    //public GameObject tmpLight;
    private Rigidbody2D rigidbody;
    private float countDown = 0;
    GameObject player;
    SpriteRenderer playersprite;
    GameObject projectile;
    SpriteRenderer fireball;


    public IEnumerator StartCountdown(float countdownValue, GameObject theProjectile)
    {

        countDown = countdownValue;
        while (countDown > 0)
        {
            Debug.Log("Countdown: " + countDown);
            if (countDown == 1)
                Destroy(theProjectile);
            yield return new WaitForSeconds(1.0f);
            countDown--;
        }
       // Destroy(theProjectile);
    }
    public float projectileTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playersprite = player.GetComponent<SpriteRenderer>();
        projectile = GameObject.FindWithTag("Projectile");
        fireball = projectile.GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        if (playersprite.flipX == false)
        {
            fireball.flipX = false;
            rigidbody.velocity = transform.right * projectileSpeed;
        }
        else
        {
            fireball.flipX = true;
            rigidbody.velocity = transform.right * -projectileSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if(collision.tag == "Ground"){
        // Instantiate(tmpLight, transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(StartCountdown(1, this.gameObject));
        }
        else
        {
            StartCoroutine(StartCountdown(3, this.gameObject));
        }
            // Destroy(collision.gameObject);
           // Destroy(tmpLight);
            //Destroy(this.gameObject);
       // }
    }

   

}
