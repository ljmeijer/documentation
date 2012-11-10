Working with humanoid animations
================================


The Mecanim Animation System is particularly well suited for working with animations for humanoid skeletons. Since humanoid skeletons are a very common special case and are used extensively in games, Unity provides a specialized workflow, and an extended tool set for humanoid animations. 

Because of the similarity in bone structure, it is possible to map animations from one humanoid skeleton to another, allowing <span class=keyword>retargeting</span> and <span class=keyword>inverse kinematics</span>
With rare exceptions, humanoid models can be expected to have the same basic structure, representing the major articulate parts of the body, head and limbs. The Mecanim system makes good use of this idea to simplify the rigging and control of animations. A fundamental step in creating a animation is to set up a mapping between the simplified humanoid bone structure understood by Mecanim and the actual bones present in the skeleton; in Mecanim terminology, this mapping is called an <span class=keyword>Avatar</span>. The pages in this section explain how to create an Avatar for your model. 

(:tocportion:)
