using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rot_speed = 100f;
    public float spd = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = spd;
        if (Input.GetMouseButton(1))
        {
            transform.position += transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"); //вперед-назад
            transform.position += transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"); //право-лево
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetMouseButton(1)) //бег
            {
                speed = Running(speed);
            }

            if (Input.GetKey(KeyCode.D) && !Input.GetMouseButton(1))
            {
                transform.Rotate(Vector3.up * rot_speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) && !Input.GetMouseButton(1))
            {
                transform.Rotate(-Vector3.up * rot_speed * Time.deltaTime);
            }

            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     rb.AddForce(Vector3.up * 50, ForceMode.Impulse);
            // }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position +=
                    transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"); //вперед-назад
            }
        }
    }

    float Running(float speed)
    {
        speed += spd;
        return speed;
    }
}