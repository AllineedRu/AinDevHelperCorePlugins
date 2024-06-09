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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using AinDevHelperPluginLibrary;
using AinDevHelperPluginLibrary.Actions;
using AinDevHelperPluginLibrary.Language;
using static AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants;
using static AinDevHelperPluginLibrary.Actions.AinDevHelperPluginActionCoreTagsConstants;

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

        // =======================================================================================================================
        // [RU] ID поддерживаемых плагином действий
        // [EN] IDs of actions supported by the plugin
        // =======================================================================================================================
        public const string ID_ACTION_SHOW_CURRENT_ACTIVE_ANGULAR_CLI_VERSION = "show_current_active_angular_cli_version";
        public const string ID_ACTION_SHOW_CURRENT_ACTIVE_NODE_VERSION = "show_current_active_nodejs_version";
        public const string ID_ACTION_SHOW_CURRENT_ACTIVE_NPM_VERSION = "show_current_active_npm_version";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_APP = "create_new_angular_app_via_angular_cli";
        public const string ID_ACTION_CREATE_NEW_ANGULAR_COMPONENT = "create_new_angular_component_via_angular_cli";

        // =======================================================================================================================
        // [RU] Внутренние константы для работы плагина
        // [EN] Internal constants for plugin operation
        // =======================================================================================================================
        public const string FILENAME_ANGLULAR_CLI_VERSION = "angular_cli_version.txt";
        public const string FILENAME_NODE_VERSION = "node_version.txt";
        public const string FILENAME_NPM_VERSION = "npm_version.txt";

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
            AinDevHelperPluginParameterizedAction createNewAngularAppAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_APP, ID_ACTION_CREATE_NEW_ANGULAR_APP);
            createNewAngularAppAction.AddTextParameter("appName", "Название нового Angular приложения:", "Название проекта, который будет создан через Angular CLI", "my-angular-app");
            createNewAngularAppAction.AddTextParameter("appPath", "Путь для создания нового Angular проекта:", "Путь файловой системы, в котором будет создан новый проект для Angular приложения", Host.GetAppStartupPath());

            createNewAngularAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_APP));
            createNewAngularAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_APP));


            AinDevHelperPluginParameterizedAction createNewAngularComponentAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_ANGULAR_COMPONENT, ID_ACTION_CREATE_NEW_ANGULAR_COMPONENT);
            createNewAngularComponentAction.AddTextParameter("newComponentName", "Название нового Angular компонента:", "Название компонента, который будет создан через Angular CLI", "my-angular-component");
            if (string.IsNullOrEmpty(RecentAngularAppPath)) {
                createNewAngularComponentAction.AddTextParameter("appPath", "Путь Angular проекта, в котором создать компонент:", "Путь до проекта Angular, в котором будет создан новый компонент", Host.GetAppStartupPath());
            } else {
                createNewAngularComponentAction.AddTextParameter("appPath", "Путь Angular проекта, в котором создать компонент:", "Путь до проекта Angular, в котором будет создан новый компонент", RecentAngularAppPath);
            }

            createNewAngularComponentAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_ANGULAR_COMPONENT));
            createNewAngularComponentAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_ANGULAR_COMPONENT));

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
                createNewAngularComponentAction                
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
                AinCommandLineHelper.RunProcessWithoutWindow("cmd", $"/c ng version 1> {FILENAME_ANGLULAR_CLI_VERSION}");

                if (File.Exists(FILENAME_ANGLULAR_CLI_VERSION)) {
                    string commandOutput = File.ReadAllText(FILENAME_ANGLULAR_CLI_VERSION);
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
                AinCommandLineHelper.RunProcessWithoutWindow("cmd", $"/c node -v 1> {FILENAME_NODE_VERSION}");

                if (File.Exists(FILENAME_NODE_VERSION)) {
                    string commandOutput = File.ReadAllText(FILENAME_NODE_VERSION);
                    return new AinDevHelperPluginActionResult(this, actionToRun, commandOutput);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }

            return GetErroneousResponseFileWasNotFound(actionToRun, FILENAME_NODE_VERSION);
        }

        private AinDevHelperPluginActionResult ShowCurrentActiveNPMVersion(AinDevHelperPluginAction actionToRun) {            
            try {
                AinCommandLineHelper.RunProcessWithoutWindow("cmd", $"/c npm -v 1> {FILENAME_NPM_VERSION}");

                if (File.Exists(FILENAME_NPM_VERSION)) {
                    string commandOutput = File.ReadAllText(FILENAME_NPM_VERSION);                    
                    return new AinDevHelperPluginActionResult(this, actionToRun, commandOutput);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }

            return GetErroneousResponseFileWasNotFound(actionToRun, FILENAME_NPM_VERSION);
        }

        private AinDevHelperPluginActionResult CreateNewAngularApp(AinDevHelperPluginAction actionToRun) {
            try {
                if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedActionCreateNewApp) {
                    RecentAngularAppName = parameterizedActionCreateNewApp.GetTextParameterValue("appName");
                    string targetDirectory = parameterizedActionCreateNewApp.GetTextParameterValue("appPath");

                    if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, targetDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(targetDirectory, "cmd", "/c ng new " + RecentAngularAppName + " 1> new_angular_app.txt");

                    RecentAngularAppPath = Path.Combine(targetDirectory, RecentAngularAppName);

                    string outputFile = Path.Combine(targetDirectory, "new_angular_app.txt");

                    StringBuilder sbAdditionalInfo = new StringBuilder();
                    if (File.Exists(outputFile)) {
                        string[] lines = File.ReadAllLines(outputFile);
                        if (lines != null) {
                            sbAdditionalInfo.Append("\r\n");
                            foreach (string line in lines) {
                                sbAdditionalInfo.Append("\r\n").Append(line);
                            }
                        }
                        File.Delete(outputFile);
                    }

                    return new AinDevHelperPluginActionResult(this, actionToRun, "Angular приложение '" + RecentAngularAppName + "' успешно создано в директории '" + targetDirectory + "'" + sbAdditionalInfo.ToString(), true);
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
                    string workingAngularProjectDirectory = parameterizedActionCreateNewAngularComponent.GetTextParameterValue("appPath");
                    string newComponentName = parameterizedActionCreateNewAngularComponent.GetTextParameterValue("newComponentName");

                    if (string.IsNullOrEmpty(workingAngularProjectDirectory) || !Directory.Exists(workingAngularProjectDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, workingAngularProjectDirectory);
                    }

                    AinCommandLineHelper.RunProcessWithWindow(workingAngularProjectDirectory, "cmd", "/c ng generate component " + newComponentName + " 1> new_angular_component.txt 2> new_angular_component_error.txt");

                    string outputLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_component.txt");
                    string outputErrorLogFile = Path.Combine(workingAngularProjectDirectory, "new_angular_component_error.txt");

                    if (File.Exists(outputLogFile)) {
                        string[] allLines = File.ReadAllLines(outputLogFile);
                        if (allLines != null && allLines.Length > 0) {
                            StringBuilder sbCommandOutput = new StringBuilder("\r\n");
                            foreach (string line in allLines) {
                                sbCommandOutput.Append("\r\n").Append(line);
                            }
                            File.Delete(outputLogFile);
                            return new AinDevHelperPluginActionResult(this, actionToRun, $"Новый Angular компонент '{newComponentName}' успешно создан для проекта '{workingAngularProjectDirectory}'." + sbCommandOutput.ToString());
                        }
                    }

                    if (File.Exists(outputErrorLogFile)) {
                        string errorLogDetails = File.ReadAllText(outputErrorLogFile);
                        File.Delete(outputErrorLogFile);
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"Новый Angular компонент '{newComponentName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json. Дополнительные детали ошибки:\r\n" + errorLogDetails);
                    } else {
                        if (File.Exists(outputLogFile)) {
                            File.Delete(outputLogFile);
                        }
                        return new AinDevHelperPluginActionResult(this, actionToRun, $"Новый Angular компонент '{newComponentName}' не был создан для проекта '{workingAngularProjectDirectory}', поскольку целевая директория не является валидным проектом. Проверьте наличие в ней файла package.json.");
                    }
                } else {
                    return GetErroneousResponseExpectedParameterizedAction(actionToRun);
                }
            } catch (Exception exception) {
                return GetErroneousResponseForException(actionToRun, exception);
            }
        }

        public override void Initialize() {
            AinDevHelperSettingTextBoxControl textBox = new AinDevHelperSettingTextBoxControl("targetProjectsDirectory", "Путь для новых проектов:", PluginDirectory);

            textBox.OffsetLeft = 10;
            textBox.Width = 500;

            pluginSettings.AddSettingControl(textBox);

            AinDevHelperSettingRadioButtonGroup radioButtonGroup = new AinDevHelperSettingRadioButtonGroup();
            radioButtonGroup.AddValue("Опция 1");
            radioButtonGroup.AddValue("Опция 2");

            AinDevHelperSettingRadioButtonsControl radioButtonsControl = new AinDevHelperSettingRadioButtonsControl("someOptions", radioButtonGroup);
            radioButtonsControl.OffsetLeft = 10;

            pluginSettings.AddSettingControl(radioButtonsControl);
        }
    }
}
