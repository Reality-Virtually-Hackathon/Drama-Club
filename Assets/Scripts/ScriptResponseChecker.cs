using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class ScriptResponseChecker : MonoBehaviour {

    private GameController _gameController;
    private ScriptManager _scriptManager;

    public ResponseAccuracyStats CheckResponse(string playerResponse)
    {
        ScriptLine activeLine = _scriptManager.GetActiveLine ();
        Regex pattern = new Regex("[;,!.]");
        string expected = pattern.Replace(activeLine.line, "");
        Debug.Log ("---- checking (" + playerResponse + ") vs. expected (" + expected + ")");
        // TODO: handle special characters
        
		string[] activeWords = expected.Split ();
		activeWords = activeWords.Select(s => s.ToLowerInvariant()).ToArray();
		HashSet<String> activeWordsSet = new HashSet<String> (activeWords);
        
		string[] playerWords = playerResponse.Split ();
		playerWords = playerWords.Select(s => s.ToLowerInvariant()).ToArray();

        int numWordsCorrect = 0;
        int numWordsExpected = activeWords.Length;

		for (int i = 0; i < playerWords.Length; i++)
        {
			if (activeWordsSet.Contains(playerWords[i]))
			{
                numWordsCorrect++;
            }
        }
        ResponseAccuracyStats stats = new ResponseAccuracyStats();
        stats.NumWordsCorrect = numWordsCorrect;
        stats.NumWordsExpected = numWordsExpected;
        return stats;
    }

    void Start () {
        _gameController = FindObjectOfType<GameController> ();
        _scriptManager = FindObjectOfType<ScriptManager> ();
    }

    void Update () {

    }

}
