using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScroll : MonoBehaviour
{
    [SerializeField] float _speed;
    Material _material;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        _material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = _material.mainTextureOffset;
        offset.y += _speed * Time.deltaTime;
        if (offset.y > 1f)
        {
            offset.y -= 1f;
        }
        _material.mainTextureOffset = offset;
    }
}
