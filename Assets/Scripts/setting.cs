using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting : MonoBehaviour
{
    [SerializeField] GameObject settingPanel ;
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
       
    }
    public void cancel()
    {
        settingPanel.SetActive(false);
        
    }
}
