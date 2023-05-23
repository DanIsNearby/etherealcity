using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;

public class Mint : MonoBehaviour
{
    public string chain = "optimism-goerli";
    public Prefab_ConnectWallet prefabConnectWallet;

    ThirdwebSDK SDK;
    // Start is called before the first frame update
    private async void OnEnable()
    {
        SDK = prefabConnectWallet.SDK;
        Contract contract = SDK.GetContract("0xa1216c84bcaafd72aee1c1dea29f86dae76f00ba");
        var data = await contract.Write("claim");
        if (data.isSuccessful()){
            Debug.Log("Sucess");
        }else{
            Debug.Log("Failure");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
