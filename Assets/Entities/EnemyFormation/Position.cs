using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	public float ridus;
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position,ridus);
	}
}
