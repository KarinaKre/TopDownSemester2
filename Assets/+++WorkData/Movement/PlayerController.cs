using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ___WorkData.Movement
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        
        private Player_InputActions _inputActions;
        private InputAction _moveAction;
        private InputAction _interactAction;
        public Vector2 moveInput;

        public Interactable selectedInteractable;
        public float speed  = 5f;
        private Rigidbody2D _rb;
        public Animator _anim;
        private SpriteRenderer _sr;
        #endregion
       
        private void Awake()
        {
            _inputActions = new Player_InputActions();

            _moveAction = _inputActions.Player.Move;
            _interactAction = _inputActions.Player.Interact;
            
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        { 
            UpdateVelocity(); 
            updateAnimations();
        }

        private void OnEnable()
        { 
            
           _moveAction.performed += Move;
           _moveAction.canceled += Move;
           _interactAction.performed += Interact;
        }
        private void OnDisable()
        {
           
            _moveAction.performed -= Move;
            _moveAction.canceled -= Move;
            _interactAction.performed -= Interact;
        }
        public void EnableInput()
        {
            _inputActions.Enable();
        }

        public void DisableInput()
        {
            _inputActions.Disable();
        }
        
        private void FixedUpdate()
        {
            //_rb.velocity = new Vector2(moveInput.x * speed,moveInput.y);
            _rb.velocity = moveInput * speed;
        }

        #region MovementFunctions

        private void Move(InputAction.CallbackContext ctx)
        {
            moveInput = ctx.ReadValue<Vector2>().normalized;
        }

        void UpdateVelocity()
        {
            
        }
        #endregion

        #region Animations

        void updateAnimations()
        {
            if (moveInput != Vector2.zero) 
            {
                _anim.SetFloat("dirY", moveInput.y);
                _anim.SetFloat("dirX", moveInput.x);
                _anim.SetFloat("MovementSpeed",5);
            }
            else
            {
                _anim.SetFloat("MovementSpeed",0);
            }
            
           //_anim.SetBool("isMoving",moveInput != Vector2.zero);
        }
        

        #endregion

        #region Physics

        private void OnTriggerEnter2D(Collider2D other)
        {
            TrySelectedInteractable(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
        TryDelectedInteractable(other);
        }

        #endregion
        
        #region Interaction
        
        private void Interact(InputAction.CallbackContext ctx)
        {
            if (selectedInteractable != null)
            {
                selectedInteractable.Interact();
            }
        }

        private void TrySelectedInteractable(Collider2D other)
        {
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable == null) 
            {
                return;
            }

            if (selectedInteractable != null)
            {
                selectedInteractable.Deselect();
            }

            selectedInteractable = interactable;
            selectedInteractable.Select();
        }
        
        private void TryDelectedInteractable(Collider2D other)
        {
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable == null) 
            {
                return;
            }
            
            if (selectedInteractable != null)
            {
                selectedInteractable.Deselect();
                selectedInteractable = null;
            }
        }
        #endregion
    }
}
