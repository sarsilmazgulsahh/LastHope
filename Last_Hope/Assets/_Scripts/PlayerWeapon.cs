using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public bool isArmed;
	public Transform weapon;
	public Transform drawPositon;
	public Transform seathePosition;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R) && weapon!=null){
			if(isArmed == true){
                GetComponent<Animator>().SetBool("isWeaponOut",true);
			}
			if(isArmed == false){
                GetComponent<Animator>().SetBool("isWeaponOut", false);
            }
			isArmed = !isArmed;
		}
	}

	void SeatheWeapon(){
		weapon.parent=seathePosition;
		weapon.localRotation = Quaternion.identity;
		weapon.localPosition = Vector3.zero;
		weapon.localScale = Vector3.one;
	}

	void DrawWeapon(){
		weapon.parent=drawPositon;
		weapon.localRotation = Quaternion.identity;
		weapon.localPosition = Vector3.zero;
		weapon.localScale = Vector3.one;
	}
}
