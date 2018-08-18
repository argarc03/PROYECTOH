using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {

	public GameObject talkIcon;
	public GameObject Dialogue;
	public Button Start;

	void Update()
	{
		if (talkIcon.activeInHierarchy && Input.GetKeyDown (KeyCode.E)) 
		{
			StartCoroutine (StartTalking ());
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
			talkIcon.SetActive (true);
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			talkIcon.SetActive (false);
			Dialogue.SetActive (false);
		}
	}

	IEnumerator StartTalking()
	{
		Dialogue.SetActive (true);

		yield return 0.1f;

		Start.onClick.Invoke();
	}
}
