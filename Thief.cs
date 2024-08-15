using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private int _pointGet = 0;

    private void Update()
    {
        if (_pointGet == 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, _target.position.z, _speed * Time.deltaTime));

            if(transform.position.z == _target.transform.position.z)
            {
                _pointGet = 1;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, _target.position.z, _speed * -3 * Time.deltaTime));
        }
    }
}
