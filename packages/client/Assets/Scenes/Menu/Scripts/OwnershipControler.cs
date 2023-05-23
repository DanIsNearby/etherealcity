using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class ConnectWallet : MonoBehaviour
{
    [Header("UI")]
    public GameObject IsOwner;
    public GameObject NotOwner;
    public GameObject city;
    public string contractAddress = "0xfa14e1157f35e1dad95dc3f822a9d18c40e360e2";
    public string apiKey = "TG6CX8S45HKCPTPVIXTBMJ7Y37DT3U3E78";
    public Prefab_ConnectWallet prefabConnectWallet;

    private async void OnEnable()
    {
        string addressValue = prefabConnectWallet.address;
        await CheckBalance(addressValue);
        NotOwner.SetActive(false);
        IsOwner.SetActive(false);
    }

    void Update()
    {

    }

    public async Task CheckBalance(string address)
    {
        string apiUrl = $"https://api-goerli-optimistic.etherscan.io/api?module=account&action=tokennfttx&contractaddress={contractAddress}&address={address}&apikey={apiKey}";
        int balance = await FetchNFTInfo(apiUrl);

        if (balance > 0)
        {
            city.SetActive(true);
        }
        if (balance == 0)
        {
            NotOwner.SetActive(true);
        }
    }

    private async Task<int> FetchNFTInfo(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            var asyncOperation = webRequest.SendWebRequest();

            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                // Handle any errors that occur during the API request
                Debug.Log($"Error: {webRequest.error}");
                return 0;
            }
            else
            {
                // Parse the response to extract the relevant information
                string responseText = webRequest.downloadHandler.text;
                ResponseData responseData = JsonUtility.FromJson<ResponseData>(responseText);

                int numberOfNFTs = responseData.result.Length;

                // Display the number of NFTs
                Debug.Log($"Number of NFTs held: {numberOfNFTs}");
                return numberOfNFTs;
            }
        }
    }

    [Serializable]
    private class ResponseData
    {
        public ResultData[] result;
    }

    [Serializable]
    private class ResultData
    {
        public string tokenName;
        public string tokenId;
    }
}
