using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Utilities;

public class GameController : MonoBehaviour
{
    private ScriptManager _scriptManager;
    private ScriptReader _scriptReader;
    private Director _director;
    private VoiceProcessor _voiceProcessor;
    private Player _player;
    private ScriptResponseChecker _responseChecker;

    public int SelectedScriptIndex = 0;

    public void NarrateLine(ScriptLine line)
    {
        if (line == null)
        {
            Debug.Log ("error reading active line");
            return;
        }
        string lineText = line.line;
        _scriptManager.MoveToNextLine ();
        string toRead = lineText; //"<speak version=\"1.0\"><express-as type=\"GoodNews\">" + lineText + "</express-as></speak>";
        _scriptReader.ReadText(toRead, DoneReadingCallback);
    }

    private void processCurrentLine()
    {
        ScriptLine activeLine = _scriptManager.GetActiveLine ();
        if (_director.IsMyLine (activeLine))
        {
            NarrateLine (activeLine);
        } else
        {
            // player's turn to respond
        }
    }

    public void DoneReadingCallback()
    {
        if (_scriptManager.HasMoreLines ())
        {
            processCurrentLine ();
        }
    }

    public void StartGame()
    {
        ScriptLine activeLine = _scriptManager.GetActiveLine ();
        processCurrentLine ();
    }

    public void AfterSpeechCallback(string text, double confidence)
    {
        ScriptLine activeLine = _scriptManager.GetActiveLine ();
        if (_director.IsMyLine (activeLine))
        {
            // the user just uttered something again before the director spoke,
            // but not their turn, just ignore
            return;
        }
        ResponseAccuracyStats stats = _responseChecker.CheckResponse (text);
        Debug.Log("numCorrect: " + stats.NumCorrect + " numExpected: " + stats.NumExpected);
        _scriptManager.MoveToNextLine ();
        if (_scriptManager.HasMoreLines ())
        {
            processCurrentLine ();
        }
    }

    void Start()
    {
        _scriptManager = FindObjectOfType<ScriptManager> ();
        _scriptReader = FindObjectOfType<ScriptReader> ();
        _voiceProcessor = FindObjectOfType<VoiceProcessor> ();
        _director = FindObjectOfType<Director> ();
        _player = FindObjectOfType<Player> ();
        _responseChecker = FindObjectOfType<ScriptResponseChecker> ();

        _scriptManager.LoadScript (SelectedScriptIndex);
        _voiceProcessor.SetAfterSpeechCallback (AfterSpeechCallback);
    }

    void Update()
    {
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
