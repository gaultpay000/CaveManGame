using System.IO;
using UnityEngine;

public class SaveLoadBase 
{
    public static void Save(string fileName, GameData2 data)
    //public static void Save(string fileName, 
    {
        if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\GameData\\"))
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\GameData\\");

        //string path = Application.persistentDataPath + "/" + fileName + ".json";
        string path = Directory.GetCurrentDirectory() + "\\GameData\\" + fileName + ".json";

        string json = JsonUtility.ToJson(data);
        Debug.Log(data);
        //Debug.Log(data.weapons.Length);
        StreamWriter sw = new StreamWriter(path);
        sw.Write(json);
        sw.Close();

        //File.WriteAllText(path, JsonUtility.ToJson(data, true)); //pretty print, true

        Debug.Log(path);
    }

    public static GameData2 Load(string fileName)
    {
        //string path = Application.persistentDataPath + "/" + fileName + ".json";
        string path = Directory.GetCurrentDirectory() + "\\GameData\\" + fileName + ".json";

        if (File.Exists(path))
        {
            string json = string.Empty;
            StreamReader sr = new StreamReader(path);
            json = sr.ReadToEnd();

            GameData2 data = JsonUtility.FromJson<GameData2>(json);
            sr.Close();

            //GameData2 data = JsonUtility.FromJson<GameData2>(File.ReadAllText(path));

            return data;
        }

        return null;
    }
}
