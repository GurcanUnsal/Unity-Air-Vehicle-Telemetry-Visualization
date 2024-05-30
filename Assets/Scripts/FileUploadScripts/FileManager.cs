using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Globalization;

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
		catch (ArgumentException ) 
		{ 
			Debug.Log("Argument exception, please make sure to select a csv file as the dataset...");
		}
		catch (IOException)
		{
			Debug.Log("Input-Output exception, please make sure your dataset file is not open...");
		}
	}

	private void ReadDatasetValues()
	{
		if (path != null)
		{
			StreamReader streamReader = new StreamReader(path);  // Read the dataset with the file path

			bool endOfFile = false;
			string stringData;
			string[] stringDataArray;
			List<float> floatDataList;

			stringData = streamReader.ReadLine();
			stringDataArray = stringData.Split(',');
				
			foreach (string value in stringDataArray)
			{
				Dataset.columns.Add(value);
			}

			while (!endOfFile) // Loop through the dataset until the file is finished
			{
				stringData = streamReader.ReadLine(); // Read the dataset rows
				if (stringData == null) // Check dataset file is finished
				{
					endOfFile = true;
					break;
				}
				stringDataArray = stringData.Split(','); // Split the values using comma
				floatDataList = new List<float>();
				for (int i = 0; i < stringDataArray.Length; i++)
				{
					if (float.TryParse(stringDataArray[i], NumberStyles.Any, CultureInfo.InvariantCulture, out float result))
					{
						floatDataList.Add(result); // Parse string data to float for each row
					}
				}

				Dataset.telemetryData.Add(floatDataList); // Add dataset rows to a list
			}
		}
		LoadDataPlaybackScene();
	}
	private void LoadDataPlaybackScene()
	{
		SceneManager.LoadScene("DataPlayback");
	}
}
