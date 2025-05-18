using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float shootDistance = 100f;
    [SerializeField] private LayerMask hitLayers;

    void Update()
    {
        // Dispara solo cuando se hace click izquierdo
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        Vector3 origin = shootOrigin.position;
        Vector3 direction = shootOrigin.forward;

        Debug.DrawRay(origin, direction * shootDistance, Color.green, 1f);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, shootDistance))
        {

            Target target = hit.collider.gameObject.GetComponent<Target>();

            if (target)
            {
                if (!target.WasHit)
                {

                    ScoreManager.Instance.AddScore(target.TargetValue);
                    target.MarkAsHit();
                }

            }

        }
    }
}
