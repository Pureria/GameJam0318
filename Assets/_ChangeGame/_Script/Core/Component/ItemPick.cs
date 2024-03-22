using System;

namespace CorePackage
{
    public class ItemPick : CoreComponent
    {
        public Action OnPickUpEvent;

        public void PickUp()
        {
            OnPickUpEvent?.Invoke();
        }
    }
}
