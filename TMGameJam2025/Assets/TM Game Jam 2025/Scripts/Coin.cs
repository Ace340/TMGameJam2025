using UnityEngine;
using System;
using System.Collections;

public class Coin : MonoBehaviour
{



    [SerializeField] GameObject coin;
    [SerializeField] AudioSource coinsound;







    void OnTriggerEnter(Collider other)



    {
        Debug.Log("hay colision");
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(50);
            coin.SetActive(false);
            coinsound.Play();
        }
    }

}