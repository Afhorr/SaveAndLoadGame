using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPrevious : MonoBehaviour {

    public void PreviousWeapon()
    {
        GameController.gameController.PreviousWeapon();
    }
}
