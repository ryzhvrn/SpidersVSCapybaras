using UnityEngine;
using IJunior.TypedScenes;

public class StartChoosenLevel : MonoBehaviour
{
    public void StartFirstLevel()
    {
        Level1.Load();
    }

    public void StartSecondLevel()
    {
        Level2.Load();
    }

    public void StartThirdLevel()
    {
        Level3.Load();
    }

    public void StartFourthLevel()
    {
        Level4.Load();
    }

    public void StartFifthLevel()
    {
        Level5.Load();
    }

    public void StartSixthLevel()
    {
        Level6.Load();
    }
}
