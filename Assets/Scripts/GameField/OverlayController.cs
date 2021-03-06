﻿using UnityEngine;
using UnityEngine.UI;

public class OverlayController : MonoBehaviour
{
    public GameObject LetterPanel;
    public GameObject ButtonPanel;
    public GameObject InfoPanel;
    public int WidthCoef;//Width is divided by this coefficient
    public int HeightCoef;

    //ButtonPanel
    public Button NextTurnButton;

    public Button SkipTurnButton;
    public Button ChangeLetterButton;
    public Button RemoveAllButton;
    public Button CenterButton;

    //InfoPanel
    public GameObject MessagePanel;

    public GameObject Player1Info;
    public GameObject Player2Info;
    public GameObject Timer;

    private void Start()
    {
        var parent = gameObject.GetComponent<RectTransform>();
        var width = parent.rect.width;
        var height = parent.rect.height;
        LetterPanel.transform.localPosition = new Vector3((width / WidthCoef - width) / 2, 0);
        LetterPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(width / WidthCoef, height - 2 * height / HeightCoef);
        ButtonPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonPanel.GetComponent<RectTransform>().sizeDelta.x, height / HeightCoef);
        ButtonPanel.transform.localPosition = new Vector3(ButtonPanel.transform.localPosition.x, (height / HeightCoef - height) / 2);
        InfoPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(InfoPanel.GetComponent<RectTransform>().sizeDelta.x, height / HeightCoef);
        InfoPanel.transform.localPosition = new Vector3(InfoPanel.transform.localPosition.x, (height - height / HeightCoef) / 2);
        var letterGrid = LetterPanel.GetComponent<UIGrid>();
        letterGrid.Initialize();
        var buttonGrid = ButtonPanel.GetComponent<UIGrid>();
        buttonGrid.Initialize();
        var infoGrid = InfoPanel.GetComponent<UIGrid>();
        infoGrid.Initialize();
        //HideMenuButton
        buttonGrid.AddElement(0, 0, RemoveAllButton.gameObject, .05f);
        buttonGrid.AddElement(0, 1, SkipTurnButton.gameObject, .05f);
        buttonGrid.AddElement(0, 2, NextTurnButton.gameObject, .05f);
        buttonGrid.AddElement(0, 3, ChangeLetterButton.gameObject, .05f);
        buttonGrid.AddElement(0, 4, CenterButton.gameObject, .05f);
        if (GameObject.FindGameObjectWithTag("Manager") != null)
        {
            SkipTurnButton.interactable=false;
            NextTurnButton.interactable = false;
            ChangeLetterButton.interactable = false;
            RemoveAllButton.interactable = false;
        }
        infoGrid.AddElement(0, 0, Player1Info);
        infoGrid.AddElement(0, 4, Player2Info);
        if (PlayerPrefs.GetInt("TimerEnabled", 0) == 1)
        {
            infoGrid.AddElement(0, 1, Timer);
            infoGrid.AddElement(0, 2, 0, 3, MessagePanel);
        }
        else
        {
            infoGrid.AddElement(0, 1, 0, 3, MessagePanel);
        }
    }
}