using UnityEngine;
public class NPCscript : MonoBehaviour
{
    public float hp = 100f;
    public void getDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}