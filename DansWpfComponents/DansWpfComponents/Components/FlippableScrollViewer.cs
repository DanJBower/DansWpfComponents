using DansWpfComponents.Enums;
using DansWpfComponents.Utility;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace DansWpfComponents.Components;

public class FlippableScrollViewer : ScrollViewer
{
    static FlippableScrollViewer()
    {
        RegisterNewEvents();
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FlippableScrollViewer), new FrameworkPropertyMetadata(typeof(FlippableScrollViewer)));
    }

    public FlippableScrollViewer()
    {
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        Window win = Window.GetWindow(this);
        if (win != null)
        {
            EnableMouseHorizontalWheelSupport(win);
        }
    }

    private const double HorizontalScrollOffset = 48;

    public static readonly DependencyProperty HorizontalScrollBarPositionProperty =
        DependencyProperty.Register(
            "HorizontalScrollBarPosition",
            typeof(HorizontalScrollBarPosition),
            typeof(FlippableScrollViewer),
            new PropertyMetadata(HorizontalScrollBarPosition.Bottom));

    public static readonly DependencyProperty VerticalScrollBarPositionProperty =
        DependencyProperty.Register(
            "VerticalScrollBarPosition",
            typeof(VerticalScrollBarPosition),
            typeof(FlippableScrollViewer),
            new PropertyMetadata(VerticalScrollBarPosition.Right));

    public static readonly RoutedEvent PreviewMouseHorizontalWheelEvent =
        EventManager.RegisterRoutedEvent(
            "PreviewMouseHorizontalWheel",
            RoutingStrategy.Tunnel,
            typeof(MouseHorizontalWheelEventHandler),
            typeof(FlippableScrollViewer));

    public static readonly RoutedEvent MouseHorizontalWheelEvent =
        EventManager.RegisterRoutedEvent(
            "MouseHorizontalWheel",
            RoutingStrategy.Bubble,
            typeof(MouseHorizontalWheelEventHandler),
            typeof(FlippableScrollViewer));

    public HorizontalScrollBarPosition HorizontalScrollBarPosition
    {
        get => (HorizontalScrollBarPosition)GetValue(HorizontalScrollBarPositionProperty);
        set => SetValue(HorizontalScrollBarPositionProperty, value);
    }

    public VerticalScrollBarPosition VerticalScrollBarPosition
    {
        get => (VerticalScrollBarPosition)GetValue(VerticalScrollBarPositionProperty);
        set => SetValue(VerticalScrollBarPositionProperty, value);
    }

    public event MouseHorizontalWheelEventHandler PreviewMouseHorizontalWheel
    {
        add => AddHandler(PreviewMouseHorizontalWheelEvent, value);
        remove => RemoveHandler(PreviewMouseHorizontalWheelEvent, value);
    }

    public event MouseHorizontalWheelEventHandler MouseHorizontalWheel
    {
        add => AddHandler(MouseHorizontalWheelEvent, value);
        remove => RemoveHandler(MouseHorizontalWheelEvent, value);
    }

    private static void RegisterNewEvents()
    {
        EventManager.RegisterClassHandler(
            typeof(FlippableScrollViewer),
            PreviewMouseHorizontalWheelEvent,
            new MouseHorizontalWheelEventHandler(OnPreviewMouseHorizontalWheelThunk),
            false);

        EventManager.RegisterClassHandler(
            typeof(FlippableScrollViewer),
            MouseHorizontalWheelEvent,
            new MouseHorizontalWheelEventHandler(OnMouseHorizontalWheelThunk),
            false);
    }

    private static void OnPreviewMouseHorizontalWheelThunk(object sender, MouseHorizontalWheelEventArgs mouseHorizontalWheelEventArgs)
    {
        if (!mouseHorizontalWheelEventArgs.Handled && sender is FlippableScrollViewer view)
        {
            view.OnPreviewMouseHorizontalWheel(mouseHorizontalWheelEventArgs);
        }
    }

    protected virtual void OnPreviewMouseHorizontalWheel(MouseHorizontalWheelEventArgs mouseHorizontalWheelEventArgs) { }

    private static void OnMouseHorizontalWheelThunk(object sender, MouseHorizontalWheelEventArgs mouseHorizontalWheelEventArgs)
    {
        if (!mouseHorizontalWheelEventArgs.Handled && sender is FlippableScrollViewer view)
        {
            view.OnMouseHorizontalWheel(mouseHorizontalWheelEventArgs);
        }
    }

    protected virtual void OnMouseHorizontalWheel(MouseHorizontalWheelEventArgs mouseHorizontalWheelEventArgs)
    {
        if (mouseHorizontalWheelEventArgs.HorizontalDelta < 0)
        {
            ScrollToHorizontalOffset(HorizontalOffset + HorizontalScrollOffset);
        }
        else
        {
            ScrollToHorizontalOffset(HorizontalOffset - HorizontalScrollOffset);
        }
    }

    private static readonly HashSet<IntPtr> HookedWindows = new();

    private static void EnableMouseHorizontalWheelSupport(Window window)
    {
        if (window == null)
        {
            throw new ArgumentNullException(nameof(window));
        }

        if (window.IsLoaded)
        {
            IntPtr handle = new WindowInteropHelper(window).Handle;
            EnableMouseHorizontalWheelSupport(handle);
        }
        else
        {
            window.Loaded += (_, _) =>
            {
                IntPtr handle = new WindowInteropHelper(window).Handle;
                EnableMouseHorizontalWheelSupport(handle);
            };
        }
    }

    private static void EnableMouseHorizontalWheelSupport(IntPtr handle)
    {
        if (HookedWindows.Contains(handle)) return;

        HookedWindows.Add(handle);
        HwndSource source = HwndSource.FromHwnd(handle);
        source?.AddHook(WndProcHook);
    }

    private static void HandleMouseHorizontalWheel(IntPtr wParam)
    {
        int tilt = -Win32.HiWord(wParam);

        if (tilt == 0)
        {
            return;
        }

        IInputElement element = Mouse.DirectlyOver;

        if (element == null) return;

        MouseHorizontalWheelEventArgs ev = new(Mouse.PrimaryDevice, Environment.TickCount, tilt)
        {
            RoutedEvent = PreviewMouseHorizontalWheelEvent,
        };

        element.RaiseEvent(ev);

        if (ev.Handled)
        {
            return;
        }

        ev.RoutedEvent = MouseHorizontalWheelEvent;
        element.RaiseEvent(ev);
    }

    private static IntPtr WndProcHook(
        IntPtr windowHandle,
        int message,
        IntPtr wParam,
        IntPtr lParam,
        ref bool handled)
    {
        if (message == Win32.WmMouseHWheel)
        {
            HandleMouseHorizontalWheel(wParam);
        }

        return IntPtr.Zero;
    }

    private static class Win32
    {
        public const int WmMouseHWheel = 0x020E;

        private static int GetIntUnchecked(IntPtr value)
        {
            return IntPtr.Size == 8 ? unchecked((int)value.ToInt64()) : value.ToInt32();
        }

        public static int HiWord(IntPtr ptr)
        {
            return unchecked((short)((uint)GetIntUnchecked(ptr) >> 16));
        }
    }
}
