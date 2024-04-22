using UnityEngine;

public class Visitor : Character
{
    [SerializeField] private TableCharacterPosition _characterPosition;
    [SerializeField] private Table _table;
    [SerializeField] private Transform _tablePosition;
    [SerializeField] private Transform _leavePosition;

    [SerializeField] private Order _order;
    [SerializeField] private OrderView _orderView;

    [SerializeField] private VisitorState _currentState;

    public Order Order
    {
        get { return _order; }
        set
        {
            _order = value;
            _orderView.Initialize(_order);

        }
    }

    public Table Table => _table;

    public void Initialize(Table table, TableCharacterPosition characterPosition, Transform leavePosition)
    {
        base.Initialize();

        _table = table;
        _characterPosition = characterPosition;
        _tablePosition = characterPosition.position;
        _characterPosition.State = CharacterPositionState.Taken;
        _characterPosition.character = this;

        _leavePosition = leavePosition;

        GoTo(_tablePosition);
        _currentState = VisitorState.MoveToTable;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case VisitorState.MoveToTable:
                _animator.Play(WALK_ANIMATION);
                RotateToTable();
                break;
            case VisitorState.Idle:
                _animator.Play(IDLE_ANIMATION);
                break;
            case VisitorState.Leave:
                _animator.Play(WALK_ANIMATION);
                break;
            default:
                break;
        }
    }

    private void RotateToTable()
    {


        if (Vector3.Distance(_tablePosition.position, transform.position) <= _stopDistance)
        {
            _navMeshAgent.isStopped = true;

            transform.position = Vector3.MoveTowards(transform.position, _tablePosition.position, _speed * Time.deltaTime);

            Quaternion targetRotation = _tablePosition.rotation;
            if (targetRotation != transform.rotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);
            }
            else
            {
                _currentState = VisitorState.Idle;
                _characterPosition.State = CharacterPositionState.Waiting;
            }
        }
    }
}

public enum VisitorState
{
    MoveToTable,
    Idle,
    Leave,
}
