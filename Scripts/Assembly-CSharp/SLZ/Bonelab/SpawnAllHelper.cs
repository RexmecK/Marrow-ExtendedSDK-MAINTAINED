using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Pool;
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Bonelab
{
	public class SpawnAllHelper : MonoBehaviour
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CSpawnAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public SpawnAllHelper _003C_003E4__this;

			private List<Poolee> _003C_003E7__wrap1;

			private UniTask<Poolee[]>.Awaiter _003C_003Eu__1;

			public void MoveNext()
			{
			}

			[DebuggerHidden]
			public void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}
		}

		[SerializeField]
		private CrateSpawner[] _crateSpawners;

		private List<Poolee> _poolees;

		public void SpawnAll()
		{
		}

		public void DespawnAll()
		{
		}

		[AsyncStateMachine(typeof(_003CSpawnAsync_003Ed__4))]
		private UniTaskVoid SpawnAsync()
		{
			return default(UniTaskVoid);
		}

		public void ToggleSpawn()
		{
		}
	}
}
