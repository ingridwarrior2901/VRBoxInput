//
//  VRBoxBridge.m
//  VRBoxBluetoothController
//
//  Created by pc-laptop on 12/3/18.
//  Copyright © 2018 Ingrid Guerrero. All rights reserved.
//

#import <UIKit/UIKit.h>
#include "VRBoxPlugin-Swift.h"

#pragma mark - C interface

extern "C" {
    void _vr_startTrackingBluetoothKey() {
        [[VRBoxManager shared] startCaptureBluetoothKeys];
    }
    
    void _vr_stopTrackingBluetoothKey() {
        [[VRBoxManager shared] stopCaptureBluetoothKeys];
    }
}
