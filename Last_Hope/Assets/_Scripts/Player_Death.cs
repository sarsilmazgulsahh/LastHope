using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player_Death : NetworkBehaviour {

	private Player_Health healthScript;


	public override void PreStartClient ()
	{
		healthScript = GetComponent<Player_Health>();
		healthScript.EventDie += DisablePlayer;
	}

	public override void OnStartLocalPlayer ()
	{

	}
	
	public override void OnNetworkDestroy ()
	{
		healthScript.EventDie -= DisablePlayer;
	}

	void DisablePlayer ()
	{
		GetComponent<CharacterController>().enabled = false;
		GetComponent<Player_Swing>().enabled = false;
		GetComponent<BoxCollider>().enabled = false;

		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach(Renderer ren in renderers)
		{
			ren.enabled = false;
		}

		healthScript.isDead = true;

		if(isLocalPlayer)
		{
			GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton.SetActive(true);
		}
	}
}
