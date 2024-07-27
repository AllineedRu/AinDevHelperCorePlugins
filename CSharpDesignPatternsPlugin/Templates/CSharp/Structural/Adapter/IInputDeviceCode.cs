namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Adapter {
    public partial class IInputDevice {
        private string LanguageCode { get; set; }
        public IInputDevice(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
