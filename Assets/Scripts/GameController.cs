using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Utilities;

public class GameController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
