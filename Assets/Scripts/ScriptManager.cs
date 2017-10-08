using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScriptManager : MonoBehaviour {

    private string activeScriptsFile = "active-scripts.json";
    private string[] activeScripts;
    private Script loadedScript;
    private int activeLine = 0;

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

    public string GetActiveLineText()
    {
        if (activeLine < loadedScript.lines.Length)
        {
            return loadedScript.lines [activeLine].line;
        }
        return null;
    }

    public bool HasMoreLines()
    {
        if ((activeLine + 1) < loadedScript.lines.Length)
        {
            return true;
        }
        return false;
    }

    public void MoveToNextLine()
    {
        activeLine += 1;
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
