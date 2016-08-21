using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	static private GameManager s_Instance;
	static public GameManager Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = FindObjectOfType<GameManager>();
			}
			return s_Instance;
		}
	}

	public int Captian;
	public int AftGunner;
	public int ForeGunner;
	public int Technician;

	public GameObject[] gmBullets;
	public int currentopen;
	public InputManager[] gmInputs;
	public GameObject gmPlayer;

	public void UpdateCurrentOpen()
	{
		if(currentopen < gmBullets.Length-1)
		{
			++currentopen;
		}
		else
		{
			currentopen = 0;
		}
	}

	private void UpdateInputs()
	{
		gmInputs[0].move.x = Input.GetAxis("P1_x");
		gmInputs[0].move.y = Input.GetAxis("P1_y");
		gmInputs[0].trigger1 = Input.GetAxis("P1_tr1");
		gmInputs[1].move.x = Input.GetAxis("P2_x");
		gmInputs[1].trigger1 = Input.GetAxis("P2_tr1");
	}

	void Awake()
	{
		currentopen = 0;
		gmInputs[0] = (InputManager)ScriptableObject.CreateInstance("InputManager");
		gmInputs[1] = (InputManager)ScriptableObject.CreateInstance("InputManager");
	}

	void Update()
	{
		UpdateInputs();
	}
}