using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuArt;
    [SerializeField] private GameObject _options;
    [SerializeField] private GameObject _credits;

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(int i)
    {
        if (i == 0)
        {
            _menuArt.transform.DOLocalMoveX(-800, 1.5f);
            _credits.transform.DOLocalMoveX(0, 1.5f);
        }
        else if(i == 1)
        {
            _options.transform.DOLocalMoveX(0, 1.5f);
            _menuArt.transform.DOLocalMoveX(804, 1.5f);
        }
    }

    public void ReturnMain(int i)
    {
        if (i == 0)
        {
            _credits.transform.DOLocalMoveX(804, 1.5f);
        }
        else if(i == 1)
        {
            _options.transform.DOLocalMoveX(-805, 1.5f);
        }
        _menuArt.transform.DOLocalMoveX(0, 1.5f);
    }
}
