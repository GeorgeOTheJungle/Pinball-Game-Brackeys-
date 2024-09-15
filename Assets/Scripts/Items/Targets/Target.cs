using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IGivePoints
{
    [HideInInspector] public TargetGroup TargetGroup;
    private SpriteRenderer m_spriteRenderer;
    private Collider2D m_collider;
    private Color m_baseColor;
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_baseColor = m_spriteRenderer.color;
        m_collider = GetComponent<Collider2D>();
    }
    public void GivePoints()
    {
        m_spriteRenderer.color = Color.gray;
        ScoreManager.Instance.PointsToAdd(100);
    }

    public void Restart()
    {
        m_spriteRenderer.color = m_baseColor;
        m_collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            GivePoints();
            m_collider.enabled = false;
            TargetGroup.OnTargetDestroyed();
            //Disable 
        }
    }
}
