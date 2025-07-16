using System;
using UnityEngine;

namespace Scripts.UI
{
    public class Accept : MonoBehaviour
    {
        public event Action AcceptButtonPressed;

        public void Pressed()
        {
            AcceptButtonPressed?.Invoke();
        }
    }
}
