using UnityEngine;
using System;
using System.Collections;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioSource coinound;







    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(50);
            StartCoroutine(PlaySoundAndDisable());
        }
    }

    IEnumerator PlaySoundAndDisable()
    {
        coinound.Play();
        yield return new WaitForSeconds(coinound.clip.length);
        gameObject.SetActive(false);
    }
}