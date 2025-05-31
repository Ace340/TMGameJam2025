using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource coinSound; 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hay colisión");
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(50);

            // Play Sound
            if (coinSound != null)
            {
                coinSound.Play();
            }

            if (coinSound != null && coinSound.clip != null)
            {
                Destroy(gameObject, coinSound.clip.length);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}