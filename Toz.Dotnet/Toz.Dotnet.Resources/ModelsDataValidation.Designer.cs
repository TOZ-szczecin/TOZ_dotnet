﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Toz.Dotnet.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   Klasa zasobu wymagająca zdefiniowania typu do wyszukiwania zlokalizowanych ciągów itd.
    /// </summary>
    // Ta klasa została automatycznie wygenerowana za pomocą klasy StronglyTypedResourceBuilder
    // przez narzędzie, takie jak ResGen lub Visual Studio.
    // Aby dodać lub usunąć członka, edytuj plik .ResX, a następnie ponownie uruchom ResGen
    // z opcją /str lub ponownie utwórz projekt VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ModelsDataValidation {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ModelsDataValidation() {
        }
        
        /// <summary>
        /// Zwraca buforowane wystąpienie ResourceManager używane przez tę klasę.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Toz.Dotnet.Resources.ModelsDataValidation", typeof(ModelsDataValidation).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Przesłania właściwość CurrentUICulture bieżącego wątku dla wszystkich
        ///   przypadków przeszukiwania zasobów za pomocą tej klasy zasobów wymagającej zdefiniowania typu.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu Bank account number must be exactly 26 digits.
        /// </summary>
        public static string BankAccountLength {
            get {
                return ResourceManager.GetString("BankAccountLength", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu Bank account number is invaild.
        /// </summary>
        public static string BankAccountValidationMessage {
            get {
                return ResourceManager.GetString("BankAccountValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu Invalid Email Address.
        /// </summary>
        public static string EmailValidationMessage {
            get {
                return ResourceManager.GetString("EmailValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu You can&apos;t leave this empty..
        /// </summary>
        public static string EmptyField {
            get {
                return ResourceManager.GetString("EmptyField", resourceCulture);
            }
        }
        
        /// <summary>
<<<<<<< HEAD
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu The firstname can only consist of letters..
=======
        ///   Looks up a localized string similar to Invalid phone number.
        /// </summary>
        public static string InvaildPhoneNumber {
            get {
                return ResourceManager.GetString("InvaildPhoneNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum length is {1} characters..
>>>>>>> 5a4a5ae07cc9e64e9ea10897094f2e508fb1f9cb
        /// </summary>
        public static string FirstnameLetters {
            get {
                return ResourceManager.GetString("FirstnameLetters", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu The surname can only consist of letters..
        /// </summary>
        public static string LastnameLetters {
            get {
                return ResourceManager.GetString("LastnameLetters", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu The maximum length is {1} characters..
        /// </summary>
        public static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu This field can only consist of digits..
        /// </summary>
        public static string OnlyDigits {
            get {
                return ResourceManager.GetString("OnlyDigits", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu Select a pet sex..
        /// </summary>
        public static string PetSexUndefined {
            get {
                return ResourceManager.GetString("PetSexUndefined", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu Select a pet type..
        /// </summary>
        public static string PetTypeUndefined {
            get {
                return ResourceManager.GetString("PetTypeUndefined", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu Select a user type..
        /// </summary>
        public static string TypeUndefined {
            get {
                return ResourceManager.GetString("TypeUndefined", resourceCulture);
            }
        }
    }
}
