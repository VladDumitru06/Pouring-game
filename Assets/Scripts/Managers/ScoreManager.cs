using Enums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// This value needs to be saved as score
    /// </summary>
    private int _points = 0;
    [SerializeField] Camera _mainCamera;
    [SerializeField] Color _negativeScoreColor;
    [SerializeField] Color _positiveScoreColor;
    [SerializeField] TextPool _textPool;
    private void Start()
    {
        PointManager.onPointsAdded += AddPoints;
        PointManager.onPointsRemoved += RemovePoints;
        PointManager.onPointsReceived += ShowScore;
    }
    public void AddPoints(int points)
    {
        _points += points;
    }
    public void RemovePoints(int points)
    {
        _points -= points;
    }



    /// <summary>
    /// Displays a score popup at the given position with the appropriate color
    /// </summary>
    public void ShowScore(int score, Transform transform)
    {
        if (score < 0)
            ShowText(score.ToString(), _negativeScoreColor, transform);
        else
            ShowText("+" + score.ToString(), _positiveScoreColor, transform);
    }
    /// <summary>
    /// Takes a TMPro from the objectPool and animates it towards north
    /// </summary>
    public void ShowText(string content, Color color, Transform transform) => ShowText(content, color, transform, Direction.North);

    /// <summary>
    /// Takes a TMPro from the objectPool and animates it towards a given position
    /// </summary>
    /// <param name="content">Text to display</param>
    /// <param name="color">Text color</param>
    /// <param name="spawnTransform">Position of the popup</param>
    /// <param name="animationDirection">Direction where the text is heading during animation</param>
    public void ShowText(string content, Color color, Transform spawnTransform, Direction animationDirection)
    {
        TextMeshProUGUI _tempTMPro = _textPool.GetTextFromPool(content, color);

        RectTransform rectTransform = _tempTMPro.GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        _tempTMPro.transform.position = RectTransformUtility.WorldToScreenPoint(_mainCamera, spawnTransform.position);

        if (animationDirection == Direction.North)
            LeanTween.moveY(_tempTMPro.gameObject, _tempTMPro.transform.position.y + 50, 2.5f).setEaseOutSine().setOnComplete(() => {
                FadeOutScore(_tempTMPro);
            });
        else if (animationDirection == Direction.South)
            LeanTween.moveY(_tempTMPro.gameObject, _tempTMPro.transform.position.y - 50, 2.5f).setEaseOutSine().setOnComplete(() => {
                FadeOutScore(_tempTMPro);
            });
        else if (animationDirection == Direction.East)
            LeanTween.moveX(_tempTMPro.gameObject, _tempTMPro.transform.position.x + 50, 2.5f).setEaseOutSine().setOnComplete(() => {
                FadeOutScore(_tempTMPro);
            });
        else
            LeanTween.moveX(_tempTMPro.gameObject, _tempTMPro.transform.position.x - 50, 2.5f).setEaseOutSine().setOnComplete(() => {
                FadeOutScore(_tempTMPro);
            });
    }

    /// <summary>
    /// Clamp the viewPort position of the popup and then convert it back to worldPoint   
    /// </summary>
    /// <param name="target">The target's Vector2</param>
    /// <returns></returns>
    private Vector3 ClampPopup(Vector2 target, float width, float height)
    {
        Vector2 clampedPosition = _mainCamera.WorldToViewportPoint(target);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, width / 2f, 1f - width / 2f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, height / 2f, 1f - height / 2f);
        Vector2 worldPos = RectTransformUtility.WorldToScreenPoint(_mainCamera, clampedPosition);
        return worldPos;
    }
    private void FadeOutScore(TextMeshProUGUI TMP)
    {
        LeanTween.value(TMP.gameObject, TMP.color, new Color(TMP.color.r, TMP.color.g, TMP.color.b, 0), 1f).setOnUpdate((Color val) =>
        {
            TMP.color = val;
        }).setOnComplete(() => { TMP.gameObject.SetActive(false); });
    }
}
