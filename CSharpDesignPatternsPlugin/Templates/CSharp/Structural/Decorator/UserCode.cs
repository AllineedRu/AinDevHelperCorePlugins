namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Decorator {
    public partial class User {
        private string LanguageCode { get; set; }
        public User(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
