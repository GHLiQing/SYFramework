using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentInvoker
{
	private DisPlayCommand playCommand;

	private UndoCommand undoCommand;

	private RedoCommand redoCommand;

	public DocumentInvoker(DisPlayCommand dpc,UndoCommand udc,RedoCommand rdc)
	{
		this.playCommand = dpc;
		this.undoCommand = udc;
		this.redoCommand = rdc;
	}


	public void Display()
	{
		playCommand.Execute();
	}

	public void Redo()
	{
		redoCommand.Execute();
	}

	public void Undo()
	{
		undoCommand.Execute();
	}
}
