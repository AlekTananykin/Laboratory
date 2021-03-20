using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationScreenView
{
    private Image _helthImage;
    private Text _helthCount;

    public void Initialization()
    {
        _helthImage = GameObject.Find("HealthBant").GetComponent<Image>();
        _helthCount = GameObject.Find("HelthCountText").GetComponent<Text>();
    }

    public void Refresh(int helth, int maxHealth)
    {
        if (helth < 0)
            helth = 0;
        if (helth > maxHealth)
            helth = maxHealth;

        Vector2 imageSize = _helthImage.rectTransform.sizeDelta;
        _helthImage.rectTransform.sizeDelta = new Vector2(helth, imageSize.y);
        _helthCount.text = helth.ToString();
    }
}
