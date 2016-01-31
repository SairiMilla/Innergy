using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {

    public Image endImage;

    void Start() {
        endImage.CrossFadeAlpha(0f, 0f, false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hey");
        endImage.CrossFadeAlpha(1f, 1f, false);
    }
}
