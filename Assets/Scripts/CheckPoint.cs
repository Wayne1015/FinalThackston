using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    [SerializeField]
    private float activatedScale;

    [SerializeField]
    private float nonactivatedScale;

    [SerializeField]
    private Color activatedColor;
    [SerializeField]
    private Color nonactivatedColor;

    public static CheckPoint currentActiveCheckPoint;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        DeactivatedCheckPoint();
    }

    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isActive)
        {
            ActivateCheckPoint();
           
        }

    }
private void ActivateCheckPoint()
    {
        if (currentActiveCheckPoint != null)
        {
            currentActiveCheckPoint.DeactivatedCheckPoint();
        }

        isActive = true;

        currentActiveCheckPoint = this;

        transform.localScale = transform.localScale * activatedScale;

        spriteRenderer.color = activatedColor;
        
    }
private void DeactivatedCheckPoint()
    {
        isActive = false;
        transform.localScale = Vector3.one * nonactivatedScale;
        spriteRenderer.color = nonactivatedColor;
    }
}
