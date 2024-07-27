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
using System.IO;
using System.Collections.Generic;
using AinDevHelperPluginLibrary;
using AinDevHelperPluginLibrary.Actions;
using static AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants;
using AinDevHelperPluginLibrary.Language;
using static AinDevHelperPluginLibrary.AinDevHelperPluginActionResult;

namespace TauriHelperPlugin {
    /// <summary>
    /// [RU] Плагин для программы AinDevHelper, который предоставляет различные полезные действия для разработчиков на фреймворке Tauri<br/>
    /// [EN] Plugin for the AinDevHelper program, which provides various useful actions for developers on the Tauri framework
    /// </summary>
    public class TauriHelperPlugin : StandardAinDevHelperPlugin {
        // =======================================================================================================================
        // [RU] Имена поддерживаемых плагином действий
        // [EN] Names of actions supported by this plugin
        // =======================================================================================================================
        public readonly string RU_ACTION_CREATE_NEW_TAURI_APP = "Создать новое Tauri приложение";
        public readonly string EN_ACTION_CREATE_NEW_TAURI_APP = "Create a new Tauri application";
        public readonly string DE_ACTION_CREATE_NEW_TAURI_APP = "Erstellen Sie eine neue Tauri-Anwendung";

        public readonly string RU_ACTION_OPEN_TAURI_APP_IN_VS_CODE = "Открыть Tauri приложение в среде Visual Studio Code";
        public readonly string EN_ACTION_OPEN_TAURI_APP_IN_VS_CODE = "Open the Tauri application in Visual Studio Code";
        public readonly string DE_ACTION_OPEN_TAURI_APP_IN_VS_CODE = "Öffnen Sie die Tauri-Anwendung in Visual Studio Code";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_WEBSITE = "Браузер - Открыть главную страницу сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_WEBSITE = "Browser - Open the main page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_WEBSITE = "Browser – Öffnen Sie die Hauptseite der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_GUIDES = "Браузер - Открыть страницу \"Guides\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_GUIDES = "Browser - Open the \"Guides\" page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_GUIDES = "Browser – Öffnen Sie die Seite „Guides“ der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES = "Браузер - Открыть страницу \"Guides → Getting Started → Prerequisites\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES = "Browser - Open the \"Guides → Getting Started → Prerequisites\" page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES = "Browser – Öffnen Sie die Seite „Anleitungen → Erste Schritte → Voraussetzungen“ auf der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START = "Браузер - Открыть страницу \"Guides → Getting Started → Quick Start\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START = "Browser - Open the \"Guides → Getting Started → Quick Start\" page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START = "Browser – Öffnen Sie die Seite „Anleitungen → Erste Schritte → Schnellstart“ auf der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE = "Браузер - Открыть страницу \"Guides → Development → Development Cycle\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE = "Browser - Open the page \"Guides → Development → Development Cycle\" of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE = "Browser – Öffnen Sie die Seite „Anleitungen → Entwicklung → Entwicklungszyklus“ der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION = "Браузер - Открыть страницу \"API → Configuration\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION = "Browser - Open the \"API → Configuration\" page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION = "Browser – Öffnen Sie die Seite „API → Konfiguration“ der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_API_CLI = "Браузер - Открыть страницу \"API → CLI\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_API_CLI = "Browser - Open the \"API → CLI\" page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_API_CLI = "Browser – Öffnen Sie die Seite „API → CLI“ der Tauri-Website";

        public readonly string RU_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT = "Браузер - Открыть страницу \"API → JavaScript / TypeScript\" сайта Tauri";
        public readonly string EN_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT = "Browser - Open the \"API → JavaScript / TypeScript\" page of the Tauri website";
        public readonly string DE_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT = "Browser – Öffnen Sie die Seite „API → JavaScript / TypeScript“ der Tauri-Website";

        // =======================================================================================================================
        // [RU] ID поддерживаемых плагином действий
        // [EN] IDs of actions supported by the plugin
        // =======================================================================================================================
        public const string ID_ACTION_CREATE_NEW_TAURI_APP = "create_new_tauri_application";
        public const string ID_ACTION_OPEN_TAURI_APP_IN_VS_CODE = "open_tauri_application_in_vscode";

