using UnityEngine;
// You must include this namespace to use the SceneManager class
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Function to load a scene using its text Name
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to load a scene using its Build Index number
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}