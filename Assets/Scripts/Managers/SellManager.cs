using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update()
    {
        
    }
    #endregion
    #region Methods
    void DisplaySellPopUp(GameObject Cup)
    {
        GameObject _TempGO = Instantiate(_sellPopUp);
        _TempGO.SetActive(false);
        _TempGO.transform.position = Cup.transform.position;
        _TempGO.transform.parent = Cup.transform;
        float height = Cup.GetComponent<SpriteRenderer>().size.y;
        
        Debug.Log(Cup.GetComponent<SpriteRenderer>().sprite.rect.height + " SIZE" + Cup.GetComponent<SpriteRenderer>().sprite.rect.height);
        _TempGO.transform.position = new Vector3(_TempGO.transform.position.x, _TempGO.transform.position.y + height/2 + 2, _TempGO.transform.position.z);
        _TempGO.SetActive(true); 
        Debug.Log(Cup.name + "Is in the selling point");
        Cup.GetComponent<Cup>().OnCupTapped += CupTap;
    }
    void CupTap()
    {
        Debug.Log("I HAVe BEEn tAPPED");
    }
    #endregion
}
