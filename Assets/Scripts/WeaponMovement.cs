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

        
        //более - менне рабочий
        // Vector3 currentForward = Weapon.transform.forward; 
        // Vector3 desiredDir = (targetPoint - Weapon.transform.position).normalized;
        // Quaternion deltaRot = Quaternion.FromToRotation(currentForward, desiredDir);
        // transform.rotation = deltaRot * transform.rotation;
        
        
        
        
       //  Vector3 dir = targetPoint - Weapon.transform.position;
       //  Vector3 localDir = transform.InverseTransformDirection(dir);
       //  Quaternion targetrot=Quaternion.LookRotation(dir,Vector3.up);
       //  Quaternion parrot = Quaternion.LookRotation(dir,transform.up);
       //  transform.rotation=Quaternion.RotateTowards(transform.rotation, targetrot,rotSpeed*Time.deltaTime);
    }
    public GameObject ReturnWeapon()
    {
        return Weapon;
    }
}
