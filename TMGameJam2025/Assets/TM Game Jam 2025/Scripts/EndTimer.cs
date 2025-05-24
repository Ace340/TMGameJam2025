using UnityEngine;

public class EndTimer : MonoBehaviour
{
    [SerializeField] UIManager uIManager;




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.startTime = false;
        }
    }
}
