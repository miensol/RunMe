using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.VisualStudio.PlatformUI;

namespace miensol.RunMe
{
    /// <summary>
    /// Interaction logic for TypeCommandWindow.xaml
    /// </summary>
    public partial class TypeCommandWindow : DialogWindow
    {
        public TypeCommandWindow()
        {
            InitializeComponent();
        }

        private void MouseOverCommandItem(object sender, MouseEventArgs e)
        {
            var model = (CommandsModel) DataContext;
            var command = (ICommandToRun)((FrameworkElement) sender).DataContext;
            model.CommandToExecute = command;
        }

        private void MouseClickedCommandItem(object sender, MouseButtonEventArgs e)
        {
            var model = (CommandsModel)DataContext;
            var command = (ICommandToRun)((FrameworkElement)sender).DataContext;
            model.SetCommandToExecuteAndStart(command);
        }
    }
}
