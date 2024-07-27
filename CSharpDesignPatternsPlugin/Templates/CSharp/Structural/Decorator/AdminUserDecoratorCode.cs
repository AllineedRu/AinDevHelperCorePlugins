namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Decorator {
    public partial class AdminUserDecorator {
        private string LanguageCode { get; set; }
        public AdminUserDecorator(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
