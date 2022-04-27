using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using System.IO;
// using IxMilia.Step;
// using IxMilia.Step.Items;

namespace _3d_modelling
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FilePath = null;
        // public StepFile stepFile;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.InitialDirectory = "C:\\";
            fileDlg.Filter = "STL file(*.stl)|*.stl|All files(*.*)|*.*";
            fileDlg.FilterIndex = 0;

            fileDlg.ShowDialog();
            FilePath = fileDlg.FileName;

            if (FilePath != null && FilePath.ToLower().EndsWith(".stl"))
            {
                ModelVisual3D device3D = new ModelVisual3D();
                device3D.Content = Display3d(FilePath);
                viewPort3d.Children.Add(device3D);
            }
        }

        private Model3D Display3d(string model)
        {
            Model3D device = null;
            try
            {
                viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);
                ModelImporter importer = new ModelImporter();
                device = importer.Load(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Error: " + ex.Message);
            }
            return device;
        }
    }
}
