using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace SkiaSharpSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OnPaintingArrowDown(object sender, SKPaintSurfaceEventArgs e)
	{
		var surface = e.Surface;
		var canvas = surface.Canvas;
		canvas.Clear(SKColors.Transparent);

		var arrowPaint = new SKPaint
		{
			IsAntialias = true,
			Style = SKPaintStyle.StrokeAndFill,
			Color = new SKColor(102, 102, 102),
			StrokeWidth = canvas.DeviceClipBounds.Right / 20f
		};

		var path = new SKPath();
		path.MoveTo(0, 0);
		path.LineTo(canvas.DeviceClipBounds.Right, 0);
		path.LineTo(canvas.DeviceClipBounds.MidX, canvas.DeviceClipBounds.Bottom);
		canvas.DrawPath(path, arrowPaint);
	}
}

