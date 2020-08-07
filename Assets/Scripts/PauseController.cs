using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public PlayerController player;
    public GameObject pausePanel;
    bool isPaused;

    public List<Button> pauseButtons = new List<Button>();
    GameObject selectedButton;

    public Text menuText;
    Vector3 textOffset;

    // Start is called before the first frame update
    void Start()
    {
        textOffset = new Vector3(0, -45, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            if (Input.GetButtonDown("Cancel")) DeactivatePauseMenu();
        }
    }

    public void ActivatePauseMenu()
    {
        isPaused = true;
        player.enabled = false;
        pausePanel.SetActive(true);
        pauseButtons[0].Select();
    }

    public void DeactivatePauseMenu()
    {
        isPaused = false;
        player.enabled = true;
        pausePanel.SetActive(false);
    }

    public void UpdateSelectedButton(GameObject buttonSelected, string textInfo)
    {
        selectedButton = buttonSelected;
        menuText.transform.position = selectedButton.transform.position + textOffset;
        menuText.text = textInfo;
    }
}