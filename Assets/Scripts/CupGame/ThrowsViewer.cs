using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowsViewer : MonoBehaviour
{
    private TMP_Text _text;
    private int _throws;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

        _text.text = "Throws: 0";
    }

    public void UpdateValue()
    {
        _throws++;
        _text.text = $"Throws: {_throws}";
    }
}
