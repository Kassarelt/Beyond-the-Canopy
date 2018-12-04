using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverAudioClip;
    public AudioClip unactiveHoverAudioClip;
    private AudioSource audioSource;

    public Button button;

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        if (button.interactable == false)
        {
            audioSource.PlayOneShot(unactiveHoverAudioClip);
        } else { audioSource.PlayOneShot(hoverAudioClip); }
    }
}