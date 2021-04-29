using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAttack : MonoBehaviour
{

    public float speed = 1;
    public Transform target;
    public float attackRange;
    private float attackTime;
    public float attackDelay;
    public GameObject projectile;
    public float projForce;
    bool hiding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer < attackRange)
            {
                Vector3 targetDir = target.position - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);
                //transform.rotation = ;
                if (Time.time > attackTime + attackDelay)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);
                    //check if ray hit player
                    if (hit.transform == target && hiding == false)
                    {
                        GameObject newProj = Instantiate(projectile, transform.position, transform.rotation);
                        newProj.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, projForce));
                        attackTime = Time.time;
                    }
                }
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            hiding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            hiding = false;
        }
    }
}
