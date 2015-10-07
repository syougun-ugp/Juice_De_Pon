using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PurchaseManager : MonoBehaviour {

    public enum Type
    {
        NULL = -1,
        Cola,
	    Calpis,
	    Orange,
	    Oolong,
	    Sports,
	    Konpota,
	    Vitamin,
	    Cocoa,
	    Coffee,
	    MilkTea,
	    GreenTea,
        Water,
    };

    public enum TypeJP
    {
        NULL = -1,
        コーラ,
        カルピス,
        オレンジ,
        ウーロン茶,
        スポーツドリンク,
        コンポタージュ,
        ビタミンドリンク,
        ココア,
        コーヒー,
        ミルクティー,
        緑茶,
        水,
    };

    public static Type PurchaseType { get; private set; }

    [SerializeField]
    Sprite onPushButtonSprite = null;

    void Start()
    {
        PurchaseType = Type.Oolong;
    }

    public void SetPurchaseType(Button button,Type type)
    {
        PurchaseType = type;
        AllButtonDisable();
        button.image.sprite = onPushButtonSprite;
        SceneManager.Instance.StartChange(SceneNameManager.Scene.Purchase, new FadeTimeData(1, 1));
    }


    void AllButtonDisable()
    {
        var buttons = GameObject.FindObjectsOfType<Button>();

        foreach (var button in buttons)
        {
            button.enabled = false;
        }
    }

}
