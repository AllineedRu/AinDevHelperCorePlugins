﻿/*
Copyright 2024 Allineed.Ru, Max Damascus

Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
and associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Версия среды выполнения: 17.0.0.0
//  
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Adapter
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using AinDevHelperPluginLibrary.Language;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class AdapterCSharpProgram : AdapterCSharpProgramBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\n\r\nnamespace AinDevHelperAdapterPattern {\r\n    /// <summary>\r\n");
            
            #line 11 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 if (AinDevHelperLanguageCodeConstants.EN.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write(@"    /// This program provides sample code in C# demonstrating the use of the Adapter pattern to transform an interface 
    /// of one class to the interface of another class. For example, let's take a situation where we have a third-party library that provides functionality 
    /// work with different input devices and we want to use this library in our project, but we already have our own interface 
    /// for working with input devices.
    ///
    /// In this example, the <see cref=""ThirdPartyInputDevice"" /> class represents a third-party library, <see cref=""IInputDevice"" /> is an interface in our project, 
    /// and <see cref=""InputDeviceAdapter"" /> is an adapter that allows you to use the functionality of a third-party library through our interface. 
    /// The adapter allows us to encapsulate the logic for converting method calls from our interface into calls to methods of a third-party library.
");
            
            #line 20 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 } else if (AinDevHelperLanguageCodeConstants.DE.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write(@"    /// Dieses Programm stellt Beispielcode in C# bereit, der die Verwendung des Adaptermusters zum Transformieren einer Schnittstelle demonstriert 
    /// einer Klasse an die Schnittstelle einer anderen Klasse. Nehmen wir zum Beispiel eine Situation an, in der wir über eine Bibliothek eines Drittanbieters verfügen, die Funktionalität bereitstellt 
    /// Wir arbeiten mit verschiedenen Eingabegeräten und möchten diese Bibliothek in unserem Projekt verwenden, verfügen jedoch bereits über eine eigene Schnittstelle 
    /// für die Arbeit mit Eingabegeräten.
    ///
    /// In diesem Beispiel stellt die Klasse <see cref=""ThirdPartyInputDevice"" /> eine Bibliothek eines Drittanbieters dar, <see cref=""IInputDevice"" /> ist eine Schnittstelle in unserem Projekt. 
    /// und <see cref=""InputDeviceAdapter"" /> ist ein Adapter, der es Ihnen ermöglicht, die Funktionalität einer Drittanbieter-Bibliothek über unsere Schnittstelle zu nutzen. 
    /// Mit dem Adapter können wir die Logik zum Konvertieren von Methodenaufrufen von unserer Schnittstelle in Aufrufe von Methoden einer Drittanbieterbibliothek kapseln.
");
            
            #line 29 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write(@"    /// В этой программе представлен пример кода на C#, демонстрирующий использование паттерна ""Адаптер"" (Adapter) для преобразования интерфейса 
    /// одного класса в интерфейс другого класса. Для примера возьмем ситуацию, когда у нас есть сторонняя библиотека, предоставляющая функциональность 
    /// работы с различными устройствами ввода, и мы хотим использовать эту библиотеку в нашем проекте, но у нас уже есть свой собственный интерфейс 
    /// для работы с устройствами ввода.
    ///
    /// В этом примере класс <see cref=""ThirdPartyInputDevice"" /> представляет стороннюю библиотеку, <see cref=""IInputDevice"" /> - интерфейс в нашем проекте, 
    /// а <see cref=""InputDeviceAdapter"" /> - адаптер, который позволяет использовать функциональность сторонней библиотеки через наш интерфейс. 
    /// Адаптер позволяет инкапсулировать логику преобразования вызовов методов из нашего интерфейса в вызовы методов сторонней библиотеки.
");
            
            #line 38 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    /// </summary>\r\n    public static class Program {\r\n        public static void" +
                    " Main() {\r\n            Console.WriteLine(\"======================================" +
                    "=======================================\");\r\n");
            
            #line 43 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 if (AinDevHelperLanguageCodeConstants.EN.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"Demonstration of the \\\"Adapter\\\" Design Pattern\");" +
                    "\r\n");
            
            #line 45 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 } else if (AinDevHelperLanguageCodeConstants.DE.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"Demonstration des „Adapter“-Musters\");\r\n");
            
            #line 47 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"Демонстрация применения шаблона проектирования \\\"А" +
                    "даптер\\\" (Adapter)\");\r\n");
            
            #line 49 "C:\Users\1\source\repos\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Adapter\AdapterCSharpProgram.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"            Console.WriteLine(""============================================================================="");

            ThirdPartyInputDevice thirdPartyDevice = new ThirdPartyInputDevice();
            InputDeviceAdapter adapter = new InputDeviceAdapter(thirdPartyDevice);

            adapter.Connect();
            adapter.Disconnect();
        }
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class AdapterCSharpProgramBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}