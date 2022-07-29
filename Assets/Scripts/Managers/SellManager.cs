using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class SellManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    TransferCupController _transferPosition;
    [SerializeField]
    Transform _sellPosition;
    [SerializeField]
    GameObject _sellPopUp;
    #endregion
    #region Unity_Methods
    void Start()
    {
        _transferPosition.CupFound += DisplaySellPopUp;
        _transferPosition.CupFound += (GameObject Cup) => { Cup.GetComponent<Cup>().cupStatus = CupStatus.WaitForTransfer; };
    }

    void Update()
    {
        
    }
    #endregion
    #region Methods
    /// <summary>
    /// Change method 
    /// </summary>
    /// <param name="Cup"></param>
    void DisplaySellPopUp(GameObject Cup)
    {
        GameObject _TempGO = Instantiate(_sellPopUp);
        _TempGO.SetActive(false);
        _TempGO.transform.position = Cup.transform.position;
        _TempGO.transform.parent = Cup.transform;
        float height = Cup.GetComponent<SpriteRenderer>().size.y;
        _TempGO.transform.position = new Vector3(_TempGO.transform.position.x, _TempGO.transform.position.y + height/2 + 2, _TempGO.transform.position.z);
        _TempGO.SetActive(true); 
        Debug.Log(Cup.name + "Is in the selling point");
        Cup.GetComponent<Cup>().OnCupTapped += CupTap;
    }
    void CupTap(GameObject cup)
    {
        Cup _tempCup = cup.GetComponent<Cup>();
        if (_tempCup.isMoving == false && _tempCup.cupStatus == CupStatus.WaitForTransfer)
            MoveCupToSellPosition(_tempCup);
        if (_tempCup.cupStatus == CupStatus.WaitForPackaging)
            SellCup(_tempCup);
    }
    private void MoveCupToSellPosition(Cup Cup)
    {
        Cup.FreezeLiquid();
        LeanTween.moveX(Cup.gameObject, _sellPosition.position.x, 5f);
        LeanTween.moveY(Cup.gameObject, Cup.transform.position.y + 1f, 2.5f).setOnComplete(() => {
            LeanTween.moveY(Cup.gameObject, Cup.transform.position.y - 1f, 2.5f).setOnComplete(()=> {
                Cup.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Cup.GetComponent<Rigidbody2D>().angularVelocity = 0;
                Cup.GetComponent<Cup>().UnFreezeLiquid();
                Cup.cupStatus = CupStatus.WaitForPackaging;
            });
        });
    }
    private void SellCup(Cup Cup)
    {
        Destroy(Cup.gameObject);
    }
    #endregion
}
