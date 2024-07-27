using AinDevHelperPluginLibrary;
using AinDevHelperPluginLibrary.Actions;
using AinDevHelperPluginLibrary.Language;
using System.Collections.Generic;
using static AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants;

namespace HelloWorldPlugin
{
    public class HelloWorldPlugin : StandardAinDevHelperPlugin {
        // ============================
        // [RU] Имена поддерживаемых плагином действий
        // [EN] Names of actions supported by this plugin
        // ============================
        public const string RU_HELLO_WORLD_ACTION = "Привет, мир!";
        public const string EN_HELLO_WORLD_ACTION = "Hello World!";
        public const string DE_HELLO_WORLD_ACTION = "Hallo Welt!";

        // =======================================================================================================================
        // [RU] ID поддерживаемых плагином действий
        // [EN] IDs of actions supported by the plugin
        // =======================================================================================================================
        public const string ID_HELLO_WORLD = "hello_world";

        // =======================================================================================================================
        // [RU] Переопределения для свойств базового класса StandardAinDevHelperPlugin
        // [EN] Overrides for properties of the StandardAinDevHelperPlugin base class
        // =======================================================================================================================
        public override string Name => "Hello World Plugin";
        public override string Company => "Название Вашей компании-производителя или просто пустая строка";
        public override string Description => "Мой первый плагин для AinDevHelper.";
        public override string Author => "Ваше Имя";
        public override string AuthorEmail => "youremail@yourdomain.ru";
        public override int MajorVersion => 1;
        public override int MinorVersion => 0;
        public override int BuildVersion => 0;
        public override int RevisionVersion => 0;
        public override string AuthorSiteURL => "https://yourdomain.ru";
        public override IEnumerable<string> Tags => new List<string>() { "helloworld", "hello", "greeting", "first plugin" };
        public override IEnumerable<string> SupportedLanguageCodes => new List<string>() { RU, EN, DE };

        public override IEnumerable<AinDevHelperLocalizedMessage> LocalizedDescriptions => new HashSet<AinDevHelperLocalizedMessage>() {
            new AinDevHelperLocalizedMessage(EN, "My first plugin for AinDevHelper."),
            new AinDevHelperLocalizedMessage(DE, "Mein erstes Plugin für AinDevHelper."),
        };

        // =======================================================================================================================
        // [RU] Реализация методов плагина
        // [EN] Implementing plugin methods
        // =======================================================================================================================
        public override IEnumerable<AinDevHelperPluginAction> GetActions() {
            AinDevHelperPluginAction helloWorldAction = new AinDevHelperPluginAction(RU_HELLO_WORLD_ACTION, ID_HELLO_WORLD);
            helloWorldAction.AddLocalizedName(EN, EN_HELLO_WORLD_ACTION);
            helloWorldAction.AddLocalizedName(DE, DE_HELLO_WORLD_ACTION);

            return AinDevHelperPluginAction.From(helloWorldAction);
        }

        public override AinDevHelperPluginActionResult RunAction(AinDevHelperPluginAction actionToRun) {
            string actionId = actionToRun.ID;

            if (ID_HELLO_WORLD.Equals(actionId)) {
                return new AinDevHelperPluginActionResult(this, actionToRun, RU_HELLO_WORLD_ACTION, (EN, EN_HELLO_WORLD_ACTION), (DE, DE_HELLO_WORLD_ACTION));
            }

            return GetErroneousResponseActionNotRecognized(actionToRun);
        }
    }
}
