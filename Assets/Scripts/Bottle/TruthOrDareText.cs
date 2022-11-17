using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TruthOrDareText : MonoBehaviour
{
    [SerializeField] private TMP_Text _tMP_Text;

    public void SetText(string text)
    {
        _tMP_Text.text = text; 
    }
}
