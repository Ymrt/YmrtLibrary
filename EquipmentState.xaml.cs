using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YmrtLibrary
{
    /// <summary>
    /// EquipmentState.xaml 的交互逻辑
    /// </summary>
    public partial class EquipmentState : UserControl
    {
        public EquipmentState()
        {
            InitializeComponent();
            DataContext = this;
        }


        [Category("Cutom"), DisplayName("设备运行状态图片")]
        public ImageSource RunEquipmentStateSource
        {
            get { return (ImageSource)GetValue(RunEquipmentStateSourceProperty); }
            set { SetValue(RunEquipmentStateSourceProperty, value); }
        }

        public static readonly DependencyProperty RunEquipmentStateSourceProperty =
            DependencyProperty.Register("RunEquipmentStateSource", typeof(ImageSource), typeof(EquipmentState), new PropertyMetadata(default, (d, e) => (d as EquipmentState)?.SetState()));



        [Category("Cutom"), DisplayName("设备停止状态图片")]
        public ImageSource StopEquipmentStateSource
        {
            get { return (ImageSource)GetValue(StopEquipmentStateSourceProperty); }
            set { SetValue(StopEquipmentStateSourceProperty, value); }
        }

        public static readonly DependencyProperty StopEquipmentStateSourceProperty =
            DependencyProperty.Register("StopQuipmentStateSource", typeof(ImageSource), typeof(EquipmentState), new PropertyMetadata(default, (d, e) => (d as EquipmentState)?.SetState()));



        [Category("Cutom"), DisplayName("设备运行状态")]
        public bool EquipmeentState
        {
            get { return (bool)GetValue(EquipmeentStateProperty); }
            set { SetValue(EquipmeentStateProperty, value); }
        }

        public static readonly DependencyProperty EquipmeentStateProperty =
            DependencyProperty.Register("EquipmeentState", typeof(bool), typeof(EquipmentState), new PropertyMetadata(true,(d,e)=>(d as EquipmentState)?.SetState()));

  


        [Category("Cutom"), DisplayName("是否故障状态")]
        public bool IsFault
        {
            get { return (bool)GetValue(IsFaultProperty); }
            set { SetValue(IsFaultProperty, value); }
        }

        public static readonly DependencyProperty IsFaultProperty =
            DependencyProperty.Register("IsFault", typeof(bool), typeof(EquipmentState), new PropertyMetadata(false, (d, e) => (d as EquipmentState)?.SetFault()));
  



        [Category("Cutom"), DisplayName("是否锁定状态")]
        public bool IsLock
        {
            get { return (bool)GetValue(IsLockProperty); }
            set { SetValue(IsLockProperty, value); }
        }

        public static readonly DependencyProperty IsLockProperty =
            DependencyProperty.Register("IsLock", typeof(bool), typeof(EquipmentState), new PropertyMetadata(false, (d, e) => (d as EquipmentState)?.SetLock()));



        [Category("Cutom"), DisplayName("故障状态图片")]
        public ImageSource FaultSource
        {
            get { return (ImageSource)GetValue(FaultSourceProperty); }
            set { SetValue(FaultSourceProperty, value); }
        }

        public static readonly DependencyProperty FaultSourceProperty =
            DependencyProperty.Register("FaultSource", typeof(ImageSource), typeof(EquipmentState));


        [Category("Cutom"), DisplayName("锁定状态图片")]
        public ImageSource LockSource
        {
            get { return (ImageSource)GetValue(LockSourceProperty); }
            set { SetValue(LockSourceProperty, value); }
        }

        public static readonly DependencyProperty LockSourceProperty =
            DependencyProperty.Register("LockSource", typeof(ImageSource), typeof(EquipmentState));




        [Category("Cutom"), DisplayName("故障图片宽度")]
        public double FaultWidth
        {
            get { return (double)GetValue(FaultWidthProperty); }
            set { SetValue(FaultWidthProperty, value); }
        }

        public static readonly DependencyProperty FaultWidthProperty =
            DependencyProperty.Register("FaultWidth", typeof(double), typeof(EquipmentState), new PropertyMetadata(20d));


        [Category("Cutom"), DisplayName("故障图片高度")]
        public double FaultHeight
        {
            get { return (double)GetValue(FaultHeightProperty); }
            set { SetValue(FaultHeightProperty, value); }
        }

        public static readonly DependencyProperty FaultHeightProperty =
            DependencyProperty.Register("FaultHeight", typeof(double), typeof(EquipmentState), new PropertyMetadata(10d));


        [Category("Cutom"), DisplayName("锁定图片宽度")]
        public double LockWidth
        {
            get { return (double)GetValue(LockWidthProperty); }
            set { SetValue(LockWidthProperty, value); }
        }

        public static readonly DependencyProperty LockWidthProperty =
            DependencyProperty.Register("LockWidth", typeof(double), typeof(EquipmentState), new PropertyMetadata(5d));


        [Category("Cutom"), DisplayName("锁定图片高度")]
        public double LockHeight
        {
            get { return (double)GetValue(LockHeightProperty); }
            set { SetValue(LockHeightProperty, value); }
        }

        public static readonly DependencyProperty LockHeightProperty =
            DependencyProperty.Register("LockHeight", typeof(double), typeof(EquipmentState), new PropertyMetadata(5d));




        private void SetState()
        {
            _equipment.Source = EquipmeentState ? RunEquipmentStateSource : StopEquipmentStateSource;
            SetLock();
        }

        private void SetFault()
        {
            _fault.Visibility = IsFault ? Visibility.Visible : Visibility.Hidden;
        }

        private void SetLock()
        {
            if (!EquipmeentState)
                _lock.Visibility = IsLock ? Visibility.Visible : Visibility.Hidden;
            else
                _lock.Visibility = Visibility.Hidden;
        }
    }
}
