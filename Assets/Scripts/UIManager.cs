using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtItems, txtVictoryCondition;
    [SerializeField] GameObject victoryCondition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    private static UIManager instance;

    public static UIManager MyInstance 
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }

    }

    public void UpdateItemUI(int _items, int _victoryCondition)
    {
        txtItems.text = "Items Collected: " + _items + "/ " + _victoryCondition;
    }

    public void ShowVictoryCondition(int _items, int _victoryCondition)
    {
        victoryCondition.SetActive(true);
        txtVictoryCondition.text = "YOU MUST COLLECT ALL ITEMS BEFORE LEAVING";
    }
    public void HideVictoryCondition()
    {
        victoryCondition.SetActive(false);
    }
}
