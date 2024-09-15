using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroup : MonoBehaviour
{
    [SerializeField] private Target[] m_targets;
    [SerializeField] private int m_basePoints = 100;
    private int m_targetsDestroyed = 0;
    private int m_totalTargets;

    private void Awake()
    {
        m_targets = GetComponentsInChildren<Target>();
    }

    private void Start()
    {
        m_totalTargets = m_targets.Length;

        foreach (var target in m_targets)
        {
            target.TargetGroup = this;
        }
    }
    public void OnTargetDestroyed()
    {
        m_targetsDestroyed++;

        if(AllTargetDestroyed())
        {
            m_targetsDestroyed = 0;
            StartCoroutine(OnTargetDestroyedAnimation());

            ScoreManager.Instance.PointsToAdd(m_basePoints * m_totalTargets);
        }

        bool AllTargetDestroyed()
        {
            return m_targetsDestroyed >= m_totalTargets;
        }

        IEnumerator OnTargetDestroyedAnimation()
        {
            yield return new WaitForSeconds(0.5f);
            foreach (var target in m_targets)
                target.Restart();
        }
    }


}
