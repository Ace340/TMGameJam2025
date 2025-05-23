using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireCooldown = 0.5f;
    [SerializeField] private GameObject bulletPrefab;

    private float lastFireTime;

    [SerializeField] private AudioSource shootSound; 

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= lastFireTime + fireCooldown)
        {
            ShootBullet();
            lastFireTime = Time.time;
            shootSound.Play();
        }
    }

    private void ShootBullet()
    {
        // Instantiate the bullet at the shootOrigin position and rotation
        GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);

        // Apply velocity to the bullet if it has a Rigidbody
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.linearVelocity = shootOrigin.forward * bulletSpeed; 
        }
    }


    //[SerializeField] private float shootDistance = 100f;
    //[SerializeField] private LayerMask hitLayers;












    // Logica Roberto
    //void Update()
    //{
    //    if (Mouse.current.leftButton.wasPressedThisFrame)
    //    {
    //        ShootRay();
    //    }
    //}

    //private void ShootRay()
    //{
    //    Vector3 origin = shootOrigin.position;
    //    Vector3 direction = shootOrigin.forward;

    //    Debug.DrawRay(origin, direction * shootDistance, Color.green, 1f);

    //    if (Physics.Raycast(origin, direction, out RaycastHit hit, shootDistance))
    //    {

    //        Target target = hit.collider.gameObject.GetComponent<Target>();

    //        if (target)
    //        {
    //            if (!target.WasHit)
    //            {

    //                ScoreManager.Instance.AddScore(target.TargetValue);
    //                target.MarkAsHit();
    //            }

    //        }

    //    }
    //}
}
