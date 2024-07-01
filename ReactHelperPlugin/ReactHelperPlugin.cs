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
using System.Collections.Generic;
using System.IO;
using AinDevHelperPluginLibrary;
using AinDevHelperPluginLibrary.Actions;
using static AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants;
using AinDevHelperPluginLibrary.Language;
using static AinDevHelperPluginLibrary.AinDevHelperPluginActionResult;
using AinDevHelperPluginLibrary.Settings.Controls;

namespace ReactHelperPlugin
{
    public class ReactHelperPlugin : StandardAinDevHelperPlugin {
        // ============================
        // [RU] Имена поддерживаемых плагином действий
        // [EN] Names of actions supported by this plugin
        // ============================
        public const string RU_ACTION_CREATE_NEW_REACT_APP = "Создать новое React приложение";
        public const string EN_ACTION_CREATE_NEW_REACT_APP = "Create a new React application";
        public const string DE_ACTION_CREATE_NEW_REACT_APP = "Erstellen Sie eine neue React-Anwendung";

        public const string RU_ACTION_OPEN_REACT_APP_IN_VS_CODE = "Открыть React приложение в среде Visual Studio Code";
        public const string EN_ACTION_OPEN_REACT_APP_IN_VS_CODE = "Open React application in Visual Studio Code";
        public const string DE_ACTION_OPEN_REACT_APP_IN_VS_CODE = "Öffnen Sie die React-Anwendung in Visual Studio Code";

        public readonly string RU_ACTION_NAVIGATE_TO_REACT_WEBSITE = "Браузер - Открыть главную страницу сайта React";
        public readonly string EN_ACTION_NAVIGATE_TO_REACT_WEBSITE = "Browser - Open the main page of the React site";
        public readonly string DE_ACTION_NAVIGATE_TO_REACT_WEBSITE = "Browser – Öffnen Sie die Hauptseite der React-Site";

        public readonly string RU_ACTION_NAVIGATE_TO_REACT_QUICK_START = "Браузер - Открыть страницу \"Quick Start\" сайта React";
        public readonly string EN_ACTION_NAVIGATE_TO_REACT_QUICK_START = "Browser - Open the \"Quick Start\" page of the React site";
        public readonly string DE_ACTION_NAVIGATE_TO_REACT_QUICK_START = "Browser – Öffnen Sie die Seite „Schnellstart“ der React-Site";

        //public readonly string ACTION_NAVIGATE_TO_REACT_TUTORIAL_TIC_TAC_TOE = "Браузер - Открыть страницу \"Quick Start → Tutorial: Tic-Tac-Toe\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_TUTORIAL_THINKING_IN_REACT = "Браузер - Открыть страницу \"Quick Start → Thinking in React\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_DESCRIBING_THE_UI = "Браузер - Открыть страницу \"Learn React → Describing the UI\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_YOUR_FIRST_COMPONENT = "Браузер - Открыть страницу \"Learn React → Describing the UI → Your First Component\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_IMPORTING_AND_EXPORTING_COMPONENTS = "Браузер - Открыть страницу \"Learn React → Describing the UI → Importing and Exporting Components\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_WRITING_MARKUP_WITH_JSX = "Браузер - Открыть страницу \"Learn React → Describing the UI → Writing Markup with JSX\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_JAVASCRIPT_IN_JSX_WITH_CURLY_BRACES = "Браузер - Открыть страницу \"Learn React → Describing the UI → JavaScript in JSX with Curly Braces\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_PASSING_PROPS_TO_A_COMPONENT = "Браузер - Открыть страницу \"Learn React → Describing the UI → Passing Props to a Component\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_CONDITIONAL_RENDERING = "Браузер - Открыть страницу \"Learn React → Describing the UI → Conditional Rendering\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_RENDERING_LISTS = "Браузер - Открыть страницу \"Learn React → Describing the UI → Renderling Lists\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_KEEPING_COMPONENTS_PURE = "Браузер - Открыть страницу \"Learn React → Describing the UI → Keeping Components Pure\" сайта React";
        //public readonly string ACTION_NAVIGATE_TO_REACT_YOUR_UI_AS_A_TREE = "Браузер - Открыть страницу \"Learn React → Describing the UI → Your UI as a Tree\" сайта React";

