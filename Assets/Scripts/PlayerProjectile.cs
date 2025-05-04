using System;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
        [SerializeField] private GameObject target;
        [SerializeField] Rigidbody2D slimeRb;
        private Animator _animator;
       
        private bool isGrounded;
        
        private bool isCharging = false;

        private void Awake()
        {
            slimeRb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, target.transform.position.z);
            
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                LaunchProjectile();
            }
        }
        void LaunchProjectile()
        {

            Vector2 origin = slimeRb.position;
            Vector2 hitPoint = (Vector2)target.transform.position;

           
            Vector2 launchVelocity = CalculateProjectileVelocity(origin, hitPoint, 1f);

            _animator.SetTrigger("doTouch");
            AudioManager.instance.PlaySFX(AudioManager.instance.jump);
            slimeRb.velocity = launchVelocity;
            Debug.Log($"Launched! vel={launchVelocity}");
        }

        Vector2 CalculateProjectileVelocity(Vector2 origin,Vector2 target, float time)
        {
            Vector2 distance = target - origin;
            
            float velocityX = distance.x / time;
            float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
            
            Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
            return projectileVelocity;
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                isGrounded = true;
            }
                
            
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
                isGrounded = false;
        }

}
