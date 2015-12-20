using UnityEngine;
using System.Collections;

public class JuiceMenuDisplayer : MonoBehaviour {

    [SerializeField]
    MenuDisplayer menu = null;

    RectTransform rectTrans = null;

	// Use this for initialization
	void Start () {
        rectTrans = menu.transform as RectTransform;
	}

    RaycastHit hit;

	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "Player")
        {
            var hitPos = hit.collider.transform.position;
            menu.transform.position = new Vector3(hitPos.x, hitPos.y + 0.08f, hitPos.z);
            menu.Enable();
            menu.ChangeText(hit.collider.gameObject);
        }
        else
        {
            menu.Disable();
        }
	}
}
