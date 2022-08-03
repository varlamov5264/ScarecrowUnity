using System;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : Item
    {
        public Action onFire;
        
        private void Update()
        {
            if (InHand)
            {
                if (Input.GetKeyDown(_interactKey) && FireCondition())
                {
                    Fire();
                    onFire?.Invoke();
                }
            }
        }

        protected virtual bool FireCondition() => true;

        protected abstract void Fire();
    }
}