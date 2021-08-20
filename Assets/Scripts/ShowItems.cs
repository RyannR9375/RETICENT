using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    [SerializeField] GameObject itemWallet;

    public void showWallet()
    {
        itemWallet.gameObject.SetActive(true);
    }
}
