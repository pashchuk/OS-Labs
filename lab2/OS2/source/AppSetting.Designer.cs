﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OS2.source {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class AppSetting : global::System.Configuration.ApplicationSettingsBase {
        
        private static AppSetting defaultInstance = ((AppSetting)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AppSetting())));
        
        public static AppSetting Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int VirtualPageCountMax {
            get {
                return ((int)(this["VirtualPageCountMax"]));
            }
            set {
                this["VirtualPageCountMax"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int VirtualMemory {
            get {
                return ((int)(this["VirtualMemory"]));
            }
            set {
                this["VirtualMemory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PhysicMemory {
            get {
                return ((int)(this["PhysicMemory"]));
            }
            set {
                this["PhysicMemory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int GenerateProcessTimeLimit {
            get {
                return ((int)(this["GenerateProcessTimeLimit"]));
            }
            set {
                this["GenerateProcessTimeLimit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ReadDataTimeLimit {
            get {
                return ((int)(this["ReadDataTimeLimit"]));
            }
            set {
                this["ReadDataTimeLimit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ProcessExpirationTimeLimit {
            get {
                return ((int)(this["ProcessExpirationTimeLimit"]));
            }
            set {
                this["ProcessExpirationTimeLimit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int SimulationTimeLimit {
            get {
                return ((int)(this["SimulationTimeLimit"]));
            }
            set {
                this["SimulationTimeLimit"] = value;
            }
        }
    }
}
