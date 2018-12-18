The following steps show how to setup the asset:
1. Make sure to use iOS platform and move the Plugins folder to the assets root.
2. You must have had an Xcode project created, if not, Start a new build so Unity creates the Xcode project.
3. Open your Xcode project and go to the build settings
4. Find Objective-c Bridging Header and copy and paste the following `Libraries/Plugins/iOS/VRBox/VRBoxBluetoothController-Bridging-Header.h`
5. you will need to  change Objective-c Generated Interface Header Name to 
`VRBoxPlugin-Swift.h` if you want to keep Objective-c Generated Interface Header Name with the name of the Product name, then you will have to change `VRBoxBridge.mm` this line `#include "VRBoxPlugin-Swift.h"` with the product name, example #include `"#includ "MyNewProductName-Swift.h"`
6. Finally, Search Runpath Search Paths, and add this `@executable_path/Frameworks`
