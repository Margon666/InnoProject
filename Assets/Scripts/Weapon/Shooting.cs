using UnityEngine;

public class Shooting : MonoBehaviour
{
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
            if (Physics.Raycast(muzzle, out shoot, range))
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
}