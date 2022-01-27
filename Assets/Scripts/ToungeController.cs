using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToungeController : MonoBehaviour
{
    public LineRenderer toungeLineRenderer;
    public Camera debugCamera;
    public Camera mainCamera;
    public float toungeWidth = 1f;
    public float toungeMaxLength = 5f;

    private void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        toungeLineRenderer.SetPositions(initLaserPositions);
        toungeLineRenderer.SetWidth(toungeWidth, toungeWidth);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InitiateTounge();
            toungeLineRenderer.enabled = true;
        }
        else
        {
            toungeLineRenderer.enabled = false;
        }
    }

    void InitiateTounge() {
        Ray ray = new Ray(debugCamera.transform.position, debugCamera.transform.forward);
        RaycastHit hitData;
        Vector3 endPosition = debugCamera.transform.position + (toungeMaxLength * debugCamera.transform.forward);

        if (Physics.Raycast(ray, out hitData, toungeMaxLength))
        {
            if (hitData.transform.gameObject.tag == "PickUp") {
                hitData.transform.gameObject.SetActive(false);
            }
            endPosition = hitData.point;
        }

        toungeLineRenderer.SetPosition(0, debugCamera.transform.position - Vector3.up * 0.1f);
        toungeLineRenderer.SetPosition(1, endPosition);

    }
}
