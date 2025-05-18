using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] int targetValue;


    private bool wasHit = false;

    public bool WasHit
    {
        get => wasHit;
        set => wasHit = value;
    }




    public int TargetValue => targetValue;



    public void MarkAsHit()
    {
        wasHit = true;
    }
}
