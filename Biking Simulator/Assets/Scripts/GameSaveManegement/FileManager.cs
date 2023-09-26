using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public static class FileManager {
    public static void WriteToFile(string fileName, BikeFrame fileContents) {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, JsonUtility.ToJson(fileContents)); 
    }
    public static void WriteToFile(string fileName, LevelSave fileContents) {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, JsonUtility.ToJson(fileContents)); 
    }
    public static void WriteToFile(string fileName, LoadSave fileContents) {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, JsonUtility.ToJson(fileContents)); 
    }
    public static void WriteToFile(string fileName, DistanceCounter fileContents) {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, JsonUtility.ToJson(fileContents)); 
    }

    public static string LoadFromFile(string fileName) {
        string result = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
        return result;
    }
}
