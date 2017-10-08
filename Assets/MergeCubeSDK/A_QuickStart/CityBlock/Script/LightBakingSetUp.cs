using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class LightBakingSetUp : MonoBehaviour {
	[System.Serializable]
	public struct SizeStruct
	{
		public Transform toSet;
		public float sizeWhenBake;
		public Vector3 posWhenBake;
		public Vector3 posWhenNotBake;
	}
	public bool isActive = false;
	public bool isSetToBake = false;
	public Transform [] ToSets;
	public Transform[] BakePost;
	public Transform [] PlayPost;
	public GameObject [] ActiveWhenBake;
	public GameObject [] DeActiveWhenBake;
	public SizeStruct [] BakeMoveObj;
	void OnValidate(){
		if (isActive) {
			if (isSetToBake) {
				for (int i = 0; i < ToSets.Length; i++) {
					ToSets [i].localPosition = BakePost [i].localPosition;
					ToSets [i].localEulerAngles = BakePost [i].localEulerAngles;
					ToSets [i].localScale = BakePost [i].localScale;
				}
				foreach (GameObject tp in ActiveWhenBake) {
					tp.SetActive (true);
				}
				foreach (GameObject tp in DeActiveWhenBake) {
					tp.SetActive (false);
				}

				foreach (SizeStruct tp in BakeMoveObj) {
					tp.toSet.position = tp.posWhenBake;
					tp.toSet.localScale = Vector3.one * tp.sizeWhenBake;
				}
			} else {
				for (int i = 0; i < ToSets.Length; i++) {
					ToSets [i].localPosition = PlayPost [i].localPosition;
					ToSets [i].localEulerAngles = PlayPost [i].localEulerAngles;
					ToSets [i].localScale = PlayPost [i].localScale;
				}
				foreach (GameObject tp in ActiveWhenBake) {
					tp.SetActive (false);
				}
				foreach (GameObject tp in DeActiveWhenBake) {
					tp.SetActive (true);
				}


				foreach (SizeStruct tp in BakeMoveObj) {
					tp.toSet.position = tp.posWhenNotBake;
					tp.toSet.localScale = Vector3.one;
				}
			}
		}
	}
}
