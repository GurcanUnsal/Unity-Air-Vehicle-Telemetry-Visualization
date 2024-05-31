using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataProgressSlider : MonoBehaviour, IPointerDownHandler
{
	DataPlayer player;
	public void OnPointerDown(PointerEventData eventData)
	{
		player = GameObject.Find("DataPlayer").GetComponent<DataPlayer>();
		player.StopData();

		float startFrom = Mathf.Floor(this.GetComponent<Slider>().value);

		player.StartData(startFrom);
	}
}
