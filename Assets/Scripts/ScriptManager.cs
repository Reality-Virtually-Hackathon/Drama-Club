using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScriptManager : MonoBehaviour {

    private string activeScriptsFile = "active-scripts.json";
    private string[] activeScripts;
    private Script loadedScript;

    public void LoadScript(int scriptIndex)
    {
        if (activeScripts == null)
        {
            return;
        }
        if (scriptIndex < activeScripts.Length)
        {
            string scriptFilename = activeScripts [scriptIndex] + ".json";
            string filePath = Path.Combine (Application.streamingAssetsPath, scriptFilename);

            if(File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText (filePath);

                loadedScript = JsonUtility.FromJson<Script> (dataAsJson);
            }
            else
            {
                Debug.LogError ("Cannot load credential data");
            } 
        }
    }

    private void LoadActiveScripts()
    {
        string filePath = Path.Combine (Application.streamingAssetsPath, activeScriptsFile);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText (filePath);

            ActiveScripts activeScriptParent = JsonUtility.FromJson<ActiveScripts> (dataAsJson);
            activeScripts = activeScriptParent.activeScripts;
        }
        else
        {
            Debug.LogError ("Cannot load credential data");
        }
    }

    void Start () {
        DontDestroyOnLoad (gameObject);
        LoadActiveScripts ();
        LoadScript (0);
    }

    void Update () {

    }
}
