Creating an Impression of Large or Small Size
=============================================


From the graphical point of view, the units of distance in Unity are arbitrary and don't correspond to real world measurements. Although this gives flexibility and convenience for design, it is not always easy to convey the intended size of the object. For example, a toy car looks different to a full size car even though it may be an accurate scale model of the real thing.

A major element in the impression of an object's size is the way the perspective changes over the object's length. For example, if a toy car is viewed from behind then the front of the car will only be a short distance farther away than the back. Since the distance is small, perspective will have relatively little effect and so the front will appear little different in size to the back. With a full size car, however, the front will be several metres farther away from the camera than the back and the effect of perspective will be much more noticeable.

For an object to appear small, the lines of perspective should diverge only very slightly over its depth. You can achieve this by using a narrower field of view than the default 60º and moving the camera farther away to compensate for the increased onscreen size. Conversely, if you want to make an object look big, use a wide FOV and move the camera in close. When these perspective alterations are used with other obvious techniques (like looking down at a "small" object from higher-than-normal vantage point) the result can be quite convincing.
