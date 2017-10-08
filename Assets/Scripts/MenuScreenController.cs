using UnityEngine;

public class MenuScreenController : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
