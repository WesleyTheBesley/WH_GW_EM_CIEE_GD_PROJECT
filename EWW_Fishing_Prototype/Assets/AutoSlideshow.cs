using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoSlideshow : MonoBehaviour
{
    public Sprite[] slides;
    public float slideDuration = 3f;

    private Image slideshowImage;
    private int currentSlideIndex = 0;

    void Start()
    {
        slideshowImage = GetComponent<Image>();
        if (slides.Length > 0)
        {
            StartCoroutine(PlaySlideshow());
        }
    }

    IEnumerator PlaySlideshow()
    {
        while (true)
        {
            // Display current slide
            slideshowImage.sprite = slides[currentSlideIndex];

            // Wait for the specified duration
            yield return new WaitForSeconds(slideDuration);

            // Move to the next slide, loop back to 0 at the end
            currentSlideIndex = (currentSlideIndex + 1) % slides.Length;
        }
    }
}
