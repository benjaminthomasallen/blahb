using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyOptions : MonoBehaviour {

    public GameObject optionsCanvas;

    void start()
    {
        optionsCanvas.SetActive(false);
    }

    public void ShowInst()
    {
        optionsCanvas.SetActive(true);
    }

    public void HideInst()
    {
        optionsCanvas.SetActive(false);
    }
}
