using CorePackage;
using UnityEngine;
using System;

namespace ChangeGame.Item
{
    public class ItemController : MonoBehaviour
    {
        public Action OnPickUpEvent;
        [SerializeField] private AudioSource _seSource;
        [SerializeField] private AudioClip _pickUpSE;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Core pCore = other.GetComponentInChildren<Core>();
                if (pCore == null) return;
                if (pCore.GetCoreComponentBool(out ItemPick itemPick))
                {
                    itemPick.PickUp();
                    //Destroy(this.gameObject);
                    _seSource.PlayOneShot(_pickUpSE);
                    OnPickUpEvent?.Invoke();
                }
            }
        }
    }
}
