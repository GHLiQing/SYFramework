using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class TestCommand : MonoBehaviour
{

	private void Start()
	{
		Document document = new Document();
		
		DocumentInvoker documentInvoker = new DocumentInvoker(new DisPlayCommand(document), new UndoCommand(document),new RedoCommand(document));

		Observable.EveryUpdate()
			.Where(_ => Input.GetMouseButtonDown(0))
			.Subscribe(_ => {
				documentInvoker.Display();

			})
			.AddTo(this);
	}
}
