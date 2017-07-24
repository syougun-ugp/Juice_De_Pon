using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    [SerializeField]
    string publicityURL = "http://ugp.space/";

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

		Debug.logger.logEnabled = false;

//        var eval = "window.open('" + publicityURL + "','宣伝', 'width=800, height=600, menubar=no,location=no,status=no, toolbar=no, scrollbars=yes')";
//        Application.ExternalEval(eval);
	}

}
