using System.Collections;
using System.Collections.Generic;
using CorePackage;
using UnityEngine;
using CorePackage;

namespace ChangeGame.Item
{
    public class ItemController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Core pCore = other.GetComponentInChildren<Core>();
                if (pCore == null) return;
                if (pCore.GetCoreComponentBool<ItemPick>(out ItemPick item))
                {
                    item.PickUp();
                }
                Destroy(this.gameObject);
            }
        }
    }
}
