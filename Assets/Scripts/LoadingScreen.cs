using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public GameObject loadingScreenObj;
    public Slider slider;

    AsyncOperation async;


    private void Start()
    {
        loadingScreenObj.SetActive(false);
    }
    public void LoadScreenExample()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}   
