# AinDevHelperCorePlugins

* **[Русский]** Вы просматриваете версию данного README на английском языке. Вы также можете читать данное руководство на других языках.
* **[English]** You are viewing the English version of this README. You can also read this manual in other languages.
* **[Deutsch]** Sie sehen sich die englische Version dieser README-Datei an. Sie können dieses Handbuch auch in anderen Sprachen lesen.

[Русский](README-ru.md) | [English](README.md)

# About Repository
<div align="justify">
**AinDevHelperCorePlugins** is a repository containing a set of standard *core plugins* and test plugins for the AinDevHelper program. *Core plugins* are 
plugins that are prepared by the AinDevHelper developers and are supplied with the AinDevHelper installation package. 
Like any other plugins compatible with the AinDevHelper program, they are developed using the **AinDevHelperPluginLibrary** library, which 
also comes with the AinDevHelper program and provides the necessary API for interaction between the AinDevHelper host program and compatible plugins. 
Test plugins are not included in the AinDevHelper installation package, but their code is used in the offline documentation for the AinDevHelper program, 
and they are intended to demonstrate to developers the test minimalistic code of plugins for AinDevHelper, written in C# and Visual Basic .NET.
</div>

<div align="justify">
Currently, the AinDevHelper core plugins include the following plugins:
- **Angular Helper Plugin** - A plugin that provides Angular developers with various useful actions, such as getting information about versions of
Angular CLI, NPM, Node.js, and also facilitating the creation of new applications and components on Angular. You will find the plugin code in the [AngularHelperPlugin](./AngularHelperPlugin) directory
- **C# Design Patterns Plugin** - A plugin that helps the developer quickly generate code samples in C# for various well-known design patterns. You will find the plugin code in the [CSharpDesignPatternsPlugin](./CSharpDesignPatternsPlugin) directory
- **React Helper Plugin** - A plugin that helps the developer with various actions related to the development of applications on React. You will find the plugin code in the [ReactHelperPlugin](./ReactHelperPlugin) directory
- **Tauri Helper Plugin** - A plugin that helps the developer with various actions related to developing applications on Tauri. You will find the plugin code in the [TauriHelperPlugin](./TauriHelperPlugin) directory
</div>

<div align="justify">
Test plugins that are not included in the AinDevHelper installation package include:
- **Hello World Plugin (C#)** - a "Hello, World!" style plugin for AinDevHelper written in C#. You will find the plugin code in the [HelloWorldPlugin](./HelloWorldPlugin) directory
- **Hello World Plugin (Visual Basic .NET)** - a "Hello, World!" style plugin for AinDevHelper written in Visual Basic .NET. You will find the plugin code in the [VbHelloWorldPlugin](./VbHelloWorldPlugin) directory
</div>