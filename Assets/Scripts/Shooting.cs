using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public WeaponMovement wpmv;
    public Camera playerCamera;
    public float range = 100f;

    public float damage = 10f;

    // // Update is called once per frame
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
            ////Debug.Log("Shoot!");
            Ray muzzle = new Ray(weapon.transform.position, weapon.transform.forward);
            if (Physics.Raycast(muzzle, out shoot, range))
            {
                GameObject shooted = shoot.collider.gameObject;
                //Debug.Log(shooted.name);
                if (shoot.collider.GetComponent<NPCscript>())
                {
                    NPCscript enemy = shoot.collider.GetComponent<NPCscript>();
                    enemy.getDamage(damage);
                    //Debug.Log(shooted.name + " is being hit");
                }
            }
        }
    }
}