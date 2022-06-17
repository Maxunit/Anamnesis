﻿// © Anamnesis.
// Licensed under the MIT license.

namespace Anamnesis.Panels;

using FontAwesome.Sharp;
using System;
using System.Windows;
using System.Windows.Controls;

public interface IPanelGroupHost : IPanel
{
	ContentPresenter PanelGroupArea { get; }
	void Show();
}

public interface IPanel
{
	string Title { get; set; }
	IconChar Icon { get; set; }
	Rect Rect { get; set; }
	bool ShowBackground { get; set; }
	bool AllowAutoClose { get; set; }

	void DragMove();
}