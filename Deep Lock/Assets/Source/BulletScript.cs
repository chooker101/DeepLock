using UnityEngine;
using System.Collections;
using System;

public class BulletScript : MonoBehaviour
{
	public int index;
	public float Speed;
	public float lifetime;
	Rigidbody2D cacheRB;
	public GameObject player;
	Vector2 move;

	// Use this for initialization
	void Start ()
	{
		cacheRB = GetComponent<Rigidbody2D>();
	}

	public void startlife()
	{
		StartCoroutine(LifeTime());
	}

	private IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(lifetime);
		GameManager.Instance.gmBullets[index].SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
		cacheRB.velocity = cacheRB.transform.up * Speed;
	}

	private Vector2 resultant(Vector2 a, Vector2 b)
	{
		Vector2 result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		return result;
	}
}
