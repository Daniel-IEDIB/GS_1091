using System;
using Shared;
using UnityEngine;
using Console = Shared.Console;
using Random = UnityEngine.Random;

public abstract class EnemyBase : MonoBehaviour {
    public int Health { get; private set; }
    public int Strength { get; private set; }
    public float Speed { get; private set; }

    private Transform _target;
    public GameObject Heart;
    public event Action OnDeath;
    private Animator _animator;


    public void Initialize(Transform target, int health, int strength, float speed) {
       _target = target;
       Health = health;
       Strength = strength;
       Speed = speed;
       _animator = GetComponentInChildren<Animator>();

    }
    
    protected virtual void Update() {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget() {
        if (_target == null) return;

        Vector3 direction = (_target.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
        
        transform.LookAt(new Vector3(_target.position.x, transform.position.y, _target.position.z));
    }
    
    public void TakeDamage(int damage) {
        Health -= damage;
        _animator.SetTrigger("IsEnemyHit");
        if (Health <= 0) Die();
    }
    
    private void Die() {
        OnDeath?.Invoke();
        HandleDeath();
        Destroy(gameObject);
        TryDropHeart();
    }

    private void TryDropHeart() {
        if (Random.value <= 0.33f && Heart != null) {
            Instantiate(Heart, transform.position, Quaternion.identity);
            "El enemigo ha dejado caer un corazón!".LogLevel(Console.Level.Info);
        }
    }

    protected virtual void HandleDeath() {}
    
    
    
}