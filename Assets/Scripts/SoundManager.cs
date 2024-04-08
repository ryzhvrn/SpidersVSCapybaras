using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _sceneLevelLoadSound;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(_sceneLevelLoadSound, transform.position);
    }
}
