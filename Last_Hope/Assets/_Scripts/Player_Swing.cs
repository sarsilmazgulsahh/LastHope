using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_Swing : NetworkBehaviour {

	private int damage = 25;
	private float range = 5;
	[SerializeField] private Transform camTransform;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckIfHitting();
	}

	void CheckIfHitting()
	{
		if(!isLocalPlayer)
		{
			return;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
            GetComponent<Animator>().SetBool("isAttacking",true);
		}
	}

	void Swing()
	{
		if(Physics.Raycast(transform.position+new Vector3(0, 0, 0.5f), camTransform.forward, out hit, range))
		{
			//Debug.Log(hit.transform.tag);
			Debug.Log("ASDAWDASDASDASDASD");
			if(hit.transform.tag == "Player")
			{
				string uIdentity = hit.transform.name;
				CmdTellServerWhoWasShot(uIdentity, damage);
			}

		}
	}

	[Command]
	void CmdTellServerWhoWasShot (string uniqueID, int dmg)
	{
		GameObject go = GameObject.Find(uniqueID);
		go.GetComponent<Player_Health>().DeductHealth(dmg);
	}

}
