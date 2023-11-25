using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] private Text CoinText;
    [SerializeField] private AudioSource CoinCollectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Collision with Coin detected!");

            CoinCollectSound.Play();
            Destroy(collision.gameObject);
            coins++;
            CoinText.text = "Coin : " + coins;
            Debug.Log("Coin " + coins);
        }
    }

    
}
