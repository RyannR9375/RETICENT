using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : Collectable
{
    [SerializeField] int itemValue = 1;
    [SerializeField] GameObject itemWallet;

    protected override void Collected()
    {
        GameManager.MyInstance.AddItems(itemValue);
        Destroy(this.gameObject);
        itemWallet.gameObject.SetActive(true);
    }

}
