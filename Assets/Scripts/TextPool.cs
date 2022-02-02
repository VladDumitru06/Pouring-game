using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPool : MonoBehaviour
{
    #region Members
    private bool _isDone = false;

    public bool IsDone => _isDone;

    private List<GameObject> _textPoolList;

    [SerializeField]
    private GameObject _popupTextObject;
    #endregion
    #region Unity Methods
    private void Start()
    {
        SpawnText(10);
    }
    #endregion
    #region Methods
    /// <summary>
    /// Initialize new gameobjects with a textmeshpro component and setting them to inactive
    /// </summary>
    /// <param name="ammount"></param>
    private void SpawnText(int ammount)
    {
        _textPoolList = new List<GameObject>();
        for (int i = 1; i <= ammount; i++)
        {
            GameObject obj = Instantiate(_popupTextObject, transform);
            obj.SetActive(false);
            _textPoolList.Add(obj);
        }
    }
    /// <summary>
    /// sets the nr and color of the text, makes it active
    /// </summary>
    /// <returns></returns>
    public TextMeshProUGUI GetTextFromPool(string content, Color color)
    {

        foreach (GameObject x in _textPoolList)
        {
            if (x.activeSelf == false && x != null)
            {

                TextMeshProUGUI _tempTMP = x.GetComponent<TextMeshProUGUI>();
                _tempTMP.text = content;
                _tempTMP.color = color;
                x.SetActive(true);
                RectTransform RTransform = x.GetComponent<RectTransform>();
                RTransform.localPosition = new Vector3(20000, 20000);
                return _tempTMP;
            }
        }
        return CreateNewTMP(content, color);
    }
    /// <summary>
    /// When all the members of the textPoolList are active create a new one and spawn it
    /// </summary>
    /// <param name="nr"></param>
    /// <param name="color"></param>
    /// <param name="transform"></param>
    /// <returns></returns>
    private TextMeshProUGUI CreateNewTMP(string content, Color color)
    {
        GameObject obj = Instantiate(_popupTextObject);
        TextMeshProUGUI _tempTMP = obj.GetComponent<TextMeshProUGUI>();
        _tempTMP.text = content;
        _tempTMP.color = color;
        obj.SetActive(true);
        _textPoolList.Add(obj);
        return obj.GetComponent<TextMeshProUGUI>();
    }
    #endregion
}
