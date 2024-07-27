namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Adapter {
    public partial class ThirdPartyInputDevice {
        private string LanguageCode { get; set; }
        public ThirdPartyInputDevice(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
