using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu()]
public class AvatarID : ScriptableObject
{
    public int BGIndex;
    public int IconIndex;
    public int EyesIndex;
    public int MouthIndex;
    public int HatIndex;

    public string SavePath => Application.persistentDataPath + Path.DirectorySeparatorChar + name + ".txt";

    public void SaveData()
    {
        string avatarData = JsonUtility.ToJson(this, true);
        File.WriteAllText(SavePath, avatarData);
    }
    public void LoadData()
    {
        if(File.Exists(SavePath))
        {
            string loadedAvatarData = File.ReadAllText(SavePath);
            JsonUtility.FromJsonOverwrite(loadedAvatarData, this);
        }
    }

}
