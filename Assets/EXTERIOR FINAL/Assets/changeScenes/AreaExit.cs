using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class AreaExit : MonoBehaviour
{
    public string sceneToLoad;
    public string transitionName;
    public AreaEntrance locationHere;
    private void Start()
    {
        locationHere.transitionName = transitionName;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("rayos") != null || GameObject.FindGameObjectWithTag("lluvia") != null)
            {
                GameObject.FindGameObjectWithTag("rayos").SetActive(false);
                GameObject.FindGameObjectWithTag("lluvia").SetActive(false);
            }

            GameManager.manager.loadingScreen.transform.GetChild(0).gameObject.SetActive(true);
            //GameManager.manager.loadingScreen.transform.GetChild(1).gameObject.SetActive(true);
            GameManager.manager.loadingScreen.GetComponent<Image>().enabled = true;

            if (GameManager.manager.loadingScreen.GetComponent<Image>().isActiveAndEnabled)
                StartCoroutine(LoadAsynchronously(sceneToLoad));         

            SceneManager.LoadScene(sceneToLoad);
            MainController.instance.areaTransitionName = transitionName;
        }
    }
    IEnumerator LoadAsynchronously(String sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            /**GameManager.manager.loadingScreen.transform.GetChild(1).GetComponent<Slider>().value = progress;
            Debug.Log(progress);
            GameManager.manager.loadingScreen.transform.GetChild(1).GetComponent<Text>().text = progress * 100f + "%";**/
            yield return null;
        }
    }
}
