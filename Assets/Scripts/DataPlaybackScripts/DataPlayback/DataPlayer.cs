using UnityEngine;
using TMPro;

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
	private TextMeshProUGUI tas_ms_text;
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
		tas_ms_text = GameObject.Find("tas_ms_text").GetComponent<TextMeshProUGUI>();
		de_rad_text = GameObject.Find("de_rad_text").GetComponent<TextMeshProUGUI>();
		dr_rad_text = GameObject.Find("dr_rad_text").GetComponent<TextMeshProUGUI>();
		da_rad_text = GameObject.Find("da_rad_text").GetComponent<TextMeshProUGUI>();
		mass_kg_text = GameObject.Find("mass_kg_text").GetComponent<TextMeshProUGUI>();
		thrust_N_text = GameObject.Find("thrust_N_text").GetComponent<TextMeshProUGUI>();
		lat_rad_text = GameObject.Find("lat_rad_text").GetComponent<TextMeshProUGUI>();
		lon_rad_text = GameObject.Find("lon_rad_text").GetComponent<TextMeshProUGUI>();
		alt_m_text = GameObject.Find("alt_m_text").GetComponent<TextMeshProUGUI>();
	}
}
