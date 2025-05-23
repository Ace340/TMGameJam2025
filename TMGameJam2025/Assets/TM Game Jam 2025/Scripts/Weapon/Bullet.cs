using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f; 

    void Start()
    {
        // Destroy the bullet after its lifetime
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a Target component
        Target target = collision.gameObject.GetComponent<Target>();
        if (target != null && !target.WasHit)
        {
            ScoreManager.Instance.AddScore(target.TargetValue);
            target.MarkAsHit();
        }

        // Destroy the bullet on collision
        Destroy(gameObject);
    }
}
