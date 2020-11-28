using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //needed for serialization of data
public class SaveSystem : MonoBehaviour
{
    /// <summary>
    /// creates file and path for save data
    /// opens the file for save data to be streamed too
    /// create the data to be saved
    /// Converts data to text, writes the data to file and closes stream
    /// </summary>
    /// <param name="player"></param>
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/player.meme";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    /// <summary>
    /// Loads data from path and file
    /// Opens file, rebuilds data, closes stream, returns rebuilt data
    /// else throw back error and return nothing
    /// </summary>
    /// <returns>Load saved player data from player.meme</returns>
    public static PlayerData LoadPlayer()
    {
        string path = Application.dataPath + "/player.meme";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}