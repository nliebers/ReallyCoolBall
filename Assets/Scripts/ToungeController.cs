using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class ToungeController : MonoBehaviour
{
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
    public LineRenderer toungeLineRenderer;
    public Camera debugCamera;
    public Camera mainCamera;
    public float toungeWidth = 1f;
    public float toungeMaxLength = 5f;
    public bool DebugMode;
    public SteamVR_Action_Boolean spit;
	public SteamVR_Action_Boolean toss;
    public SteamVR_Input_Sources handType;

    private int count;
    private Camera cameraInUse;
    private Interactable interactable;
    private List<GameObject> collectedEggs = new List<GameObject>();

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        if (DebugMode)
        {
            cameraInUse = debugCamera;
        }
        else {
            cameraInUse = mainCamera;
        }
		SetCountText();
		winTextObject.SetActive(false);
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        toungeLineRenderer.SetPositions(initLaserPositions);
        toungeLineRenderer.SetWidth(toungeWidth, toungeWidth);

        spit.AddOnStateDownListener(Spit, handType);
		toss.AddOnStateDownListener(Toss, handType);
    }
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 13){
			winTextObject.SetActive(true);
		}
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InitiateTounge();
            toungeLineRenderer.enabled = true;
			StartCoroutine(DelayCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.Tab)) {
            LaunchEgg();
        }
    }

    void Spit(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        InitiateTounge();
		toungeLineRenderer.enabled = true;
		StartCoroutine(DelayCoroutine());
    }
	
	IEnumerator DelayCoroutine() {
		yield return new WaitForSeconds(0.1f);
		toungeLineRenderer.enabled = false;
	}
	
	public void Toss(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        LaunchEgg();
    }

    void LaunchEgg() {
        if (collectedEggs.Count > 0) {
            GameObject egg = collectedEggs[0];
            collectedEggs.RemoveAt(0);
            count -= 1;
            SetCountText();
            egg.SetActive(true);
            egg.transform.position = cameraInUse.transform.position + cameraInUse.transform.forward * 1.5f;
            egg.GetComponent<Rigidbody>().AddForce(1000.0f * cameraInUse.transform.forward);
        }
    }

    void InitiateTounge() {
        Ray ray = new Ray(cameraInUse.transform.position, cameraInUse.transform.forward);
        RaycastHit hitData;
        Vector3 endPosition = cameraInUse.transform.position + (toungeMaxLength * cameraInUse.transform.forward);

        if (Physics.Raycast(ray, out hitData, toungeMaxLength))
        {
            if (hitData.transform.gameObject.tag == "PickUp") {
                hitData.transform.gameObject.SetActive(false);
                collectedEggs.Add(hitData.transform.gameObject);
				count += 1;
				SetCountText();
            }
            endPosition = hitData.point;
        }

        toungeLineRenderer.SetPosition(0, cameraInUse.transform.position - Vector3.up * 0.1f);
        toungeLineRenderer.SetPosition(1, endPosition);

    }
}
