using UnityEngine;
using UnityEngine.Events;
namespace ca.HenrySoftware.Atom
{
	public class AtomEventHandler : MonoBehaviour
	{
		public AtomEvent Event;
		public UnityEvent Response;
		protected void OnEnable() => Event?.Register(this);
		protected void OnDisable() => Event?.Unregister(this);
		public void Invoke() => Response?.Invoke();
	}
	public interface IAtomEventHandler<T>
	{
		void Invoke(T t);
	}
	public abstract class AtomEventHandler<T, E, UE> : MonoBehaviour, IAtomEventHandler<T>
		where E : AtomEvent<T>
		where UE : UnityEvent<T>
	{
		public E Event;
		public UE Response;
		protected void OnEnable() => Event?.Register(this);
		protected void OnDisable() => Event?.Unregister(this);
		public void Invoke(T t) => Response?.Invoke(t);
	}
}
