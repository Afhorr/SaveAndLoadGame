using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnAddAttackWeapon : MonoBehaviour {

    public void IncreaseAttackWeapon()
    {
        GameController.gameController.addAttackToCurrentWeapon();
    }
}
