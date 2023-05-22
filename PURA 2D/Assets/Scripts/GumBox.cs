using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumBox : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField]
    Transform[] covers;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Finish()
    {
        foreach (var item in covers)
        {
            item.Rotate(-Vector3.forward * 25);
        }
        ps.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Finish();
        }
    }
}
