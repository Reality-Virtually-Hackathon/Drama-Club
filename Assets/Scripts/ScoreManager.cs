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

	public int passOrFailLimit(int numWords) {
		if (numWords <= 2) {
			return 0;
		} 
		else if (numWords <= 3) {
			return 1;
		}
		else if (numWords <= 5) {
			return 2;
		}
		else if (numWords <= 7) {
			return 3;
		}
		else if (numWords <= 10) {
			return 4;
		}
		else if (numWords <= 15) {
			return 5;
		}
		else if (numWords <= 20) {
			return 6;
		}
		else if (numWords <= 30) {
			return 8;
		}
		else if (numWords <= 40) {
			return 9;
		}
		else {
			return 10;
		}
	}


    public void UpdateStats(int lineNum, ResponseAccuracyStats lineStats)
    {
        _score.LastLineNum = lineNum;

		int missedWords = lineStats.NumWordsExpected - lineStats.NumWordsCorrect;


		int currentMissedWordLimit = passOrFailLimit (lineStats.NumWordsExpected);
		Debug.Log("missedWordLimit: " + currentMissedWordLimit);
		if (missedWords <= currentMissedWordLimit)
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

	public int GetNumLinesMissed()
	{
		return _score.TotalLines - _score.NumLinesCorrect;
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
