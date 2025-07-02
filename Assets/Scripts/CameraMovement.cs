using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset =  new Vector3(0f, 1f, -2.5f);
    public Vector3 offsetAiming = new Vector3(1f, 2f, -2f);
    public float angleX;
    public float angleY;

    void Start()
    {
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            angleX += Input.mousePositionDelta.x *0.2f;
            angleY -= Input.mousePositionDelta.y *0.2f;
            transform.position = player.position  + transform.forward * offsetAiming.z + player.up * offsetAiming.y+player.right * offsetAiming.x;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x,angleX,transform.eulerAngles.z), 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleY,transform.eulerAngles.y,transform.eulerAngles.z), 0.1f);
            
        }
        else
        {
            angleX += Input.mousePositionDelta.x *0.2f;
            angleY -= Input.mousePositionDelta.y *0.2f;
            transform.position = player.position + transform.forward * offset.z + player.up * offset.y;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x,angleX,transform.eulerAngles.z), 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleY,transform.eulerAngles.y,transform.eulerAngles.z), 0.1f);
            //transform.Rotate(Vector3.left,Input.mousePositionDelta.y*0.1f,Space.Self);   
        }
    }
}
