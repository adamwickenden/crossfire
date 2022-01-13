using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public int maxBulletCount { get; set; }
    public float goalScaleFactor { get; set; }

    public bool canFire { get; set; }
    public bool shieldUp { get; set; }

    public List<GameObject> activeBullets { get; set; }

    public GoalScale goal { get; set; }

    public IWeapon currentWeapon { get; set; }

    private bool weaponChanged;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        weaponChanged = false;
        currentWeapon = new BaseWeapon();
        activeBullets = new List<GameObject>();
        maxBulletCount = currentWeapon.GetTotalBullets();
        goalScaleFactor = currentWeapon.GetGoalScaleFactor();
    }

    void Update()
    {
        CheckCanShoot();

        if (weaponChanged)
        {
            maxBulletCount = currentWeapon.GetTotalBullets();
            goalScaleFactor = currentWeapon.GetGoalScaleFactor();
            weaponChanged = false;
        }


    }

    // Update is called once per frame
    public void Fire(Vector3 position, Vector3 direction)
    {
        if (activeBullets.Count >= maxBulletCount)
        {
            Debug.Log("MaxBullets");
            return;
        }

        if (canFire & !shieldUp)
        {
            List<GameObject> bullets = currentWeapon.Fire(position, direction);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].GetComponent<BallController>().parentManager = this.GetComponent<WeaponManager>();
                goal.ScaleUp(goalScaleFactor);
                activeBullets.Add(bullets[i]);
            }
        }
    }

    private void CheckCanShoot()
    {
        if ((currentWeapon.GetTotalBullets() - activeBullets.Count) >= currentWeapon.GetBulletsPerShot())
        {
            canFire = true;
        }
        else { canFire = false; }
    }

    public void ChangeWeapon(IWeapon weapon)
    {
        currentWeapon = weapon;
        weaponChanged = true;
    }
}
