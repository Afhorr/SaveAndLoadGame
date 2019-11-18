using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneCrontroller : MonoBehaviour {


    public void NextScene()
    {
        SceneController.sceneController.NextScene();
    }
    public void PreviousScene()
    {
        SceneController.sceneController.PreviousScene();
    }
}
