using UnityEngine;

public class Flying_Camera : MonoBehaviour
{	
	[SerializeField] float cameraSensitivity = 90;
	[SerializeField] float climbSpeed = 4;
	[SerializeField] float normalMoveSpeed = 10;
	[SerializeField] float slowMoveFactor = 0.25f;
	[SerializeField] float fastMoveFactor = 3;

	[SerializeField] Camera mainCamera;
 
	float rotationX = 0.0f;
	float rotationY = 0.0f;

	bool isNoClipActive;

	private Vector3 characterCameraPositionOnNoClipActivation;
	private Quaternion characterCameraRotationOnNoClipActivation;
 
 
	void Update ()
	{
		if(Input.GetKeyUp(KeyCode.K))
			SwitchNoClipState();
		
		if (isNoClipActive)
			HandleNoClip();
 
	}


	void SwitchNoClipState()
	{
		isNoClipActive = !isNoClipActive;
		
		if (isNoClipActive)
			SetUpNoClip();
		else
			DeactivateNoClip();

	}
	
	void HandleNoClip()
	{
		rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90);
 
		mainCamera.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		mainCamera.transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
 
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
		{
			mainCamera.transform.position += mainCamera.transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			mainCamera.transform.position += mainCamera.transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		else if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
		{
			mainCamera.transform.position += mainCamera.transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			mainCamera.transform.position += mainCamera.transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		else
		{
			mainCamera.transform.position += mainCamera.transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			mainCamera.transform.position += mainCamera.transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
 
 
		if (Input.GetKey (KeyCode.Q)) {mainCamera.transform.position += mainCamera.transform.up * climbSpeed * Time.deltaTime;}
		if (Input.GetKey (KeyCode.E)) {mainCamera.transform.position -= mainCamera.transform.up * climbSpeed * Time.deltaTime;}
	}

	void SetUpNoClip()
	{
		if (mainCamera == null) return;
		characterCameraPositionOnNoClipActivation = mainCamera.transform.position;
		characterCameraRotationOnNoClipActivation = mainCamera.transform.rotation;
	}

	void DeactivateNoClip()
	{
		if (mainCamera == null) return;
		mainCamera.transform.position = characterCameraPositionOnNoClipActivation;
		mainCamera.transform.rotation = characterCameraRotationOnNoClipActivation;
	}
}

