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
        //if (!Input.GetMouseButtonDown(0)) return;

        ScenarioFinish();

        ChangeBackGround();

        text.text = string.Empty;
        canNextClick = false;
        index += 2;
        tapImage.gameObject.SetActive(false);

    }

    void AutoShowText()
    {
        if (!autoShowText) return;
        if (IsFinish()) return;

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
        if (IsFinish()) return;

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
        if (IsFinish()) return false;

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
        if (IsFinish()) return;
        if (textAsset.text[index] != '#') return;

        index++;
        var id = int.Parse(textAsset.text[index].ToString()) - 1;

        if (id >= type.backGround.Count || id < 0)
        {
            Debug.LogError("シナリオの#番号が登録画像IDと違います : " + id);
            return;
        }

        index++;
        backGround.sprite = type.backGround[id];
        
    }

    bool IsFinish()
    {
        if (textAsset.text.Length <= index)
        {
            return true;
        }

        return false;

    }

    void ScenarioFinish()
    {
        if (IsFinish())
        {
            SceneManager.Instance.StartChange(SceneNameManager.Scene.Main, new FadeTimeData(1, 1));

            enabled = false;
        }
    }
}
