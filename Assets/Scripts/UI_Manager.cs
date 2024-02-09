using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    private static int sceneIndex;

    public void StartGame()
    {
        string path = Application.persistentDataPath + "/Savefile.save";

        if (File.Exists(Application.persistentDataPath + "/Savefile.save"))
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();

            SaveManager.UneccessaryOverdimensionatedDataClass uneccessaryOverdimensionatedDataClass = 
                JsonUtility.FromJson<SaveManager.UneccessaryOverdimensionatedDataClass>(data);

            sceneIndex = uneccessaryOverdimensionatedDataClass.sceneIndex;

            reader.Close();

            if (sceneIndex == SceneManager.sceneCountInBuildSettings-1)
            {
                Debug.Log("Savefile found: last game was ended successfully - load Level_1");
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("Savefile found: resume last level played");
                SceneManager.LoadScene(sceneIndex);
            }   
        }
        else
        {
            Debug.Log("No Savefile found: load Level_1");
            SceneManager.LoadScene(1);
        }   
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu_Screen");
    }
}
