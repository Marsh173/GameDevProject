using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class softBodySkin : MonoBehaviour
{

    #region
    private const float splineOffset = 0.5f;
    #endregion

    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;
    #endregion

    #region 
    private void Awake()
    {
        updateVertices();
    }

    private void Update()
    {
        updateVertices();
    }
    #endregion

    #region 

    private void updateVertices()
    {
        for(int i = 0; i< points.Length - 1; i++)
        {
            Vector2 _vertex = points[i].localPosition;
            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;

            float _colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));

            try
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch
            {
                Debug.Log("Spline points too close, recalculate.");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius + splineOffset)));
            }

            Vector2 _left = spriteShape.spline.GetLeftTangent(i);
            Vector2 _right = Vector2.Perpendicular(_towardsCenter) * _left.magnitude;

            Vector2 new_left = Vector2.zero - (_right);

            spriteShape.spline.SetRightTangent(i, _right);
            spriteShape.spline.SetLeftTangent(i, new_left);
        }
    }

    #endregion


}
