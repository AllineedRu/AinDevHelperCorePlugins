namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Proxy {
    public partial class IImageService {
        private string LanguageCode { get; set; }
        public IImageService(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
