using UnityEngine;

public class HealRoom : MonoBehaviour
{
    public bool isHeal = false;
    public GameObject player;

    void Update()
    {
        if (!isHeal && Mathf.Abs(transform.position.x - player.transform.position.x) <= 5 &&
            Mathf.Abs(transform.position.z - player.transform.position.z) <= 5)
        {
            player.GetComponent<Parameters>().Heal(700);
        }
    }
}