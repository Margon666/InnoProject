using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public bool isAiming = false;
    public Image crosshair;
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }
        crosshair.enabled = isAiming;
    }
}