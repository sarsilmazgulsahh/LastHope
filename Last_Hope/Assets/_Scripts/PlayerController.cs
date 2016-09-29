using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed ;
	public float rotateSpeed ;
	public string scene;


	CharacterController controller;
	Animator animator;

	void Start(){
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	void Update() {
		//Rotatiton
		float curRotation = Input.GetAxis("Horizontal") * rotateSpeed;
		transform.Rotate(0, curRotation, 0);
		//Vertical Movement
		Vector3 forward = transform.forward;
		float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
        Debug.DrawRay(transform.position, forward * curSpeed, Color.red, 0, false);
        //Animation
        animator.SetFloat("Speed",curSpeed);
    }
}
