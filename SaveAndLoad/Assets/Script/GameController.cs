using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {
    public static GameController gameController;

    public int attack;
    public int defense;
    public int Health;

	// Use this for initialization
	void Start () {
        if (gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
            SetDefaultValue();
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
    public void SetDefaultValue()
    {
        attack = 1;
        defense = 1;
        Health = 1;
    }
    public void addAttack()
    {
        attack++;
    }
    public void addDefense()
    {
        defense++;
    }
    public void addHealth()
    {
        Health++;
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void load()
    {

        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameinfo.dat"))
        {
            throw new Exception("Game file not exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameinfo.dat", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        Health = playerDataToLoad.Health;        
        file.Close();
    }
    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameinfo.dat", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.Health = Health;
        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    public void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack" +attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense" +defense,style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health "+Health, style);
    }
}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int Health;
}
