using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TapController : MonoBehaviour {

    [SerializeField]
    float toScale = 0.5f;

    [SerializeField]
    float time = 1.0f;

    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;

	// Use this for initialization
	void Start () {
        iTween.ValueTo(gameObject, iTween.Hash("from", 1, "to", toScale, "time", time,
            "looptype",iTween.LoopType.pingPong,
            "easetype",easeType,"onupdate","UpdateHandler"));	    
	}

    void UpdateHandler(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }
}
