using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DocumentCommand
{
	protected Document document;

	public DocumentCommand(Document doc)
	{
		this.document = doc;
	}

	public abstract void Execute();

}

public class DisPlayCommand : DocumentCommand
{
	public DisPlayCommand(Document document) : base(document)
	{

	}

	public override void Execute()
	{
		this.document.DisPlay();
	}
}

public class UndoCommand : DocumentCommand
{
	public UndoCommand(Document document) : base(document)
	{

	}

	public override void Execute()
	{
		this.document.Undo();
	}
}


public class RedoCommand : DocumentCommand
{
	public RedoCommand(Document document) : base(document)
	{

	}

	public override void Execute()
	{
		this.document.Redo();
	}
}