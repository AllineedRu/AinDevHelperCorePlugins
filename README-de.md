# AinDevHelperCorePlugins

* **[Русский]** Вы просматриваете версию данного README на немецком языке. Вы также можете читать данное руководство на других языках.
* **[English]** You are viewing the German version of this README. You can also read this manual in other languages.
* **[Deutsch]** Sie sehen die deutsche Version dieser README-Datei. Sie können dieses Handbuch auch in anderen Sprachen lesen.

[Русский](README-ru.md) | [English](README.md)

## Über das Repository

**AinDevHelperCorePlugins** ist ein Repository, das eine Reihe von Standard-*Kern-Plugins* und Test-Plugins für das AinDevHelper-Programm enthält. *Kernel-Plugins* sind
Plugins, die von AinDevHelper-Entwicklern vorbereitet und mit dem AinDevHelper-Installationspaket geliefert werden.
Wie alle anderen mit dem AinDevHelper-Programm kompatiblen Plugins werden sie mithilfe der Bibliothek **AinDevHelperPluginLibrary** entwickelt
wird außerdem mit dem AinDevHelper-Programm geliefert und stellt die notwendige API für die Interaktion zwischen dem AinDevHelper-Hostprogramm und seinen kompatiblen Plugins bereit.
Test-Plugins sind nicht im Installationspaket des AinDevHelper-Programms enthalten, ihr Code wird jedoch in der Offline-Dokumentation für das AinDevHelper-Programm verwendet
Sie sollen Entwicklern den minimalistischen Testcode von Plugins für AinDevHelper demonstrieren, der in C# und Visual Basic .NET geschrieben ist.

Derzeit umfassen die AinDevHelper-Kern-Plugins die folgenden Plugins:

- **Angular Helper Plugin** – Ein Plugin, das Angular-Entwicklern verschiedene nützliche Aktionen bietet, z. B. das Abrufen von Versionsinformationen
Angular CLI, NPM, Node.js und erleichtert außerdem die Erstellung neuer Anwendungen und Komponenten in Angular. Der Plugin-Code befindet sich im Verzeichnis [AngularHelperPlugin](./AngularHelperPlugin).
- **C# Design Patterns Plugin** – Ein Plugin, das dem Entwickler hilft, schnell Codebeispiele in C# für verschiedene bekannte Designmuster (Patterns) zu generieren. Der Plugin-Code befindet sich im Verzeichnis [CSharpDesignPatternsPlugin](./CSharpDesignPatternsPlugin)
- **React Helper Plugin** – Ein Plugin, das den Entwickler bei verschiedenen Aktionen im Zusammenhang mit der Entwicklung von Anwendungen in React unterstützt. Der Plugin-Code befindet sich im Verzeichnis [ReactHelperPlugin](./ReactHelperPlugin).
- **Tauri Helper Plugin** – Ein Plugin, das den Entwickler bei verschiedenen Aktionen im Zusammenhang mit der Entwicklung von Anwendungen auf Tauri unterstützt. Der Plugin-Code befindet sich im Verzeichnis [TauriHelperPlugin](./TauriHelperPlugin)

Zu den Test-Plugins, die nicht im AinDevHelper-Installationspaket enthalten sind, gehören:
- **Hello World Plugin (C#)** – Plugin im Stil von „Hello, world!“ für AinDevHelper, geschrieben in C#. Der Plugin-Code befindet sich im Verzeichnis [HelloWorldPlugin](./HelloWorldPlugin).
- **Hello World Plugin (Visual Basic .NET)** - Plugin im Stil von „Hello, world!“ für AinDevHelper, geschrieben in Visual Basic .NET. Der Plugin-Code befindet sich im Verzeichnis [VbHelloWorldPlugin](./VbHelloWorldPlugin)