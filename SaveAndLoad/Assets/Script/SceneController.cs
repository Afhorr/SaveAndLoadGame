using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController sceneController;

    // Use this for initialization
    void Start() {
        if (sceneController == null)
        { 
            DontDestroyOnLoad(gameObject);
            sceneController = this;
        }
        else
        {
            Destroy(gameObject);
}
	}

    public void NextScene()
    {
        if (SceneManager.sceneCountInBuildSettings-1 > SceneManager.GetActiveScene().buildIndex)
        {
            print(" Loading: " + SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            print(" Error can't load scene: this is the last scene");
        }
    }
    public void PreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex !=0)
        {
            print(" Loading: " + (SceneManager.GetActiveScene().buildIndex - 1));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            print(" Error can't load scene: this is the first scene");
        }
    }
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 56;
        GUI.Label(new Rect(10,10,180,80),"Active Scene : " + SceneManager.GetActiveScene().buildIndex, style);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
