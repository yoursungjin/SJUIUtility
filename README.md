# SJUIUtility for Unity3D
UI Utility for seamlessly concatenated transition in Unity3D <br>
<br>
Click the image below to play the demo video.<br>
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/aevJOaQ7XhM/0.jpg)](https://youtu.be/aevJOaQ7XhM)

## Background
It is for when you want GUI groups to transition in a seamlessly concatenated way.<br>
![image](ScreenCapture/UI%20hierarchy.png)

## How to use
```
using YourSungjin.UI;

SJUIUtility.ShowUI (this, groupA, false, 0, .5f, delegate() {
	SJUIUtility.ShowUI (this, groupB, true, 0, .5f, delegate() {
		SJUIUtility.ShowUI (this, groupC, true, 0, .5f); 
	});
});
```

## Author
Sungjin Lee<br> 
sungjinlee0417@gmail.com
