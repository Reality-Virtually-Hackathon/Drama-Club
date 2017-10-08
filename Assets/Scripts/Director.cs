using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {

    public string[] MyParts;

    public bool IsMyLine(ScriptLine line)
    {
        if (System.Array.IndexOf (MyParts, line.speaker) != -1)
        {
            return true;
        }
        return false;
    }

    void Start () {

    }

    void Update () {

    }
}
