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

    public float bulletScale { get; set; } = 1f;

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
            return;
        }

        if (canFire & !shieldUp)
        {
            List<GameObject> bullets = currentWeapon.Fire(position, direction, bulletScale);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].GetComponent<BallController>().parentWeaponManager = this.GetComponent<WeaponManager>();
                bullets[i].GetComponent<BallController>().parentPlayer = this.GetComponent<Player>();
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
