using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Samples;
using DigitalRubyShared;
using System;
using UnityHFSM;
using Freya;

public class IdlePlayerController : BaseController<PlayerModel, LogView, PlayerPresenter, PlayerData>, IMoveable

{
    [SerializeField]
    CharacterController characterController;


    private MyCustomStateMachine idlePlayerStateMachine;

    [SerializeField]

    private IdlePlayerInput playerInput;
    private MovementAction movementAction;
    private RotationAction rotationAction;


    private void OnEnable()
    {
        playerInput.OnJoystickBegan += StartMovementInput;
        playerInput.OnJoystickChanged += UpdateMovement;
        playerInput.OnJoystickEnded += EndMovementInput;

    }

    private void EndMovementInput(FingersJoystickScript script, Vector2 vector)
    {
        idlePlayerStateMachine.RequestStateChange("Idle");
    }

    private void StartMovementInput(FingersJoystickScript script, Vector2 vector)
    {
        idlePlayerStateMachine.RequestStateChange("Moving");
    }

    private MyCustomStateMachine SetupStateMachine()
    {
        MyCustomStateMachine fsm = new();
        fsm.AddState("Init");
        fsm.AddState("Idle", new State(onLogic: state => view.UpdateView(data)));
        fsm.AddState("Blocked", new State());
        fsm.AddState("Popup", new State());
        fsm.AddState("Moving", new State(onLogic: state => { movementAction.Act(); rotationAction.Act(); }));
        fsm.SetStartState("Init");
        fsm.Init();
        return fsm;

    }
    private void UpdateMovement(FingersJoystickScript script, Vector2 vector)
    {

        movementAction.SetModifier(vector.XZtoXYZ());
        rotationAction.SetModifier(vector.XZtoXYZ());
    }

    protected override void Awake()
    {
        base.Awake();
        movementAction = new MovementAction(TranslationType.CharacterController, data.speed);
        movementAction.Initialize(characterController: characterController);
        rotationAction = new RotationAction(characterController.transform, data.speed);
        idlePlayerStateMachine = SetupStateMachine();
    }
    private void Update()
    {
        idlePlayerStateMachine.OnLogic();
    }
    public void Move()
    {

    }
}
public class PlayerData : IDataPack
{
    public float health;

    public PlayerData(float health, float speed)
    {
        this.health = health;
        this.speed = speed;
    }

    [field: SerializeField]
    // Specific implementation for PlayerModel
    public float speed { get; private set; }

    public T GetData<T>() where T : notnull, new()
    {
        throw new NotImplementedException();
    }
}

public class PlayerModel : BaseModel<PlayerData>
{
    public override PlayerData Initialize()
    {
        PlayerData playerData = new PlayerData(1, 3);
        return playerData;
    }
}

public class PlayerPresenter : BasePresenter<PlayerModel, LogView, PlayerData>
{
    // Specific implementation for PlayerPresenter
}

public interface IMoveable
{
    public void Move();
}