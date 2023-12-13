using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager Instance;

    [SerializeField] public bool deposit;

    public GameObject littleCashUI;

    public TMP_Text name;
    public TMP_Text myCashText;
    public int myCash;
    public TMP_Text bankCashText;
    public int bankCash;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Test(int inputcash)
    {
        if (deposit) //입금
        {
            //myacsh에 inputcash만큼 돈이 있는지 확인
            if (myCash >= inputcash)
            {
                //bankcash에 inputcash만큼 넣는다.
                myCash -= inputcash;
                bankCash += inputcash;
                myCashText.text = $"{myCash.ToString("#,###")}";
                bankCashText.text = $"{bankCash.ToString("#,###")}";
            }
            else
            {
                //잔액부족창
                littleCashUI.gameObject.SetActive(true);

            }
        }
        else if (!deposit) //출금
        {
            //bankcash에 inputcash만큼 돈이 있는지 확인
            if (bankCash >= inputcash)
            {
                //mycash에 inputcash만큼 넣는다.
                myCash += inputcash;
                bankCash -= inputcash;
                myCashText.text = $"{myCash.ToString("#,###")}";
                bankCashText.text = $"{bankCash.ToString("#,###")}";
            }
            else
            {
                //잔액부족창
                littleCashUI.gameObject.SetActive(true);

            }
        }
    }
}
