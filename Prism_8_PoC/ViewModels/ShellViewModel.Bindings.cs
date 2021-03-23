namespace Prism_8_PoC.ViewModels
{
    public sealed partial class ShellViewModel
    {
        private string title = "Proof of Concept prism 8";

        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }
    }
}
