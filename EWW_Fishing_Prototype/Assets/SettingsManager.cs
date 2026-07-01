using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static bool konamiEnabled = false;

    public void ToggleKonami()
    {
        konamiEnabled = !konamiEnabled;

        Debug.Log("Konami Enabled: " + konamiEnabled);
    }
}