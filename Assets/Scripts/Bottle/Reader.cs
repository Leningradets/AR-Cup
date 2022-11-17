using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Reader
{
    public string[] GetTruthQuestions()
    {
        return GetQuestions();
    }

    public string[] GetDares()
    {
        return GetActions();
    }

    public string[] GetQuestions()
    {
        return GetStringArrayByTag("Questions:");
    }
    public string[] GetActions()
    {
        return GetStringArrayByTag("Actions:");
    }

    private static string[] GetStringArrayByTag(string tag)
    {
        string fileText = ((TextAsset)Resources.Load("Questions")).text;

        //try
        //{
        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        fileText = sr.ReadToEnd();
        //    }
        //}
        //catch (Exception e)
        //{
        //    throw e;
        //}

        int startIndexOfArrayText = fileText.IndexOf("{", fileText.IndexOf(tag)) + 1;
        int endIndexOfArrayText = fileText.IndexOf("}", startIndexOfArrayText) - 1;

        string arrayText = fileText.Substring(startIndexOfArrayText, endIndexOfArrayText - startIndexOfArrayText);

        return arrayText.Split('\n');
    }
}

