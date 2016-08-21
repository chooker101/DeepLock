using UnityEngine;
using System.Collections;

public class AIShip : MonoBehaviour
{
	[SerializeField]
	private Vector3 Target;

	private Transform cache_tf;
	private Transform plyrcache_tf;
	private Rigidbody2D cache_rb;
	private Vector3 prevUp;
	[SerializeField]
	private Vector3 toTarget;
	public float zRotSpeed;
	public float speedForward;
	public float nearVal;

	// Use this for initialization
	void Start ()
	{
		cache_tf = GetComponent<Transform>();
		cache_rb = GetComponent<Rigidbody2D>();
		plyrcache_tf = GameManager.Instance.gmPlayer.GetComponent<Transform>();
		prevUp = cache_tf.up;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Target = plyrcache_tf.position;
		toTarget = Target - cache_tf.position;
		Debug.Log(Mathf.Abs(toTarget.magnitude));
		if (Mathf.Abs(toTarget.magnitude) > 2.0f)
		{
			MoveToTarget();
		}
		else
		{
			cache_rb.velocity = Vector3.zero;
			prevUp = cache_tf.up;
		}
	}

	void MoveToTarget()
	{
		toTarget.Normalize();
		if (toTarget != cache_tf.up)
		{
			cache_tf.rotation = Quaternion.Lerp(cache_tf.rotation, Quaternion.FromToRotation(Vector3.up, toTarget), Time.fixedDeltaTime * zRotSpeed);
		}
		else
		{
			cache_rb.velocity = speedForward * toTarget;
			prevUp = cache_tf.up;
		}
	}
}
