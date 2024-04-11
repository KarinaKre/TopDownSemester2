using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ___WorkData.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Variables
        
        private Player_InputActions _inputActions;
        private InputAction _moveAction;
        
        public Vector2 moveInput;
        public float speed  = 5f;
        private Rigidbody2D _rb;
        private Animator _anim;
        private SpriteRenderer _sr;
        #endregion
       
        private void Awake()
        {
            _inputActions = new Player_InputActions();

            _moveAction = _inputActions.Player.Move;
         
            
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        { 
            UpdateVelocity();
        updateAnimations();
        
        }

        private void OnEnable()
        {
           _inputActions.Enable();
           _moveAction.performed += Move;
           _moveAction.canceled += Move;
        }

        private void FixedUpdate()
        {
            //_rb.velocity = new Vector2(moveInput.x * speed,moveInput.y);
            _rb.velocity = moveInput * speed;
        }

        private void OnDisable()
        {
          _inputActions.Disable();

          _moveAction.performed -= Move;
          _moveAction.canceled -= Move;
        }

        #region MovementFuntions

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
        
        
        
    }
}
