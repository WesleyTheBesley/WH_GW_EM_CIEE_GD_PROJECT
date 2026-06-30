using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KonamiCodeManager : MonoBehaviour
{
    // Set your target scene build index in the inspector
    [SerializeField] private int sceneBuildIndexToLoad = 1;

    // The sequential path of keys using the New Input System enum
    private readonly Key[] konamiCode = new Key[]
    {
        Key.UpArrow, Key.UpArrow,
        Key.DownArrow, KeyCodeToKeyFix(KeyCode.DownArrow), // Safety double-binding for Down
        Key.LeftArrow, Key.RightArrow,
        Key.LeftArrow, Key.RightArrow,
        Key.B, Key.A
    };

    private int sequenceIndex = 0;

    void Update()
    {
        // Safe check if a keyboard is connected
        if (Keyboard.current == null) return;

        // Clean frame execution: Only proceed if ANY key was freshly pressed down
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Key expectedKey = konamiCode[sequenceIndex];

            // Handle dual mapping fallback for down arrow anomalies
            if (expectedKey == KeyCodeToKeyFix(KeyCode.DownArrow))
            {
                expectedKey = Key.DownArrow;
            }

            // Check if the expected key was the one hit this frame
            if (Keyboard.current[expectedKey].wasPressedThisFrame)
            {
                sequenceIndex++;

                // Complete combination check
                if (sequenceIndex >= konamiCode.Length)
                {
                    LoadNextScene();
                }
            }
            else
            {
                // Wrong key pressed! Reset progress.
                sequenceIndex = 0;

                // Forgiving reset: If the wrong key was an UpArrow, count it as Step 1
                if (Keyboard.current[Key.UpArrow].wasPressedThisFrame)
                {
                    sequenceIndex = 1;
                }
            }
        }
    }

    private void LoadNextScene()
    {
        Debug.Log($"Konami Code Match! Instantly loading scene index: {sceneBuildIndexToLoad}");
        SceneManager.LoadScene(sceneBuildIndexToLoad);
    }

    // Secondary definition helper to handle backend layout inconsistencies
    private static Key KeyCodeToKeyFix(KeyCode dummy) => Key.DownArrow;
}
