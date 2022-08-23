using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnClickPannel : MonoBehaviour
{
    [SerializeField] private GameObject _titleImage;
    [SerializeField] private GameObject _selectPanel;
    void Start()
    {
        StartCoroutine(ChangeThings());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
    }

    IEnumerator ChangeThings()
    {
        yield return new WaitForSeconds(8);
        _titleImage.SetActive(false);
        _selectPanel.SetActive(true);

        gameObject.SetActive(false);


    }
}
