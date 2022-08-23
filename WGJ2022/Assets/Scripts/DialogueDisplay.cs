using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class DialogueDisplay : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button[] _choices;
    [SerializeField] private Image _image;
    [SerializeField] private float _typeSpeed;
    [SerializeField] private GameObject _choicesUI;
    [SerializeField] private GameSound _gameSound;

    private string _currentSentence;

    private int _setenceIndex = 0;
    private int _setenceLenght;

    private bool _hasAxe = false;
    void Start()
    {

        SetVariables();
    }


    public void Update()
    {
        if (_dialogueText.text == _currentSentence)
        {
            ShowChoices();
            _dialogueText.text += " ";
        }
    }
    public void ChangeDialogue(int i)
    {
        if (_dialogue.index == 1 && i == 1)
        {
            _hasAxe = true;
            Debug.Log("pegou o maqsado");
        }

        if (_dialogue.index == 3 && i == 1 || _dialogue.index == 5)
        {
            SceneManager.LoadScene(0);
        }

        //_dialogue = i == 0 ? _dialogue.dialogueAnswerOne : _dialogue.dialogueAnswerTwo;
        if (_dialogue.index == 2 && _hasAxe && i == 1)
        {
            _dialogue = _dialogue.nextDialogueAnswers[2];
        }
        else
        {
            _dialogue = i == 0 ? _dialogue.nextDialogueAnswers[0] : _dialogue.nextDialogueAnswers[1];

        }

        if(_dialogue.index == 3)
        {
            _gameSound.FinalSound();
        }

        if(_dialogue.index == 4)
        {
            _gameSound.ReturnMusic();
        }



        for (int a = 0; a < _choices.Length; a++)
        {
            _choices[a].gameObject.SetActive(false);
        }
        SetVariables();

    }

    private void SetVariables()
    {

        _dialogueText.text = "";
        _currentSentence = _dialogue.dialogues[0];
        _choicesUI.transform.localPosition = new Vector3(2.6389f, -368, 0);

        for (int i = 0; i < _dialogue.choices.Length; i++)
        {
            _choices[i].gameObject.SetActive(true);
            _choices[i].GetComponentInChildren<TextMeshProUGUI>().text = _dialogue.choices[i];
        }
        //_choices[0].text = _dialogue.choiceOne;
        //_choices[1].text = _dialogue.choiceTwo;
        _image.sprite = _dialogue.art;

        _setenceLenght = _dialogue.dialogues.Length;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in _currentSentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(_typeSpeed);
        }

    }

    public void NextSetence()
    {
        if (_dialogueText.text != _currentSentence)
        {
            StopAllCoroutines();
            _dialogueText.text = _currentSentence;
        }
        else
        {
            if (_setenceLenght > _setenceIndex + 1)
            {
                _setenceIndex++;
                _currentSentence = _dialogue.dialogues[_setenceIndex];
                _dialogueText.text = "";

                Debug.Log("tem mais uiui");

                StartCoroutine(Type());
            }
            else
            {
                Debug.Log("cabou");
            }
        }
    }

    public void ShowChoices()
    {
        _choicesUI.transform.DOLocalMoveY(-173, 1);
    }
}
