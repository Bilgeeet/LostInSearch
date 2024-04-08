using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{

    public string nextSceneName;
    public float waitingTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        OnComplete();
    }

     public void OnComplete()
    {
        StartCoroutine(WaitForScene());
    }

   IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene(nextSceneName);
    }
}
