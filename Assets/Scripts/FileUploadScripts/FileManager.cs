using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class FileManager : MonoBehaviour
{
	// Exception handling for the columns will be added...

	private string path; // Path variable for the dataset file

	private void OpenFileBrowser() // Runs when upload button is clicked
	{
		try
		{
			path = EditorUtility.OpenFilePanel("CSV File Reader", "", "csv");  // Get the dataset file path
			ReadDatasetValues();
		}
		catch (Exception)
		{
			Debug.LogError("Please select a proper dataset...");
		}
	}

	private void ReadDatasetValues()
	{
		if (path != null)
		{
			StreamReader streamReader = new StreamReader(path);  // Read the dataset with the file path

			bool endOfFile = false;
			string stringData;
			string[] dataValues;

			while (!endOfFile) // Loop through the dataset until the file is finished
			{
				stringData = streamReader.ReadLine(); // Read the dataset rows
				if (stringData == null) // Check dataset file is finished
				{
					endOfFile = true;
					break;
				}
				dataValues = stringData.Split(','); // Split the values using comma

				Dataset.telemetryData.Add(dataValues); // Add dataset rows to a list
			}
		}
		LoadDataPlaybackScene();
	}
	private void LoadDataPlaybackScene()
	{
		SceneManager.LoadScene("DataPlayback");
	}
}
