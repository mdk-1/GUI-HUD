using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{   
    //variables to be saved to file
    public int level;
    public float health;
    public float[] position; // = Vector3 / cant serialize unity specific components - store vector in float array

    //reference to what data is being saved and from where
    public PlayerData(PlayerController player)
    {
        level = player.level;
        health = GameManager.instance.currentHealth;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}