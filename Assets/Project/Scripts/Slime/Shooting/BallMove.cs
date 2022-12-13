using UnityEngine;

namespace Project.Scripts.Slime.Shooting
{
    public class BallMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] int speed = 50;
        
        private float _damage;
        private float _timeToDestruct = 3f;
        private Vector3 _previousStep;

        void Awake ()
        {
            Invoke ("DestroyNow", _timeToDestruct);

            rb.velocity = transform.TransformDirection(Vector3.forward * speed);

            _previousStep = gameObject.transform.position;
        }

        public void SetBallDamage(float ballDamage)
        {
            _damage = ballDamage;
        }

        void FixedUpdate()
        {
            Quaternion currentStep = gameObject.transform.rotation;

            transform.LookAt (_previousStep, transform.up);
            RaycastHit[] objects;
            
            Ray ray = new Ray (transform.position, transform.forward);
            float distance = Vector3.Distance (_previousStep, transform.position);
            
            if (distance == 0)
                distance = 1.0f;
            
            objects = Physics.RaycastAll (ray, distance);
            
            if (objects.Length != 0)
            {
                SendDamage(objects [objects.Length - 1].transform.gameObject);
            }

            gameObject.transform.rotation = currentStep;

            _previousStep = gameObject.transform.position;
        }

        void OnCollisionEnter(Collision hit)
        {
            SendDamage(hit.gameObject);
        }

        void SendDamage(GameObject Hit)
        {
            if (Hit.CompareTag("Enemy"))
            {
                Hit.SendMessage("ApplyDamage", _damage,
                    SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
            }
        }
        
        void DestroyNow ()
        {
            DestroyObject(gameObject);
        }
    }
}
 