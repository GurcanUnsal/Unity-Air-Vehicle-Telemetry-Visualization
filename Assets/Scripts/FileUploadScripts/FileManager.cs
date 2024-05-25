using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class FileManager : MonoBehaviour
{
    string path;
    public string firstRow;

    public void OpenFileBrowser()
    {
        path = EditorUtility.OpenFilePanel("CSV File Reader", "", "csv");  //Read the dataset file path
		ReadDataset();
	}

    private void ReadDataset()
    {
        if (path != null)
        {
            StreamReader streamReader = new StreamReader(path);  //Read the dataset with the file path
            bool endOfFile = false;

            while (!endOfFile)
            {
                string stringData = streamReader.ReadLine();
                if (stringData == null)
                {
                    endOfFile = true;
                    break;
                }
                var dataValues = stringData.Split(',');

                for (int i = 0; i < dataValues.Length; i++)
                {
                    Debug.Log("Value: " + i.ToString() + " " + dataValues[i].ToString());
                }
            }
        }


    }
}
