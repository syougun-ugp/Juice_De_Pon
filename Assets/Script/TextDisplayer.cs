using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class TextDisplayer : MonoBehaviour {

    [System.Serializable]
    public struct ScenarioTypeData
    {
        public TextAsset textAsset;
        public List<Sprite> backGround;
    }

    [SerializeField]
    Image tapImage = null;
    
    [SerializeField]
    Image backGround =  null;

    [SerializeField]
    int nextFrame = 10;

    [SerializeField]
    List<ScenarioTypeData> scenarioTypeList = new List<ScenarioTypeData>();

    ScenarioTypeData type;

    TextAsset textAsset = null;

    Text text = null;

    bool canNextClick = false;
    bool autoShowText = false;

    int count = 0;
    int index = 0;

    int backGroundID = 0;

	void Start () 
    {
        type = scenarioTypeList.Find(i => i.textAsset.name == PurchaseManager.PurchaseType.ToString());
        textAsset = type.textAsset;
        backGround.sprite = type.backGround[backGroundID];

        text = GetComponent<Text>();
        text.text = "";
        tapImage.gameObject.SetActive(false);
	}

	void Update () 
    {
        ShowText();
        AutoShowText();
        NextClick();
	}

    void NextClick()
    {
        if (!canNextClick) return;

        if (Input.GetMouseButtonDown(0))
        {
            ChangeBackGround();

            text.text = string.Empty;
            canNextClick = false;
            index += 2;
            tapImage.gameObject.SetActive(false);
        }
    }

    void AutoShowText()
    {
        if (!autoShowText) return;

        index++;

        if (IsNextClick())
        {
            autoShowText = false;
            return;
        }

        text.text += textAsset.text[index];

    }

    void ShowText()
    {
        if (canNextClick || autoShowText) return;

        if (Input.GetMouseButtonDown(0))
        {
            autoShowText = true;
        }

        count++;
        if (count >= nextFrame)
        {
            count = 0;
            if (IsNextClick()) return;

            text.text += textAsset.text[index];
            index++;
        }
    }

    bool IsNextClick()
    {
        if (textAsset.text[index] == '@')
        {
            index++;
            canNextClick = true;
            tapImage.gameObject.SetActive(true);
            return true;
        }
        return false;
    }


    void ChangeBackGround()
    {
        if (textAsset.text[index] == '#')
        {
            index++;
            backGroundID++;
            if (backGroundID >= type.backGround.Count) return;

            backGround.sprite = type.backGround[backGroundID];
        }
        
    }

}
