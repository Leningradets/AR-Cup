using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ThrowableObjectInCupHandler _handler;
    private TMP_Text _text;
    private int _throws;

    private void OnEnable()
    {
        _handler.ThrowableObjectInCup += UpdateValue;
    }

    private void OnDisable()
    {
        _handler.ThrowableObjectInCup -= UpdateValue;
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        _text.text = "Score: 0";
    }

    public void UpdateValue()
    {
        _throws++;
        _text.text = $"Score: {_throws}";
    }
}
