using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScreenController : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    void Start()
    {
        SceneManager.LoadScene ("Game");
    }
}
