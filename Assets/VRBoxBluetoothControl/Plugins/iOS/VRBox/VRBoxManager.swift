//
//  VRBoxManager.swift
//  VRBoxBluetoothController
//
//  Created by pc-laptop on 12/3/18.
//  Copyright © 2018 Ingrid Guerrero. All rights reserved.
//

import UIKit

@objc public class VRBoxManager: NSObject {
    
    // MARK: - Properties
    
    @objc static let shared = VRBoxManager()
    
    var vrBoxViewController: VRBoxViewController?
    
    // MARK: - Init
    
    private override init() {
        vrBoxViewController = VRBoxViewController()
    }
    
    // MARK: - Public methods
    
    @objc public func startCaptureBluetoothKeys() {
        guard let unityViewController = UnityGetGLViewController(),
            let vrBoxViewController = vrBoxViewController,
            !unityViewController.view.subviews.contains(vrBoxViewController.view) else { return }
        unityViewController.view.addSubview(vrBoxViewController.view)
    }
    
    @objc public func stopCaptureBluetoothKeys() {
        guard let vrBoxViewController = vrBoxViewController else { return }
        vrBoxViewController.view.removeFromSuperview()
    }
}
