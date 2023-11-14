using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayForCoins : MonoBehaviour
{
    public void PayTurretBullet()
    {
        if (UILevelProgress.currentMomey >= 3)
        {
            UILevelProgress.currentMomey -= 3;
            Turret.currentprojectileAmount += 2;
        }
        else return;
    }

    public void PayTurretDamage()
    {
        if (UILevelProgress.currentMomey >= 2)
        {
            UILevelProgress.currentMomey -= 2;
            Turret.currentDamage += 2;
        }
        else return;
    }

    public void PayTurretFireRate()
    {
        if (UILevelProgress.currentMomey >= 3)
        {
            UILevelProgress.currentMomey -= 3;
            Turret.currentFireRate += 0.2f;
        }
        else return;
    }

}
