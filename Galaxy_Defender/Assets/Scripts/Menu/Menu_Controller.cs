using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu_Controller : MonoBehaviour 
{	
	private List<IMenuStateHandler> m_Stack = new List<IMenuStateHandler>();
	
	//add whichever menu was passed to the top of the stack
	public void Push(IMenuStateHandler menu)
	{
		//add menu
		m_Stack.Add(menu);
		//enable menu
		m_Stack[m_Stack.Count - 1].EnableMenu();
		
		//disable layer underneath
		if(m_Stack.Count == 1)
		{
			//no other layers, so we are in the game
			
			//deactivate the ingame menu
			//menuInGame.gameObject.SetActive(false);				
		}
		else
		{
			//disable a layer
			m_Stack[m_Stack.Count - 2].DisableMenu();
		}
	}
	
	//pop off the top of the stack
	public void Pop()
	{
		//disable menu at top of stack
		m_Stack[m_Stack.Count - 1].DisableMenu();
		//remove the item from the stack
		m_Stack.RemoveAt(m_Stack.Count - 1);
		//enable the top of the stack
		if(m_Stack.Count == 0)
		{
			//nothing in the stack, enable the game again
			//menuInGame.gameObject.SetActive(true);
		}
		else
		{
			//enable the next on the stack
			m_Stack[m_Stack.Count - 1].EnableMenu();
		}
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
