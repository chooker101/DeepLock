using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour
{
	public float XSensitivity;
	public float YSensitivity;

	//public GameObject bullet;
	public GameObject gun;
	public float firerate;
	public float lerpSpeed;
	bool canfire = true;
	//private int myplayer;

	Rigidbody2D cacheRB;
	Transform cacheTF;

	private Quaternion targetRot;

	// Use this for initialization
	void Start()
	{
		cacheRB = GetComponent<Rigidbody2D>();
		cacheTF = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		CheckFire();
	}

	private IEnumerator untilfireable()
	{
		yield return new WaitForSeconds(firerate);
		canfire = true;
	}

	void Move()
	{
		//Vector2 final = Vector2.zero;
		float zRot = (-GameManager.Instance.gmInputs[GameManager.Instance.Captian].move.x) * XSensitivity;
		targetRot = cacheTF.rotation * Quaternion.Euler(0f, 0f, zRot);
		cacheTF.rotation = targetRot;
		float yForce = GameManager.Instance.gmInputs[0].trigger1 * YSensitivity;
		//yForce = Mathf.Lerp((cacheRB.velocity.magnitude * GameManager.Instance.gmInputs[0].move.y), yForce, Time.fixedDeltaTime);
		cacheRB.velocity = Vector3.Lerp(cacheRB.velocity, yForce * cacheTF.up,Time.fixedDeltaTime * lerpSpeed);
	}

	void CheckFire()
	{
		if (GameManager.Instance.gmInputs[1].trigger1 > 0.1f && canfire)
		{
			int i = GameManager.Instance.currentopen;
			GameManager.Instance.UpdateCurrentOpen();

			BulletScript tempbs = GameManager.Instance.gmBullets[i].GetComponent<BulletScript>();
			Transform temptf = GameManager.Instance.gmBullets[i].GetComponent<Transform>();

			if (!GameManager.Instance.gmBullets[i].activeSelf)
			{
				GameManager.Instance.gmBullets[i].SetActive(true);
				tempbs.startlife();
			}

			tempbs.player = this.gameObject;
			tempbs.index = i;
			temptf.position = gun.GetComponent<Transform>().position;
			temptf.rotation = cacheTF.rotation;
			canfire = false;
			StartCoroutine(untilfireable());
		}
	}
}
