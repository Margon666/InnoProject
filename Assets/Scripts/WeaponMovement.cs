using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float angleX;
    public float angleY;
    public float rotSpeed=0.1f;
    public GameObject Weapon;
    public void WeaponTurn(Vector3 targetPoint)
    {
        Vector3 direction = targetPoint - Weapon.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(direction, Vector3.up);
        Quaternion parentRot = lookRot * Quaternion.Inverse(Weapon.transform.localRotation);
        transform.rotation = parentRot;
    }
    public GameObject ReturnWeapon()
    {
        return Weapon;
    }
}
