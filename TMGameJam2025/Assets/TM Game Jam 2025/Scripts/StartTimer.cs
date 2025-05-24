using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] UIManager uIManager;




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.StartTimer();
        }
    }
}
