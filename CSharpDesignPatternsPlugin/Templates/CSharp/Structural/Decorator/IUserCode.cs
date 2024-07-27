namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Decorator {
    public partial class IUser {
        private string LanguageCode { get; set; }
        public IUser(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
