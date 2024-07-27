namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Decorator {
    public partial class ModeratorUserDecorator {
        private string LanguageCode { get; set; }
        public ModeratorUserDecorator(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
