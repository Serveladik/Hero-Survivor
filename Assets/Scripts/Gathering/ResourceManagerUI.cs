using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ResourceManagerUI : MonoBehaviour
{
    public static Action ResourceGathered;
    public Image woodSprite;
    public Image rockSprite;
    public Image swordSprite;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI rockText;
    public TextMeshProUGUI swordText;

    public WoodResource woodResource;
    public RockResource rockResource;
    public SwordResource swordResource;

    void OnEnable()
    {
        ResourceGathered += UpdateTextValues;
    }

    void OnDisable()
    {
        ResourceGathered -= UpdateTextValues;
    }
    void Start()
    {  
        woodSprite.sprite = woodResource.image;
        rockSprite.sprite = rockResource.image;
        swordSprite.sprite = swordResource.image;
        
    }
    void Update()
    {
        //UpdateTextValues();
    }

    void UpdateTextValues()
    {
        woodText.text = woodResource.amount.ToString();
        rockText.text = rockResource.amount.ToString();
        swordText.text = swordResource.amount.ToString();
    }
}
