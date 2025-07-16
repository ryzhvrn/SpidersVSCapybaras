using System;
using UnityEngine;

namespace Scripts.UI
{
    public class Decline : MonoBehaviour
    {
        public event Action DeclineButtonPressed;

        public void Pressed()
        {
            DeclineButtonPressed?.Invoke();
        }
    }
}
