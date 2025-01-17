﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Версия среды выполнения: 17.0.0.0
//  
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Composite
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using AinDevHelperPluginLibrary.Language;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CompositeCSharpProgram : CompositeCSharpProgramBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\n\r\nnamespace AinDevHelperCompositePattern {\r\n    /// <summary>\r\n");
            
            #line 11 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 if (AinDevHelperLanguageCodeConstants.EN.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write(@"    /// Below is an example of implementing the ""Linker"" pattern in C# using the task of organizing files and folders.
    /// In this example, the <see cref=""File"" /> and <see cref=""Folder"" /> classes represent files and folders, respectively. 
    /// The <see cref=""Folder"" /> class can contain both files and other folders. 
    /// The <see cref=""FileSystemItem.Print"" /> method is called recursively for each item, which allows you to display the structure 
    /// of the file system, taking into account nested items.
");
            
            #line 17 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } else if (AinDevHelperLanguageCodeConstants.DE.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write(@"    /// Nachfolgend finden Sie ein Beispiel für die Implementierung des „Linker“-Musters in C# unter Verwendung der Aufgabe, Dateien und Ordner zu organisieren.
    /// In diesem Beispiel stellen die Klassen <see cref=""File"" /> und <see cref=""Folder"" /> Dateien bzw. Ordner dar. Die Klasse <see cref=""Folder"" /> kann sowohl 
    /// Dateien als auch andere Ordner enthalten. 
    /// Die Methode <see cref=""FileSystemItem.Print"" /> wird rekursiv für jedes Element aufgerufen, wodurch Sie die Struktur des Dateisystems unter 
    /// Berücksichtigung verschachtelter Elemente anzeigen können.
");
            
            #line 23 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write(@"    /// Ниже представлен пример реализации паттерна ""Компоновщик"" на языке C# с использованием задачи организации файлов и папок.
    /// В этом примере классы <see cref=""File"" /> и <see cref=""Folder"" /> представляют файлы и папки соответственно. Класс <see cref=""Folder"" /> 
    /// может содержать как файлы, так и другие папки. 
    /// Метод <see cref=""FileSystemItem.Print"" /> вызывается рекурсивно для каждого элемента, что позволяет выводить структуру файловой системы с учетом вложенных элементов.
");
            
            #line 28 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    /// </summary>\r\n    public static class Program {\r\n        public static void" +
                    " Main() {\r\n            Console.WriteLine(\"======================================" +
                    "=======================================\");\r\n");
            
            #line 33 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 if (AinDevHelperLanguageCodeConstants.EN.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"Demonstration of the \\\"Composite\\\" Design Pattern\"" +
                    ");\r\n");
            
            #line 35 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } else if (AinDevHelperLanguageCodeConstants.DE.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"Demonstration der Verwendung des „Composer“-Muster" +
                    "s\");\r\n");
            
            #line 37 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"Демонстрация применения шаблона проектирования \\\"К" +
                    "омпоновщик\\\" (Composite)\");\r\n");
            
            #line 39 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine(\"==================================================" +
                    "===========================\");\r\n    \r\n");
            
            #line 42 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 if (AinDevHelperLanguageCodeConstants.EN.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write("            var root = new Folder(\"Root\");\r\n            var folder1 = new Folder(" +
                    "\"Folder 1\");\r\n            var folder2 = new Folder(\"Folder 2\");\r\n            var" +
                    " file1 = new File(\"File 1.txt\");\r\n            var file2 = new File(\"File 2.txt\")" +
                    ";\r\n");
            
            #line 48 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } else if (AinDevHelperLanguageCodeConstants.DE.Equals(LanguageCode)) { 
            
            #line default
            #line hidden
            this.Write("            var root = new Folder(\"Wurzel\");\r\n            var folder1 = new Folde" +
                    "r(\"Ordner 1\");\r\n            var folder2 = new Folder(\"Ordner 2\");\r\n            v" +
                    "ar file1 = new File(\"Datei 1.txt\");\r\n            var file2 = new File(\"Datei 2.t" +
                    "xt\");\r\n");
            
            #line 54 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("            var root = new Folder(\"Корень\");\r\n            var folder1 = new Folde" +
                    "r(\"Каталог 1\");\r\n            var folder2 = new Folder(\"Каталог 2\");\r\n           " +
                    " var file1 = new File(\"Файл 1.txt\");\r\n            var file2 = new File(\"Файл 2.t" +
                    "xt\");\r\n");
            
            #line 60 "C:\Users\1\source\repos\test\AinDevHelperCorePlugins\CSharpDesignPatternsPlugin\Templates\CSharp\Structural\Composite\CompositeCSharpProgram.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            root.Add(folder1);\r\n            root.Add(folder2);\r\n            folde" +
                    "r1.Add(file1);\r\n            folder2.Add(file2);\r\n\r\n            root.Print(0);   " +
                    " \r\n        }\r\n    }\r\n}");
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
    public class CompositeCSharpProgramBase
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
