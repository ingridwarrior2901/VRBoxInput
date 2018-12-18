
![VRBox Image](https://github.com/ingridwarrior2901/VRBoxInput/blob/master/Assets/VRBoxBluetoothControl/vrbox.jpg?raw=true)

# VRBoxInput
iOS Plugin for Unity to capture VRBox control inputs


# The following steps show how to setup this asset:
1. Make sure that you are using iOS platform in Unity 
2. Move the `Plugins` folder into the assets root.
3. You must have had an Xcode project created, if not, Start a new build and Unity will create a new Xcode project.
4. Open your Xcode project and go to the build settings
5. Find Objective-c Bridging Header and copy and paste the following `Libraries/Plugins/iOS/VRBox/VRBoxBluetoothController-Bridging-Header.h`
6. You will need to change `Objective-c Generated Interface Header Name` to 
`VRBoxPlugin-Swift.h` if you want to keep `Objective-c Generated Interface Header Name` with the Product name, then you will have to change this line `#include "VRBoxPlugin-Swift.h"` in file `VRBoxBridge.mm`  with the product name, example #include `"#includ "MyNewProductName-Swift.h"`
6. Finally, Search Runpath Search Paths, and add this `@executable_path/Frameworks`
