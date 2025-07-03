using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootdur = 0.1f;
    public LineRenderer shootWi;
    public WeaponMovement wpmv;
    public Camera playerCamera;
    public float range = 100f;
    public float damage = 10f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject weapon = wpmv.ReturnWeapon();
        Ray aimray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 aimPoint;
        if (Physics.Raycast(aimray, out hit, range))
        {
            aimPoint = hit.point;
        }
        else
        {
            aimPoint = aimray.GetPoint(range);
        }

        wpmv.WeaponTurn(aimPoint);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit shoot;
            Ray muzzle = new Ray(weapon.transform.position, weapon.transform.forward);
            bool hasHit = Physics.Raycast(muzzle, out shoot, range);
            shootWi.SetPosition(0, weapon.transform.position);
            shootWi.SetPosition(1, hasHit ? shoot.point : weapon.transform.position + weapon.transform.forward * range);
            shootWi.enabled = true;
            Invoke("DisableLaser", shootdur);
            if (hasHit)
            {
                GameObject shooted = shoot.collider.gameObject;
                if (shoot.collider.GetComponent<NPCscript>())
                {
                    NPCscript enemy = shoot.collider.GetComponent<NPCscript>();
                    enemy.getDamage(damage);
                }
            }
        }
    }

    void DisableLaser()
    {
        shootWi.enabled = false;
    }
}