namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Facade {
    public partial class FileFacade {
        private string LanguageCode { get; set; }
        public FileFacade(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
