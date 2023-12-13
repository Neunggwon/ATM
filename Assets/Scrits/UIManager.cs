using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private bool deposit;

    public GameObject inputButton;
    public GameObject startButton;
    public GameObject littleCashUI;

    public TMP_Text myCashText;
    public int myCash;
    public TMP_Text bankCashText;
    public int bankCash;

    private void Awake()
    {
        inputButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);

        littleCashUI.gameObject.SetActive(false);
    }
    void Start()
    {
        myCashText.text = myCash.ToString("#,###");
        bankCashText.text = bankCash.ToString("#,###");
        BankManager.Instance.deposit = true;
    }

    public void StartButton(bool depositBool)
    {
        bool deposit1 = depositBool;
        deposit = deposit1;
        startButton.gameObject.SetActive(false);
        inputButton.gameObject.SetActive(true);
    }
    //초기화면으로 이동
    public void ExitButton()
    {
        inputButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }

    public void DepositAndWithdraw(int inputcash)
    {
        if (deposit) //입금
        {
            if (myCash >= inputcash)
            {
                myCash -= inputcash;
                bankCash += inputcash;
                myCashText.text = $"{myCash.ToString("#,###")}";
                bankCashText.text = $"{bankCash.ToString("#,###")}";
            }
            else
            {
                littleCashUI.gameObject.SetActive(true);

            }
        }
        else if (!deposit) //출금
        {
            if (bankCash >= inputcash)
            {
                myCash += inputcash;
                bankCash -= inputcash;
                myCashText.text = $"{myCash.ToString("#,###")}";
                bankCashText.text = $"{bankCash.ToString("#,###")}";
            }
            else
            {
                littleCashUI.gameObject.SetActive(true);

            }
        }
    }

    public void LittleCashButton()
    {
        littleCashUI.gameObject.SetActive(false);
    }


    //public void OnValueChanged(int inputcash)
    //{
    //    BankManager.Instance.Test(inputcash);
    //}

    //public void OnEndEdit(int inputcash)
    //{
    //    BankManager.Instance.Test(inputcash);
    //}

    //public void OnDeselect(int inputcash)
    //{
    //    BankManager.Instance.Test(inputcash);
    //}

    //public void OnSelect(int inputcash)
    //{
    //    BankManager.Instance.Test(inputcash);
    //}
}
