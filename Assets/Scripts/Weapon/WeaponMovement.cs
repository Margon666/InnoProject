using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public float rotSpeed = 0.1f;
    public GameObject Weapon;
    public float angleX;
    public float angleY;

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