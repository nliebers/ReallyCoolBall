using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	private int count;
	
    // Start is called before the first frame update
    void Start()
    {		
		SetCountText();
		winTextObject.SetActive(false);


	}
	
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12){
			winTextObject.SetActive(true);
		}
	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
			
		}

	}

}
