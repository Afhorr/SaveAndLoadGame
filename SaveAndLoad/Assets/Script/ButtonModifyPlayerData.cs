using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifyPlayerData : MonoBehaviour {

    public void IncreaseAttack()
    {
        GameController.gameController.addAttack();
    }
    public void IncreaseDefense()
    {
        GameController.gameController.addDefense();
    }
    public void IncreaseHealth()
    {
        GameController.gameController.addHealth();
    }
}
