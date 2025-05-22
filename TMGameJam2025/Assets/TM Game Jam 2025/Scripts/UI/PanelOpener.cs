using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PanelOpener : MonoBehaviour
{

    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
}
