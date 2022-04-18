using System.Collections;
using UnityEngine;

public class CellComponent : MonoBehaviour
{
    [SerializeField] private float _rotationTime;
    [SerializeField] private AnimationCurve _rotationAnimationCurve;
    
    private SpriteRenderer _spriteRenderer;

    public static bool CellRotating { get; set; }
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void OnMouseDown()
    {
        if (CellRotating) { return; }
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        CellRotating = true;
        var timer = 0f;
        var initialRotation = transform.eulerAngles.z;
        while (timer < 1)
        {
            var rotation = Vector3.zero;
            rotation.z = Mathf.Lerp(initialRotation, initialRotation + 90, _rotationAnimationCurve.Evaluate(timer));
            transform.eulerAngles = rotation;
            timer += Time.deltaTime / _rotationTime;
            yield return null;
        }

        transform.eulerAngles = new Vector3(0, 0, Mathf.RoundToInt(initialRotation + 90));
        CellRotating = false;
    }
}