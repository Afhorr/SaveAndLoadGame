using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSaveAndLoad : MonoBehaviour {

    public void Save()
    {
        GameController.gameController.save();
    }
    public void Load()
    {
        GameController.gameController.load();
    }
}
