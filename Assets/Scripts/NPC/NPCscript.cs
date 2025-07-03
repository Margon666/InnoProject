using UnityEngine;
using System.Collections;

public class NPCscript : MonoBehaviour
{
    public WeaponMovement Weapon;
    public float shootdur = 0.1f;
    public LineRenderer shootWi;
    public float range = 100f;
    public GameObject player;
    public GameObject muzzle;
    public float damage;
    public float deltaX;
    public float deltaY;
    public float deltaZ;
    public float hp;

    void Start()
    {
        StartCoroutine(Shooting());
        StartCoroutine(deltas());
        damage = Random.Range(1, 10);
        hp = Random.Range(30, 70);
    }

    void Update()
    {
        Vector3 dir = new Vector3(player.transform.position.x + deltaX, player.transform.position.y + deltaY,
            player.transform.position.z + deltaZ);
        Weapon.WeaponTurn(dir);
        lookAtPlayer();
    }

    void lookAtPlayer()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
        }
    }

    public void getDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(Random.Range(0.3f, 1.8f));
        }
    }

    void Shoot()
    {
        RaycastHit shoot;
        Ray sht = new Ray(muzzle.transform.position, muzzle.transform.forward);
        bool hasHit = Physics.Raycast(sht, out shoot, range);
        shootWi.SetPosition(0, muzzle.transform.position);
        shootWi.SetPosition(1, hasHit ? shoot.point : muzzle.transform.position + muzzle.transform.forward * range);
        shootWi.enabled = true;
        Invoke("DisableLaser", shootdur);
        if (hasHit)
        {
            GameObject shooted = shoot.collider.gameObject;
            if (shoot.collider.GetComponent<Parameters>())
            {
                shooted.GetComponent<Parameters>().GetDamage(damage);
            }
        }
    }

    void DisableLaser()
    {
        shootWi.enabled = false;
    }

    IEnumerator deltas()
    {
        while (true)
        {
            deltaX = Random.Range(-0.3f, 0.3f);
            deltaY = Random.Range(-0.3f, 0.3f);
            deltaZ = Random.Range(-0.3f, 0.3f);
            yield return new WaitForSeconds(5);
        }
    }
}