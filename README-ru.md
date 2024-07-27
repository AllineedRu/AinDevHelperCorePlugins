# AinDevHelperCorePlugins

![.NET worflow status badge](https://github.com/AllineedRu/AinDevHelperPluginLibrary/actions/workflows/dotnet.yml/badge.svg?branch=master)
![version Pre-Alpha](https://img.shields.io/badge/version-Pre--Alpha-red)

* **[Русский]** Вы просматриваете версию данного README на русском языке. Вы также можете читать данное руководство на других языках.
* **[English]** You are viewing the Russian version of this README. You can also read this manual in other languages.
* **[Deutsch]** Sie sehen sich die russische Version dieser README-Datei an. Sie können dieses Handbuch auch in anderen Sprachen lesen.

[English](README.md) | [Deutsch](README-de.md)

## О репозитории

**AinDevHelperCorePlugins** - это репозиторий, содержащий набор стандартных *плагинов ядра* и тестовых плагинов для программы AinDevHelper. *Плагины ядра* - это
плагины, которые подготовлены разработчиками AinDevHelper и поставляются вместе с установочным пакетом AinDevHelper. 
Как и любые другие плагины, совместимые с программой AinDevHelper, они разработаны с использованием библиотеки **AinDevHelperPluginLibrary**, которая 
также поставляется вместе с программой AinDevHelper и обеспечивает необходимый API для взаимодействия программы-хоста AinDevHelper и совместимых с ней плагинов.
Тестовые плагины не входят в установочный пакет программы AinDevHelper, однако их код используется в оффлайн-документации на программу AinDevHelper, и 
они призваны продемонстрировать разработчикам тестовый минималистичный код плагинов для AinDevHelper, написанных на языках C# и Visual Basic .NET.

На текущий момент в состав плагинов ядра AinDevHelper входят следующие плагины:

- **Angular Helper Plugin** - Плагин, предоставляющий разработчикам на Angular различные полезные действия, такие как получение информации о версиях
Angular CLI, NPM, Node.js, а также облегчающий создание новых приложений и компонентов на Angular. Код плагина Вы найдете в каталоге [AngularHelperPlugin](./AngularHelperPlugin)
- **C# Design Patterns Plugin** - Плагин, который помогает разработчику быстро генерировать примеры кода на языке C# для различных известных шаблонов проектирования (паттернов). Код плагина Вы найдете в каталоге [CSharpDesignPatternsPlugin](./CSharpDesignPatternsPlugin)
- **React Helper Plugin** - Плагин, помогающий разработчику с выполнением различных действий, связанных с разработкой приложений на React. Код плагина Вы найдете в каталоге [ReactHelperPlugin](./ReactHelperPlugin)
- **Tauri Helper Plugin** - Плагин, помогающий разработчику с выполнением различных действий, связанных с разработкой приложений на Tauri. Код плагина Вы найдете в каталоге [TauriHelperPlugin](./TauriHelperPlugin)

К тестовым плагинам, которые не входят в установочный пакет AinDevHelper, относятся:
- **Hello World Plugin (C#)** - плагин в стиле "Здравствуй, мир!" для AinDevHelper, написанный на языке C#. Код плагина Вы найдете в каталоге [HelloWorldPlugin](./HelloWorldPlugin)
- **Hello World Plugin (Visual Basic .NET)** - плагин в стиле "Здравствуй, мир!" для AinDevHelper, написанный на языке Visual Basic .NET. Код плагина Вы найдете в каталоге [VbHelloWorldPlugin](./VbHelloWorldPlugin)

## Схема взаимодействия и принцип работы

Ниже схематично представлен основной принцип работы и взаимодействия трёх типов компонентов, представленных на диаграмме:

* *Приложение **AinDevHelper***, которое выступает в роли *хоста* для совместимых с ним плагинов
* *Библиотека **AinDevHelperPluginLibrary***, выступающая в роли своеобразного "моста" между *хостом* и поддерживаемыми плагинами. Взаимодействие между хостом и плагинами осуществляется посредством общего API, которое использует как хост, так и плагины.
* *Набор плагинов*, поддерживаемых приложением AinDevHelper и совместимых с ним, - за счёт реализации API, предоставляемого библиотекой AinDevHelperPluginLibrary


![Принцип работы библиотеки](docs/images/principle-of-work-1-ru.drawio.png)