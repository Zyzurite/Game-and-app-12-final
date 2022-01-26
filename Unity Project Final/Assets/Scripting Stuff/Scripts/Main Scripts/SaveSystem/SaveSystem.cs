using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerCombat player, DataMemory playerstats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSave data = new PlayerSave(player, playerstats);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerSave LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSave data = formatter.Deserialize(stream) as PlayerSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}