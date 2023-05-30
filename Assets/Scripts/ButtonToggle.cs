using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    public Image image;

    private bool isImageVisible;

    public void ToggleImageVisibility()
    {
        isImageVisible = !isImageVisible;
        image.gameObject.SetActive(isImageVisible);


    }
}
 