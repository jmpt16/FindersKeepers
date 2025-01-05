using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float sensitivity;
	public float moveSpeed;


	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update()
	{
		Movement();
		Rotation();
		if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
		{
			Debug.Log(hit.transform.name);
			if(Input.GetMouseButtonDown(0))
			{
				Destroy(hit.transform.gameObject);
			}
		}
	}

	public void Rotation()
	{
		Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		transform.Rotate(mouseInput * sensitivity);
		Vector3 eulerRotation = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
	}

	public void Movement()
	{
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Z-Axis"), Input.GetAxis("Vertical"));
		transform.Translate(input * moveSpeed * Time.deltaTime);
	}
}
