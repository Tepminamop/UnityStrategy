using UnityEngine;
using UnityEngine.UI;

public class TransparentClick : MonoBehaviour
{
    public float AlphaThreshold = 0.001f;

    private void Start()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }
}
