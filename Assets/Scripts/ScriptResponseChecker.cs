using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ScriptResponseChecker : MonoBehaviour {

    private ScriptManager _scriptManager;

    public ResponseAccuracyStats CheckResponse(string playerResponse)
    {
        ScriptLine activeLine = _scriptManager.GetActiveLine ();
        Regex pattern = new Regex("[;,!.]");
        string expected = pattern.Replace(activeLine.line, "");
        Debug.Log ("checking (" + playerResponse + ") vs. expected (" + expected + ")");
        // TODO: handle special characters
        string[] activeWords = expected.Split ();
        string[] playerWords = playerResponse.Split ();
        int numCorrect = 0;
        int numExpectedWords = activeWords.Length;
        for (int i = 0; i < numExpectedWords && i < playerWords.Length; i++)
        {
            // TODO: perform better and more forgiving checking versus exact match, in order
            Debug.Log("comparing: (" + activeWords[i] + ") and (" + playerWords[i] + ")");
            if (activeWords[i].Equals(playerWords[i], StringComparison.OrdinalIgnoreCase))
            {
                numCorrect++;
            }
        }
        ResponseAccuracyStats stats = new ResponseAccuracyStats();
        stats.NumCorrect = numCorrect;
        stats.NumExpected = numExpectedWords;
        return stats;
    }

    void Start () {
        _scriptManager = FindObjectOfType<ScriptManager> ();
    }

    void Update () {

    }

}
