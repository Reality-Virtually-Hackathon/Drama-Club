using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private Score _score;

    public void Reset()
    {
        _score.NumLinesCorrect = 0;
        _score.NumWordsCorrect = 0;
        _score.TotalLines = 0;
        _score.TotalWords = 0;
        _score.LastLineNum = 0;
        _score.OverallScore = 0;
    }

    public void UpdateStats(int lineNum, ResponseAccuracyStats lineStats)
    {
        _score.LastLineNum = lineNum;
        // TODO: update, only for testing
        if (lineStats.NumWordsCorrect > 0)
        {
            _score.NumLinesCorrect++;
        }
        _score.NumWordsCorrect = lineStats.NumWordsCorrect;
        _score.TotalLines++;
        _score.TotalWords = lineStats.NumWordsExpected;
        UpdateScore ();
    }

    public void UpdateScore()
    {
        // TODO: adjust to real scoring criteria
        _score.OverallScore = _score.NumLinesCorrect;
    }

    public int GetOverallScore()
    {
        return _score.OverallScore;
    }

    void Start ()
    {
        DontDestroyOnLoad (gameObject);
        _score = new Score ();
    }

    void Update ()
    {

    }

}