        public const string ID_ACTION_NAVIGATE_TO_TAURI_WEBSITE = "navigate_to_tauri_website";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_GUIDES = "navigate_to_tauri_guides";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES = "navigate_to_tauri_guides_getting_started_prerequisites";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START = "navigate_to_tauri_guides_getting_started_quickstart";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE = "navigate_to_tauri_guides_development_development_cycle";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION = "navigate_to_tauri_api_configuration";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_API_CLI = "navigate_to_tauri_api_cli";
        public const string ID_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT = "navigate_to_tauri_api_javascript_typescript";

        // =======================================================================================================================
        // [RU] Переопределения для свойств базового класса StandardAinDevHelperPlugin
        // [EN] Overrides for properties of the StandardAinDevHelperPlugin base class
        // =======================================================================================================================
        private string RecentTauriAppName { get; set; }
        private string RecentTauriAppPath { get; set; }
        public override string Name => "Tauri Helper Plugin";
        public override string Company => "Allineed.Ru";
        public override string Description => "Плагин, помогающий разработчику с выполнением различных действий, связанных с разработкой приложений на Tauri.";
        public override string Author => "Max Damascus";
        public override string AuthorEmail => "allineed.ru@gmail.com";
        public override int MajorVersion => 1;
        public override int MinorVersion => 0;
        public override int BuildVersion => 0;
        public override int RevisionVersion => 0;
        public override string AuthorSiteURL => "https://allineed.ru";
        public override IEnumerable<string> Tags => new List<string>() { "tauri" };
        public override IEnumerable<string> SupportedLanguageCodes => new List<string>() { RU, EN, DE };

        public override IEnumerable<AinDevHelperLocalizedMessage> LocalizedDescriptions => new HashSet<AinDevHelperLocalizedMessage>() {
            new AinDevHelperLocalizedMessage(EN, "A plugin that helps the developer with various actions related to developing applications on Tauri."),
            new AinDevHelperLocalizedMessage(DE, "Ein Plugin, das den Entwickler bei verschiedenen Aktionen im Zusammenhang mit der Entwicklung von Anwendungen auf Tauri unterstützt."),
        };

