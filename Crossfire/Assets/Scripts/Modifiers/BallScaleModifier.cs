using UnityEngine;

public class BallScaleModifier : IModifier
{
    private WeaponManager weaponManager;
    
    public float Timeout {get;} = 5f;
    
    // Start is called before the first frame update
    public void Activate(GameObject collision)
    {
        weaponManager = collision.GetComponent<BallController>().parentWeaponManager;
        
        int x = Random.Range(0, 2);
        switch (x) 
        {
            case 0:
                weaponManager.bulletScale = 0.05f;
                break;
            case 1:
                weaponManager.bulletScale = 0.5f;
                break;
        }
    }

    public void Deactivate()
    {
        weaponManager.bulletScale = 0.2f;
    }

}
