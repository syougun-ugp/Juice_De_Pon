using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JuiceButtonController : MonoBehaviour
{
    [SerializeField]
    PurchaseManager.Type type = PurchaseManager.Type.NULL;

    Button button = null;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPurchase);
    }

    void OnPurchase()
    {
        var purchaseManager = GameObject.FindObjectOfType<PurchaseManager>();
        purchaseManager.SetPurchaseType(button, type);
    }
}
