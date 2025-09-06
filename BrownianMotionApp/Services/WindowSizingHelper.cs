#if WINDOWS
using Microsoft.UI.Windowing;
using Microsoft.UI;
#endif

namespace BrownianMotionApp.Services {
    public static class WindowSizingHelper {
        public static void MaximizeWindow(Window window) {
#if WINDOWS
            var nativeWindow = window.Handler.PlatformView;
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId WindowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = AppWindow.GetFromWindowId(WindowId);

            var p = appWindow.Presenter as OverlappedPresenter;

            p!.Maximize();
#endif
        }
    }
}
