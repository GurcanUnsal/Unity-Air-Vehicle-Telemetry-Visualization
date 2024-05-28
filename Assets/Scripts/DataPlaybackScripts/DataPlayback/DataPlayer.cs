using UnityEngine;
using TMPro;
using System.Collections;

public class DataPlayer : MonoBehaviour
{
	// Variable declarations for text components

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

	void Start()
	{
		// Initializing the text component variables

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

		StartCoroutine(PlayData());
	}

	IEnumerator PlayData()
	{
		int i = 0;
		float deltaTime;
		while (i < Dataset.telemetryData.Count)
		{
			time_sn_text.text = Dataset.telemetryData[i][0].ToString();
			ctrlong_text.text = Dataset.telemetryData[i][1].ToString();
			ctrlatr_text.text = Dataset.telemetryData[i][2].ToString();
			ax_m_s2_text.text = Dataset.telemetryData[i][3].ToString();
			ay_m_s2_text.text = Dataset.telemetryData[i][4].ToString();
			az_m_s2_text.text = Dataset.telemetryData[i][5].ToString();
			p_rad_s_text.text = Dataset.telemetryData[i][6].ToString();
			q_rad_s_text.text = Dataset.telemetryData[i][7].ToString();
			r_rad_s_text.text = Dataset.telemetryData[i][8].ToString();
			quat_e0_text.text = Dataset.telemetryData[i][9].ToString();
			quat_ex_text.text = Dataset.telemetryData[i][10].ToString();
			quat_ey_text.text = Dataset.telemetryData[i][11].ToString();
			quat_ez_text.text = Dataset.telemetryData[i][12].ToString();
			alpha_rad_text.text = Dataset.telemetryData[i][13].ToString();
			beta_rad_text.text = Dataset.telemetryData[i][14].ToString();
			tas_m_s_text.text = Dataset.telemetryData[i][15].ToString();
			de_rad_text.text = Dataset.telemetryData[i][16].ToString();
			dr_rad_text.text = Dataset.telemetryData[i][17].ToString();
			da_rad_text.text = Dataset.telemetryData[i][18].ToString();
			mass_kg_text.text = Dataset.telemetryData[i][19].ToString();
			thrust_N_text.text = Dataset.telemetryData[i][20].ToString();
			lat_rad_text.text = Dataset.telemetryData[i][21].ToString();
			lon_rad_text.text = Dataset.telemetryData[i][22].ToString();
			alt_m_text.text = Dataset.telemetryData[i][23].ToString();

			if (i + 1 >= Dataset.telemetryData.Count)
			{
				break;
			}

			deltaTime = Dataset.telemetryData[i + 1][0] - Dataset.telemetryData[i][0];

			i++;

			yield return new WaitForSeconds(deltaTime);
		}
	}
}
