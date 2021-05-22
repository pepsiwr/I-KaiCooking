using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public void LoadLevel(string LevelName)
    {
        StartCoroutine(loadLevelAsync(LevelName));
    }
    private IEnumerator loadLevelAsync(string LevelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelName);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            Debug.Log(progress);

            yield return null;
        }
    }
}
