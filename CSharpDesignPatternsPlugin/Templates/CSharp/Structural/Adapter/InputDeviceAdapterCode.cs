namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Adapter {
    public partial class InputDeviceAdapter {
        private string LanguageCode { get; set; }
        public InputDeviceAdapter(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
