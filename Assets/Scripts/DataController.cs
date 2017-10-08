using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour 
{
    private string credentialsDataFileName = "credentials.json";

    public CredentialData serviceCredentials;

    private void LoadCredentials()
    {
        string filePath = Path.Combine (Application.streamingAssetsPath, credentialsDataFileName);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText (filePath);

            serviceCredentials = JsonUtility.FromJson<CredentialData> (dataAsJson);
        }
        else
        {
            Debug.LogError ("Cannot load credential data");
        }
    }

    void Start ()  
    {
        DontDestroyOnLoad (gameObject);

        LoadCredentials ();

        SceneManager.LoadScene ("MenuScreen");
    }

    public CredentialData GetServiceCredentials()
    {
        return serviceCredentials;
    }
}
