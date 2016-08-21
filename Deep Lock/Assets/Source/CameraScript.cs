using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	Transform cache_tf;
	public Vector3 pullback;
	// Use this for initialization
	void Start ()
	{
		cache_tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		cache_tf.position = GameManager.Instance.gmPlayer.GetComponent<Transform>().position + pullback;
	}
}
