using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

public class ConnectWallet : MonoBehaviour
{
    private ThirdwebSDK SDK;
    [Header("UI")]
    public GameObject IsOwner;
    public GameObject NotOwner;

    public Prefab_ConnectWallet prefabConnectWallet;

    // Start is called before the first frame update
    private async void Start()
    {
        SDK = new ThirdwebSDK("optimism");
        string addressValue = prefabConnectWallet.address;
        await CheckBalance(addressValue);
        NotOwner.SetActive(false);
        IsOwner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task CheckBalance(string address)
    {

        Contract contract = SDK.GetContract("0xfa14e1157f35e1dad95dc3f822a9d18c40e360e2");
        string balanceStr = await contract.ERC721.BalanceOf(address);
        float balance = float.Parse(balanceStr);
        Debug.Log("Balance: " + float.Parse(balanceStr));
        if (balance > 0 ){
            IsOwner.SetActive(true);
        }else{
            NotOwner.SetActive(true);
        }
    }
}
