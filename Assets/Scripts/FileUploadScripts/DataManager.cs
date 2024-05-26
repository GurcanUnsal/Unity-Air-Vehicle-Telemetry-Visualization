using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
	public static List<string[]> telemetryData = new List<string[]>();

	public static List<Dictionary<string, float>> telemetryData1 = new();

	private string path;

	private void OpenFileBrowser() //Runs when upload button is clicked
	{
		try
		{
			path = EditorUtility.OpenFilePanel("CSV File Reader", "", "csv");  //Read the dataset file path
			ReadDataset();
		}
		catch (Exception)
		{
			Debug.LogError("Please select a proper dataset...");
		}
	}

	private void LoadDataPlaybackScene()
	{
		SceneManager.LoadScene("DataPlayback");
	}

	private void ReadDataset()
	{
		if (path != null)
		{
			StreamReader streamReader = new StreamReader(path);  //Read the dataset with the file path

			bool endOfFile = false;
			string stringData;
			string[] dataValues;

			while (!endOfFile)
			{
				stringData = streamReader.ReadLine();
				if (stringData == null)
				{
					endOfFile = true;
					break;
				}
				dataValues = stringData.Split(',');

				telemetryData.Add(dataValues);
			}
		}
		LoadDataPlaybackScene();
	}
}
