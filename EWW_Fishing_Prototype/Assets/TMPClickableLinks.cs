using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TMPClickableLinks : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text textComponent;
    private Canvas parentCanvas;

    void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Screen Space - Overlay requires a NULL camera parameter to calculate coordinates correctly
        Camera eventCamera = (parentCanvas != null && parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
            ? null
            : eventData.pressEventCamera;

        // Find the index of the link that was clicked
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textComponent, eventData.position, eventCamera);

        if (linkIndex == -1) return;

        // Get link information
        TMP_LinkInfo linkInfo = textComponent.textInfo.linkInfo[linkIndex];

        // Open the URL
        string url = linkInfo.GetLinkID();
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
            Debug.Log($"Opening URL: {url}");
        }
    }
}
