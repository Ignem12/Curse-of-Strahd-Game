using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private Text coinsNumber;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Collectible")){
            Destroy(collision.gameObject);
            coins++;
            coinsNumber.text = "  "+coins;
        }
    }
}
