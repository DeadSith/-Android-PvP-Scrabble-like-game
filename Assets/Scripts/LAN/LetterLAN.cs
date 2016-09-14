using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetterLAN : MonoBehaviour, IPointerClickHandler
{
    public Text LetterText;
    public Text PointsText;
    public Material StandardMaterial;
    public Material CheckedMaterial;
    public bool isChecked = false;
    private LetterBoxLAN parent;
    private DateTime _lastTap;

    private void Start()
    {
        parent = gameObject.transform.parent.GetComponent<LetterBoxLAN>();
    }

    public void ChangeLetter(string letter)
    {
        LetterText.text = letter;
        PointsText.text = LetterBoxH.PointsDictionary[letter].ToString();
        PointsText.enabled = true;
    }

    //Mark LetterH as checked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (DateTime.Now - _lastTap < new TimeSpan((int)(TimeSpan.TicksPerSecond * parent.DoubleTapDuration)) && parent.CanChangeLetters)
        {
            gameObject.GetComponent<Image>().material = isChecked ? StandardMaterial : CheckedMaterial;
            isChecked = !isChecked;
            _lastTap = new DateTime(0);
        }
        else
            _lastTap = DateTime.Now;
    }

    //Hides points, shows letter
    public void OnMouseExit()
    {
        LetterText.enabled = true;
        PointsText.enabled = false;
    }

    //Shows points for current letter
    public void OnMouseEnter()
    {
        LetterText.enabled = false;
        PointsText.enabled = true;
    }

    //Removes stuck letter from field
    public void Fix()
    {
        throw new NotImplementedException();
    }
}