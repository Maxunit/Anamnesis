// © Anamnesis.
// Licensed under the MIT license.

namespace Anamnesis.Panels;

using Anamnesis.Files;
using Anamnesis.Memory;
using System.Windows;
using System;
using Anamnesis.Actor;
using XivToolsWpf.Extensions;

public partial class ImportPosePanel : PanelBase
{
	public ImportPosePanel(IPanelGroupHost host, OpenResult openFile)
		: base(host)
	{
		this.InitializeComponent();
		this.ContentArea.DataContext = this;

		if (openFile.File is not PoseFile file)
			throw new Exception("Import file was not a pose file");

		this.Title = openFile.Path?.Name;
		this.File = file;
	}

	public PoseFile.Mode Mode { get; set; } = PoseFile.Mode.All;
	public PoseFile File { get; set; }
	public PinnedActor? Actor { get; set; }

	private async void OnImportClicked(object sender, RoutedEventArgs e)
	{
		ActorMemory? memory = this.Actor?.GetMemory();

		if (memory == null)
			throw new Exception("Actor has no memory");

		// TODO: skeleton not here.
		SkeletonVisual3d skeleton = new SkeletonVisual3d();
		await skeleton.SetActor(memory);
		this.File.Apply(memory, skeleton, null, this.Mode).Run();
		this.Close();
	}
}
