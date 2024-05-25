using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class FileManager : MonoBehaviour
{
    public static List<string[]> data = new List<string[]>();

    private string path;

	private int columnCount = 0;

	private void OpenFileBrowser()
    {
        try
        {
			path = EditorUtility.OpenFilePanel("CSV File Reader", "", "csv");  //Read the dataset file path
			ReadDataset();
		}
        catch(Exception)
        {
            Debug.LogError("Please select a proper dataset...");
        }
	}

    private bool CheckColumns()
    {
        if (columnCount <= 24)
        {
            return false;
        }

        return true;
    }

    private void ReadDataset()
    {
        if (path != null)
        {
            StreamReader streamReader = new StreamReader(path);  //Read the dataset with the file path
            bool endOfFile = false;
            
            /*
            string firstLine = streamReader.ReadLine();
			var firstRow = firstLine.Split(',');
            columnCount = firstRow.Length;
            if (CheckColumns() )
            {
                Debug.LogError("Eksik Sütun");
                return;
            }
            */
			while (!endOfFile)
            {
                string stringData = streamReader.ReadLine();
                if (stringData == null)
                {
                    endOfFile = true;
                    break;
                }
                var dataValues = stringData.Split(',');

                data.Add(dataValues);
            }
		}
    }
}
