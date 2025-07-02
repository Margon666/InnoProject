using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetMouseButton(1)) // бег
        {
            animator.SetBool("RunForward", true);
        }
        else
        {
            animator.SetBool("RunForward", false);
        }
        
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) // ходьба
        {
            animator.SetBool("WalkForward", true);
        }
        else
        {
            animator.SetBool("WalkForward", false);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetMouseButton(1)) // повороты
        {
            if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) // направо
            {
                animator.SetBool("TurnRight", true);
            }
            else
            {
                animator.SetBool("TurnRight", false);
            }
            if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) // налево
            {
                animator.SetBool("TurnLeft", true);
            }
            else
            {
                animator.SetBool("TurnLeft", false);
            }
        }
    }
}
