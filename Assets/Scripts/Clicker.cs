using UnityEngine;
using System.Collections;
using Gvr;

public class Clicker : MonoBehaviour {
    public bool clicked()
    {
#if (UNITY_ANDROID || UNITY_IPHONE)
        Debug.Log("Cardboard Clicked");
        return GvrController.ClickButton;
    #else
        Debug.Log("Other Control Clicked");
        return Input.anyKeyDown;
    #endif
    }
}
