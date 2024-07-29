/*
Copyright 2024 Allineed.Ru, Max Damascus

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using AinDevHelperPluginLibrary;
using AinDevHelperPluginLibrary.Actions;
using AinDevHelperPluginLibrary.Language;
using static AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants;
using static AinDevHelperPluginLibrary.Actions.AinDevHelperPluginActionCoreTagsConstants;
using AinDevHelperPluginLibrary.Settings.Controls;
using AinDevHelperPluginLibrary.Actions.Parameters;

namespace AngularHelperPlugin {
    /// <summary>
    /// [RU] Плагин для программы AinDevHelper, который предоставляет различные полезные действия для разработчиков на Angular<br/>
    /// [EN] A plugin for the AinDevHelper program that provides various useful actions for Angular developers
    /// </summary>
    public class AngularHelperPlugin : StandardAinDevHelperPlugin {
        // =======================================================================================================================
        // [RU] Имена поддерживаемых плагином действий
        // [EN] Names of actions supported by this plugin
        // =======================================================================================================================
        public const string RU_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION = "Показать текущую активную версию Angular CLI";
        public const string EN_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION = "Show currently active version of Angular CLI";
        public const string DE_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION = "Zeigt die aktuell aktive Version von Angular CLI an";        

        public const string RU_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION = "Показать текущую активную версию Node.js";
        public const string EN_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION = "Show the current active version of Node.js";
        public const string DE_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION = "Zeigt die aktuell aktive Version von Node.js an";

        public const string RU_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION = "Показать текущую активную версию NPM";
        public const string EN_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION = "Show currently active NPM version";
        public const string DE_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION = "Zeigt die aktuell aktive NPM-Version an";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_APP = "Создать новое Angular приложение через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_APP = "Create a new Angular application via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_APP = "Erstellen Sie eine neue Angular-Anwendung über die Angular-CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_COMPONENT = "Создать новый Angular компонент через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_COMPONENT = "Create a new Angular component via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_COMPONENT = "Erstellen Sie eine neue Angular-Komponente über die Angular-CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_SERVICE = "Создать новый Angular сервис через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_SERVICE = "Create a new Angular service via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_SERVICE = "Erstellen Sie einen neuen Angular-Dienst über die Angular-CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_CONFIG = "Создать новый конфигурационный файл через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_CONFIG = "Create a new configuration file via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_CONFIG = "Erstellen Sie eine neue Konfigurationsdatei über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_LIBRARY = "Создать новую библиотеку через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_LIBRARY = "Create a new library via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_LIBRARY = "Erstellen Sie eine neue Bibliothek über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_MODULE = "Создать новый модуль через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_MODULE = "Create a new module via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_MODULE = "Erstellen Sie ein neues Modul über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_ENUM = "Создать новый enum через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_ENUM = "Create a new enum via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_ENUM = "Erstellen Sie eine neue Enumeration über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_INTERFACE = "Создать новый интерфейс через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_INTERFACE = "Create a new interface via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_INTERFACE = "Erstellen Sie eine neue Schnittstelle über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_RESOLVER = "Создать новый резолвер (resolver) через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_RESOLVER = "Create a new resolver via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_RESOLVER = "Erstellen Sie einen neuen Resolver über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_PIPE = "Создать новый пайп (pipe) через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_PIPE = "Create a new pipe via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_PIPE = "Erstellen Sie eine neue Pipe über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE = "Создать новую директиву (directive) через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE = "Create a new directive via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE = "Erstellen Sie eine neue Direktive über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER = "Создать service-worker через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER = "Create service-worker via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER = "Erstellen Sie einen Servicemitarbeiter über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER = "Создать web-worker через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER = "Create a new web-worker via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER = "Erstellen Sie einen Web Worker über Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_GUARD = "Создать защитника (guard) через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_GUARD = "Create a new guard via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_GUARD = "Erstellen Sie einen Guard über die Angular CLI";

        public const string RU_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR = "Создать перехватчика (interceptor) через Angular CLI";
        public const string EN_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR = "Create a new interceptor via Angular CLI";
        public const string DE_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR = "Erstellen Sie einen Web Worker über Angular CLI";

        public const string RU_ACTION_GENERATE_ENVIRONMENTS = "Сгенерировать окружения (environments) для проекта через Angular CLI";
        public const string EN_ACTION_GENERATE_ENVIRONMENTS = "Generate environments for a project via Angular CLI";
        public const string DE_ACTION_GENERATE_ENVIRONMENTS = "Generieren Sie Umgebungen für das Projekt über Angular CLI";

        // =======================================================================================================================
        // [RU] ID поддерживаемых плагином действий
        // [EN] IDs of actions supported by the plugin
        // =======================================================================================================================
        public const string ID_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION = "show_current_active_angular_cli_version";
        public const string ID_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION = "show_current_active_nodejs_version";
        public const string ID_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION = "show_current_active_npm_version";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_APP = "create_new_angular_app_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_COMPONENT = "create_new_angular_component_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_SERVICE = "create_new_angular_service_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_CONFIG = "create_new_angular_config_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_LIBRARY = "create_new_angular_library_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_MODULE = "create_new_angular_module_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_ENUM = "create_new_angular_enum_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_INTERFACE = "create_new_angular_interface_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_RESOLVER = "create_new_angular_resolver_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_PIPE = "create_new_angular_pipe_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE = "create_new_angular_directive_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER = "create_new_angular_service_worker_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER = "create_new_angular_web_worker_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_GUARD = "create_new_angular_guard_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR = "create_new_angular_interceptor_via_angular_cli";
        public const string ID_ACTION_GENERATE_ENVIRONMENTS = "generate_environments_via_angular_cli";

        // =======================================================================================================================
        // [RU] Внутренние константы для работы плагина
        // [EN] Internal constants for plugin operation
        // =======================================================================================================================
        public const string FILENAME_ANGLULAR_CLI_VERSION = "angular_cli_version.txt";
        public const string FILENAME_NODE_VERSION = "node_version.txt";
        public const string FILENAME_NPM_VERSION = "npm_version.txt";
        private const string PARAM_NAME_CHECKBOX_OPEN_PROJECT_DIRECTORY_AFTER_CREATION = "openProjectDirectoryAfterCreation";

        // =======================================================================================================================
        // [RU] Переопределения для свойств базового класса StandardAinDevHelperPlugin
        // [EN] Overrides for properties of the StandardAinDevHelperPlugin base class
        // =======================================================================================================================
        private string RecentAngularAppName { get; set; }
        private string RecentAngularAppPath { get; set; }        
        public override string Name => "Angular Helper Plugin";
        public override string Company => "Allineed.Ru";
        public override string Description => "Плагин, предоставляющий разработчикам на Angular различные полезные действия, такие как получение информации о версиях Angular CLI, NPM, Node.js, а также облегчающий создание новых приложений и компонентов на Angular.";
        public override string Author => "Max Damascus";
        public override string AuthorEmail => "allineed.ru@gmail.com";
        public override string AuthorSiteURL => "https://allineed.ru";
        public override int MajorVersion => 1;
        public override int MinorVersion => 0;
        public override int RevisionVersion => 0;
        public override int BuildVersion => 0;
        public override IEnumerable<string> Tags => new List<string>() { "angular", "helper", WEB, WEB_DEVELOPMENT, "frontend", "cli", "angular cli", "npm", "node.js", "angular version" };
        public override IEnumerable<string> SupportedLanguageCodes => new List<string>() { RU, EN, DE };
        public override IEnumerable<AinDevHelperLocalizedMessage> LocalizedDescriptions => new HashSet<AinDevHelperLocalizedMessage>() {
            new AinDevHelperLocalizedMessage(EN, "A plugin that provides Angular developers with various useful actions, such as obtaining information about Angular CLI, NPM, Node.js versions, and also makes it easier to create new applications and components in Angular."),
            new AinDevHelperLocalizedMessage(DE, "Ein Plugin, das Angular-Entwicklern verschiedene nützliche Aktionen bietet, z. B. das Abrufen von Informationen zu Angular-CLI-, NPM- und Node.js-Versionen, und das außerdem die Erstellung neuer Anwendungen und Komponenten in Angular erleichtert."),
        };

        // =======================================================================================================================
        // [RU] Реализация методов плагина
        // [EN] Implementing plugin methods
        // =======================================================================================================================
        public override IEnumerable<AinDevHelperPluginAction> GetActions() {
            // [RU] "Создать новое Angular приложение через Angular CLI"
            // [EN] "Create a new Angular application via Angular CLI"

            AinDevHelperSettingBaseControl targetProjectsDirectoryControl = pluginSettings.GetControlByNameOrNull("targetProjectsDirectory");
            AinDevHelperSettingBaseControl newProjectAppNameControl = pluginSettings.GetControlByNameOrNull("newProjectAppName");
            AinDevHelperSettingBaseControl newComponentNameControl = pluginSettings.GetControlByNameOrNull("newComponentName");
            AinDevHelperSettingBaseControl newServiceNameControl = pluginSettings.GetControlByNameOrNull("newServiceName");
            AinDevHelperSettingBaseControl newLibraryNameControl = pluginSettings.GetControlByNameOrNull("newLibraryName");
            AinDevHelperSettingBaseControl newModuleNameControl = pluginSettings.GetControlByNameOrNull("newModuleName");
            AinDevHelperSettingBaseControl newEnumNameControl = pluginSettings.GetControlByNameOrNull("newEnumName");
            AinDevHelperSettingBaseControl newInterfaceNameControl = pluginSettings.GetControlByNameOrNull("newInterfaceName");
            AinDevHelperSettingBaseControl newResolverNameControl = pluginSettings.GetControlByNameOrNull("newResolverName");            
            AinDevHelperSettingBaseControl newPipeNameControl = pluginSettings.GetControlByNameOrNull("newPipeName");
            AinDevHelperSettingBaseControl newDirectiveNameControl = pluginSettings.GetControlByNameOrNull("newDirectiveName");
            AinDevHelperSettingBaseControl newWebWorkerNameControl = pluginSettings.GetControlByNameOrNull("newWebWorkerName");
            AinDevHelperSettingBaseControl newGuardNameControl = pluginSettings.GetControlByNameOrNull("newGuardName");
            AinDevHelperSettingBaseControl newInterceptorNameControl = pluginSettings.GetControlByNameOrNull("newInterceptorName");

            string pathForNewProjects = PluginDirectory;
            if (targetProjectsDirectoryControl is AinDevHelperSettingDirectorySelectionControl directorySelectionControl && Directory.Exists(directorySelectionControl.SelectedDirectory)) {
                pathForNewProjects = directorySelectionControl.SelectedDirectory;
            }

            string defaultAngularAppName = newProjectAppNameControl is AinDevHelperSettingTextBoxControl textBoxNewAppNameControl ? textBoxNewAppNameControl.Text : "my-angular-app";
            string defaultAngularComponentName = newComponentNameControl is AinDevHelperSettingTextBoxControl textBoxNewComponentNameControl ? textBoxNewComponentNameControl.Text : "my-angular-component";
            string defaultAngularServiceName = newServiceNameControl is AinDevHelperSettingTextBoxControl textBoxNewServiceNameControl ? textBoxNewServiceNameControl.Text : "my-angular-service";
            string defaultAngularLibraryName = newLibraryNameControl is AinDevHelperSettingTextBoxControl textBoxNewLibraryNameControl ? textBoxNewLibraryNameControl.Text : "my-angular-library";
            string defaultAngularModuleName = newModuleNameControl is AinDevHelperSettingTextBoxControl textBoxNewModuleNameControl ? textBoxNewModuleNameControl.Text : "my-angular-module";
            string defaultAngularEnumName = newEnumNameControl is AinDevHelperSettingTextBoxControl textBoxNewEnumNameControl ? textBoxNewEnumNameControl.Text : "my-angular-enum";
            string defaultAngularInterfaceName = newInterfaceNameControl is AinDevHelperSettingTextBoxControl textBoxNewInterfaceNameControl ? textBoxNewInterfaceNameControl.Text : "my-angular-interface";
            string defaultAngularResolverName = newResolverNameControl is AinDevHelperSettingTextBoxControl textBoxNewResolverNameControl ? textBoxNewResolverNameControl.Text : "my-angular-resolver";            
            string defaultAngularPipeName = newPipeNameControl is AinDevHelperSettingTextBoxControl textBoxNewPipeNameControl ? textBoxNewPipeNameControl.Text : "my-angular-pipe";
            string defaultAngularDirectiveName = newDirectiveNameControl is AinDevHelperSettingTextBoxControl textBoxNewDirectiveNameControl ? textBoxNewDirectiveNameControl.Text : "my-angular-directive";
            string defaultAngularWebWorkerName = newWebWorkerNameControl is AinDevHelperSettingTextBoxControl textBoxNewWebWorkerNameControl ? textBoxNewWebWorkerNameControl.Text : "my-angular-web-worker";
            string defaultAngularGuardName = newGuardNameControl is AinDevHelperSettingTextBoxControl textBoxNewGuardNameControl ? textBoxNewGuardNameControl.Text : "my-angular-guard";
            string defaultAngularInterceptorName = newInterceptorNameControl is AinDevHelperSettingTextBoxControl textBoxNewInterceptorNameControl ? textBoxNewInterceptorNameControl.Text : "my-angular-interceptor";

            // [RU] "Создать новое Angular приложение через Angular CLI"
            // [EN] "Create a new Angular application via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewAngularAppAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_APP, ID_ACTION_CREATE_NEW_ANGULAR_APP);
            createNewAngularAppAction.AddTextParameter(
                "appName", 
                "Название нового Angular приложения:", 
                "Название проекта, который будет создан через средства Angular CLI",
                defaultAngularAppName, 
                (EN, "Name of the new Angular application:", "The name of the project that will be created through the Angular CLI tools"),
                (DE, "Name der neuen Angular-Anwendung:", "Der Name des Projekts, das über die Angular CLI-Tools erstellt wird")
            );
            createNewAngularAppAction.AddDirectorySelectionParameter(
                "appPath", 
                "Путь для создания нового Angular проекта:", 
                "Путь файловой системы, в котором будет создан новый проект для Angular приложения",
                pathForNewProjects, 
                (EN, "Path to create a new Angular project:", "The file system path where the new project for the Angular application will be created"),
                (DE, "Pfad zum Erstellen eines neuen Angular-Projekts:", "Der Dateisystempfad, in dem das neue Projekt für die Angular-Anwendung erstellt wird")
            );
            createNewAngularAppAction.AddCheckBoxParameter(
                PARAM_NAME_CHECKBOX_OPEN_PROJECT_DIRECTORY_AFTER_CREATION, 
                "Открыть каталог проекта в Проводнике после создания", 
                "Отметьте чекбокс, если требуется открыть в Проводнике каталог сразу после его создания", 
                true,
                (EN, "Open project directory in Explorer after creation", "Check the box if you want to open a directory in Explorer immediately after its creation"), 
                (DE, "Öffnen Sie nach der Erstellung das Projektverzeichnis im Explorer", "Aktivieren Sie das Kontrollkästchen, wenn Sie ein Verzeichnis sofort nach seiner Erstellung im Explorer öffnen möchten")
            );

            createNewAngularAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_APP));
            createNewAngularAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_APP));


            // [RU] "Создать новый Angular компонент через Angular CLI"
            // [EN] "Create a new Angular component via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewAngularComponentAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_COMPONENT, ID_ACTION_CREATE_NEW_ANGULAR_COMPONENT);
            createNewAngularComponentAction.AddTextParameter(
                "newComponentName", 
                "Название нового Angular компонента:", 
                "Название нового компонента, который будет создан через Angular CLI", 
                defaultAngularComponentName, 
                (EN, "Name of the new Angular component:", "The name of the new component that will be created via Angular CLI"), 
                (DE, "Name der neuen Angular-Komponente:", "Der Name der neuen Komponente, die über Angular CLI erstellt wird")
            );
            string newAngularComponentPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewAngularComponentAction.AddDirectorySelectionParameter(
                "appPath", 
                "Путь до проекта Angular, в котором создать компонент:", 
                "Полный путь до каталога с проектом Angular, в котором будет создан новый компонент", 
                newAngularComponentPath, 
                (EN, "Path to the Angular project in which to create the component:", "Full path to the directory with the Angular project in which the new component will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem die Komponente erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die neue Komponente erstellt wird")
            );

            createNewAngularComponentAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_COMPONENT));
            createNewAngularComponentAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_COMPONENT));


            // [RU] "Создать новый Angular сервис через Angular CLI"
            // [EN] "Create a new Angular service via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewAngularServiceAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_SERVICE, ID_ACTION_CREATE_NEW_ANGULAR_SERVICE);
            createNewAngularServiceAction.AddTextParameter(
                "newServiceName", 
                "Название нового Angular сервиса:", 
                "Название сервиса, который будет создан через Angular CLI", 
                defaultAngularServiceName,
                (EN, "Name of the new Angular service:", "The name of the service that will be created via Angular CLI"),
                (DE, "Name des neuen Angular-Dienstes:", "Name des Dienstes, der über Angular CLI erstellt wird")
            );
            string newAngularServicePath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewAngularServiceAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать сервис:",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый сервис",
                newAngularServicePath,
                (EN, "Path to the Angular project in which to create the service:", "Full path to the directory with the Angular project in which the new service will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem der Dienst erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem der neue Dienst erstellt wird")
            );

            createNewAngularServiceAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_SERVICE));
            createNewAngularServiceAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_SERVICE));

            // [RU] "Создать новый конфигурационный файл через Angular CLI"
            // [EN] "Create a new configuration file via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewConfigAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_CONFIG, ID_ACTION_CREATE_NEW_ANGULAR_CONFIG);           
            AinDevHelperPluginActionDropDownListParameter configDropDownListParam = new AinDevHelperPluginActionDropDownListParameter(
                "newConfigType", 
                "Тип конфигурационного файла", 
                "Тип конфигурационного файла, который будет создан через Angular CLI"
            );
            configDropDownListParam.Values.Add(new AinDevHelperDropDownListValue("karma", "karma"));
            configDropDownListParam.Values.Add(new AinDevHelperDropDownListValue("browserslist", "browserslist"));
            configDropDownListParam.SelectedValue = new AinDevHelperDropDownListValue("karma", "karma");

            createNewConfigAction.AddDropDownListParameter(configDropDownListParam, 
                (EN, "Configuration file type", "The type of configuration file that will be created via Angular CLI"), 
                (DE, "Konfigurationsdateityp", "Der Typ der Konfigurationsdatei, die über die Angular-CLI erstellt wird"));

            createNewConfigAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_CONFIG));
            createNewConfigAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_CONFIG));

            string newAngularConfigPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewConfigAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать конфигурационный файл:",
                "Полный путь до каталога с проектом Angular, в котором будет создан конфигурационный файл",
                newAngularConfigPath,
                (EN, "Path to the Angular project in which to create the configuration file:", "Full path to the directory with the Angular project where the configuration file will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem die Konfigurationsdatei erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die Konfigurationsdatei erstellt wird")
            );

            createNewConfigAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_SERVICE));
            createNewConfigAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_SERVICE));

            // [RU] "Создать новую библиотеку через Angular CLI"
            // [EN] "Create a new library via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewLibraryAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_LIBRARY, ID_ACTION_CREATE_NEW_ANGULAR_LIBRARY);
            createNewLibraryAction.AddTextParameter(
                "newLibraryName", 
                "Название новой библиотеки:", 
                "Название новой библиотеки, которая будет создана через Angular CLI", 
                defaultAngularLibraryName, 
                (EN, "Name of the new library:", "The name of the new library that will be created via the Angular CLI"), 
                (DE, "Name der neuen Bibliothek:", "Der Name der neuen Bibliothek, die über Angular CLI erstellt wird")
            );
            
            string newAngularLibraryPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;
            createNewLibraryAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новую библиотеку:",
                "Полный путь до каталога с проектом Angular, в котором будет создана новая библиотека",
                newAngularLibraryPath,
                (EN, "Path to the Angular project in which to create a new library:", "Full path to the directory with the Angular project in which the new library will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem eine neue Bibliothek erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die neue Bibliothek erstellt wird")
            );

            createNewLibraryAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_LIBRARY));
            createNewLibraryAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_LIBRARY));

            // [RU] "Создать новый модуль через Angular CLI"
            // [EN] "Create a new module via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewModuleAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_MODULE, ID_ACTION_CREATE_NEW_ANGULAR_MODULE);
            createNewModuleAction.AddTextParameter(
                "newModuleName", 
                "Название нового модуля:", 
                "Название нового модуля, который будет создан через Angular CLI", 
                defaultAngularModuleName,
                (EN, "Name of the new module:", "The name of the new module that will be created via Angular CLI"),
                (DE, "Name des neuen Moduls:", "Der Name des neuen Moduls, das über Angular CLI erstellt wird")
            );
            string newAngularModulePath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewModuleAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новый модуль:",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый модуль",
                newAngularModulePath,
                (EN, "Path to the Angular project in which to create a new module:", "Full path to the directory with the Angular project in which the new module will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem ein neues Modul erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem das neue Modul erstellt wird")
            );

            createNewModuleAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_MODULE));
            createNewModuleAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_MODULE));

            // [RU] "Создать новый enum через Angular CLI"
            // [EN] "Create a new enum via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewEnumAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_ENUM, ID_ACTION_CREATE_NEW_ANGULAR_ENUM);
            createNewEnumAction.AddTextParameter(
                "newEnumName",
                "Название нового enum:",
                "Название нового enum, который будет создан через Angular CLI",
                defaultAngularEnumName,
                (EN, "Name of the new enum:", "The name of the new enum that will be created via the Angular CLI"),
                (DE, "Name der neuen Enumeration:", "Der Name der neuen Enumeration, die über Angular CLI erstellt wird")
            );
            string newAngularEnumPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewEnumAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новый enum:",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый enum",
                newAngularEnumPath,
                (EN, "Path to the Angular project in which to create the new enum:", "Full path to the directory with the Angular project in which the new enum will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem eine neue Enumeration erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die neue Enumeration erstellt wird")
            );

            createNewEnumAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_ENUM));
            createNewEnumAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_ENUM));

            // [RU] "Создать новый интерфейс через Angular CLI"
            // [EN] "Create a new interface via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewInterfaceAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_INTERFACE, ID_ACTION_CREATE_NEW_ANGULAR_INTERFACE);
            createNewInterfaceAction.AddTextParameter(
                "newInterfaceName",
                "Название нового интерфейса:",
                "Название нового интерфейса, который будет создан через Angular CLI",
                defaultAngularInterfaceName,
                (EN, "Name of the new interface:", "The name of the new interface that will be created via Angular CLI"),
                (DE, "Name der neuen Schnittstelle:", "Der Name der neuen Schnittstelle, die über Angular CLI erstellt wird")
            );

            string newAngularInterfacePath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewInterfaceAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новый интерфейс:",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый интерфейс",
                newAngularInterfacePath,
                (EN, "Path to the Angular project in which to create a new interface:", "Full path to the directory with the Angular project in which the new interface will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem eine neue Schnittstelle erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die neue Schnittstelle erstellt wird")
            );

            createNewInterfaceAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_INTERFACE));
            createNewInterfaceAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_INTERFACE));

            // [RU] "Создать новый резолвер (resolver) через Angular CLI"
            // [EN] "Create a new resolver via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewResolverAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_RESOLVER, ID_ACTION_CREATE_NEW_ANGULAR_RESOLVER);
            createNewResolverAction.AddTextParameter(
                "newResolverName",
                "Название нового резолвера:",
                "Название нового резолвера, который будет создан через Angular CLI",
                defaultAngularResolverName,
                (EN, "Name of the new resolver:", "The name of the new resolver that will be created via the Angular CLI"),
                (DE, "Name des neuen Resolvers:", "Der Name des neuen Resolvers, der über Angular CLI erstellt wird")
            );

            string newAngularResolverPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewResolverAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новый резолвер:",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый резолвер",
                newAngularResolverPath,
                (EN, "Path to the Angular project in which to create a new resolver:", "Full path to the directory with the Angular project where the new resolver will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem ein neuer Resolver erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem der neue Resolver erstellt wird")
            );

            createNewResolverAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_RESOLVER));
            createNewResolverAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_RESOLVER));

            // [RU] "Создать новый пайп (pipe) через Angular CLI"
            // [EN] "Create a new pipe via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewPipeAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_PIPE, ID_ACTION_CREATE_NEW_ANGULAR_PIPE);
            createNewPipeAction.AddTextParameter(
                "newPipeName",
                "Название нового пайп (pipe):",
                "Название нового пайп (pipe), который будет создан через Angular CLI",
                defaultAngularPipeName,
                (EN, "Name of the new pipe:", "The name of the new pipe that will be created via the Angular CLI"),
                (DE, "Name der neuen Pipe:", "Der Name der neuen Pipe, die über die Angular CLI erstellt wird")
            );

            string newAngularPipePath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewPipeAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новый пайп (pipe):",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый пайп (pipe)",
                newAngularPipePath,
                (EN, "Path to the Angular project in which to create a new pipe:", "Full path to the directory with the Angular project where the new pipe will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem eine neue Pipe erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die neue Pipe erstellt wird")
            );

            createNewPipeAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_PIPE));
            createNewPipeAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_PIPE));

            // [RU] "Создать новую директиву (directive) через Angular CLI"
            // [EN] "Create a new directive via Angular CLI"
            AinDevHelperPluginParameterizedAction createNewDirectiveAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE, ID_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE);
            createNewDirectiveAction.AddTextParameter(
                "newDirectiveName",
                "Название новой директивы (directive):",
                "Название новой директивы (directive), которая будет создана через Angular CLI",
                defaultAngularDirectiveName,
                (EN, "Name of the new directive:", "The name of the new directive that will be created via the Angular CLI"),
                (DE, "Name der neuen Direktive:", "Der Name der neuen Direktive, die über die Angular CLI erstellt wird")
            );

            string newAngularDirectivePath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewDirectiveAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новую директиву (directive):",
                "Полный путь до каталога с проектом Angular, в котором будет создана новая директива (directive)",
                newAngularDirectivePath,
                (EN, "Path to the Angular project in which to create a new directive:", "Full path to the directory with the Angular project where the new directive will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem eine neue Direktive erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die neue Direktive erstellt wird")
            );

            createNewDirectiveAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE));
            createNewDirectiveAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE));

            // [RU] Создать service-worker через Angular CLI
            // [EN] Create service-worker via Angular CLI
            AinDevHelperPluginParameterizedAction createServiceWorkerAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER, ID_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER);

            string newAngularServiceWorkerPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createServiceWorkerAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать service-worker:",
                "Полный путь до каталога с проектом Angular, в котором будет создан service-worker",
                newAngularServiceWorkerPath,
                (EN, "Path to the Angular project in which to create the service-worker:", "Full path to the directory with the Angular project where the service-worker will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem ein Service-Worker erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem der Service-Worker erstellt wird")
            );

            createServiceWorkerAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER));
            createServiceWorkerAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER));

            // [RU] Создать web-worker через Angular CLI
            // [EN] Create web-worker via Angular CLI
            AinDevHelperPluginParameterizedAction createNewWebWorkerAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER, ID_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER);

            createNewWebWorkerAction.AddTextParameter(
                "newWebWorkerName",
                "Название нового web-worker:",
                "Название нового web-worker, который будет создан через Angular CLI",
                defaultAngularWebWorkerName,
                (EN, "Name of the new web-worker:", "The name of the new web worker that will be created via the Angular CLI"),
                (DE, "Name des neuen Web-Workers:", "Der Name des neuen Web-Workers, der über Angular CLI erstellt wird")
            );

            string newAngularWebWorkerPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewWebWorkerAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать новый web-worker:",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый web-worker",
                newAngularWebWorkerPath,
                (EN, "Path to the Angular project in which to create a new web-worker:", "Full path to the directory with the Angular project where the new web-worker will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem ein neuer Web-Worker erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem der neue Web-Worker erstellt wird")
            );

            createNewWebWorkerAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER));
            createNewWebWorkerAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER));

            // [RU] Создать защитника (guard) через Angular CLI
            // [EN] Create a new guard via Angular CLI
            AinDevHelperPluginParameterizedAction createNewGuardAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_GUARD, ID_ACTION_CREATE_NEW_ANGULAR_GUARD);

            createNewGuardAction.AddTextParameter(
                "newGuardName",
                "Название нового защитника (guard):",
                "Название нового защитника (guard), который будет создан через Angular CLI",
                defaultAngularGuardName,
                (EN, "Name of the new guard:", "The name of the new guard that will be created via the Angular CLI"),
                (DE, "Name des neuen Guards:", "Der Name des neuen Guards, der über die Angular CLI erstellt wird")
            );

            string newAngularGuardPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewGuardAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать нового защитника (guard):",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый защитник (guard)",
                newAngularGuardPath,
                (EN, "Path to Angular project where to create a new guard:", "Full path to the directory with the Angular project where the new guard will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem ein neuer Guard erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem der neue Guard erstellt wird")
            );

            createNewGuardAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_GUARD));
            createNewGuardAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_GUARD));

            // [RU] Создать перехватчика (interceptor) через Angular CLI
            // [EN] Create a new interceptor via Angular CLI
            AinDevHelperPluginParameterizedAction createNewInterceptorAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR, ID_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR);

            createNewInterceptorAction.AddTextParameter(
                "newInterceptorName",
                "Название нового перехватчика (interceptor):",
                "Название нового перехватчика (interceptor), который будет создан через Angular CLI",
                defaultAngularInterceptorName,
                (EN, "Name of the new interceptor:", "The name of the new interceptor that will be created via the Angular CLI"),
                (DE, "Name des neuen Interceptors:", "Der Name des neuen Interceptors, der über die Angular-CLI erstellt wird")
            );

            string newAngularInterceptorPath = string.IsNullOrEmpty(RecentAngularAppPath) ? pathForNewProjects : RecentAngularAppPath;

            createNewInterceptorAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором создать нового перехватчика (interceptor):",
                "Полный путь до каталога с проектом Angular, в котором будет создан новый перехватчик (interceptor)",
                newAngularInterceptorPath,
                (EN, "Path to the Angular project in which to create a new interceptor:", "Full path to the directory with the Angular project in which the new interceptor will be created"),
                (DE, "Pfad zum Angular-Projekt, in dem ein neuer Interceptor erstellt werden soll:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem der neue Interceptor erstellt wird")
            );

            createNewInterceptorAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR));
            createNewInterceptorAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR));

            // [RU] Сгенерировать окружения (environments) для проекта через Angular CLI
            // [EN] Generate environments for a project via Angular CLI
            AinDevHelperPluginParameterizedAction generateEnvironmentsAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_GENERATE_ENVIRONMENTS, ID_ACTION_GENERATE_ENVIRONMENTS);
            generateEnvironmentsAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до проекта Angular, в котором сгенерировать окружения (environments):",
                "Полный путь до каталога с проектом Angular, в котором будут сгенерированы окружения (environments)",
                newAngularWebWorkerPath,
                (EN, "Path to the Angular project in which to generate environments:", "Full path to the directory with the Angular project, in which the environments will be generated"),
                (DE, "Pfad zum Angular-Projekt, in dem Umgebungen generiert werden sollen:", "Vollständiger Pfad zum Verzeichnis mit dem Angular-Projekt, in dem die Umgebungen generiert werden")
            );
            generateEnvironmentsAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_GENERATE_ENVIRONMENTS));
            generateEnvironmentsAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_GENERATE_ENVIRONMENTS));

            /*
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_SERVICE = "create_new_angular_service_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_CONFIG = "create_new_angular_config_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_LIBRARY = "create_new_angular_library_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_MODULE = "create_new_angular_module_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_ENUM = "create_new_angular_enum_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_INTERFACE = "create_new_angular_interface_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_RESOLVER = "create_new_angular_resolver_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_PIPE = "create_new_angular_pipe_via_angular_cli";
                [+] public const string ID_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE = "create_new_angular_directive_via_angular_cli";
                    public const string ID_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER = "create_new_angular_service_worker_via_angular_cli";
                    public const string ID_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER = "create_new_angular_web_worker_via_angular_cli"; 
             */



            return AinDevHelperPluginAction.From(
                AinDevHelperPluginAction.ActionFrom(RU_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION, ID_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION,
                    (EN, EN_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION),
                    (DE, DE_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION)),
                AinDevHelperPluginAction.ActionFrom(RU_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION, ID_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION,
                    (EN, EN_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION),
                    (DE, DE_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION)),
                AinDevHelperPluginAction.ActionFrom(RU_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION, ID_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION,
                    (EN, EN_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION),
                    (DE, DE_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION)),                    
                createNewAngularAppAction,
                createNewAngularComponentAction,
                createNewAngularServiceAction,
                createNewConfigAction,
                createNewLibraryAction,
                createNewModuleAction,
                createNewEnumAction,
                createNewInterfaceAction,
                createNewResolverAction,
                createNewPipeAction,
                createNewDirectiveAction,
                createServiceWorkerAction,
                createNewWebWorkerAction,
                createNewGuardAction,
                createNewInterceptorAction,
                generateEnvironmentsAction
            );
        }

        public override AinDevHelperPluginActionResult RunAction(AinDevHelperPluginAction actionToRun) {
            string actionId = actionToRun.ID;

            if (ID_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION.Equals(actionId)) {
                return ShowCurrentActiveAngularCLIVersion(actionToRun);
            } else if (ID_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION.Equals(actionId)) {
                return ShowCurrentActiveNodeVersion(actionToRun);
            } else if (ID_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION.Equals(actionId)) {
                return ShowCurrentActiveNPMVersion(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_APP.Equals(actionId)) {
                return CreateNewAngularApp(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_COMPONENT.Equals(actionId)) {
                return CreateNewAngularComponent(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_SERVICE.Equals(actionId)) {
                return CreateNewAngularService(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_CONFIG.Equals(actionId)) {
                return CreateNewAngularConfig(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_LIBRARY.Equals(actionId)) {
                return CreateNewAngularLibrary(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_MODULE.Equals(actionId)) {
                return CreateNewAngularModule(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_ENUM.Equals(actionId)) {
                return CreateNewAngularEnum(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_INTERFACE.Equals(actionId)) {
                return CreateNewAngularInterface(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_RESOLVER.Equals(actionId)) {
                return CreateNewAngularResolver(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_PIPE.Equals(actionId)) {
                return CreateNewAngularPipe(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_DIRECTIVE.Equals(actionId)) {
                return CreateNewAngularDirective(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_SERVICE_WORKER.Equals(actionId)) {
                return CreateNewAngularServiceWorker(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_WEB_WORKER.Equals(actionId)) {
                return CreateNewAngularWebWorker(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_GUARD.Equals(actionId)) {
                return CreateNewAngularGuard(actionToRun);
            } else if (ID_ACTION_CREATE_NEW_ANGULAR_INTERCEPTOR.Equals(actionId)) {
                return CreateNewAngularInterceptor(actionToRun);
            } else if (ID_ACTION_GENERATE_ENVIRONMENTS.Equals(actionId)) {
                return GenerateAngularEnvironments(actionToRun);
            }

            return GetErroneousResponseActionNotRecognized(actionToRun);
        }

        /// <summary>
        /// [RU] Метод для действия по отображению текущей активной версии Angular CLI, установленной на компьютере<br/>
        /// [EN] Method for action to display the current active version of Angular CLI installed on the machine
        /// </summary>
        /// <param name="actionToRun">[RU] экземпляр действия для выполнения, передаваемый от AinDevHelper;<br/>[EN] an instance of the action to execute, passed from AinDevHelper</param>
        /// <returns>[RU] экземпляр <see cref="AinDevHelperPluginActionResult"/>, описывающий результат выполнения действия плагина;<br/>[EN] <see cref="AinDevHelperPluginActionResult"/> instance describing the result of executing the plugin action</returns>
        private AinDevHelperPluginActionResult ShowCurrentActiveAngularCLIVersion(AinDevHelperPluginAction actionToRun) {            
            try {
                AinCommandLineHelper.RunProcessWithoutWindow(PluginDirectory, "cmd", $"/c ng version 1> {FILENAME_ANGLULAR_CLI_VERSION}");
                string outputFile = Path.Combine(PluginDirectory, FILENAME_ANGLULAR_CLI_VERSION);

                if (File.Exists(outputFile)) {
                    string commandOutput = File.ReadAllText(outputFile);
                    commandOutput = commandOutput.Replace("\n", "\r\n");
                    return new AinDevHelperPluginActionResult(this, actionToRun, commandOutput);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }

            return GetErroneousResponseFileWasNotFound(actionToRun, FILENAME_ANGLULAR_CLI_VERSION);            
        }

        /// <summary>
        /// [RU] Метод для действия по отображению текущей активной версии установленного Node.js<br/>
        /// [EN] Method for the action to display the currently active version of Node.js installed
        /// </summary>
        /// <param name="actionToRun">[RU] экземпляр действия для выполнения, передаваемый от AinDevHelper;<br/>[EN] an instance of the action to execute, passed from AinDevHelper</param>
        /// <returns>[RU] экземпляр <see cref="AinDevHelperPluginActionResult"/>, описывающий результат выполнения действия плагина;<br/>[EN] <see cref="AinDevHelperPluginActionResult"/> instance describing the result of executing the plugin action</returns>
        private AinDevHelperPluginActionResult ShowCurrentActiveNodeVersion(AinDevHelperPluginAction actionToRun) {            
            try {
                AinCommandLineHelper.RunProcessWithoutWindow(PluginDirectory, "cmd", $"/c node -v 1> {FILENAME_NODE_VERSION}");
                string outputFile = Path.Combine(PluginDirectory, FILENAME_NODE_VERSION);

                if (File.Exists(outputFile)) {
                    string commandOutput = File.ReadAllText(outputFile);
                    return new AinDevHelperPluginActionResult(this, actionToRun, commandOutput);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }

            return GetErroneousResponseFileWasNotFound(actionToRun, FILENAME_NODE_VERSION);
        }

        private AinDevHelperPluginActionResult ShowCurrentActiveNPMVersion(AinDevHelperPluginAction actionToRun) {            
            try {
                AinCommandLineHelper.RunProcessWithoutWindow(PluginDirectory, "cmd", $"/c npm -v 1> {FILENAME_NPM_VERSION}");
                string outputFile = Path.Combine(PluginDirectory, FILENAME_NPM_VERSION);

                if (File.Exists(outputFile)) {
                    string commandOutput = File.ReadAllText(outputFile);                    
                    return new AinDevHelperPluginActionResult(this, actionToRun, commandOutput);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }

            return GetErroneousResponseFileWasNotFound(actionToRun, FILENAME_NPM_VERSION);
        }

        private StringBuilder GetFileContentsAndDeleteFileIfExists(string filePath) {
            StringBuilder sbAdditionalInfo = new StringBuilder();
            if (File.Exists(filePath)) {
                string[] lines = File.ReadAllLines(filePath);
                if (lines != null && lines.Length > 0) {
                    sbAdditionalInfo.Append("\r\n");
                    foreach (string line in lines) {
                        sbAdditionalInfo.Append("\r\n").Append(line);
                    }
                }
                File.Delete(filePath);
            }
            return sbAdditionalInfo;
        }

        private AinDevHelperPluginActionResult CreateNewAngularApp(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewApp) {
                    RecentAngularAppName = parameterizedActionCreateNewApp.GetTextParameterValue("appName");
                    string targetDirectory = parameterizedActionCreateNewApp.GetDirectorySelectionParameterValue("appPath");

                    if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, targetDirectory);
                    }

                    int procExitCode = AinCommandLineHelper.RunProcessWithWindow(targetDirectory, "cmd", "/c ng new " + RecentAngularAppName + " 1> new_angular_app.txt");

                    if (procExitCode == 0) {
                        RecentAngularAppPath = Path.Combine(targetDirectory, RecentAngularAppName);
                        string outputFile = Path.Combine(targetDirectory, "new_angular_app.txt");

                        StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputFile);

                        bool isOpenProjectDirectoryAfterCreation = parameterizedActionCreateNewApp.GetCheckBoxParameterValue(PARAM_NAME_CHECKBOX_OPEN_PROJECT_DIRECTORY_AFTER_CREATION);
                        if (isOpenProjectDirectoryAfterCreation) {
                            Process.Start(RecentAngularAppPath);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Angular приложение '{RecentAngularAppName}' успешно создано в директории '{targetDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"Angular application '{RecentAngularAppName}' successfully created in the '{targetDirectory}' directory.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die Angular-App „{RecentAngularAppName}“ wurde erfolgreich im Verzeichnis „{targetDirectory}“ erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    } else {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Angular приложение '{RecentAngularAppName}' не создано в директории '{targetDirectory}'. Код завершения процесса не равен 0: {procExitCode}",
                            true,
                            (EN, $"Angular application '{RecentAngularAppName}' is not created in directory '{targetDirectory}'. Process exit code is not 0: {procExitCode}"),
                            (DE, $"Die Angular-App „{RecentAngularAppName}“ wurde nicht im Verzeichnis „{targetDirectory}“ erstellt. Prozess-Exit-Code ist nicht 0: {procExitCode}")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }            
        }

        private AinDevHelperPluginActionResult CreateNewAngularComponent(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularComponent) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularComponent.GetDirectorySelectionParameterValue("appPath");
                    string newComponentName = parameterizedActionCreateNewAngularComponent.GetTextParameterValue("newComponentName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate component " + newComponentName + " 1> new_angular_component.txt 2> new_angular_component_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_component.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_component_error.txt");


                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular компонент '{newComponentName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular component '{newComponentName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die neue Angular-Komponente „{newComponentName}“ wurde erfolgreich für das Projekt „{workingAngularProjectDirectory}“ erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular компонент '{newComponentName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"The new Angular component '{newComponentName}' was not created for the project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Komponente „{newComponentName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular компонент '{newComponentName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"The new Angular component '{newComponentName}' was not created for the project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Komponente „{newComponentName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularService(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularService) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularService.GetDirectorySelectionParameterValue("appPath");
                    string newServiceName = parameterizedActionCreateNewAngularService.GetTextParameterValue("newServiceName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate service " + newServiceName + " 1> new_angular_service.txt 2> new_angular_service_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_service.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_service_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular сервис '{newServiceName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular service '{newServiceName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die neue Angular-Dienst „{newServiceName}“ wurde erfolgreich für das Projekt „{workingAngularProjectDirectory}“ erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular сервис '{newServiceName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular service '{newServiceName}' was not created for the project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Dienst „{newServiceName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular компонент  '{newServiceName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular service '{newServiceName}' was not created for the project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Dienst „{newServiceName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularConfig(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularConfig) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularConfig.GetDirectorySelectionParameterValue("appPath");
                    string newConfigType = parameterizedActionCreateNewAngularConfig.GetDropDownListParameterSelectedValueName("newConfigType");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate config " + newConfigType + " 1> new_angular_config.txt 2> new_angular_config_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_config.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_config_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular конфигурационный файл с типом '{newConfigType}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular config file with type '{newConfigType}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die neue Angular-Konfigurationsdatei mit dem Typ „{newConfigType}“ wurde erfolgreich für das Projekt „{workingAngularProjectDirectory}“ erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular конфигурационный файл с типом '{newConfigType}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"The new Angular config file with type '{newConfigType}' was not created for the project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Konfigurationsdatei mit dem Typ „{newConfigType}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular конфигурационный файл с типом '{newConfigType}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"The new Angular config file with type '{newConfigType}' was not created for the project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Konfigurationsdatei mit dem Typ „{newConfigType}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularLibrary(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularLibrary) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularLibrary.GetDirectorySelectionParameterValue("appPath");
                    string newLibraryName = parameterizedActionCreateNewAngularLibrary.GetTextParameterValue("newLibraryName");
                    


                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate library " + newLibraryName + " 1> new_angular_library.txt 2> new_angular_library_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_library.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_library_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новая Angular библиотека '{newLibraryName}' успешно создана для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular library '{newLibraryName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die neue Angular-Bibliothek „{newLibraryName}“ wurde erfolgreich für das Projekt „{workingAngularProjectDirectory}“ erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новая Angular библиотека '{newLibraryName}' не была создана для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular library '{newLibraryName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Bibliothek „{newLibraryName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новая Angular библиотека '{newLibraryName}' не была создана для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular library '{newLibraryName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Bibliothek „{newLibraryName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularModule(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularModule) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularModule.GetDirectorySelectionParameterValue("appPath");
                    string newModuleName = parameterizedActionCreateNewAngularModule.GetTextParameterValue("newModuleName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate module " + newModuleName + " 1> new_angular_module.txt 2> new_angular_module_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_module.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_module_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular модуль '{newModuleName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular module '{newModuleName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Das neue Angular-Modul „{newModuleName}“ wurde erfolgreich für das Projekt „{workingAngularProjectDirectory}“ erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular модуль '{newModuleName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular module '{newModuleName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Das neue Angular-Modul „{newModuleName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular модуль '{newModuleName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular module '{newModuleName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Das neue Angular-Modul „{newModuleName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularEnum(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularEnum) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularEnum.GetDirectorySelectionParameterValue("appPath");
                    string newEnumName = parameterizedActionCreateNewAngularEnum.GetTextParameterValue("newEnumName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate enum " + newEnumName + " 1> new_angular_enum.txt 2> new_angular_enum_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_enum.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_enum_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular enum '{newEnumName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular enum '{newEnumName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Neue Angular-Enumeration „{newEnumName}“ für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular enum '{newEnumName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular enum '{newEnumName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Enumeration „{newEnumName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular enum '{newEnumName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular enum '{newEnumName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Enumeration „{newEnumName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularInterface(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularInterface) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularInterface.GetDirectorySelectionParameterValue("appPath");
                    string newInterfaceName = parameterizedActionCreateNewAngularInterface.GetTextParameterValue("newInterfaceName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate interface " + newInterfaceName + " 1> new_angular_interface.txt 2> new_angular_interface_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_interface.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_interface_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular интерфейс '{newInterfaceName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular interface '{newInterfaceName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Neue Angular-Schnittstelle „{newInterfaceName}“ für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular интерфейс '{newInterfaceName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular interface '{newInterfaceName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Schnittstelle „{newInterfaceName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular интерфейс '{newInterfaceName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular interface '{newInterfaceName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Schnittstelle „{newInterfaceName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularResolver(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularResolver) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularResolver.GetDirectorySelectionParameterValue("appPath");
                    string newResolverName = parameterizedActionCreateNewAngularResolver.GetTextParameterValue("newResolverName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate resolver " + newResolverName + " 1> new_angular_resolver.txt 2> new_angular_resolver_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_resolver.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_resolver_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular резолвер (resolver) '{newResolverName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular resolver '{newResolverName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Der neue Angular-Resolver „{newResolverName}“ für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular резолвер (resolver) '{newResolverName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular resolver '{newResolverName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Der neue Angular-Resolver „{newResolverName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular резолвер (resolver) '{newResolverName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular resolver '{newResolverName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Der neue Angular-Resolver „{newResolverName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularPipe(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularPipe) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularPipe.GetDirectorySelectionParameterValue("appPath");
                    string newPipeName = parameterizedActionCreateNewAngularPipe.GetTextParameterValue("newPipeName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate pipe " + newPipeName + " 1> new_angular_pipe.txt 2> new_angular_pipe_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_pipe.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_pipe_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular пайп (pipe) '{newPipeName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular pipe '{newPipeName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die neue Angular-Pipe „{newPipeName}“ für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular пайп (pipe) '{newPipeName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular pipe '{newPipeName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Pipe „{newPipeName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новый Angular пайп (pipe) '{newPipeName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular pipe '{newPipeName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Pipe „{newPipeName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularDirective(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularDirective) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularDirective.GetDirectorySelectionParameterValue("appPath");
                    string newDirectiveName = parameterizedActionCreateNewAngularDirective.GetTextParameterValue("newDirectiveName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate directive " + newDirectiveName + " 1> new_angular_directive.txt 2> new_angular_directive_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_directive.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_directive_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новая Angular директива '{newDirectiveName}' успешно создана для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"New Angular directive '{newDirectiveName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Die neue Angular-Direktive „{newDirectiveName}“ für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новая Angular директива '{newDirectiveName}' не была создана для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"New Angular directive '{newDirectiveName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Die neue Angular-Direktive „{newDirectiveName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Новая Angular директива '{newDirectiveName}' не была создана для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"New Angular directive '{newDirectiveName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Die neue Angular-Direktive „{newDirectiveName}“ wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularServiceWorker(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularServiceWorker) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularServiceWorker.GetDirectorySelectionParameterValue("appPath");                    

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate service-worker 1> new_angular_service_worker.txt 2> new_angular_service_worker_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_service_worker.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_service_worker_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"service-worker успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"service-worker successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"service-worker für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"service-worker не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"service-worker was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"service-worker wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"service-worker не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"service-worker was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"service-worker wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularWebWorker(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularWebWorker) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularWebWorker.GetDirectorySelectionParameterValue("appPath");
                    string newWebWorkerName = parameterizedActionCreateNewAngularWebWorker.GetTextParameterValue("newWebWorkerName");
                    
                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate web-worker " + newWebWorkerName + " 1> new_angular_web_worker.txt 2> new_angular_web_worker_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_web_worker.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_web_worker_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"web-worker '{newWebWorkerName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"web-worker '{newWebWorkerName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"web-worker '{newWebWorkerName}' für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"web-worker '{newWebWorkerName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"web-worker '{newWebWorkerName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"web-worker '{newWebWorkerName}' wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"web-worker '{newWebWorkerName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"web-worker '{newWebWorkerName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"web-worker '{newWebWorkerName}' wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularGuard(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularWebWorker) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularWebWorker.GetDirectorySelectionParameterValue("appPath");
                    string newGuardName = parameterizedActionCreateNewAngularWebWorker.GetTextParameterValue("newGuardName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate guard " + newGuardName + " 1> new_angular_guard.txt 2> new_angular_guard_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_guard.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_guard_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Защитник (guard) '{newGuardName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"Guard '{newGuardName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Guard '{newGuardName}' für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Защитник (guard) '{newGuardName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"Guard '{newGuardName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Guard '{newGuardName}' wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Защитник (guard) '{newGuardName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"Guard '{newGuardName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Guard '{newGuardName}' wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult CreateNewAngularInterceptor(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularWebWorker) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularWebWorker.GetDirectorySelectionParameterValue("appPath");
                    string newInterceptorName = parameterizedActionCreateNewAngularWebWorker.GetTextParameterValue("newInterceptorName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate interceptor " + newInterceptorName + " 1> new_angular_interceptor.txt 2> new_angular_interceptor_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_interceptor.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_interceptor_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Перехватчик (interceptor) '{newInterceptorName}' успешно создан для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"Interceptor '{newInterceptorName}' successfully created for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Interceptor '{newInterceptorName}' für Projekt „{workingAngularProjectDirectory}“ erfolgreich erstellt.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Перехватчик (interceptor) '{newInterceptorName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"Interceptor '{newInterceptorName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Interceptor '{newInterceptorName}' wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Перехватчик (interceptor) '{newInterceptorName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"Interceptor '{newInterceptorName}' was not created for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Interceptor '{newInterceptorName}' wurde nicht für das Projekt „{workingAngularProjectDirectory}“ erstellt, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        private AinDevHelperPluginActionResult GenerateAngularEnvironments(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewAngularWebWorker) {
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularWebWorker.GetDirectorySelectionParameterValue("appPath");                    

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate environments 1> new_angular_environments.txt 2> new_angular_environments_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_environments.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_environments_error.txt");

                    StringBuilder sbAdditionalInfo = GetFileContentsAndDeleteFileIfExists(outputLogFile);
                    if (sbAdditionalInfo.Length > 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Окружения успешно сгенерированы для проекта '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}",
                            true,
                            (EN, $"Environments generated successfully for project '{workingAngularProjectDirectory}'.{sbAdditionalInfo.ToString()}"),
                            (DE, $"Umgebungen für Projekt „{workingAngularProjectDirectory}“ erfolgreich generiert.{sbAdditionalInfo.ToString()}")
                        );
                    }

                    StringBuilder sbErrorLogDetails = GetFileContentsAndDeleteFileIfExists(outputErrorLogFile);
                    if (sbErrorLogDetails.Length > 0) {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Окружения не были сгенерированы для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:{sbErrorLogDetails.ToString()}",
                            true,
                            (EN, $"Environments were not generated for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the package.json file. Additional error details:{sbErrorLogDetails.ToString()}"),
                            (DE, $"Für das Projekt „{workingAngularProjectDirectory}“ wurden keine Umgebungen generiert, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei package.json vorhanden ist. Zusätzliche Fehlerdetails:{sbErrorLogDetails.ToString()}")
                        );
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }

                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            AinDevHelperPluginActionResult.ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Окружения не были сгенерированы для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла 'package.json'.",
                            true,
                            (EN, $"Environments were not generated for project '{workingAngularProjectDirectory}' because the target directory is not a valid project. Check for the presence of the 'package.json' file."),
                            (DE, $"Für das Projekt „{workingAngularProjectDirectory}“ wurden keine Umgebungen generiert, da das Zielverzeichnis kein gültiges Projekt ist. Überprüfen Sie, ob die Datei 'package.json' vorhanden ist.")
                        );
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        public override void Initialize() {
            AinDevHelperSettingDirectorySelectionControl directorySelection = new AinDevHelperSettingDirectorySelectionControl("targetProjectsDirectory", "Директория для новых проектов:", PluginDirectory);
            
            directorySelection.Width = 420;
            directorySelection.OffsetLeft = 10;
            directorySelection.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(EN, "Directory for new projects:"));
            directorySelection.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(DE, "Verzeichnis für neue Projekte:"));

            pluginSettings.AddSettingControl(directorySelection);

            AinDevHelperSettingTextBoxControl textBoxNewProjectName = new AinDevHelperSettingTextBoxControl("newProjectAppName", "Название для нового проекта:", "my-angular-app");
            textBoxNewProjectName.OffsetLeft = 10;
            textBoxNewProjectName.Width = 550;
            textBoxNewProjectName.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(EN, "Name for the new project:"));
            textBoxNewProjectName.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(DE, "Name für das neue Projekt:"));

            pluginSettings.AddSettingControl(textBoxNewProjectName);

            AinDevHelperSettingTextBoxControl textBoxNewComponentName = new AinDevHelperSettingTextBoxControl("newComponentName", "Название для нового компонента:", "my-angular-component");
            textBoxNewComponentName.OffsetLeft = 10;
            textBoxNewComponentName.Width = 550;
            textBoxNewComponentName.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(EN, "Name for the new component:"));
            textBoxNewComponentName.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(DE, "Name für die neue Komponente:"));

            pluginSettings.AddSettingControl(textBoxNewComponentName);
        }
    }
}
