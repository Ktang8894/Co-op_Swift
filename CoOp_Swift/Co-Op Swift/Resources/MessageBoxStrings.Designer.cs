﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Co_Op_Swift.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MessageBoxStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageBoxStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Co_Op_Swift.Resources.MessageBoxStrings", typeof(MessageBoxStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End Date cannot be before Start Date.
        /// </summary>
        internal static string EndDateBeforeStartDate {
            get {
                return ResourceManager.GetString("EndDateBeforeStartDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ERROR.
        /// </summary>
        internal static string ERROR {
            get {
                return ResourceManager.GetString("ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ExecuteActionQuery failed to execute query.
        /// </summary>
        internal static string FailedToExecuteActionQuery {
            get {
                return ResourceManager.GetString("FailedToExecuteActionQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not a valid start/end date.
        /// </summary>
        internal static string InvalidStartEndDate {
            get {
                return ResourceManager.GetString("InvalidStartEndDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not an owner. Cannot edit..
        /// </summary>
        internal static string NotOwner {
            get {
                return ResourceManager.GetString("NotOwner", resourceCulture);
            }
        }
    }
}