using UnityEngine;
using System.Collections;

public class CityAsteroid : MonoBehaviour
{
	public float speed = 1f;
	public GameObject explosionPrefab;
	public GameObject shatterPrefab;

	public AudioClip explosionClip;

	public Vector3 directionToGo;

	public GameObject objectToListenTo; // Destroy if this object disables


	public GameObject firePrefab;

	void Update()
	{
		transform.position += directionToGo * Time.deltaTime * speed;
		if (Vector3.Distance (transform.position, Camera.main.transform.position) > 10f) {
			Destroy (gameObject);
		}
	}

	bool collided = false;

	void OnCollisionEnter(Collision other)
	{
		if (collided)
		{
			return;
		}

		collided = true;

		// Spawn fire
		print(other.transform);
		GameObject fireInstance = Instantiate(firePrefab, other.contacts[0].point, Quaternion.LookRotation(other.transform.up)) as GameObject;
		Destroy(fireInstance, 3f);

		fireInstance.transform.SetParent(other.transform, true);

		CityCubeManager.ins.PlayAudio(explosionClip);

		GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy(explosion, 2f);
		GameObject shatter = Instantiate(shatterPrefab, transform.position, transform.rotation) as GameObject;
		shatter.transform.localScale = transform.localScale;
		Destroy(shatter, .03f);
		Destroy(gameObject);
	}

}
