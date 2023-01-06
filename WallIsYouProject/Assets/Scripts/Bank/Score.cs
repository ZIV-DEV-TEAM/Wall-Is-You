using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Score : BankDefault, IDataPersistence
{
    public static Score instance = null;
    private int _moneyAmountOnStart;
    public int GetMoneyOnLevel()
    {
        return Value - _moneyAmountOnStart;
    }
    private void Awake()
    {
        Initialize();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    public void LoadData(GameData data)
    {
        _bankValue.Value = data.MoneyAmount;
    }

    public void SaveData(GameData data)
    {
        data.MoneyAmount = Value;
    }
}
