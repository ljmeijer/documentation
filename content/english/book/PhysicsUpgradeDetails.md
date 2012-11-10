Physics upgrade details
=======================

For Unity 3.0, we upgraded the NVIDIA PhysX library from version 2.6 to 2.8.3, to give you access to many new features. Generally for existing projects, the behavior should be roughly the same as in Unity 2.x, but there may be slight differences in the outcome of physics simulation, so if your content depends on the exact behavior or on chain reactions of physical events, you may have to re-tweak your setup to work as expected in Unity 3.x.

If you are using [Configurable Joints](class-ConfigurableJoint.md), the JointDrive.maximumForce property will now also be taken into consideration when JointDrive.mode is JointDriveMode.Position. If you have set this value to the default value of zero, the joint will not apply any forces. We will automatically change all JointDrive properties imported from old versions if JointDrive.mode is JointDriveMode.Position, but when you set up a joint from code, you may have to manually change this. Also, note that we have changed the default value for JointDrive.maximumForce to infinity.
