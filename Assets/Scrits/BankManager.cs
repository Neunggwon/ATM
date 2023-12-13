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
        if (deposit) //�Ա�
        {
            //myacsh�� inputcash��ŭ ���� �ִ��� Ȯ��
            if (myCash >= inputcash)
            {
                //bankcash�� inputcash��ŭ �ִ´�.
                myCash -= inputcash;
                bankCash += inputcash;
                myCashText.text = $"{myCash.ToString("#,###")}";
                bankCashText.text = $"{bankCash.ToString("#,###")}";
            }
            else
            {
                //�ܾ׺���â
                littleCashUI.gameObject.SetActive(true);

            }
        }
        else if (!deposit) //���
        {
            //bankcash�� inputcash��ŭ ���� �ִ��� Ȯ��
            if (bankCash >= inputcash)
            {
                //mycash�� inputcash��ŭ �ִ´�.
                myCash += inputcash;
                bankCash -= inputcash;
                myCashText.text = $"{myCash.ToString("#,###")}";
                bankCashText.text = $"{bankCash.ToString("#,###")}";
            }
            else
            {
                //�ܾ׺���â
                littleCashUI.gameObject.SetActive(true);

            }
        }
    }
}
