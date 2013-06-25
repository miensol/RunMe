using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace miensol.RunMe.Options
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid(Guids.OptionsPageGuid)]
    public class OptionsPage : DialogPage
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                var optionsView = new OptionsView();
                optionsView.optionsPage = this;
                return optionsView;
            }
        }
    }
}