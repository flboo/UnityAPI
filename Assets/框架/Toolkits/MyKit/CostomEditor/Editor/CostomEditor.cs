using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEditor;
using UnityEngine;

public class CostomEditor 
{
    [MenuItem("CustomEditor/ɾ�����б�������")]
    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        string path = $"{Application.persistentDataPath}/SaveData";
        if (Directory.Exists(path))
        {
            DirectoryInfo diSource = new DirectoryInfo(path);
            FileSystemInfo[] files = diSource.GetFileSystemInfos();
            for (var i = 0; i < files.Length; i++)
            {
                File.Delete(files[i].FullName);
            }
        }
        Debug.Log("ɾ���ɹ�");
    }

    [MenuItem("CustomEditor/����浵")]
    public static void FileInit()
    {
        Dictionary<string, string> files = JsonMapper.ToObject<Dictionary<string, string>>(GUIUtility.systemCopyBuffer);
        string path = $"{Application.persistentDataPath}/SaveData";
        DeleteAllData();

        foreach (var file in files)
        {
            FileStream fs = new FileStream($"{path}/{file.Key}", FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(file.Value);  //������д�������             
            sw.Flush();
        }
        Debug.Log("����ɹ�");
    }

    [MenuItem("CustomEditor/����")]
    public static void Test()
    {
        
    }
}
