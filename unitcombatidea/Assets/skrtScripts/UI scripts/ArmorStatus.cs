using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorStatus : MonoBehaviour
{
    public MechStatusHolder msh;
    public Image head;
    public Image torso;
    public Image leftArm;
    public Image rightArm;
    public Image leftLeg;
    public Image rightLeg;
    public Image leftArmArmor;
    public Image rightArmArmor;
    public Image leftLegArmor;
    public Image rightLegArmor;
    public Gradient leftArm2;
    public Gradient rightArm2;
    public Gradient leftLeg2;
    public Gradient rightLeg2;
    public Gradient leftArmArmor2;
    public Gradient rightArmArmor2;
    public Gradient leftLegArmor2;
    public Gradient rightLegArmor2;
    public Gradient head2;
    public Gradient torso2;
    // Start is called before the first frame update
    void Start()
    {
        head.color = head2.Evaluate(msh.headHp / msh.headMaxHp);
        torso.color = torso2.Evaluate(msh.torsoHp / msh.torsoMaxHp );
        leftArm.color = leftArm2.Evaluate(msh.leftArmHp / msh.leftArmMaxHp);
        rightArm.color = rightArm2.Evaluate(msh.rightArmHp / msh.rightArmMaxHp);
        leftLeg.color = leftLeg2.Evaluate(msh.leftLegHp / msh.leftLegMaxHp);
        rightLeg.color = rightLeg2.Evaluate(msh.rightLegHp / msh.rightLegMaxHp);
        leftArmArmor.color = leftArmArmor2.Evaluate(msh.leftArmArmorCount / msh.leftArmArmorMax);
        rightArmArmor.color = rightArmArmor2.Evaluate(msh.rightArmArmorCount / msh.rightArmArmorMax);
        leftLegArmor.color = leftArmArmor2.Evaluate(msh.leftLegArmorCount / msh.leftLegArmorMax);
        rightLegArmor.color = rightLegArmor2.Evaluate(msh.rightLegArmorCount / msh.rightLegArmorMax);
    }

    // Update is called once per frame
    public void updateArmorStatus()
    {
        head.color = head2.Evaluate(msh.headHp / msh.headMaxHp);
        torso.color = torso2.Evaluate(msh.torsoHp / msh.torsoMaxHp );
        leftArm.color = leftArm2.Evaluate(msh.leftArmHp / msh.leftArmMaxHp);
        rightArm.color = rightArm2.Evaluate(msh.rightArmHp / msh.rightArmMaxHp);
        leftLeg.color = leftLeg2.Evaluate(msh.leftLegHp / msh.leftLegMaxHp);
        rightLeg.color = rightLeg2.Evaluate(msh.rightLegHp / msh.rightLegMaxHp);
        leftArmArmor.color = leftArmArmor2.Evaluate(msh.leftArmArmorCount / msh.leftArmArmorMax);
        rightArmArmor.color = rightArmArmor2.Evaluate(msh.rightArmArmorCount / msh.rightArmArmorMax);
        leftLegArmor.color = leftArmArmor2.Evaluate(msh.leftLegArmorCount / msh.leftLegArmorMax);
        rightLegArmor.color = rightLegArmor2.Evaluate(msh.rightLegArmorCount / msh.rightLegArmorMax);
    }
}
