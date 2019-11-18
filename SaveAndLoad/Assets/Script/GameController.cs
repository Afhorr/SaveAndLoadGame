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
    public List<Weapon> weapon;
    public int idWeapon;
	// Use this for initialization
	void Start () {
        if (gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
            SetDefaultValue();
            weapon.Add(new Weapon());
            idWeapon = 0;
            //File.Delete(Application.persistentDataPath + "gameinfo.dat");

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
        idWeapon = 0;
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
    public void NextWeapon()
    {
        if (idWeapon < weapon.Count-1)
        {
            idWeapon++;
        }
        else
        {
            idWeapon = 0;
        }
    }
    public void PreviousWeapon()
    {
        if (idWeapon != 0)
        {
            idWeapon--;
        }
        else
        {
            idWeapon = weapon.Count - 1;
        }
    }
    public void addWeapon()
    {
        weapon.Add(new Weapon());
    }
    public void addAttackToCurrentWeapon()
    {
        weapon[idWeapon].attack++;
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
        idWeapon = playerDataToLoad.idWeapon;
        weapon = playerDataToLoad.weapon;
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
        playerDataToSave.idWeapon = idWeapon;
        playerDataToSave.weapon = weapon;
        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    public void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack: " +attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense: " +defense,style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health: "+Health, style);
        GUI.Label(new Rect(10, 210, 180, 80), "Index: " + idWeapon, style);
        GUI.Label(new Rect(10, 260, 180, 80), "Weapon: " + weapon[idWeapon].attack, style);
    }
}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int Health;
    public List<Weapon> weapon;
    public int idWeapon;
}
