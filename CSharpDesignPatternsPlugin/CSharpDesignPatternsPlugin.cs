/*
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
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using AinDevHelperPluginLibrary;
using AinDevHelperPluginLibrary.Actions;
using AinDevHelperPluginLibrary.Language;
using static AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants;
using static AinDevHelperPluginLibrary.Actions.AinDevHelperPluginActionCoreTagsConstants;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Visitor;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.ChainOfResponsibility;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Command;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.TemplateMethod;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.NullObject;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Strategy;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Observer;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.State;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Memento;
using CSharpDesignPatternsPlugin.Templates.CSharp.Techniques.MethodCascading;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Mediator;
using CSharpDesignPatternsPlugin.Templates.CSharp.Behavioral.Iterator;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.AbstractFactory;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.Builder;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.FactoryMethod;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.NotThreadSafeSingleton;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.ThreadSafeSingleton;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.ObjectPool;
using CSharpDesignPatternsPlugin.Templates.CSharp.Creational.Prototype;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Adapter;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Decorator;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Composite;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Flyweight;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Proxy;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Router;
using CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Facade;

namespace CSharpDesignPatternsPlugin {
    /// <summary>
    /// [RU] Плагин для программы AinDevHelper, который умеет генерировать проекты на C# с примерами известных шаблонов проектирования (Design Patterns)<br/>
    /// [EN] Plugin for the AinDevHelper program, which can generate projects in C# with examples of well-known Design Patterns
    /// </summary>
    public class CSharpDesignPatternsPlugin : StandardAinDevHelperPlugin {
        /// <summary>
        /// [RU] Название директории, в которую плагин генерирует код проектов-примеров с шаблонами проектирования на языке C#<br/>
        /// [EN] The name of the directory into which the plugin generates code for example projects with design patterns in C#
        /// </summary>
        public const string GENERATED_DIRECTORY_NAME = "generated";

        // =======================================================================================================================
        // [RU] Имена поддерживаемых плагином действий
        // [EN] Names of actions supported by this plugin
        // =======================================================================================================================
        public const string RU_ACTION_CLEAN_GENERATED_DIRECTORY = "Очистить каталог '" + GENERATED_DIRECTORY_NAME + "' плагина";
        public const string EN_ACTION_CLEAN_GENERATED_DIRECTORY = "Clear plugin '" + GENERATED_DIRECTORY_NAME + "' directory";
        public const string DE_ACTION_CLEAN_GENERATED_DIRECTORY = "'" + GENERATED_DIRECTORY_NAME + "' Plugin-Verzeichnis löschen";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Посетитель' (Visitor)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN = "[Behavioral] Generate 'Visitor' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Besucher“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Цепочка обязанностей' (Chain Of Responsibility)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN = "[Behavioral] Generate 'Chain Of Responsibility' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Chain of Responsibility“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Команда' (Chain Of Responsibility)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN = "[Behavioral] Generate 'Command' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN = "[Verhaltensmuster] Generieren Sie ein Befehlsmuster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Шаблонный метод' (Template Method)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN = "[Behavioral] Generate 'Template Method' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN = "[Verhaltensmuster] Generieren Sie das Muster „Vorlagenmethode“";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Нулевой объект' (Null Object)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN = "[Behavioral] Generate 'Null Object' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Nullobjekt“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Стратегия' (Strategy)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN = "[Behavioral] Generate 'Strategy' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Strategie“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Наблюдатель' (Observer)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN = "[Behavioral] Generate 'Observer' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Observer“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Состояние' (State)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN = "[Behavioral] Generate 'State' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Status“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Хранитель' (Memento)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN = "[Behavioral] Generate 'Memento' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Memento“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Посредник' (Mediator)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN = "[Behavioral] Generate 'Mediator' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Mediator“-Muster";

        public const string RU_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN = "[Поведенческие] Сгенерировать шаблон 'Итератор' (Iterator)";
        public const string EN_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN = "[Behavioral] Generate 'Iterator' Pattern";
        public const string DE_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN = "[Verhaltensmuster] Generieren Sie ein „Iterator“-Muster";

        public const string RU_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN = "[Порождающие] Сгенерировать шаблон 'Абстрактная фабрика' (Abstract Factory)";
        public const string EN_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN = "[Creational] Generate 'Abstract Factory' Pattern";
        public const string DE_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN = "[Schöpfungsmuster] Generieren Sie das Muster „Abstrakte Fabrik“";

        public const string RU_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN = "[Порождающие] Сгенерировать шаблон 'Строитель' (Builder)";
        public const string EN_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN = "[Creational] Generate 'Builder' Pattern";
        public const string DE_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN = "[Schöpfungsmuster] Generieren Sie ein „Builder“-Muster";

        public const string RU_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN = "[Порождающие] Сгенерировать шаблон 'Фабричный метод' (Factory Method)";
        public const string EN_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN = "[Creational] Generate 'Factory Method' Pattern";
        public const string DE_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN = "[Schöpfungsmuster] Generieren Sie ein „Factory-Methode“-Muster";

        public const string RU_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN = "[Порождающие] Сгенерировать шаблон 'Одиночка' (Singleton) - не потокобезопасный";
        public const string EN_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN = "[Creational] Generate 'Singleton' Pattern - not thread-safe";
        public const string DE_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN = "[Schöpfungsmuster] „Singleton“-Muster generieren – nicht Thread-sicher";

        public const string RU_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN = "[Порождающие] Сгенерировать шаблон 'Одиночка' (Singleton) - потокобезопасный";
        public const string EN_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN = "[Creational] Generate 'Singleton' Pattern - thread-safe";
        public const string DE_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN = "[Schöpfungsmuster] „Singleton“-Muster generieren – Thread-sicher";

        public const string RU_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN = "[Порождающие] Сгенерировать шаблон 'Пул объектов' (Object Pool)";
        public const string EN_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN = "[Creational] Generate 'Object Pool' Pattern";
        public const string DE_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN = "[Schöpfungsmuster] Generieren Sie ein „Objektpool“-Muster";

        public const string RU_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN = "[Порождающие] Сгенерировать шаблон 'Прототип' (Prototype)";
        public const string EN_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN = "[Creational] Generate 'Prototype' Pattern";
        public const string DE_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN = "[Schöpfungsmuster] Generieren Sie ein „Prototyp“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN = "[Структурные] Сгенерировать шаблон 'Адаптер' (Adapter)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN = "[Structural] Generate 'Adapter' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN = "[Strukturell] Generieren Sie ein „Adapter“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN = "[Структурные] Сгенерировать шаблон 'Мост' (Bridge)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN = "[Structural] Generate 'Bridge' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN = "[Strukturell] Generieren Sie ein „Bridge“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN = "[Структурные] Сгенерировать шаблон 'Декоратор' (Decorator)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN = "[Structural] Generate 'Decorator' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN = "[Strukturell] Generieren Sie ein „Decorator“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN = "[Структурные] Сгенерировать шаблон 'Компоновщик' (Composite)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN = "[Structural] Generate 'Composite' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN = "[Strukturell] Generieren Sie ein „zusammengesetztes“ Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN = "[Структурные] Сгенерировать шаблон 'Приспособленец/Легковес' (Flyweight)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN = "[Structural] Generate 'Flyweight' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN = "[Strukturell] Generieren Sie ein „Fliegengewicht“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN = "[Структурные] Сгенерировать шаблон 'Заместитель' (Proxy)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN = "[Structural] Generate 'Proxy' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN = "[Strukturell] Generieren Sie ein „Proxy“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN = "[Структурные] Сгенерировать шаблон 'Маршрутизатор' (Router)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN = "[Structural] Generate 'Router' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN = "[Strukturell] Generieren Sie ein „Router“-Muster";

        public const string RU_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN = "[Структурные] Сгенерировать шаблон 'Фасад' (Facade)";
        public const string EN_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN = "[Structural] Generate 'Facade' Pattern";
        public const string DE_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN = "[Strukturell] Generieren Sie das Muster „Fassade“";

        public const string RU_ACTION_GENERATE_TECHNIQUE_CASCADING_METHOD = "[Техники] Сгенерировать пример проекта для техники 'Каскадный метод' (Cascading Method)";
        public const string EN_ACTION_GENERATE_TECHNIQUE_CASCADING_METHOD = "[Tecnhiques] Generate the primer project for the technology 'Cascading Method' (Cascading Method)";
        public const string DE_ACTION_GENERATE_TECHNIQUE_CASCADING_METHOD = "[Techniken] Generieren Sie das Grundprojekt für die Technologie „Cascading Method“ (Cascading Method)";

        // =======================================================================================================================
        // [RU] ID поддерживаемых плагином действий
        // [EN] IDs of actions supported by the plugin
        // =======================================================================================================================
        public const string ID_ACTION_CLEAN_GENERATED_DIRECTORY = "clean_generated_directory";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN = "generate_behavioral_visitor_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN = "generate_behavioral_chain_of_responsibility_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN = "generate_behavioral_command_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN = "generate_behavioral_template_method_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN = "generate_behavioral_null_object_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN = "generate_behavioral_strategy_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN = "generate_behavioral_observer_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN = "generate_behavioral_state_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN = "generate_behavioral_memento_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN = "generate_behavioral_mediator_pattern";
        public const string ID_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN = "generate_behavioral_iterator_pattern";

        public const string ID_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN = "generate_creational_abstract_factory_pattern";
        public const string ID_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN = "generate_creational_builder_pattern";
        public const string ID_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN = "generate_creational_factory_method_pattern";
        public const string ID_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN = "generate_creational_not_thread_safe_singleton_pattern";
        public const string ID_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN = "generate_creational_thread_safe_singleton_pattern";
        public const string ID_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN = "generate_creational_object_pool_pattern";
        public const string ID_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN = "generate_creational_prototype_pattern";

        public const string ID_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN = "generate_structural_adapter_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN = "generate_structural_bridge_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN = "generate_structural_decorator_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN = "generate_structural_composite_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN = "generate_structural_flyweight_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN = "generate_structural_proxy_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN = "generate_structural_router_pattern";
        public const string ID_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN = "generate_structural_facade_pattern";

        public const string ID_ACTION_GENERATE_TECNHIQUE_CASCADING_METHOD = "generate_technique_cascading_method";

        // =======================================================================================================================
        // [RU] Переопределения для свойств базового класса StandardAinDevHelperPlugin
        // [EN] Overrides for properties of the StandardAinDevHelperPlugin base class
        // =======================================================================================================================

        public override string Name => "C# Design Patterns Plugin";
        public override string Description => "Плагин, который помогает разработчику быстро генерировать примеры кода на языке C# для различных известных шаблонов проектирования (паттернов).";

        public override IEnumerable<string> Tags => new HashSet<string>() { OOP, DESIGN_PATTERNS, DESIGN, CSHARP, CODE_GENERATION };

        public override IEnumerable<string> SupportedLanguageCodes => new List<string>() { RU, EN, DE };

        public override IEnumerable<AinDevHelperLocalizedMessage> LocalizedDescriptions => new HashSet<AinDevHelperLocalizedMessage>() {
            new AinDevHelperLocalizedMessage(EN, "A plugin that helps the developer quickly generate C# code examples for various well-known design patterns."),
            new AinDevHelperLocalizedMessage(DE, "Ein Plugin, das dem Entwickler hilft, schnell C#-Codebeispiele für verschiedene bekannte Entwurfsmuster zu generieren."),
        };

        public override string Author => "Max Damascus";
        public override string Company => "Allineed.Ru";
        public override string AuthorSiteURL => "https://allineed.ru";
        public override string AuthorEmail => "allineed.ru@gmail.com";

        // =======================================================================================================================
        // [RU] Реализация методов плагина
        // [EN] Implementing plugin methods
        // =======================================================================================================================

        public override IEnumerable<AinDevHelperPluginAction> GetActions() {
            // [RU] Действие плагина для на очистку каталога 'generated' плагина
            // [EN] Plugin Action for cleaning the 'generated' plugin directory
            AinDevHelperPluginAction cleanGeneratedDirectoryAction =
                new AinDevHelperPluginAction(
                    RU_ACTION_CLEAN_GENERATED_DIRECTORY,
                    ID_ACTION_CLEAN_GENERATED_DIRECTORY
                );

            cleanGeneratedDirectoryAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CLEAN_GENERATED_DIRECTORY));
            cleanGeneratedDirectoryAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CLEAN_GENERATED_DIRECTORY));

            // [RU] Действие плагина для генерации шаблона 'Посетитель'
            // [EN] Plugin Action for 'Visitor' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralVisitorPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN
                );

            generateBehavioralVisitorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN));
            generateBehavioralVisitorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Цепочка обязанностей'
            // [EN] Plugin Action for 'Chain Of Responsibility' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralChainOfResponsibilityPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN
                );

            generateBehavioralChainOfResponsibilityPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN));
            generateBehavioralChainOfResponsibilityPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Команда'
            // [EN] Plugin Action for 'Command' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralCommandPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN
                );

            generateBehavioralCommandPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN));
            generateBehavioralCommandPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Шаблонный метод'
            // [EN] Plugin Action for 'Template Method' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralTemplateMethodPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN
                );

            generateBehavioralTemplateMethodPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN));
            generateBehavioralTemplateMethodPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Нулевой объект'
            // [EN] Plugin Action for 'Null Object' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralNullObjectPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN
                );

            generateBehavioralNullObjectPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN));
            generateBehavioralNullObjectPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Стратегия'
            // [EN] Plugin Action for 'Strategy' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralStrategyPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN
                );

            generateBehavioralStrategyPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN));
            generateBehavioralStrategyPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Наблюдатель'
            // [EN] Plugin Action for 'Observer' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralObserverPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN
                );

            generateBehavioralObserverPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN));
            generateBehavioralObserverPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Состояние'
            // [EN] Plugin Action for 'State' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralStatePatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN
                );

            generateBehavioralStatePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN));
            generateBehavioralStatePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Хранитель'
            // [EN] Plugin Action for 'Memento' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralMementoPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN
                );

            generateBehavioralMementoPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN));
            generateBehavioralMementoPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN));


            // [RU] Действие плагина для генерации шаблона 'Посредник'
            // [EN] Plugin Action for 'Mediator' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralMediatorPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN
                );

            generateBehavioralMediatorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN));
            generateBehavioralMediatorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Итератор'
            // [EN] Plugin Action for 'Iterator' pattern generation
            AinDevHelperPluginGenerationAction generateBehavioralIteratorPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN,
                    ID_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN
                );

            generateBehavioralIteratorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN));
            generateBehavioralIteratorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Абстрактная фабрика'
            // [EN] Plugin Action for 'Abstract Factory' pattern generation
            AinDevHelperPluginGenerationAction generateCreationalAbstractFactoryPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN
                );

            generateCreationalAbstractFactoryPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN));
            generateCreationalAbstractFactoryPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Строитель'
            // [EN] Plugin Action for 'Builder' pattern generation
            AinDevHelperPluginGenerationAction generateCreationalBuilderPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN
                );

            generateCreationalBuilderPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN));
            generateCreationalBuilderPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Фабричный метод'
            // [EN] Plugin Action for 'Factory Method' pattern generation
            AinDevHelperPluginGenerationAction generateCreationalFactoryMethodPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN
                );

            generateCreationalFactoryMethodPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN));
            generateCreationalFactoryMethodPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Одиночка' (не потокобезопасный)
            // [EN] Plugin Action for 'Singleton' pattern generation (not thread-safe)
            AinDevHelperPluginGenerationAction generateCreationalNotThreadSafeSingletonPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN
                );

            generateCreationalNotThreadSafeSingletonPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN));
            generateCreationalNotThreadSafeSingletonPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Одиночка' (потокобезопасный)
            // [EN] Plugin Action for 'Singleton' pattern generation (thread-safe)
            AinDevHelperPluginGenerationAction generateCreationalThreadSafeSingletonPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN
                );

            generateCreationalThreadSafeSingletonPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN));
            generateCreationalThreadSafeSingletonPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Пул объектов'
            // [EN] Plugin Action for 'Object Pool' pattern generation
            AinDevHelperPluginGenerationAction generateCreationalObjectPoolPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN
                );

            generateCreationalObjectPoolPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN));
            generateCreationalObjectPoolPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Прототип'
            // [EN] Plugin Action for 'Prototype' pattern generation
            AinDevHelperPluginGenerationAction generateCreationalPrototypePatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN,
                    ID_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN
                );

            generateCreationalPrototypePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN));
            generateCreationalPrototypePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Адаптер'
            // [EN] Plugin Action for 'Adapter' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralAdapterPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN
                );

            generateStructuralAdapterPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN));
            generateStructuralAdapterPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Мост'
            // [EN] Plugin Action for 'Bridge' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralBridgePatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN
                );

            generateStructuralBridgePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN));
            generateStructuralBridgePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Декоратор'
            // [EN] Plugin Action for 'Decorator' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralDecoratorPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN
                );

            generateStructuralDecoratorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN));
            generateStructuralDecoratorPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Компоновщик'
            // [EN] Plugin Action for 'Composite' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralCompositePatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN
                );

            generateStructuralCompositePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN));
            generateStructuralCompositePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Приспособленец/Легковес'
            // [EN] Plugin Action for 'Flyweight' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralFlyweightPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN
                );

            generateStructuralFlyweightPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN));
            generateStructuralFlyweightPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Заместитель'
            // [EN] Plugin Action for 'Proxy' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralProxyPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN
                );

            generateStructuralProxyPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN));
            generateStructuralProxyPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Маршрутизатор'
            // [EN] Plugin Action for 'Router' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralRouterPatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN
                );

            generateStructuralRouterPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN));
            generateStructuralRouterPatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN));

            // [RU] Действие плагина для генерации шаблона 'Фасад'
            // [EN] Plugin Action for 'Facade' pattern generation
            AinDevHelperPluginGenerationAction generateStructuralFacadePatternAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN,
                    ID_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN
                );

            generateStructuralFacadePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN));
            generateStructuralFacadePatternAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN));

            // [RU] Действие плагина для генерации техники 'Каскадный метод'
            // [EN] Plugin Action for 'Cascading Method' technique generation
            AinDevHelperPluginGenerationAction generateTechniqueCascadingMethodAction =
                new AinDevHelperPluginGenerationAction(
                    RU_ACTION_GENERATE_TECHNIQUE_CASCADING_METHOD,
                    ID_ACTION_GENERATE_TECNHIQUE_CASCADING_METHOD
                );

            generateTechniqueCascadingMethodAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_TECHNIQUE_CASCADING_METHOD));
            generateTechniqueCascadingMethodAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_TECHNIQUE_CASCADING_METHOD));

            return AinDevHelperPluginAction.From(
                cleanGeneratedDirectoryAction,
                generateBehavioralVisitorPatternAction,
                generateBehavioralChainOfResponsibilityPatternAction,
                generateBehavioralCommandPatternAction,
                generateBehavioralTemplateMethodPatternAction,
                generateBehavioralNullObjectPatternAction,
                generateBehavioralStrategyPatternAction,
                generateBehavioralObserverPatternAction,
                generateBehavioralStatePatternAction,
                generateBehavioralMementoPatternAction,
                generateBehavioralMediatorPatternAction,
                generateBehavioralIteratorPatternAction,
                generateCreationalAbstractFactoryPatternAction,
                generateCreationalBuilderPatternAction,
                generateCreationalFactoryMethodPatternAction,
                generateCreationalNotThreadSafeSingletonPatternAction,
                generateCreationalThreadSafeSingletonPatternAction,
                generateCreationalObjectPoolPatternAction,
                generateCreationalPrototypePatternAction,
                generateStructuralAdapterPatternAction,
                generateStructuralBridgePatternAction,
                generateStructuralDecoratorPatternAction,
                generateStructuralCompositePatternAction,
                generateStructuralFlyweightPatternAction,
                generateStructuralProxyPatternAction,
                generateStructuralRouterPatternAction,
                generateStructuralFacadePatternAction,
                generateTechniqueCascadingMethodAction
            );
        }
        
        public override AinDevHelperPluginActionResult RunAction(AinDevHelperPluginAction actionToRun) {
            string actionId = actionToRun.ID;

            if (ID_ACTION_CLEAN_GENERATED_DIRECTORY.Equals(actionId)) {
                try {
                    var generatedDirectory = Path.Combine(PluginDirectory, GENERATED_DIRECTORY_NAME);
                    if (Directory.Exists(generatedDirectory)) {
                        Directory.Delete(generatedDirectory, true);
                        Directory.CreateDirectory(generatedDirectory);
                        return new AinDevHelperPluginActionResult(this, actionToRun, "Каталог '" + GENERATED_DIRECTORY_NAME + "' успешно очищен.",
                            (EN, "The directory '" + GENERATED_DIRECTORY_NAME + "' has been successfully cleaned."),
                            (DE, "Das Verzeichnis '" + GENERATED_DIRECTORY_NAME + "' wurde erfolgreich bereinigt"));
                    }
                } catch (Exception exception) {
                    return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                        (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                        (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
                }
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_VISITOR_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralVisitorPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_CHAIN_OF_RESPONSIBILITY_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralChainOfResponsibilityPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_COMMAND_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralCommandPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_TEMPLATE_METHOD_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralTemplateMethodPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_NULL_OBJECT_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralNullObjectPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_STRATEGY_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralStrategyPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_OBSERVER_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralObserverPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_STATE_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralStatePattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_MEMENTO_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralMementoPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_MEDIATOR_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralMediatorPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_BEHAVIORAL_ITERATOR_PATTERN.Equals(actionId)) {
                return HandleGenerationOfBehavioralIteratorPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_ABSTRACT_FACTORY_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalAbstractFactoryPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_BUILDER_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalBuilderPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_FACTORY_METHOD_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalFactoryMethodPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_NOT_THREAD_SAFE_SINGLETON_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalNotThreadSafeSingletonPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_THREAD_SAFE_SINGLETON_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalThreadSafeSingletonPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_OBJECT_POOL_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalObjectPoolPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_CREATIONAL_PROTOTYPE_PATTERN.Equals(actionId)) {
                return HandleGenerationOfCreationalPrototypePattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_ADAPTER_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralAdapterPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_BRIDGE_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralBridgePattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_DECORATOR_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralDecoratorPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_COMPOSITE_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralCompositePattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_FLYWEIGHT_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralFlyweightPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_PROXY_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralProxyPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_ROUTER_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralRouterPattern(actionToRun);
            } else if (ID_ACTION_GENERATE_STRUCTURAL_FACADE_PATTERN.Equals(actionId)) {
                return HandleGenerationOfStructuralFacadePattern(actionToRun);
            } else if (ID_ACTION_GENERATE_TECNHIQUE_CASCADING_METHOD.Equals(actionId)) {
                return HandleGenerationOfTechniqueCascadingMethod(actionToRun);
            }

            return GetErroneousResponseActionNotRecognized(actionToRun);
        }

        /// <summary>
        /// [RU] Метод создаёт в каталоге <see cref="GENERATED_DIRECTORY_NAME"/> новый каталог проекта-примера, где будут содержаться сгенерированные файлы проекта-примера<br/>
        /// [EN] The method creates a new example project directory in the <see cref="GENERATED_DIRECTORY_NAME"/> directory, which will contain the generated example project files
        /// </summary>
        /// <param name="patternDirectoryName">[RU] название нового каталога для генерации в нём файлов проекта;<br/>[EN] the name of the new directory for generating project files in it</param>
        /// <returns></returns>
        private string CreateDesignPatternProjectDirectory(string patternDirectoryName) {
            Directory.CreateDirectory(Path.Combine(PluginDirectory, GENERATED_DIRECTORY_NAME));
            string mainProjectPath = Path.Combine(PluginDirectory, GENERATED_DIRECTORY_NAME, patternDirectoryName);
            Directory.CreateDirectory(mainProjectPath);
            return mainProjectPath;
        }

        /// <summary>
        /// [RU] Генерация кода для поведенческого (Behavioral) шаблона проектирования "Посетитель" (Visitor)<br/>
        /// [EN] Generating Code for the Behavioral "Visitor" Design Pattern
        /// </summary>
        /// <param name="actionToRun">[RU] экземпляр действия плагина для запуска;<br/>[EN] instance of the plugin action to run</param>
        /// <returns>[RU] экземпляр результата выполнения действия: успешного при отсутствии ошибок и с сообщением об ошибке при возникновении исключения в процессе генерации;<br/>[EN] an instance of the result of the action: successful if there are no errors and with an error message if an exception occurs during the generation process</returns>
        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralVisitorPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("visitor");

                AreaVisitor areaVisitor = new AreaVisitor();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "AreaVisitor.cs", areaVisitor.TransformText());

                IShape iShape = new IShape();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "IShape.cs", iShape.TransformText());

                IVisitor iVisitor = new IVisitor();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "IVisitor.cs", iVisitor.TransformText());

                Circle circle = new Circle();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "Circle.cs", circle.TransformText());

                Square square = new Square();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "Square.cs", square.TransformText());

                Triangle triangle = new Triangle();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "Triangle.cs", triangle.TransformText());

                Rectangle rectangle = new Rectangle();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "Rectangle.cs", rectangle.TransformText());

                VisitorCSharpProgram visitorCSharpProgram = new VisitorCSharpProgram();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "Program.cs", visitorCSharpProgram.TransformText());

                VisitorCSharpProject visitorCSharpProject = new VisitorCSharpProject();
                File.WriteAllText(mainProjectPath + Path.DirectorySeparatorChar + "AinDevHelperVisitorPattern.csproj", visitorCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Посетитель' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                        (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                        (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        /// <summary>
        /// [RU] Генерация кода для поведенческого (Behavioral) шаблона проектирования "Цепочка обязанностей" (Chain Of Responsibility)<br/>
        /// [EN] Generating Code for the Behavioral "Chain Of Responsibility" Design Pattern
        /// </summary>
        /// <param name="actionToRun">[RU] экземпляр действия плагина для запуска;<br/>[EN] instance of the plugin action to run</param>
        /// <returns>[RU] экземпляр результата выполнения действия: успешного при отсутствии ошибок и с сообщением об ошибке при возникновении исключения в процессе генерации;<br/>[EN] an instance of the result of the action: successful if there are no errors and with an error message if an exception occurs during the generation process</returns>
        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralChainOfResponsibilityPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("chain_of_responsibility");

                BankManager bankManager = new BankManager();
                File.WriteAllText(Path.Combine(mainProjectPath, "BankManager.cs"), bankManager.TransformText());

                LoanManager loanManager = new LoanManager();
                File.WriteAllText(Path.Combine(mainProjectPath, "LoanManager.cs"), loanManager.TransformText());

                CreditRequest creditRequest = new CreditRequest();
                File.WriteAllText(Path.Combine(mainProjectPath, "CreditRequest.cs"), creditRequest.TransformText());

                ICreditApprover iCreditApprover = new ICreditApprover();
                File.WriteAllText(Path.Combine(mainProjectPath, "ICreditApprover.cs"), iCreditApprover.TransformText());

                ChainOfResponsibilityCSharpProgram chainOfResponsibilityProgram = new ChainOfResponsibilityCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), chainOfResponsibilityProgram.TransformText());

                ChainOfResponsibilityCSharpProject chainOfResponsibilityCSharpProject = new ChainOfResponsibilityCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperChainOfResponsibilityPattern.csproj"), chainOfResponsibilityCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Цепочка обязанностей' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        /// <summary>
        /// [RU] Генерация кода для поведенческого (Behavioral) шаблона проектирования "Команда" (Command)<br/>
        /// [EN] Generating Code for the Behavioral Design Pattern "Command"
        /// </summary>
        /// <param name="actionToRun">[RU] экземпляр действия плагина для запуска;<br/>[EN] instance of the plugin action to run</param>
        /// <returns>[RU] экземпляр результата выполнения действия: успешного при отсутствии ошибок и с сообщением об ошибке при возникновении исключения в процессе генерации;<br/>[EN] an instance of the result of the action: successful if there are no errors and with an error message if an exception occurs during the generation process</returns>
        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralCommandPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("command");

                Robot robot = new Robot();
                File.WriteAllText(Path.Combine(mainProjectPath, "Robot.cs"), robot.TransformText());

                ICommand iCommand = new ICommand();
                File.WriteAllText(Path.Combine(mainProjectPath, "ICommand.cs"), iCommand.TransformText());

                CommandExecutor commandExecutor = new CommandExecutor();
                File.WriteAllText(Path.Combine(mainProjectPath, "CommandExecutor.cs"), commandExecutor.TransformText());

                MoveForwardCommand moveForwardCommand = new MoveForwardCommand();
                File.WriteAllText(Path.Combine(mainProjectPath, "MoveForwardCommand.cs"), moveForwardCommand.TransformText());

                MoveBackwardCommand moveBackwardCommand = new MoveBackwardCommand();
                File.WriteAllText(Path.Combine(mainProjectPath, "MoveBackwardCommand.cs"), moveBackwardCommand.TransformText());

                CommandCSharpProgram commandProgram = new CommandCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), commandProgram.TransformText());

                CommandCSharpProject commandCSharpProject = new CommandCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperCommandPattern.csproj"), commandCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Команда' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        /// <summary>
        /// [RU] Генерация кода для поведенческого (Behavioral) шаблона проектирования "Шаблонный метод" (Template Method)<br/>
        /// [EN] Generating Code for the Behavioral Design Pattern "Template Method"
        /// </summary>
        /// <param name="actionToRun">[RU] экземпляр действия плагина для запуска;<br/>[EN] instance of the plugin action to run</param>
        /// <returns>[RU] экземпляр результата выполнения действия: успешного при отсутствии ошибок и с сообщением об ошибке при возникновении исключения в процессе генерации;<br/>[EN] an instance of the result of the action: successful if there are no errors and with an error message if an exception occurs during the generation process</returns>
        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralTemplateMethodPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("template_method");

                DataProcessor dataProcessor = new DataProcessor();
                File.WriteAllText(Path.Combine(mainProjectPath, "DataProcessor.cs"), dataProcessor.TransformText());

                CsvDataProcessor csvDataProcessor = new CsvDataProcessor();
                File.WriteAllText(Path.Combine(mainProjectPath, "CsvDataProcessor.cs"), csvDataProcessor.TransformText());

                ExcelDataProcessor excelDataProcessor = new ExcelDataProcessor();
                File.WriteAllText(Path.Combine(mainProjectPath, "ExcelDataProcessor.cs"), excelDataProcessor.TransformText());

                TemplateMethodCSharpProgram templateMethodProgram = new TemplateMethodCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), templateMethodProgram.TransformText());

                TemplateMethodCSharpProject templateMethodCSharpProject = new TemplateMethodCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperTemplateMethodPattern.csproj"), templateMethodCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Шаблонный метод' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralNullObjectPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("null_object");

                FileLogger fileLogger = new FileLogger();
                File.WriteAllText(Path.Combine(mainProjectPath, "FileLogger.cs"), fileLogger.TransformText());

                ILogger iLogger = new ILogger();
                File.WriteAllText(Path.Combine(mainProjectPath, "ILogger.cs"), iLogger.TransformText());

                NullLogger nullLogger = new NullLogger();
                File.WriteAllText(Path.Combine(mainProjectPath, "NullLogger.cs"), nullLogger.TransformText());

                NullObjectCSharpProgram nullObjectCSharpProgram = new NullObjectCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), nullObjectCSharpProgram.TransformText());

                NullObjectCSharpProject nullObjectCSharpProject = new NullObjectCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperNullObjectPattern.csproj"), nullObjectCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Нулевой объект' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralStrategyPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("strategy");

                IPaymentStrategy iPaymentStrategy = new IPaymentStrategy();
                File.WriteAllText(Path.Combine(mainProjectPath, "IPaymentStrategy.cs"), iPaymentStrategy.TransformText());

                PaymentProcessor paymentProcessor = new PaymentProcessor();
                File.WriteAllText(Path.Combine(mainProjectPath, "PaymentProcessor.cs"), paymentProcessor.TransformText());

                PayPalPaymentStrategy payPalPaymentStrategy = new PayPalPaymentStrategy();
                File.WriteAllText(Path.Combine(mainProjectPath, "PayPalPaymentStrategy.cs"), payPalPaymentStrategy.TransformText());

                CreditCardPaymentStrategy creditCardPaymentStrategy = new CreditCardPaymentStrategy();
                File.WriteAllText(Path.Combine(mainProjectPath, "CreditCardPaymentStrategy.cs"), creditCardPaymentStrategy.TransformText());

                StrategyCSharpProgram strategyCSharpProgram = new StrategyCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), strategyCSharpProgram.TransformText());

                StrategyCSharpProject strategyCSharpProject = new StrategyCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperStrategyPattern.csproj"), strategyCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Стратегия' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralObserverPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("observer");

                ISubscriber iSubscriber = new ISubscriber();
                File.WriteAllText(Path.Combine(mainProjectPath, "ISubscriber.cs"), iSubscriber.TransformText());

                SocialMediaPage socialMediaPage = new SocialMediaPage();
                File.WriteAllText(Path.Combine(mainProjectPath, "SocialMediaPage.cs"), socialMediaPage.TransformText());

                Subscriber subscriber = new Subscriber();
                File.WriteAllText(Path.Combine(mainProjectPath, "Subscriber.cs"), subscriber.TransformText());

                ObserverCSharpProgram observerCSharpProgram = new ObserverCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), observerCSharpProgram.TransformText());

                ObserverCSharpProject observerCSharpProject = new ObserverCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperObserverPattern.csproj"), observerCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Наблюдатель' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralStatePattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("state");

                Order order = new Order();
                File.WriteAllText(Path.Combine(mainProjectPath, "Order.cs"), order.TransformText());

                IOrderState iOrderState = new IOrderState();
                File.WriteAllText(Path.Combine(mainProjectPath, "IOrderState.cs"), iOrderState.TransformText());

                NewOrder newOrder = new NewOrder();
                File.WriteAllText(Path.Combine(mainProjectPath, "NewOrder.cs"), newOrder.TransformText());

                InProcessOrder inProcessOrder = new InProcessOrder();
                File.WriteAllText(Path.Combine(mainProjectPath, "InProcessOrder.cs"), inProcessOrder.TransformText());

                CancelledOrder cancelledOrder = new CancelledOrder();
                File.WriteAllText(Path.Combine(mainProjectPath, "CancelledOrder.cs"), cancelledOrder.TransformText());

                StateCSharpProgram stateCSharpProgram = new StateCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), stateCSharpProgram.TransformText());

                StateCSharpProject stateCSharpProject = new StateCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperStatePattern.csproj"), stateCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Состояние' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralMementoPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("memento");

                TextDocument textDocument = new TextDocument();
                File.WriteAllText(Path.Combine(mainProjectPath, "TextDocument.cs"), textDocument.TransformText());

                TextDocumentMemento textDocumentMemento = new TextDocumentMemento();
                File.WriteAllText(Path.Combine(mainProjectPath, "TextDocumentMemento.cs"), textDocumentMemento.TransformText());

                MementoConsoleUtils mementoConsoleUtils = new MementoConsoleUtils();
                File.WriteAllText(Path.Combine(mainProjectPath, "MementoConsoleUtils.cs"), mementoConsoleUtils.TransformText());

                MementoCSharpProgram mementoCSharpProgram = new MementoCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), mementoCSharpProgram.TransformText());

                MementoCSharpProject mementoCSharpProject = new MementoCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperMementoPattern.csproj"), mementoCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Хранитель' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralMediatorPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("mediator");

                AirTrafficControl airTrafficControl = new AirTrafficControl();
                File.WriteAllText(Path.Combine(mainProjectPath, "AirTrafficControl.cs"), airTrafficControl.TransformText());

                FlightManagementSystem flightManagementSystem = new FlightManagementSystem();
                File.WriteAllText(Path.Combine(mainProjectPath, "FlightManagementSystem.cs"), flightManagementSystem.TransformText());

                Participant participant = new Participant();
                File.WriteAllText(Path.Combine(mainProjectPath, "Participant.cs"), participant.TransformText());

                MediatorCSharpProgram mediatorCSharpProgram = new MediatorCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), mediatorCSharpProgram.TransformText());

                MediatorCSharpProject mediatorCSharpProject = new MediatorCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperMediatorPattern.csproj"), mediatorCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Посредник' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfBehavioralIteratorPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("iterator");

                Student student = new Student();
                File.WriteAllText(Path.Combine(mainProjectPath, "Student.cs"), student.TransformText());

                StudentCollection studentCollection = new StudentCollection();
                File.WriteAllText(Path.Combine(mainProjectPath, "StudentCollection.cs"), studentCollection.TransformText());

                IteratorCSharpProgram iteratorCSharpProgram = new IteratorCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), iteratorCSharpProgram.TransformText());

                IteratorCSharpProject iteratorCSharpProject = new IteratorCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperIteratorPattern.csproj"), iteratorCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Итератор' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalAbstractFactoryPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("abstract_factory");

                AbstractCarFactory abstractCarFactory = new AbstractCarFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "AbstractCarFactory.cs"), abstractCarFactory.TransformText());

                AbstractCarEngine abstractCarEngine = new AbstractCarEngine();
                File.WriteAllText(Path.Combine(mainProjectPath, "AbstractCarEngine.cs"), abstractCarEngine.TransformText());

                AbstractCarBody abstractCarBody = new AbstractCarBody();
                File.WriteAllText(Path.Combine(mainProjectPath, "AbstractCarBody.cs"), abstractCarBody.TransformText());

                SedanV4CarFactory sedanV4CarFactory = new SedanV4CarFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "SedanV4CarFactory.cs"), sedanV4CarFactory.TransformText());

                SedanV4CarEngine sedanV4CarEngine = new SedanV4CarEngine();
                File.WriteAllText(Path.Combine(mainProjectPath, "SedanV4CarEngine.cs"), sedanV4CarEngine.TransformText());

                SedanV4CarBody sedanV4CarBody = new SedanV4CarBody();
                File.WriteAllText(Path.Combine(mainProjectPath, "SedanV4CarBody.cs"), sedanV4CarBody.TransformText());

                SportCarV12CarFactory sportCarV12CarFactory = new SportCarV12CarFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "SportCarV12CarFactory.cs"), sportCarV12CarFactory.TransformText());

                SportCarV12CarEngine sportCarV12CarEngine = new SportCarV12CarEngine();
                File.WriteAllText(Path.Combine(mainProjectPath, "SportCarV12CarEngine.cs"), sportCarV12CarEngine.TransformText());

                SportCarV12CarBody sportCarV12CarBody = new SportCarV12CarBody();
                File.WriteAllText(Path.Combine(mainProjectPath, "SportCarV12CarBody.cs"), sportCarV12CarBody.TransformText());

                AbstractFactoryCSharpProgram abstractFactoryCSharpProgram = new AbstractFactoryCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), abstractFactoryCSharpProgram.TransformText());

                AbstractFactoryCSharpProject abstractFactoryCSharpProject = new AbstractFactoryCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperAbstractFactoryPattern.csproj"), abstractFactoryCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Абстрактная фабрика' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalBuilderPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("builder");

                IPizzaBuilder pizzaBuilder = new IPizzaBuilder();
                File.WriteAllText(Path.Combine(mainProjectPath, "IPizzaBuilder.cs"), pizzaBuilder.TransformText());

                PizzaOrder pizzaOrder = new PizzaOrder();
                File.WriteAllText(Path.Combine(mainProjectPath, "PizzaOrder.cs"), pizzaOrder.TransformText());

                PizzaDirector pizzaDirector = new PizzaDirector();
                File.WriteAllText(Path.Combine(mainProjectPath, "PizzaDirector.cs"), pizzaDirector.TransformText());

                MargheritaPizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder();
                File.WriteAllText(Path.Combine(mainProjectPath, "MargheritaPizzaBuilder.cs"), margheritaPizzaBuilder.TransformText());

                BuilderCSharpProgram builderCSharpProgram = new BuilderCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), builderCSharpProgram.TransformText());

                BuilderCSharpProject builderCSharpProject = new BuilderCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperBuilderPattern.csproj"), builderCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Строитель' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalFactoryMethodPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("factory_method");

                ITransport transport = new ITransport();
                File.WriteAllText(Path.Combine(mainProjectPath, "ITransport.cs"), transport.TransformText());

                TransportFactory transportFactory = new TransportFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "TransportFactory.cs"), transportFactory.TransformText());

                Airplane airplane = new Airplane();
                File.WriteAllText(Path.Combine(mainProjectPath, "Airplane.cs"), airplane.TransformText());

                Bicycle bicycle = new Bicycle();
                File.WriteAllText(Path.Combine(mainProjectPath, "Bicycle.cs"), bicycle.TransformText());

                Car car = new Car();
                File.WriteAllText(Path.Combine(mainProjectPath, "Car.cs"), car.TransformText());

                AirplaneFactory airplaneFactory = new AirplaneFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "AirplaneFactory.cs"), airplaneFactory.TransformText());

                BicycleFactory bicycleFactory = new BicycleFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "BicycleFactory.cs"), bicycleFactory.TransformText());

                CarFactory carFactory = new CarFactory();
                File.WriteAllText(Path.Combine(mainProjectPath, "CarFactory.cs"), carFactory.TransformText());

                FactoryMethodCSharpProgram factoryMethodCSharpProgram = new FactoryMethodCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), factoryMethodCSharpProgram.TransformText());

                FactoryMethodCSharpProject factoryMethodCSharpProject = new FactoryMethodCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperFactoryMethodPattern.csproj"), factoryMethodCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Фабричный метод' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalNotThreadSafeSingletonPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("not_thread_safe_singleton");

                NotThreadSafeLogger notThreadSafeLogger = new NotThreadSafeLogger();
                File.WriteAllText(Path.Combine(mainProjectPath, "Logger.cs"), notThreadSafeLogger.TransformText());

                NotThreadSafeSingletonCSharpProgram notThreadSafeSingletonCSharpProgram = new NotThreadSafeSingletonCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), notThreadSafeSingletonCSharpProgram.TransformText());

                NotThreadSafeSingletonCSharpProject notThreadSafeSingletonCSharpProject = new NotThreadSafeSingletonCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperNotThreadSafeSingletonPattern.csproj"), notThreadSafeSingletonCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Одиночка' (не потокобезопасный вариант) успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalThreadSafeSingletonPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("thread_safe_singleton");

                ThreadSafeLogger threadSafeLogger = new ThreadSafeLogger();
                File.WriteAllText(Path.Combine(mainProjectPath, "Logger.cs"), threadSafeLogger.TransformText());

                ThreadSafeSingletonCSharpProgram threadSafeSingletonCSharpProgram = new ThreadSafeSingletonCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), threadSafeSingletonCSharpProgram.TransformText());

                ThreadSafeSingletonCSharpProject threadSafeSingletonCSharpProject = new ThreadSafeSingletonCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperThreadSafeSingletonPattern.csproj"), threadSafeSingletonCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Одиночка' (потокобезопасный вариант) успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalObjectPoolPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("object_pool");

                DatabaseConnection databaseConnection = new DatabaseConnection();
                File.WriteAllText(Path.Combine(mainProjectPath, "DatabaseConnection.cs"), databaseConnection.TransformText());

                ConnectionPool connectionPool = new ConnectionPool();
                File.WriteAllText(Path.Combine(mainProjectPath, "ConnectionPool.cs"), connectionPool.TransformText());

                ObjectPoolCSharpProgram objectPoolCSharpProgram = new ObjectPoolCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), objectPoolCSharpProgram.TransformText());

                ObjectPoolCSharpProject objectPoolCSharpProject = new ObjectPoolCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperObjectPoolPattern.csproj"), objectPoolCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Пул объектов' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfCreationalPrototypePattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("prototype");

                DocumentPrototype documentPrototype = new DocumentPrototype();
                File.WriteAllText(Path.Combine(mainProjectPath, "DocumentPrototype.cs"), documentPrototype.TransformText());

                Document document = new Document();
                File.WriteAllText(Path.Combine(mainProjectPath, "Document.cs"), document.TransformText());

                PrototypeCSharpProgram prototypeCSharpProgram = new PrototypeCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), prototypeCSharpProgram.TransformText());

                PrototypeCSharpProject prototypeCSharpProject = new PrototypeCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperPrototypePattern.csproj"), prototypeCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Прототип' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralAdapterPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("adapter");

                IInputDevice inputDevice = new IInputDevice(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "IInputDevice.cs"), inputDevice.TransformText());

                InputDeviceAdapter inputDeviceAdapter = new InputDeviceAdapter(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "InputDeviceAdapter.cs"), inputDeviceAdapter.TransformText());

                ThirdPartyInputDevice thirdPartyInputDevice = new ThirdPartyInputDevice(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "ThirdPartyInputDevice.cs"), thirdPartyInputDevice.TransformText());

                AdapterCSharpProgram adapterCSharpProgram = new AdapterCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), adapterCSharpProgram.TransformText());

                AdapterCSharpProject adapterCSharpProject = new AdapterCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperAdapterPattern.csproj"), adapterCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Адаптер' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Adapter' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das Muster „Adapter“ wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralBridgePattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("bridge");

                IDevice device = new IDevice(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "IDevice.cs"), device.TransformText());

                RemoteControl remoteControl = new RemoteControl(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "RemoteControl.cs"), remoteControl.TransformText());

                Radio radio = new Radio(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Radio.cs"), radio.TransformText());

                TV tv = new TV(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "TV.cs"), tv.TransformText());

                RadioRemoteControl radioRemoteControl = new RadioRemoteControl(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "RadioRemoteControl.cs"), radioRemoteControl.TransformText());

                TVRemoteControl tvRemoteControl = new TVRemoteControl(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "TVRemoteControl.cs"), tvRemoteControl.TransformText());

                BridgeCSharpProgram bridgeCSharpProgram = new BridgeCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), bridgeCSharpProgram.TransformText());

                BridgeCSharpProject bridgeCSharpProject = new BridgeCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperBridgePattern.csproj"), bridgeCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Мост' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Bridge' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das „Bridge“-Muster wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralDecoratorPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("decorator");

                IUser user = new IUser(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "IUser.cs"), user.TransformText());

                User userTemplate = new User(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "User.cs"), userTemplate.TransformText());

                AdminUserDecorator adminUserDecorator = new AdminUserDecorator(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "AdminUserDecorator.cs"), adminUserDecorator.TransformText());

                ModeratorUserDecorator moderatorUserDecorator = new ModeratorUserDecorator(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "ModeratorUserDecorator.cs"), moderatorUserDecorator.TransformText());

                DecoratorCSharpProgram decoratorCSharpProgram = new DecoratorCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), decoratorCSharpProgram.TransformText());

                DecoratorCSharpProject decoratorCSharpProject = new DecoratorCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperDecoratorPattern.csproj"), decoratorCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Декоратор' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Decorator' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das „Decorator“-Muster wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralCompositePattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("composite");

                FileSystemItem fileSystemItem = new FileSystemItem(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "FileSystemItem.cs"), fileSystemItem.TransformText());

                FileTemplate fileTemplate = new FileTemplate(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "File.cs"), fileTemplate.TransformText());

                Folder folder = new Folder(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Folder.cs"), folder.TransformText());

                CompositeCSharpProgram compositeCSharpProgram = new CompositeCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), compositeCSharpProgram.TransformText());

                CompositeCSharpProject compositeCSharpProject = new CompositeCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperCompositePattern.csproj"), compositeCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Компоновщик' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Composite' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das „zusammengesetztes“ Muster wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralFlyweightPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("flyweight");

                IWebPage iWebPage = new IWebPage(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "IWebPage.cs"), iWebPage.TransformText());

                WebPage webPage = new WebPage(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "WebPage.cs"), webPage.TransformText());

                WebPageFactory webPageFactory = new WebPageFactory(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "WebPageFactory.cs"), webPageFactory.TransformText());

                FlyweightCSharpProgram flyweightCSharpProgram = new FlyweightCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), flyweightCSharpProgram.TransformText());

                FlyweightCSharpProject flyweightCSharpProject = new FlyweightCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperFlyweightPattern.csproj"), flyweightCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Приспособленец/Легковес' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Flyweight' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das Muster „Fliegengewicht“ wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralProxyPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("proxy");

                IImageService iImageService = new IImageService(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "IImageService.cs"), iImageService.TransformText());

                ImageService imageService = new ImageService(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "ImageService.cs"), imageService.TransformText());

                ImageProxy imageProxy = new ImageProxy(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "ImageProxy.cs"), imageProxy.TransformText());

                ProxyCSharpProgram proxyCSharpProgram = new ProxyCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), proxyCSharpProgram.TransformText());

                ProxyCSharpProject proxyCSharpProject = new ProxyCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperProxyPattern.csproj"), proxyCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Заместитель' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Proxy' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das „Proxy“-Muster wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralRouterPattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("router");

                Router router = new Router(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Router.cs"), router.TransformText());

                AboutController aboutController = new AboutController(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "AboutController.cs"), aboutController.TransformText());

                HomeController homeController = new HomeController(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "HomeController.cs"), homeController.TransformText());

                RouterCSharpProgram routerCSharpProgram = new RouterCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), routerCSharpProgram.TransformText());

                RouterCSharpProject routerCSharpProject = new RouterCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperRouterPattern.csproj"), routerCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Маршрутизатор' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Router' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das „Router“-Muster wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfStructuralFacadePattern(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("facade");

                TextFileHandler textFileHandler = new TextFileHandler(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "TextFileHandler.cs"), textFileHandler.TransformText());

                ImageFileHandler imageFileHandler = new ImageFileHandler(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "ImageFileHandler.cs"), imageFileHandler.TransformText());

                FileFacade fileFacade = new FileFacade(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "FileFacade.cs"), fileFacade.TransformText());

                FacadeCSharpProgram facadeCSharpProgram = new FacadeCSharpProgram(Host.GetCurrentLanguageCode());
                File.WriteAllText(Path.Combine(mainProjectPath, "Program.cs"), facadeCSharpProgram.TransformText());

                FacadeCSharpProject facadeCSharpProject = new FacadeCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "AinDevHelperFacadePattern.csproj"), facadeCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для шаблона 'Фасад' успешно сгенерирован.",
                    (EN, $"The C# project for the 'Facade' pattern has been successfully generated."),
                    (DE, $"Das C#-Projekt für das Muster „Fassade“ wurde erfolgreich generiert."));
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }

        private AinDevHelperPluginActionResult HandleGenerationOfTechniqueCascadingMethod(AinDevHelperPluginAction actionToRun) {
            try {
                string mainProjectPath = CreateDesignPatternProjectDirectory("cascading_method");

                Employee employee = new Employee();
                File.WriteAllText(Path.Combine(mainProjectPath, "Employee.cs"), employee.TransformText());

                MethodCascadingCSharpProgram methodCascadingCSharpProgram = new MethodCascadingCSharpProgram();
                File.WriteAllText(Path.Combine(mainProjectPath, "MethodCascadingCSharpProgram.cs"), methodCascadingCSharpProgram.TransformText());

                MethodCascadingCSharpProject methodCascadingCSharpProject = new MethodCascadingCSharpProject();
                File.WriteAllText(Path.Combine(mainProjectPath, "MethodCascadingCSharpProject.csproj"), methodCascadingCSharpProject.TransformText());

                Process.Start(mainProjectPath);

                return new AinDevHelperPluginActionResult(this, actionToRun, "Проект на C# для техники 'Каскадный метод' успешно сгенерирован.");
            } catch (Exception exception) {
                return GetErroneousResponse(actionToRun, $"Ошибка при выполнении действия плагина. Детали ошибки: {exception.Message}",
                    (EN, $"An error occurred while executing the plugin action. Error details: {exception.Message}"),
                    (DE, $"Beim Ausführen der Plugin-Aktion ist ein Fehler aufgetreten. Fehlerdetails: {exception.Message}"));
            }
        }
    }
}
