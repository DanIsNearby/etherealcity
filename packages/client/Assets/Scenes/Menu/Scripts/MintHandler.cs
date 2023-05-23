using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintHandler : MonoBehaviour
{
    public GameObject ownership;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Debug.Log("test");
        ownership.SetActive(false);
        ownership.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
