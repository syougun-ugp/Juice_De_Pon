using UnityEngine;
using System.Collections;

public class JuiceType : MonoBehaviour {

    [SerializeField]
    PurchaseManager.TypeJP type = PurchaseManager.TypeJP.NULL;

    public PurchaseManager.TypeJP Type { get { return type; } }
}
