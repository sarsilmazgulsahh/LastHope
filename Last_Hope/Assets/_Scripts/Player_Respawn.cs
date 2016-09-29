using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player_Respawn : NetworkBehaviour {

	private Player_Health healthScript;
	private GameObject respawnButton;

	public override void PreStartClient ()
	{
		healthScript = GetComponent<Player_Health>();
		healthScript.EventRespawn += EnablePlayer;
	}

	public override void OnStartLocalPlayer ()
	{
		SetRespawnButton();
	}

	void SetRespawnButton ()
	{
		if(isLocalPlayer)
		{
			respawnButton = GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton;
			respawnButton.GetComponent<Button>().onClick.AddListener(CommenceRespawn);
			respawnButton.SetActive(false);
		}
	}

	public override void OnNetworkDestroy ()
	{
		healthScript.EventRespawn -= EnablePlayer;
	}

	void EnablePlayer()
	{
		GetComponent<CharacterController>().enabled = true;
		GetComponent<Player_Swing>().enabled = true;
		GetComponent<BoxCollider>().enabled = true;
		
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach(Renderer ren in renderers)
		{
			ren.enabled = true;
		}

		if(isLocalPlayer)
		{
			respawnButton.SetActive(false);
		}
	}

	void CommenceRespawn()
	{
		CmdRespawnOnServer();
	}

	[Command]
	void CmdRespawnOnServer()
	{
		healthScript.ResetHealth();
	}

}
