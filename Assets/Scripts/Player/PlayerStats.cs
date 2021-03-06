using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class PlayerStats : MonoBehaviour
{
    [Range(1f, 10f)]
    public float meltSpeed = 1f;

    [Range(1f, 20f)]
    public float meltJumpModifier = 1f;

    public bool isMelted = false;

    private float _initialMeltSpeed;
    private float _initialJumpHeight;
    private float _initialDashPower;
    private PlayerController playerController;
    private SpriteRenderer playerSprite;

    void Awake()
    {
        meltSpeed = meltSpeed * 0.0001f;
        _initialMeltSpeed = meltSpeed;
    }

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        _initialJumpHeight = Mathf.Round(playerController.jumpHeight);
        _initialDashPower = Mathf.Round(playerController.dashPower);
    }

    void Update()
    {
        if (!isMelted) Melt();
    }

    public void Melt()
    {
        transform.localScale -= new Vector3(meltSpeed, meltSpeed, meltSpeed);
        playerController.jumpHeight = playerController.jumpHeight - meltSpeed * meltJumpModifier;
        playerController.dashPower = playerController.dashPower - meltSpeed * meltJumpModifier * 4f;
        CheckIfMelted();
    }

    void CheckIfMelted()
    {
        if (transform.localScale.x < 0.15 || playerController.jumpHeight < 0.15)
        {
            isMelted = true;
        }

        else isMelted = false;
    }

    public void Heal()
    {
        ResetMelt();
        ResetScale();
        ResetController();
    }

    public void ResetMelt()
    {
        meltSpeed = _initialMeltSpeed;
    }

    void ResetScale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 3f);
    }

    void ResetController()
    {
        playerController.jumpHeight = _initialJumpHeight;
        playerController.dashPower = _initialDashPower;
    }
}
