using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;
using System;

public class SaveManager : MonoBehaviour
{
    private void OnDisable()
    {
        saveData();
    }

    [Serializable]
    public class UneccessaryOverdimensionatedDataClass
    {
        public UneccessaryOverdimensionatedDataClass(int i)
        {
            sceneIndex = i;
        }
        public int sceneIndex;
    }

    public void saveData()
    {
        UneccessaryOverdimensionatedDataClass uneccessaryOverdimensionatedDataClass
            = new UneccessaryOverdimensionatedDataClass(SceneManager.GetActiveScene().buildIndex);

        string path = Application.persistentDataPath + "/Savefile.save";
        string data = JsonUtility.ToJson(uneccessaryOverdimensionatedDataClass);

        StreamWriter writer = new StreamWriter(path);
        writer.Write(data);
        writer.Close();

        Debug.Log(SceneManager.GetActiveScene().name + " saved");
    }
}
