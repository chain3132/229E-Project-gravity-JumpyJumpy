using System;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
        [SerializeField] private GameObject target;
        [SerializeField] Rigidbody2D slimeRb;
        
        [Header("Power Settings")]
        public float minPower = 1f;       // พลังเริ่มต้น
        public float maxPower = 10f;      // พลังสูงสุด
        public float powerBuildRate = 5f; // อัตราเพิ่มพลังต่อวินาที

        private float currentPower;
        private bool isCharging = false;

        private void Awake()
        {
            slimeRb = GetComponent<Rigidbody2D>();
            currentPower = minPower;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isCharging = true;
                currentPower = minPower;
            }

            // กำลังสะสมพลัง
            if (isCharging && Input.GetKey(KeyCode.Space))
            {
                currentPower += powerBuildRate * Time.deltaTime;
                currentPower = Mathf.Clamp(currentPower, minPower, maxPower);
                // (ถ้าต้องการ) อัพเดต UI ใช้แถบพลังที่นี่
                Debug.Log($"Charging... Power = {currentPower:F2}");
            }

            // ปล่อย Space -> ยิง
            if (isCharging && Input.GetKeyUp(KeyCode.Space))
            {
                isCharging = false;

                // หาเป้าหมายด้วยเมาส์ (ต้นฉบับ)
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                if (hit.collider != null)
                {
                    Vector2 hitPoint = hit.point;
                    target.transform.position = hitPoint;
                    Vector2 origin = slimeRb.position;
                    // คำนวนความเร็วขาออกโดยคูณด้วย currentPower
                    Vector2 baseVelocity = CalculateProjectileVelocity(origin, hitPoint, 1f);
                    Vector2 launchVelocity = baseVelocity * currentPower;

                    slimeRb.linearVelocity = launchVelocity;
                    Debug.Log($"Fired! Velocity = {launchVelocity}");
                }
            }
        }
        Vector2 CalculateProjectileVelocity(Vector2 origin,Vector2 target, float time)
        {
            Vector2 distance = target - origin;
            
            float velocityX = distance.x / time;
            float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
            
            Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
            return projectileVelocity;
        }
}
