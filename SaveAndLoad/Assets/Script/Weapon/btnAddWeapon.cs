using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnAddWeapon : MonoBehaviour {

    public void IncreaseWeapon()
    {
        GameController.gameController.addWeapon();
    }
}
