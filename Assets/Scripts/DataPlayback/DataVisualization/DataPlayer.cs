using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class DataPlayer : MonoBehaviour
{
	// Variable declarations for text components
	#region Text Component Declarations

	private TextMeshProUGUI time_sn_text;
	private TextMeshProUGUI ctrlong_text;
	private TextMeshProUGUI ctrlatr_text;
	private TextMeshProUGUI ax_m_s2_text;
	private TextMeshProUGUI ay_m_s2_text;
	private TextMeshProUGUI az_m_s2_text;
	private TextMeshProUGUI p_rad_s_text;
	private TextMeshProUGUI q_rad_s_text;
	private TextMeshProUGUI r_rad_s_text;
	private TextMeshProUGUI quat_e0_text;
	private TextMeshProUGUI quat_ex_text;
	private TextMeshProUGUI quat_ey_text;
	private TextMeshProUGUI quat_ez_text;
	private TextMeshProUGUI alpha_rad_text;
	private TextMeshProUGUI beta_rad_text;
	private TextMeshProUGUI tas_m_s_text;
	private TextMeshProUGUI de_rad_text;
	private TextMeshProUGUI dr_rad_text;
	private TextMeshProUGUI da_rad_text;
	private TextMeshProUGUI mass_kg_text;
	private TextMeshProUGUI thrust_N_text;
	private TextMeshProUGUI lat_rad_text;
	private TextMeshProUGUI lon_rad_text;
	private TextMeshProUGUI alt_m_text;

	#endregion

	// Variable declarations for dataset columns
	#region Dataset Column Declarations

	private string time_sn;
	private string ctrlong;
	private string ctrlatr;
	private string ax_m_s2;
	private string ay_m_s2;
	private string az_m_s2;
	private string p_rad_s;
	private string q_rad_s;
	private string r_rad_s;
	private string quat_e0;
	private string quat_ex;
	private string quat_ey;
	private string quat_ez;
	private string alpha_rad;
	private string beta_rad;
	private string tas_m_s;
	private string de_rad;
	private string dr_rad;
	private string da_rad;
	private string mass_kg;
	private string thrust_N;
	private string lat_rad;
	private string lon_rad;
	private string alt_m;

	#endregion

	private static Slider dataProgressSlider; // Variable declaration for data progress slider

	private QuaternionToEuler quaternionToEuler; // Reference to QuaternionToEuler component
	private VelocityCalculator velocityCalculator; // Reference to VelocityCalculator component
	private GeoToNED geoToNED;
	private AerodynamicCoefficients aerodynamicCoefficients; // Reference to AerodynamicCoefficients component

	private VehicleVisualization visualization; // Reference to VehicleVisualization component

	private IEnumerator dataPlayer; // Variable declaration for coroutine

	// Definition of variables assigned from the editor
	[SerializeField] private GameObject errorPanel;
	[SerializeField] private TextMeshProUGUI errorText;

	void Start()
	{
		try
		{
			// Initializing the text component variables
			#region Text Components

			time_sn_text = GameObject.Find("time_sn_text").GetComponent<TextMeshProUGUI>();
			ctrlong_text = GameObject.Find("ctrlong_text").GetComponent<TextMeshProUGUI>();
			ctrlatr_text = GameObject.Find("ctrlatr_text").GetComponent<TextMeshProUGUI>();
			ax_m_s2_text = GameObject.Find("ax_m_s2_text").GetComponent<TextMeshProUGUI>();
			ay_m_s2_text = GameObject.Find("ay_m_s2_text").GetComponent<TextMeshProUGUI>();
			az_m_s2_text = GameObject.Find("az_m_s2_text").GetComponent<TextMeshProUGUI>();
			p_rad_s_text = GameObject.Find("p_rad_s_text").GetComponent<TextMeshProUGUI>();
			q_rad_s_text = GameObject.Find("q_rad_s_text").GetComponent<TextMeshProUGUI>();
			r_rad_s_text = GameObject.Find("r_rad_s_text").GetComponent<TextMeshProUGUI>();
			quat_e0_text = GameObject.Find("quat_e0_text").GetComponent<TextMeshProUGUI>();
			quat_ex_text = GameObject.Find("quat_ex_text").GetComponent<TextMeshProUGUI>();
			quat_ey_text = GameObject.Find("quat_ey_text").GetComponent<TextMeshProUGUI>();
			quat_ez_text = GameObject.Find("quat_ez_text").GetComponent<TextMeshProUGUI>();
			alpha_rad_text = GameObject.Find("alpha_rad_text").GetComponent<TextMeshProUGUI>();
			beta_rad_text = GameObject.Find("beta_rad_text").GetComponent<TextMeshProUGUI>();
			tas_m_s_text = GameObject.Find("tas_m_s_text").GetComponent<TextMeshProUGUI>();
			de_rad_text = GameObject.Find("de_rad_text").GetComponent<TextMeshProUGUI>();
			dr_rad_text = GameObject.Find("dr_rad_text").GetComponent<TextMeshProUGUI>();
			da_rad_text = GameObject.Find("da_rad_text").GetComponent<TextMeshProUGUI>();
			mass_kg_text = GameObject.Find("mass_kg_text").GetComponent<TextMeshProUGUI>();
			thrust_N_text = GameObject.Find("thrust_N_text").GetComponent<TextMeshProUGUI>();
			lat_rad_text = GameObject.Find("lat_rad_text").GetComponent<TextMeshProUGUI>();
			lon_rad_text = GameObject.Find("lon_rad_text").GetComponent<TextMeshProUGUI>();
			alt_m_text = GameObject.Find("alt_m_text").GetComponent<TextMeshProUGUI>();

			#endregion

			// Initializing the dataset column variables
			#region Dataset Columns

			time_sn = Dataset.columns[0];
			ctrlong = Dataset.columns[1];
			ctrlatr = Dataset.columns[2];
			ax_m_s2 = Dataset.columns[3];
			ay_m_s2 = Dataset.columns[4];
			az_m_s2 = Dataset.columns[5];
			p_rad_s = Dataset.columns[6];
			q_rad_s = Dataset.columns[7];
			r_rad_s = Dataset.columns[8];
			quat_e0 = Dataset.columns[9];
			quat_ex = Dataset.columns[10];
			quat_ey = Dataset.columns[11];
			quat_ez = Dataset.columns[12];
			alpha_rad = Dataset.columns[13];
			beta_rad = Dataset.columns[14];
			tas_m_s = Dataset.columns[15];
			de_rad = Dataset.columns[16];
			dr_rad = Dataset.columns[17];
			da_rad = Dataset.columns[18];
			mass_kg = Dataset.columns[19];
			thrust_N = Dataset.columns[20];
			lat_rad = Dataset.columns[21];
			lon_rad = Dataset.columns[22];
			alt_m = Dataset.columns[23];

			#endregion

			// Initializing the data progress slider variable and its properties
			dataProgressSlider = GameObject.Find("DataProgressSlider").GetComponent<Slider>();
			dataProgressSlider.minValue = 0;
			dataProgressSlider.maxValue = Dataset.telemetryData[Dataset.telemetryData.Count - 1][0];

			// Initializing the quaternion to euler variable
			quaternionToEuler = GameObject.Find("QuaternionToEulerText").GetComponent<QuaternionToEuler>();

			// Initializing the velocity calculator variable
			velocityCalculator = GameObject.Find("VelocityCalculatorText").GetComponent<VelocityCalculator>();

			// Initializing the geo to ned variable
			geoToNED = GameObject.Find("GeoToNEDText").GetComponent<GeoToNED>();

			// Initializing the aerodynamic coefficients variable
			aerodynamicCoefficients = GameObject.Find("AerodynamicCoefficientsText").GetComponent<AerodynamicCoefficients>();

			// Initializing the vehicle visualization variable
			visualization = GameObject.Find("LightPlane").GetComponent<VehicleVisualization>();

			// Start data player coroutine when scene is loaded
			StartData(0);
		} 
		catch(ArgumentOutOfRangeException)
		{
			// Show the error window
			errorText.text = "You did not upload any dataset. Press OK to upload one.";
			errorPanel.SetActive(true);
			return;
		}
		
	}

	// Coroutine for data playback
	private IEnumerator PlayData(float startFrom)
	{
		int i = 0;
		float timeGap = 0;
		

		foreach (List<float> row in Dataset.telemetryData)
		{
			if (row[0] == startFrom)
			{
				i = Dataset.telemetryData.IndexOf(row); // Play the data with "startFrom" value
			}
		}

		while (true)
		{
			// Display the telemetry data on texts
			VisualizeTextData(i); 

			// Quaternion to euler
			quaternionToEuler.VisualizeQuaternionToEuler(Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ex)], Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ey)], 
														 Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ez)], Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_e0)]);

			// Velocity calculations
			velocityCalculator.VisualizeBodyVelocities(Dataset.telemetryData[i][Dataset.columns.IndexOf(alpha_rad)], Dataset.telemetryData[i][Dataset.columns.IndexOf(beta_rad)],
													   Dataset.telemetryData[i][Dataset.columns.IndexOf(tas_m_s)]);

			// Geo to NED calculations
			geoToNED.LatLonAltToNED(Dataset.telemetryData[0][Dataset.columns.IndexOf(lat_rad)] , Dataset.telemetryData[0][Dataset.columns.IndexOf(lon_rad)],
									Dataset.telemetryData[0][Dataset.columns.IndexOf(alt_m)], Dataset.telemetryData[i][Dataset.columns.IndexOf(lat_rad)], 
									Dataset.telemetryData[i][Dataset.columns.IndexOf(lon_rad)], Dataset.telemetryData[i][Dataset.columns.IndexOf(alt_m)]);

			// Aerodynamic Coefficients
			aerodynamicCoefficients.VisualizeAerodynamicCoefficients(Dataset.telemetryData[i][Dataset.columns.IndexOf(ax_m_s2)], Dataset.telemetryData[i][Dataset.columns.IndexOf(ay_m_s2)], 
																	Dataset.telemetryData[i][Dataset.columns.IndexOf(az_m_s2)], Dataset.telemetryData[i][Dataset.columns.IndexOf(mass_kg)],
																	Dataset.telemetryData[i][Dataset.columns.IndexOf(thrust_N)], Dataset.telemetryData[i][Dataset.columns.IndexOf(tas_m_s)], 
																	Dataset.telemetryData[i][Dataset.columns.IndexOf(alt_m)]);

			// vehicle visualization
			visualization.VisualizePlaneLocationAndRotation(Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ex)], Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ey)], 
															Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ez)], Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_e0)]);

			// Visualize time on data progress slider
			dataProgressSlider.value = Dataset.telemetryData[i][Dataset.columns.IndexOf(time_sn)];

			// Break the loop when it hits the last row
			if (i + 1 >= Dataset.telemetryData.Count) 
			{
				StopData();
				break;
			}

			// Calculating the time difference for each row
			timeGap = Dataset.telemetryData[i + 1][Dataset.columns.IndexOf(time_sn)] - Dataset.telemetryData[i][Dataset.columns.IndexOf(time_sn)];

			// increase the i for the next line
			i++;

			// Wait for the time gap between lines
			yield return new WaitForSeconds(timeGap); 
		}
	}

	// Write data to text
	private void VisualizeTextData(int i)
	{
		time_sn_text.text = $"{time_sn}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(time_sn)])}";
		ctrlong_text.text = $"{ctrlong}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(ctrlong)])}";
		ctrlatr_text.text = $"{ctrlatr}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(ctrlatr)])}";
		ax_m_s2_text.text = $"{ax_m_s2}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(ax_m_s2)])}";
		ay_m_s2_text.text = $"{ay_m_s2}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(ay_m_s2)])}";
		az_m_s2_text.text = $"{az_m_s2}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(az_m_s2)])}";
		p_rad_s_text.text = $"{p_rad_s}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(p_rad_s)])}";
		q_rad_s_text.text = $"{q_rad_s}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(q_rad_s)])}";
		r_rad_s_text.text = $"{r_rad_s}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(r_rad_s)])}";
		quat_e0_text.text = $"{quat_e0}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_e0)])}";
		quat_ex_text.text = $"{quat_ex}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ex)])}";
		quat_ey_text.text = $"{quat_ey}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ey)])}";
		quat_ez_text.text = $"{quat_ez}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(quat_ez)])}";
		alpha_rad_text.text = $"{alpha_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(alpha_rad)])}";
		beta_rad_text.text = $"{beta_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(beta_rad)])}";
		tas_m_s_text.text = $"{tas_m_s}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(tas_m_s)])}";
		de_rad_text.text = $"{de_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(de_rad)])}";
		dr_rad_text.text = $"{dr_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(dr_rad)])}";
		da_rad_text.text = $"{da_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(da_rad)])}";
		mass_kg_text.text = $"{mass_kg}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(mass_kg)])}";
		thrust_N_text.text = $"{thrust_N}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(thrust_N)])}";
		lat_rad_text.text = $"{lat_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(lat_rad)])}";
		lon_rad_text.text = $"{lon_rad}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(lon_rad)])}";
		alt_m_text.text = $"{alt_m}: {string.Format("{0:F2}", Dataset.telemetryData[i][Dataset.columns.IndexOf(alt_m)])}";
	}

	// Stop data playback
	public void StopData()
	{
		StopCoroutine(dataPlayer);
		Propeller.shouldTurn = false;
	}

	// Start data playback
	public void StartData(float startFrom)
	{
		Propeller.shouldTurn = true;
		dataPlayer = PlayData(startFrom);
		StartCoroutine(dataPlayer);
	}

	public void LoadFileUploadScene()
	{
		errorPanel.SetActive(false);
		SceneManager.LoadScene("FileUpload");
	}
}
