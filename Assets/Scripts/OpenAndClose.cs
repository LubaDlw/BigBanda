using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAndClose : MonoBehaviour
{
    public GameObject panel; // Reference to the panel game object
    public Button closeButton; // Reference to the close button

    private void Start()
    {
        closeButton.onClick.AddListener(ClosePanel);
    }

    public void ClosePanel()
    {
        panel.SetActive(false); // Deactivate the panel game object
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
