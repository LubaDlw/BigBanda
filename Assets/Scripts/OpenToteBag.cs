using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenToteBag : MonoBehaviour
{
    public GameObject ToteP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTote()
    {
        ToteP.SetActive(true);
    }
}
