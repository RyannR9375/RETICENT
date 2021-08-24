using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : Collectable
{
    [SerializeField] int itemValue = 1;
    [SerializeField] GameObject itemWallet;
    [SerializeField] GameObject itemKey;
    [SerializeField] GameObject itemPhone;

    protected override void Collected()
    {
        GameManager.MyInstance.AddItems(itemValue);
        Destroy(this.gameObject);
        itemWallet.gameObject.SetActive(true);
    }

    protected override void CollectedKeys()
    {
        GameManager.MyInstance.AddItems(itemValue);
        Destroy(this.gameObject);
        itemKey.gameObject.SetActive(true);

    }

    protected override void CollectedPhone()
    {
        GameManager.MyInstance.AddItems(itemValue);
        Destroy(this.gameObject);
        itemPhone.gameObject.SetActive(true);
    }

}
