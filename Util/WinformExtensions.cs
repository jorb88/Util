using System.Windows.Forms;

namespace Util
{
	public static class RichTextBoxContextMenuItemOptions
	{
		public static bool Undo = true;
		public static bool Redo = true;
		public static bool Copy = true;
		public static bool Cut = true;
		public static bool Paste = true;
		public static bool Delete = true;
		public static bool SelectAll = true;
	}
	public static class WinformExtensions
	{
		public static void AddContextMenu(this RichTextBox rtb)
		{
			if (rtb.ContextMenuStrip == null)
			{
				ContextMenuStrip cms = new ContextMenuStrip()
				{
					ShowImageMargin = false
				};
				ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
				tsmiUndo.Click += (sender, e) => rtb.Undo();
				ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
				tsmiRedo.Click += (sender, e) => rtb.Redo();
				ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
				tsmiCut.Click += (sender, e) => rtb.Cut();
				ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
				tsmiCopy.Click += (sender, e) => rtb.Copy();
				ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
				tsmiPaste.Click += (sender, e) => rtb.Paste();
				ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
				tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
				ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
				tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();

				if (RichTextBoxContextMenuItemOptions.Undo) cms.Items.Add(tsmiUndo);
				if (RichTextBoxContextMenuItemOptions.Redo) cms.Items.Add(tsmiRedo);
				if (RichTextBoxContextMenuItemOptions.Undo ||
					RichTextBoxContextMenuItemOptions.Redo)
						cms.Items.Add(new ToolStripSeparator());
				if (RichTextBoxContextMenuItemOptions.Cut) cms.Items.Add(tsmiCut);
				if (RichTextBoxContextMenuItemOptions.Copy) cms.Items.Add(tsmiCopy);
				if (RichTextBoxContextMenuItemOptions.Paste) cms.Items.Add(tsmiPaste);
				if (RichTextBoxContextMenuItemOptions.Delete) cms.Items.Add(tsmiDelete);
				if (RichTextBoxContextMenuItemOptions.Copy ||
					RichTextBoxContextMenuItemOptions.Cut ||
					RichTextBoxContextMenuItemOptions.Paste ||
					RichTextBoxContextMenuItemOptions.Delete)
						cms.Items.Add(new ToolStripSeparator());
				if (RichTextBoxContextMenuItemOptions.SelectAll) cms.Items.Add(tsmiSelectAll);

				cms.Opening += (sender, e) =>
				{
					tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
					tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
					tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
					tsmiCopy.Enabled = rtb.SelectionLength > 0;
					tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
					tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
					tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
				};

				rtb.ContextMenuStrip = cms;
				}
			}
		}
	}
