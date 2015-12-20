using UnityEngine;
using System.Collections;

public class ZoomController : MonoBehaviour {

    [SerializeField]
    float zoomPoint = 0.3f;

    [SerializeField]
    float moveTime = 3;

    [SerializeField]
    float delayTime = 0;

    [SerializeField]
    float siteOpenTime = 2.0f;

    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;

    [SerializeField]
    string url = "";


    public void StartZoome()
    {
        iTween.MoveTo(gameObject, iTween.Hash("z", transform.position.z - zoomPoint, "time", moveTime, "delay", delayTime, "easetype", easeType));
        StartCoroutine("WaitOpenSite");
    }

    IEnumerator WaitOpenSite()
    {
        yield return new WaitForSeconds(moveTime + delayTime + siteOpenTime);

        SceneManager.Instance.StartChange(SceneNameManager.Scene.Scenario, new FadeTimeData(1, 1));

        //var eval = "window.open('" + url + PurchaseManager.PurchaseType.ToString() + "','宣伝', 'width=800, height=600, menubar=no,location=no,status=no, toolbar=no, scrollbars=yes')";
        //Application.ExternalEval(eval);
    }

}
