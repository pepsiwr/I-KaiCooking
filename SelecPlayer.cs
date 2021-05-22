using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelecPlayer : MonoBehaviour
{
    public GameObject[] characters;
    public int selecCharacter = 0;
    [SerializeField] public GameObject progressPanel;
    [SerializeField] public Slider progressBar;
    [SerializeField] public Text progressValue;
    public void Awake()
    {
        progressPanel.SetActive(false);
    }
    public void NextCharacter()
    {
        characters[selecCharacter].SetActive(false);
        selecCharacter = (selecCharacter + 1) % characters.Length;

        characters[selecCharacter].SetActive(true);
        
    }

    public void PreviousCharacter()
    {
        characters[selecCharacter].SetActive(false);
        selecCharacter--;
        if(selecCharacter<0)
        {
            selecCharacter += characters.Length;
        }
        characters[selecCharacter].SetActive(true);
        
    }

    /*public void StartGame()
    {
        PlayerPrefs.SetInt("selecCharacter", selecCharacter);
        SceneManager.LoadScene("Level_1");
    }*/

    //LoadingScene
    public void LoadLevel(string LevelName)
    {
        progressPanel.SetActive(true);
        PlayerPrefs.SetInt("selecCharacter", selecCharacter);
        StartCoroutine(loadLevelAsync(LevelName));
    }
    private IEnumerator loadLevelAsync(string LevelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            Debug.Log(progress);

            progressBar.value = progress;
            progressValue.text = (progress * 100).ToString("F0") + "%";

            yield return null;
        }
    }
    private void Update()
    {
        StartCoroutine(selecplayer());
    }

    IEnumerator selecplayer()
    {
        yield return null;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characters[selecCharacter].SetActive(false);
            selecCharacter = (selecCharacter + 1) % characters.Length;

            characters[selecCharacter].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            characters[selecCharacter].SetActive(false);
            selecCharacter--;
            if (selecCharacter < 0)
            {
                selecCharacter += characters.Length;
            }
            characters[selecCharacter].SetActive(true);
        }
    }
}
