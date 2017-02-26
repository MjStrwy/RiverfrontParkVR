using UnityEngine;
using System.Collections;

public class DestroyHUD : MonoBehaviour {

    public float timer = 5.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timer);
	}
}