        // =======================================================================================================================
        // [RU] ID поддерживаемых плагином действий
        // [EN] IDs of actions supported by the plugin
        // =======================================================================================================================
        public const string ID_ACTION_CREATE_NEW_REACT_APP = "create_new_react_app";
        public const string ID_ACTION_OPEN_REACT_APP_IN_VS_CODE = "open_react_app_in_vs_code";
        public const string ID_ACTION_NAVIGATE_TO_REACT_WEBSITE = "navigate_to_react_website";
        public const string ID_ACTION_NAVIGATE_TO_REACT_QUICK_START = "navigate_to_react_quickstart";

        // =======================================================================================================================
        // [RU] Переопределения для свойств базового класса StandardAinDevHelperPlugin
        // [EN] Overrides for properties of the StandardAinDevHelperPlugin base class
        // =======================================================================================================================
        private string RecentReactAppName { get; set; }
        private string RecentReactAppPath { get; set; }
        public override string Name => "React Helper Plugin";
        public override string Company => "Allineed.Ru";
        public override string Description => "Плагин, помогающий разработчику с выполнением различных действий, связанных с разработкой приложений на React.";
        public override string Author => "Max Damascus";
        public override string AuthorEmail => "allineed.ru@gmail.com";
        public override int MajorVersion => 1;
        public override int MinorVersion => 0;
        public override int BuildVersion => 0;
        public override int RevisionVersion => 0;
        public override string AuthorSiteURL => "https://allineed.ru";
        public override IEnumerable<string> Tags => new List<string>() { "react", "web", "web development", "frontend", "react helper" };
        public override IEnumerable<string> SupportedLanguageCodes => new List<string>() { RU, EN, DE };

        public override IEnumerable<AinDevHelperLocalizedMessage> LocalizedDescriptions => new HashSet<AinDevHelperLocalizedMessage>() {
            new AinDevHelperLocalizedMessage(EN, "A plugin that helps the developer with various activities related to developing applications in React."),
            new AinDevHelperLocalizedMessage(DE, "Ein Plugin, das den Entwickler bei verschiedenen Aktivitäten im Zusammenhang mit der Entwicklung von Anwendungen in React unterstützt."),
        };

        // =======================================================================================================================
        // [RU] Реализация методов плагина
        // [EN] Implementing plugin methods
        // =======================================================================================================================
        public override IEnumerable<AinDevHelperPluginAction> GetActions() {
            AinDevHelperSettingBaseControl targetProjectsDirectoryControl = pluginSettings.GetControlByNameOrNull("targetProjectsDirectory");
            AinDevHelperSettingBaseControl newProjectAppNameControl = pluginSettings.GetControlByNameOrNull("newProjectAppName");            

            string pathForNewProjects = PluginDirectory;
            if (targetProjectsDirectoryControl is AinDevHelperSettingDirectorySelectionControl directorySelectionControl && Directory.Exists(directorySelectionControl.SelectedDirectory)) {
                pathForNewProjects = directorySelectionControl.SelectedDirectory;
            }

            string defaultReactAppName = newProjectAppNameControl is AinDevHelperSettingTextBoxControl textBoxNewAppNameControl ? textBoxNewAppNameControl.Text : "my-react-app";

            // [RU] "Создать новое React приложение"
            // [EN] "Create a new React application"
            AinDevHelperPluginParameterizedAction createNewReactAppAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_CREATE_NEW_REACT_APP, ID_ACTION_CREATE_NEW_REACT_APP);

            createNewReactAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_CREATE_NEW_REACT_APP));
            createNewReactAppAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_CREATE_NEW_REACT_APP));

            createNewReactAppAction.AddTextParameter(
                "appName",
                "Название нового React приложения:",
                "Название проекта для React, который будет создан в указанном каталоге",
                defaultReactAppName,
                (EN, "Name of the new React application:", "The name of the React project that will be created in the specified directory"),
                (DE, "Name der neuen React-Anwendung:", "Der Name des React-Projekts, das im angegebenen Verzeichnis erstellt wird")
                );

            createNewReactAppAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь для создания нового React проекта:",
                "Путь файловой системы, в котором будет создан новый проект для React-приложения",
                pathForNewProjects,
                (EN, "Path to create a new React project:", "The file system path where the new project for the React application will be created"),
                (DE, "Pfad zum Erstellen eines neuen React-Projekts:", "Der Dateisystempfad, in dem das neue Projekt für die React-Anwendung erstellt wird")
            );

            // [RU] "Открыть React приложение в среде Visual Studio Code"
            // [EN] "Open React application in Visual Studio Code"
            AinDevHelperPluginParameterizedAction openReactAppInVSCodeAction = new AinDevHelperPluginParameterizedAction(RU_ACTION_OPEN_REACT_APP_IN_VS_CODE, ID_ACTION_OPEN_REACT_APP_IN_VS_CODE);

            openReactAppInVSCodeAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_OPEN_REACT_APP_IN_VS_CODE));
            openReactAppInVSCodeAction.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_OPEN_REACT_APP_IN_VS_CODE));

            string existingReactProjectDirectory = string.IsNullOrEmpty(RecentReactAppPath) ? pathForNewProjects : RecentReactAppPath;

            openReactAppInVSCodeAction.AddDirectorySelectionParameter(
                "appPath",
                "Путь до существующего React проекта:",
                "Путь файловой системы, в котором расположен существующий React проект для открытия его в Visual Studio Code",
                existingReactProjectDirectory,
                (EN, "Path to existing React project:", "The file system path where the existing React project is located for opening it in Visual Studio Code"),
                (DE, "Pfad zum bestehenden React-Projekt:", "Der Dateisystempfad, in dem sich das vorhandene React-Projekt befindet, um es in Visual Studio Code zu öffnen")
            );

            // [RU] "Браузер - Открыть главную страницу сайта React"
            // [EN] "Browser - Open the main page of the React site"
            AinDevHelperPluginWebLinkAction webLinkActionNavigateToReactWebsite = new AinDevHelperPluginWebLinkAction(RU_ACTION_NAVIGATE_TO_REACT_WEBSITE, ID_ACTION_NAVIGATE_TO_REACT_WEBSITE, "https://react.dev/");
            webLinkActionNavigateToReactWebsite.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_REACT_WEBSITE));
            webLinkActionNavigateToReactWebsite.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_REACT_WEBSITE));

            // [RU] "Браузер - Открыть страницу \"Quick Start\" сайта React"
            // [EN] "Browser - Open the \"Quick Start\" page of the React site"
            AinDevHelperPluginWebLinkAction webLinkActionNavigateToReactQuickStart = new AinDevHelperPluginWebLinkAction(RU_ACTION_NAVIGATE_TO_REACT_QUICK_START, ID_ACTION_NAVIGATE_TO_REACT_QUICK_START, "https://react.dev/learn");
            webLinkActionNavigateToReactQuickStart.LocalizedNames.Add(new AinDevHelperLocalizedMessage(EN, EN_ACTION_NAVIGATE_TO_REACT_QUICK_START));
            webLinkActionNavigateToReactQuickStart.LocalizedNames.Add(new AinDevHelperLocalizedMessage(DE, DE_ACTION_NAVIGATE_TO_REACT_QUICK_START));

            //TODO: add other weblink actions for useful links from React website

            return AinDevHelperPluginAction.From(
                createNewReactAppAction, 
                openReactAppInVSCodeAction, 
                webLinkActionNavigateToReactWebsite, 
                webLinkActionNavigateToReactQuickStart
            );
            //return AinDevHelperPluginAction.CombineFrom(
            //    //AinDevHelperPluginAction.WebLinkActionsFromTuples(
            //    //    (ACTION_NAVIGATE_TO_REACT_WEBSITE, "https://react.dev/"),
            //    //    (ACTION_NAVIGATE_TO_REACT_QUICK_START, "https://react.dev/learn"),
            //    //    (ACTION_NAVIGATE_TO_REACT_TUTORIAL_TIC_TAC_TOE, "https://react.dev/learn/tutorial-tic-tac-toe"),
            //    //    (ACTION_NAVIGATE_TO_REACT_TUTORIAL_THINKING_IN_REACT, "https://react.dev/learn/thinking-in-react"),
            //    //    (ACTION_NAVIGATE_TO_REACT_DESCRIBING_THE_UI, "https://react.dev/learn/describing-the-ui"),
            //    //    (ACTION_NAVIGATE_TO_REACT_YOUR_FIRST_COMPONENT, "https://react.dev/learn/your-first-component"),
            //    //    (ACTION_NAVIGATE_TO_REACT_IMPORTING_AND_EXPORTING_COMPONENTS, "https://react.dev/learn/importing-and-exporting-components"),
            //    //    (ACTION_NAVIGATE_TO_REACT_WRITING_MARKUP_WITH_JSX, "https://react.dev/learn/writing-markup-with-jsx"),
            //    //    (ACTION_NAVIGATE_TO_REACT_JAVASCRIPT_IN_JSX_WITH_CURLY_BRACES, "https://react.dev/learn/javascript-in-jsx-with-curly-braces"),
            //    //    (ACTION_NAVIGATE_TO_REACT_PASSING_PROPS_TO_A_COMPONENT, "https://react.dev/learn/passing-props-to-a-component"),
            //    //    (ACTION_NAVIGATE_TO_REACT_CONDITIONAL_RENDERING, "https://react.dev/learn/conditional-rendering"),
            //    //    (ACTION_NAVIGATE_TO_REACT_RENDERING_LISTS, "https://react.dev/learn/rendering-lists"),
            //    //    (ACTION_NAVIGATE_TO_REACT_KEEPING_COMPONENTS_PURE, "https://react.dev/learn/keeping-components-pure"),
            //    //    (ACTION_NAVIGATE_TO_REACT_YOUR_UI_AS_A_TREE, "https://react.dev/learn/understanding-your-ui-as-a-tree")
            //    //),
            //    AinDevHelperPluginAction.From(createNewReactAppAction, openReactAppInVSCodeAction, webLinkAction1, webLinkAction2));
        }

        public override AinDevHelperPluginActionResult RunAction(AinDevHelperPluginAction actionToRun) {
            string actionId = actionToRun.ID;

            if (actionToRun is AinDevHelperPluginParameterizedAction parameterizedAction) {
                if (ID_ACTION_CREATE_NEW_REACT_APP.Equals(actionId)) {
                    RecentReactAppName = parameterizedAction.GetTextParameterValue("appName");
                    string targetDirectory = parameterizedAction.GetDirectorySelectionParameterValue("appPath");

                    if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, targetDirectory);
                    }

                    int exitCode = AinCommandLineHelper.RunProcessWithWindow(targetDirectory, "cmd", "/c npx create-react-app " + RecentReactAppName);

                    RecentReactAppPath = targetDirectory + Path.DirectorySeparatorChar + RecentReactAppName;

                    if (exitCode == 0) {
                        return new AinDevHelperPluginActionResult(
                            this,
                            actionToRun,
                            $"React приложение '{RecentReactAppName}' успешно создано в директории '{targetDirectory}'",
                            true,
                            (EN, $"React application '{RecentReactAppName}' has been successfully created in the '{targetDirectory}' directory."),
                            (DE, $"Die React-Anwendung „{RecentReactAppName}“ wurde erfolgreich im Verzeichnis „{targetDirectory}“ erstellt.")
                        );
                    } else {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun,
                            ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"React приложение '{RecentReactAppName}', вероятно, не было создано в директории '{targetDirectory}', поскольку процесс не завершён с кодом 0",
                            true,
                            (EN, $"React app '{RecentReactAppName}' was probably not created in directory '{targetDirectory}' because the process did not exit with code 0."),
                            (DE, $"Die React-App „{RecentReactAppName}“ wurde wahrscheinlich nicht im Verzeichnis „{targetDirectory}“ erstellt, da der Prozess nicht mit Code 0 beendet wurde.")
                        );
                    }
                } else if (ID_ACTION_OPEN_REACT_APP_IN_VS_CODE.Equals(actionId)) {
                    string targetDirectory = parameterizedAction.GetDirectorySelectionParameterValue("appPath");
                    if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory)) {
                        return GetErroneousResponseDirectoryWasNotFound(actionToRun, targetDirectory);
                    }

                    int exitCode = AinCommandLineHelper.RunProcessWithWindow(targetDirectory, "code", "-r " + targetDirectory);

                    RecentReactAppName ??= Path.GetFileName(targetDirectory);

                    if (exitCode == 0) {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun, 
                            $"React приложение '{RecentReactAppName}' успешно запущено в среде Visual Studio Code", 
                            true,
                            (EN, $"React application '{RecentReactAppName}' launched successfully in Visual Studio Code."),
                            (DE, $"Die React-Anwendung „{RecentReactAppName}“ wurde erfolgreich in Visual Studio Code gestartet.")
                        );
                    } else {
                        return new AinDevHelperPluginActionResult(
                            this, 
                            actionToRun,
                            ActionResultReturnCode.PluginFailedToExecuteAction,
                            $"React приложение '{RecentReactAppName}' не удалось запустить в среде Visual Studio Code, поскольку процесс не завершён с кодом 0",
                            true,
                            (EN, $"React application '{RecentReactAppName}' failed to start in Visual Studio Code because the process failed with code 0."),
                            (DE, $"Die React-Anwendung „{RecentReactAppName}“ konnte in Visual Studio Code nicht gestartet werden, da der Prozess mit Code 0 fehlgeschlagen ist.")
                        );
                    }
                }
            } else if (actionToRun is AinDevHelperPluginWebLinkAction webLinkAction) {
                webLinkAction.Navigate();
                return GetSuccessfulResponseWebLinkAction(actionToRun, webLinkAction);
            }

            return GetErroneousResponseActionNotRecognized(actionToRun);
        }

        public override void Initialize() {
            AinDevHelperSettingDirectorySelectionControl directorySelection = new AinDevHelperSettingDirectorySelectionControl("targetProjectsDirectory", "Директория для новых проектов:", PluginDirectory);

            directorySelection.Width = 440;
            directorySelection.OffsetLeft = 10;
            directorySelection.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(EN, "Directory for new projects:"));
            directorySelection.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(DE, "Verzeichnis für neue Projekte:"));

            pluginSettings.AddSettingControl(directorySelection);

            AinDevHelperSettingTextBoxControl textBoxNewProjectName = new AinDevHelperSettingTextBoxControl("newProjectAppName", "Название для нового проекта:", "my-react-app");
            textBoxNewProjectName.OffsetLeft = 10;
            textBoxNewProjectName.Width = 550;
            textBoxNewProjectName.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(EN, "Name for the new project:"));
            textBoxNewProjectName.LocalizedLabels.Add(new AinDevHelperLocalizedMessage(DE, "Name für das neue Projekt:"));

            pluginSettings.AddSettingControl(textBoxNewProjectName);
        }
    }
}
