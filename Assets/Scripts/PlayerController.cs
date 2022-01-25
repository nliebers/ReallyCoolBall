using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public float speed = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public GameObject redPillObject;
	public GameObject redPillObject02;
	public GameObject redPillObject03;
	public GameObject redPillObject04;
	public GameObject redPillObject05;
	public GameObject redPillObject06;
	public GameObject redPillObject07;
	public GameObject redPillObject08;
	public GameObject redPillObject09;
	public GameObject redPillObject10;
	public GameObject redPillObject11;
	public GameObject redPillObject12;
	public GameObject redPillObject13;




	private Rigidbody rb;
	private int count;
	private float movementX;
	private float movementY;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		
		
		SetCountText();
		winTextObject.SetActive(false);
		redPillObject.SetActive(true);
		redPillObject02.SetActive(true);
		redPillObject03.SetActive(true);
		redPillObject04.SetActive(true);
		redPillObject05.SetActive(true);
		redPillObject06.SetActive(true);
		redPillObject07.SetActive(true);
		redPillObject08.SetActive(true);
		redPillObject09.SetActive(true);
		redPillObject10.SetActive(true);
		redPillObject11.SetActive(true);
		redPillObject12.SetActive(true);
		redPillObject13.SetActive(true);


	}
	
	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 13){
			winTextObject.SetActive(true);
		}
	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		rb.AddForce(movement * speed);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
			
		} if (other.gameObject.CompareTag("BluePill"))
        
		{
			redPillObject.SetActive(true);
			redPillObject02.SetActive(true);
			redPillObject03.SetActive(true);
			redPillObject04.SetActive(true);
			redPillObject05.SetActive(true);
			redPillObject06.SetActive(true);
			redPillObject07.SetActive(true);
			redPillObject08.SetActive(true);
			redPillObject09.SetActive(true);
			redPillObject10.SetActive(true);
			redPillObject11.SetActive(true);
			redPillObject12.SetActive(true);
			redPillObject13.SetActive(true);
			count = 0;
			SetCountText();

			
        }

		

	}

	

	
}
