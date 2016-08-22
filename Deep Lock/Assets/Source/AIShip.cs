using UnityEngine;
using System.Collections;

public class AIShip : MonoBehaviour
{
	[SerializeField]
	private Vector3 Target;

	private Transform cache_tf;
	private Transform plyrcache_tf;
	private Rigidbody2D cache_rb;
	[SerializeField]
	private Vector3 toTarget;
	public float zRotSpeed;
	public float speedForward;
	public float angleThreshold;
	public float lerpSpeed;

	// Use this for initialization
	void Start ()
	{
		cache_tf = GetComponent<Transform>();
		cache_rb = GetComponent<Rigidbody2D>();
		plyrcache_tf = GameManager.Instance.gmPlayer.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		UpdateTarget();
		//Debug.Log(Mathf.Abs(toTarget.magnitude));
		if (Mathf.Abs(toTarget.magnitude) > 0.5f)
		{
			
		}
		MoveToTarget();
	}

	void UpdateTarget()
	{
		Target = plyrcache_tf.position;
		toTarget = Target - cache_tf.position;
	}

	void MoveToTarget()
	{
		toTarget.Normalize();
		Debug.Log(Mathf.Abs(Vector3.Dot(toTarget, cache_tf.up)));
		if (Mathf.Abs(Vector3.Dot(toTarget,cache_tf.up)) < angleThreshold)
		{
			cache_tf.rotation = Quaternion.Lerp(cache_tf.rotation, Quaternion.FromToRotation(Vector3.up, toTarget), Time.fixedDeltaTime * zRotSpeed);
			cache_rb.velocity = Vector3.zero;
		}
		else
		{
			cache_tf.rotation = Quaternion.Lerp(cache_tf.rotation, Quaternion.FromToRotation(Vector3.up, toTarget), Time.fixedDeltaTime * zRotSpeed);
			cache_rb.velocity = Vector3.Lerp(cache_rb.velocity,speedForward * cache_tf.up,Time.fixedDeltaTime * lerpSpeed);
		}
	}
}
