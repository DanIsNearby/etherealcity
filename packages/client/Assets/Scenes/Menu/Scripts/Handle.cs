using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Menu;
    public GameObject City;
    // Start is called before the first frame update
    private void Start(){
        Debug.Log("testing");
        Menu.SetActive(false);
        City.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
