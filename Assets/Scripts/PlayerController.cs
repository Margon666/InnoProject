using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0;
            transform.forward = cameraForward;
        }
    }
}