using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNext : MonoBehaviour {

    public void NextWeapon()
    {
        GameController.gameController.NextWeapon();
    }

}
