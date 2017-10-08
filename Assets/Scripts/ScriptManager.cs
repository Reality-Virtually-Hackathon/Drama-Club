using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScriptManager : MonoBehaviour {

    private string _activeScriptsFile = "active-scripts.json";
    private string[] _activeScripts;
    private Script _loadedScript;
    private int _activeLine = 0;

    public bool IsActiveScriptLoaded()
    {
        if (_loadedScript != null)
        {
            return true;
        }
        return false;
    }

    public bool AreAllScriptsLoaded()
    {
        if (_activeScripts != null)
        {
            return true;
        }
        return false;
    }

    public void LoadScript(int scriptIndex)
    {
        if (scriptIndex < _activeScripts.Length)
        {
            string scriptFilename = _activeScripts [scriptIndex] + ".json";
            string filePath = Path.Combine (Application.streamingAssetsPath, scriptFilename);

            if(File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText (filePath);

                _loadedScript = JsonUtility.FromJson<Script> (dataAsJson);
            }
            else
            {
                Debug.LogError ("Cannot load credential data");
            } 
        }
    }

    public ScriptLine GetActiveLine()
    {
        if (_activeLine < _loadedScript.lines.Length)
        {
            return _loadedScript.lines [_activeLine];
        }
        return null;
    }

    public int GetActiveLineNumber()
    {
        return _activeLine;
    }

    public bool HasMoreLines()
    {
        if ((_activeLine + 1) < _loadedScript.lines.Length)
        {
            return true;
        }
        return false;
    }

    public void MoveToNextLine()
    {
        _activeLine += 1;
    }

    public void Reset()
    {
        _activeLine = 0;
    }

    private void LoadActiveScripts()
    {
        string filePath = Path.Combine (Application.streamingAssetsPath, _activeScriptsFile);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText (filePath);

            ActiveScripts activeScriptParent = JsonUtility.FromJson<ActiveScripts> (dataAsJson);
            _activeScripts = activeScriptParent.activeScripts;
        }
        else
        {
            Debug.LogError ("Cannot load credential data");
        }
    }

    void Start ()
    {
        DontDestroyOnLoad (gameObject);
        LoadActiveScripts ();
    }

    void Update ()
    {

    }
}
