using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    public bool isWeaponOut = false;
    public float hitRange = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        isWeaponOut = GetComponent<PlayerWeapon>().isArmed;
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
	}

    void Hit() {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position + Vector3.up, fwd, out hit, hitRange))
        {
            // TODO: figure out a way to get pass trigger colliders
            if (hit.transform.tag == "Enemy")
            {
                Combat enemy = hit.transform.GetComponent<Combat>();
                enemy.GetHit();
            }
            else
                print("Player: I hit " + hit.transform.name + ".");
        }
        else
            Debug.Log("Player: I hit nothing.");
    }
}
