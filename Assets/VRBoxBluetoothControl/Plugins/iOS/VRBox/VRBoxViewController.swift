//
//  ViewController.swift
//  VRBoxBluetoothController
//
//  Created by pc-laptop on 12/3/18.
//  Copyright © 2018 Ingrid Guerrero. All rights reserved.
//

import UIKit

@objc public class VRBoxViewController: UIViewController {
    
    // MARK: - Properties
    
    var bluetoohCaptureCommands: [UIKeyCommand]?
    
    override public var keyCommands: [UIKeyCommand]? {
        return bluetoohCaptureCommands
    }

    let keyActionCommands = [
        UIKeyCommand(input: " ", modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: "\\b", modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: "\t", modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: "\r", modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: UIKeyCommand.inputUpArrow, modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: UIKeyCommand.inputDownArrow, modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: UIKeyCommand.inputLeftArrow, modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: UIKeyCommand.inputRightArrow, modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured),
        UIKeyCommand(input: UIKeyCommand.inputEscape, modifierFlags: Constants.keyModifierFlag, action: Selector.keyCaptured)
    ]
    
    // MARK: - Init
    
    init() {
        super.init(nibName: nil, bundle: nil)
        view.frame = CGRect.zero
        inputView?.frame = CGRect.zero
        view.backgroundColor = .clear
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    // MARK: lifecycle
    
    override public func viewDidLoad() {
        super.viewDidLoad()
        let characterCommands = Constants.characters.compactMap({ UIKeyCommand(input: String($0), modifierFlags: [], action: Selector.keyCaptured) })
        bluetoohCaptureCommands = characterCommands + keyActionCommands
    }
    
    public override func viewDidAppear(_ animated: Bool) {
        becomeFirstResponder()
    }
    
    @available(iOS 9.0, *)
    public override func shouldUpdateFocus(in context: UIFocusUpdateContext) -> Bool {
        return false
    }
    
    // MARK: public methods
    
    public override var canBecomeFirstResponder: Bool {
        return true
    }
    
    // MARK: Selectors
    @objc func handleInput(sender: UIKeyCommand) {
        let selectedTab = sender.input
        UnitySendMessage(Constants.Unity.gameObjectName, Constants.Unity.methodName, selectedTab)
    }
}


// MARK: extensions

fileprivate extension Selector {
    static let keyCaptured = #selector(VRBoxViewController.handleInput)
}

fileprivate extension VRBoxViewController {
    struct Constants {
        static let characters = "`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./"
        static let keyModifierFlag = UIKeyModifierFlags.init(rawValue: 0)
        struct Unity {
            static let gameObjectName = "VRBoxBluetoothController"
            static let methodName = "VRBoxInputHandler"
        }
    }
}
