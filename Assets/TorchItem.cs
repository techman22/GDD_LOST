using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class TorchItem : MonoBehaviour
{
    GameObject playerFire;
    Light2D TheLight;
    GameObject torch;
    SpriteRenderer torchSprite;
    GameObject ItemLight;
    Light2D torchLight;
    GameObject player;
    SpriteRenderer playersprite;
     
   // private Sprite newSprite;
    //string spriteName;

    // Start is called before the first frame update
    void Start()
    {
        playerFire = GameObject.FindWithTag("Fire");
        TheLight = playerFire.GetComponent<Light2D>();
        torch = GameObject.FindWithTag("Item"); 
        torchSprite = torch.GetComponent<SpriteRenderer>();
        ItemLight = GameObject.FindWithTag("Torchlight");
        torchLight = ItemLight.GetComponent<Light2D>();
        player = GameObject.FindWithTag("Player");
        playersprite = player.GetComponent<SpriteRenderer>();
       // newSprite = Resources.Load<Sprite>("torch_item_burntout");



    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            TheLight.pointLightOuterRadius += 2f;
            Destroy(ItemLight);
            Destroy(torch);

           // spriteName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
                }
    }

}
