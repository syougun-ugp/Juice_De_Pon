using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropMover : MonoBehaviour {

    [SerializeField]
    float dropPoint = 0.3f;

    [SerializeField]
    float moveTime = 3;

    [SerializeField]
    float delayTime = 0;

    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;

    [SerializeField]
    ZoomController zoomController = null;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = PurchaseManager.PurchaseImage.sprite;
        iTween.MoveTo(gameObject, iTween.Hash("y", transform.position.y - dropPoint, "time", moveTime, "delay", delayTime, "easetype", easeType));
        StartCoroutine("WaitStartZoom");
    }


    IEnumerator WaitStartZoom()
    {
        yield return new WaitForSeconds(moveTime + delayTime);

        zoomController.StartZoome();
    }
}
