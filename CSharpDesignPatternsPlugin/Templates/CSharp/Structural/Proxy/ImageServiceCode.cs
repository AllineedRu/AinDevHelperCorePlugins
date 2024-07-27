namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Proxy {
    public partial class ImageService {
        private string LanguageCode { get; set; }
        public ImageService(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
