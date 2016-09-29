using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AnimatorParam : NetworkBehaviour {

    Animator anim;
    Rigidbody rigid;
    public bool isArmed;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer) {
            anim.SetFloat("Speed", Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (isArmed == true)
                {
                    anim.SetTrigger("SeatheWeapon");
                }
                if (isArmed == false)
                {
                    anim.SetTrigger("DrawWeapon");
                }
                isArmed = !isArmed;
            }
            if (Input.GetKeyDown(KeyCode.Space))
                anim.SetTrigger("Attack");
        }
    }
}
