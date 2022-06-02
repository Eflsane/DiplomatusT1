using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMaterialBuyerRequest : MonoBehaviour
{
    [SerializeField]
    int price;
    public void OpenMaterial(int matID)
    {
        if (UserMaterialsRequest.Instance.coinz >= price)
        {
            UsersWithoutDTO.Instance.UpdateUserCoinz(new UsersWithout()
            {
                Username = UserMaterialsRequest.Instance.Username,
                Coinz = UserMaterialsRequest.Instance.coinz - price,
            });

            UserOpennedMaterialDTO.Instance.AddUserOpennedMaterial(new UserOpennedMaterial()
            {
                Username = UserMaterialsRequest.Instance.Username,
                MaterialId = matID,
                OpenningDate = DateTime.Now,
            });

            UsersWithoutDTO.Instance.GetUser(UserMaterialsRequest.Instance.Username);
            //UserMaterialsRequest.Instance.OpenedMats[matID - 1].SetActive(true);
            //UserMaterialsRequest.Instance.OpenedMats[matID - 1].SetActive(false);
        }
    }
}
