﻿using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject ObjectDragged;
    public static Vector3 StartPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ObjectDragged != null)
        {
            //Removes stuck LetterH from field
            ObjectDragged.GetComponent<LetterH>().Fix();
        }
        ObjectDragged = gameObject;
        ObjectDragged.GetComponent<LetterLAN>().PointsText.enabled = false;
        StartPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = //Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
            new Vector3(Input.mousePosition.x, Input.mousePosition.y);
    }

    //Called when dropped in the wrong place
    public void OnEndDrag(PointerEventData eventData)
    {
        ObjectDragged.transform.position = StartPosition;
        ObjectDragged.GetComponent<LetterLAN>().PointsText.enabled = true;
        ObjectDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}