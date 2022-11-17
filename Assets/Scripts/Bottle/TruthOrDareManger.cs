using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruthOrDareManger : MonoBehaviour
{
    [SerializeField] private BottleSpiner _bottleSpiner;
    [SerializeField] private TruthOrDareText _text;
    [SerializeField] private QuestionPanel _panel;

    private string[] _truthQuestions;
    private string[] _dares;

    private void OnEnable()
    {
        _bottleSpiner.SpinStopped += OnSpinStopped;
    }
    
    private void OnDisble()
    {
        _bottleSpiner.SpinStopped -= OnSpinStopped;
    }

    void Start()
    {
        Reader reader = new Reader();
        _truthQuestions = reader.GetTruthQuestions();
        _dares = reader.GetDares();
    }

    public string GetRandomTruthQuestion()
    {
        return _truthQuestions[Random.Range(0, _truthQuestions.Length)];
    }
    public string GetRandomDare()
    {
        return _dares[Random.Range(0, _dares.Length)];
    }

    public void SetRandomTruthQuestion()
    {
        _text.SetText(GetRandomTruthQuestion());
    }

    public void SetRandomDare()
    {
        _text.SetText(GetRandomDare());
    }

    public void SetRandom()
    {
        if(Random.Range(0, 2) == 0)
        {
            _text.SetText(GetRandomTruthQuestion());
        }
        else
        {
            _text.SetText(GetRandomDare());
        }
    }

    public void OnSpinStopped()
    {
        _panel.gameObject.SetActive(true);
    }
}