        // =======================================================================================================================
        // [RU] Реализация методов плагина
        // [EN] Implementing plugin methods
        // =======================================================================================================================
        public override IEnumerable<AinDevHelperPluginAction> GetActions() {
            // [RU] "Создать новое Tauri приложение"
            // [EN] "Create a new Tauri application"
            AinDevHelperPluginParameterizedAction createNewTauriAppAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_TAURI_APP, ID_ACTION_CREATE_NEW_TAURI_APP);
            createNewTauriAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_TAURI_APP));
            createNewTauriAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_TAURI_APP));

            createNewTauriAppAction.AddTextParameter(
                "appName", 
                "Название нового Tauri приложения:",
                "Название проекта Tauri, который будет создан при помощи интерфейса командной строки", 
                "my-tauri-app",
                (EN, "Name of the new Tauri application:", "The name of the Tauri project that will be created using the command line interface"),
                (DE, "Name der neuen Tauri-Anwendung:", "Der Name des Tauri-Projekts, das über die Befehlszeilenschnittstelle erstellt wird")
            );

            createNewTauriAppAction.AddDirectorySelectionParameter(
                "appPath", 
                "Путь для создания нового Tauri проекта:", 
                "Путь до каталога файловой системы, в котором будет создан новый проект для Tauri приложения", 
                Host.GetAppStartupPath(),
                (EN, "Path to create a new Tauri project:", "Path to the file system directory in which a new project for the Tauri application will be created"),
                (DE, "Pfad zum Erstellen eines neuen Tauri-Projekts:", "Pfad zum Dateisystemverzeichnis, in dem ein neues Projekt für die Tauri-Anwendung erstellt wird")
            );

            // [RU] "Открыть Tauri приложение в среде Visual Studio Code"
            // [EN] "Open the Tauri application in Visual Studio Code"
            AinDevHelperPluginParameterizedAction openTauriAppInVSCodeAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_OPEN_TAURI_APP_IN_VS_CODE, ID_ACTION_OPEN_TAURI_APP_IN_VS_CODE);
            openTauriAppInVSCodeAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_OPEN_TAURI_APP_IN_VS_CODE));
            openTauriAppInVSCodeAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_OPEN_TAURI_APP_IN_VS_CODE));

            string existingTauriProjectDirectory = string.IsNullOrEmpty(RecentTauriAppPath) ? Host.GetAppStartupPath() : RecentTauriAppPath;
            openTauriAppInVSCodeAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до существующего Tauri проекта:",
                "Путь до каталога файловой системы, в котором расположен существующий Tauri проект для открытия его в Visual Studio Code",
                existingTauriProjectDirectory,
                (EN, "Path to the existing Tauri project:", "Path to the file system directory in which the existing Tauri project is located for opening it in Visual Studio Code"),
                (DE, "Pfad zum bestehenden Tauri-Projekt:", "Pfad zum Dateisystemverzeichnis, in dem sich das vorhandene Tauri-Projekt befindet, um es in Visual Studio Code zu öffnen")
            );

            // [RU] "Браузер - Открыть главную страницу сайта Tauri"
            // [EN] "Browser - Open the main page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriWebsite = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_WEBSITE, 
                ID_ACTION_NAVIGATE_TO_TAURI_WEBSITE,
                "https://tauri.app/"
            );
            webLinkActionGoToTauriWebsite.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_WEBSITE));
            webLinkActionGoToTauriWebsite.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_WEBSITE));

            // [RU] "Браузер - Открыть страницу \"Guides\" сайта Tauri"
            // [EN] "Browser - Open the \"Guides\" page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriGuides = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_GUIDES, 
                ID_ACTION_NAVIGATE_TO_TAURI_GUIDES,
                "https://tauri.app/v1/guides/"
            );
            webLinkActionGoToTauriGuides.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_GUIDES));
            webLinkActionGoToTauriGuides.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_GUIDES));

            // [RU] "Браузер - Открыть страницу \"Guides → Getting Started → Prerequisites\" сайта Tauri"
            // [EN] "Browser - Open the \"Guides → Getting Started → Prerequisites\" page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriGuidesGettingStartedPrerequisites = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES,
                ID_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES,
                "https://tauri.app/v1/guides/getting-started/prerequisites"
            );
            webLinkActionGoToTauriGuidesGettingStartedPrerequisites.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES));
            webLinkActionGoToTauriGuidesGettingStartedPrerequisites.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_PREREQUISITES));

            // [RU] "Браузер - Открыть страницу \"Guides → Getting Started → Quick Start\" сайта Tauri"
            // [EN] "Browser - Open the \"Guides → Getting Started → Quick Start\" page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriGuidesGettingStartedQuickstart = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START,
                ID_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START,
                "https://tauri.app/v1/guides/getting-started/setup/"
            );
            webLinkActionGoToTauriGuidesGettingStartedQuickstart.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START));
            webLinkActionGoToTauriGuidesGettingStartedQuickstart.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_GUIDES_GETTING_STARTED_QUICK_START));

            // [RU] "Браузер - Открыть страницу \"Guides → Development → Development Cycle\" сайта Tauri"
            // [EN] "Browser - Open the page \"Guides → Development → Development Cycle\" of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriGuidesDevelopmentDevCycle = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE,
                ID_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE,
                "https://tauri.app/v1/guides/development/development-cycle"
            );
            webLinkActionGoToTauriGuidesDevelopmentDevCycle.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE));
            webLinkActionGoToTauriGuidesDevelopmentDevCycle.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_GUIDES_DEVELOPMENT_DEVELOPMENT_CYCLE));

            // [RU] "Браузер - Открыть страницу \"API → Configuration\" сайта Tauri"
            // [EN] "Browser - Open the \"API → Configuration\" page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriApiConfiguration = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION,
                ID_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION,
                "https://tauri.app/v1/api/config"
            );
            webLinkActionGoToTauriApiConfiguration.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION));
            webLinkActionGoToTauriApiConfiguration.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_API_CONFIGURATION));

            // [RU] "Браузер - Открыть страницу \"API → CLI\" сайта Tauri"
            // [EN] "Browser - Open the \"API → CLI\" page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriApiCLI = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_API_CLI,
                ID_ACTION_NAVIGATE_TO_TAURI_API_CLI,
                "https://tauri.app/v1/api/cli"
            );
            webLinkActionGoToTauriApiCLI.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_API_CLI));
            webLinkActionGoToTauriApiCLI.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, EN_ACTION_NAVIGATE_TO_TAURI_API_CLI));

            // [RU] "Браузер - Открыть страницу \"API → JavaScript / TypeScript\" сайта Tauri"
            // [EN] "Browser - Open the \"API → JavaScript / TypeScript\" page of the Tauri website"
            AinDevHelperPluginWebLinkAction webLinkActionGoToTauriApiJavascriptTypescript = new AinDevHelperPluginWebLinkAction(
                RU_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT,
                ID_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT,
                "https://tauri.app/v1/api/js/"
            );
            webLinkActionGoToTauriApiJavascriptTypescript.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT));
            webLinkActionGoToTauriApiJavascriptTypescript.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_TAURI_API_JAVASCRIPT_TYPESCRIPT));

            return AinDevHelperPluginAction.From(
                webLinkActionGoToTauriWebsite,
                webLinkActionGoToTauriGuides,
                webLinkActionGoToTauriGuidesGettingStartedPrerequisites,
                webLinkActionGoToTauriGuidesGettingStartedQuickstart,
                webLinkActionGoToTauriGuidesDevelopmentDevCycle,
                webLinkActionGoToTauriApiConfiguration,
                webLinkActionGoToTauriApiCLI,
                webLinkActionGoToTauriApiJavascriptTypescript,
                createNewTauriAppAction, 
                openTauriAppInVSCodeAction
            );
        }

        public override AinDevHelperPluginActionResult RunAction(AinDevHelperPluginAction actionToRun) {
            string actionId = actionToRun.ID;

            if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedAction) {
                if (ID_ACTION_CREATE_NEW_TAURI_APP.Equals(actionId)) {
                    RecentTauriAppName = parameterizedAction.GetTextParameterValue("appName");
                    string targetDirectory = parameterizedAction.GetDirectorySelectionParameterValue("appPath");

                    if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, targetDirectory);
                    }

                    int exitCode = AinCommandLineHelper.RunProcessWithWindow(targetDirectory, "cmd", "/c npm create tauri-app@latest " + RecentTauriAppName);

                    RecentTauriAppPath = targetDirectory + Path.DirectorySeparatorChar + RecentTauriAppName;

                    if (exitCode == 0) {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun,                             
                            $"Tauri приложение '{RecentTauriAppName}' успешно создано в директории '{targetDirectory}'.",
                            true,
                            (EN, $"Tauri application '{RecentTauriAppName}' has been successfully created in the '{targetDirectory}' directory."),
                            (DE, $"Die Tauri-Anwendung „{RecentTauriAppName}“ wurde erfolgreich im Verzeichnis „{targetDirectory}“ erstellt.")
                        );
                    } else {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun, 
                            ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Tauri приложение '{RecentTauriAppName}', вероятно, не было создано в директории '{targetDirectory}', поскольку процесс не завершён с кодом 0.", 
                            true,
                            (EN, $"Tauri app '{RecentTauriAppName}' was probably not created in directory '{targetDirectory}' because the process did not exit with code 0."),
                            (DE, $"Die Tauri-App „{RecentTauriAppName}“ wurde wahrscheinlich nicht im Verzeichnis „{targetDirectory}“ erstellt, da der Prozess nicht mit Code 0 beendet wurde.")
                        );
                    }
                } else if (ID_ACTION_OPEN_TAURI_APP_IN_VS_CODE.Equals(actionId)) {
                    string targetDirectory = parameterizedAction.GetDirectorySelectionParameterValue("appPath");
                    if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, targetDirectory);
                    }

                    int exitCode = AinCommandLineHelper.RunProcessWithWindow(targetDirectory, "code", "-r " + targetDirectory);

                    RecentTauriAppName ??= Path.GetFileName(targetDirectory);

                    if (exitCode == 0) {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun,                            
                            $"Tauri приложение '{RecentTauriAppName}' успешно запущено в среде Visual Studio Code.", 
                            true,
                            (EN, $"Tauri application '{RecentTauriAppName}' launched successfully in Visual Studio Code."),
                            (DE, $"Die Tauri-Anwendung „{RecentTauriAppName}“ wurde erfolgreich in Visual Studio Code gestartet.")
                        );
                    } else {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun,
                            ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"Tauri приложение '{RecentTauriAppName}' не удалось запустить в среде Visual Studio Code, поскольку процесс не завершён с кодом 0.", 
                            true,
                            (EN, $"Tauri application '{RecentTauriAppName}' failed to start in Visual Studio Code because the process failed with code 0."),
                            (DE, $"Die Tauri-Anwendung „{RecentTauriAppName}“ konnte in Visual Studio Code nicht gestartet werden, da der Prozess mit Code 0 fehlgeschlagen ist.")
                        );
                    }
                }
            } else if (actionToRun is AinDevHelperPluginWebLinkAction webLinkAction) {
                webLinkAction.Navigate();
                return GetSuccessfulResponseWebLinkAction(actionToRun, webLinkAction);
            }
            
            return GetErroneousResponseActionNotRecognized(actionToRun);
        }
    }
}
