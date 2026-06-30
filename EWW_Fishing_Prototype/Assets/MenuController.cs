using UnityEngine;

public class MenuController : MonoBehaviour
{
    // This method must be public to show up in the Unity inspector
    public void ExitGame()
    {
        // Quits the actual built application
        Application.Quit();

        // Closes play mode inside the Unity Editor (for testing)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
