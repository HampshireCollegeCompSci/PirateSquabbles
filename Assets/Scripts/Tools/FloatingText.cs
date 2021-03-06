using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

	public float BaseLifeSpan = 1;
	public float ScrollSpeed = 5;
	public float startToFade = 3;
	float remainingLifeSpan;
	Color baseColor;
	Color finalColor { get { return new Color (baseColor.r, baseColor.g, baseColor.g, 0); } }

	// Use this for initialization
	void Start () {
		baseColor = GetComponent<Text> ().color;
        int length = GetComponent<Text>().text.Length;
        float time = length * BaseLifeSpan / 30;
        time = Mathf.Max(time, 1f);
        time = Mathf.Min(time, 5f);
        remainingLifeSpan = time;
	}
	
	// Update is called once per frame
	void Update () {
		remainingLifeSpan -= Time.deltaTime;
		GetComponent<RectTransform> ().localPosition += Vector3.up * ScrollSpeed * Time.deltaTime;
       if (Input.GetMouseButtonDown(0) || remainingLifeSpan < 0) {
            gameObject.GetComponentInParent<SpeechBubble>().NextInteraction();
            Destroy(gameObject);
        }
		if (remainingLifeSpan < startToFade){
			GetComponent<Text> ().color = Color.Lerp (finalColor, baseColor, remainingLifeSpan / startToFade);
		}
	}
}
