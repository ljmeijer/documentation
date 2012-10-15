/*
using UnityEngine;
using System.Collections;

public class JointDriveDeclaration : MonoBehaviour {
    void Start() {
        ConfigurableJoint joint = gameObject.AddComponent<ConfigurableJoint>();
        joint.targetPosition = new Vector3(0, 0, -10);
        JointDrive drive = new JointDrive();
        drive.mode = JointDriveMode.Position;
        drive.positionSpring = 100;
        joint.zDrive = drive;
    }
}
*/
/*
import UnityEngine
import System.Collections

class JointDriveDeclaration(MonoBehaviour):

	def Start():
		joint as ConfigurableJoint = gameObject.AddComponent[of ConfigurableJoint]()
		joint.targetPosition = Vector3(0, 0, -10)
		drive as JointDrive = JointDrive()
		drive.mode = JointDriveMode.Position
		drive.positionSpring = 100
		joint.zDrive = drive
*/
function Start() {
	var joint : ConfigurableJoint = gameObject.AddComponent(ConfigurableJoint);
	joint.targetPosition = Vector3(0,0,-10);
	
	var drive : JointDrive = JointDrive();
	drive.mode = JointDriveMode.Position;
	drive.positionSpring = 100;
	joint.zDrive = drive;
}
