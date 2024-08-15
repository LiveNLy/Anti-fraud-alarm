using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;

    private int _numberOfMovePoint = 0;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoints[_numberOfMovePoint].position, _speed * Time.deltaTime);

        if (transform.position == _movePoints[_numberOfMovePoint].position)
            _numberOfMovePoint = (++_numberOfMovePoint) % _movePoints.Length;
    }
}