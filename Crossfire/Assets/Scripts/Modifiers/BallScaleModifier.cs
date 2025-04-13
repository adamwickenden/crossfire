
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class BallScaleModifier : IModifier
{
    public WeaponManager weaponManager;
    
    public float Timeout {get;} = 20f;
    
    // Start is called before the first frame update
    public void Activate(GameObject collision)
    {   
        weaponManager = collision.GetComponentInParent<WeaponManager>();
        
        float bulletScale = Random.value;
        weaponManager.bulletScale = bulletScale;
    }
    
    public void Deactivate()
    {
        weaponManager.bulletScale = 1f;
    }

}
