using UnityEngine;
using System.Collections;

public class DisconnectController : MonoBehaviour {

    public GameObject ExitButton;
    public GameObject MainMenuButton;
    public GameObject DisconnectedText;

    void Start()
    {
        var grid = gameObject.GetComponent<UIGrid>();
        grid.Initialize();
        grid.AddElement(1,1,ExitButton);
        grid.AddElement(2,1,MainMenuButton);
        grid.AddElement(3,1,DisconnectedText);
        gameObject.SetActive(false);
    }
}
