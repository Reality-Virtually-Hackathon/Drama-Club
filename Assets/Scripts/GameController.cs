using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Utilities;

public class GameController : MonoBehaviour
{
    private ScriptManager scriptManager;
    private ScriptReader scriptReader;

    public void ReadActiveLine()
    {
        string line = scriptManager.GetActiveLineText ();
        scriptManager.MoveToNextLine ();
        string toRead = "<speak version=\"1.0\"><express-as type=\"GoodNews\">" + line + "</express-as></speak>";
        scriptReader.ReadText(toRead, DoneReadingCallback);
    }

    public void DoneReadingCallback()
    {
        ReadActiveLine ();
    }

    void Start()
    {
        scriptManager = FindObjectOfType<ScriptManager> ();
        scriptReader = FindObjectOfType<ScriptReader> ();
    }

    void Update()
    {
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
