using UnityEngine;
using System.Collections;

public class CityCubeManager : MonoBehaviour
{
	static CityCubeManager S_ins;

	void Awake(){
		S_ins = this;
	}
	public static CityCubeManager ins{
		get{ return S_ins; }
	}
	void Start(){
		player = GetComponent<AudioSource> ();
		MergeMultiTarget.instance.OnTrackingFound += TrackingFound;
		MergeMultiTarget.instance.OnTrackingLost += TrackingLost;
	}
	AudioSource player;
	public void PlayAudio(AudioClip toPlay){
		player.PlayOneShot (toPlay);
	}
	public CityAsteroid asteroidPrefab;

	void TrackingFound(){
		GetComponent<AudioSource> ().volume = 1;
	}
	void TrackingLost(){
		GetComponent<AudioSource> ().volume = 0;
	}

	Vector3 hitTarget;
	public void ShootAsteroid()
	{
		Vector3 spawnPosition;

		GetAsteroidTarget();

		spawnPosition = Camera.main.transform.position + Camera.main.transform.up * 0.05f;
		
		CityAsteroid asteroid = Instantiate (asteroidPrefab, spawnPosition, Quaternion.identity) as CityAsteroid;
		
		asteroid.directionToGo = hitTarget - asteroid.transform.position;
		asteroid.directionToGo.Normalize ();
		asteroid.transform.rotation = Quaternion.LookRotation (asteroid.directionToGo);
		asteroid.objectToListenTo = gameObject;
		
		asteroid.transform.Translate ((Vector3)Random.insideUnitCircle * 0.1f);
		
		asteroid.directionToGo = hitTarget - asteroid.transform.position;
		asteroid.directionToGo.Normalize ();
		asteroid.transform.rotation = Quaternion.LookRotation (asteroid.directionToGo);
	}


	public void GetAsteroidTarget()
	{
		hitTarget = GazeCaster.instance.hit.point;
	}
		
}
