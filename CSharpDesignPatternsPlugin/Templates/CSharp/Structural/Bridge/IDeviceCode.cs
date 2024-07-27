namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge {
    public partial class IDevice {
        private string LanguageCode { get; set; }
        public IDevice(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
