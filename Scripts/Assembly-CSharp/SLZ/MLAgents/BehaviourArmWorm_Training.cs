using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PuppetMasta;
using SLZ.Marrow.PuppetMasta;
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace SLZ.MLAgents
{
	public class BehaviourArmWorm_Training : BehaviourGrabbableBaseNav
	{
		[CompilerGenerated]
		private sealed class _003CSelfDespawn_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public BehaviourArmWorm_Training _003C_003E4__this;

			private object System_002ECollections_002EGeneric_002EIEnumerator_003CSystem_002EObject_003E_002ECurrent
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			private object System_002ECollections_002EIEnumerator_002ECurrent
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSelfDespawn_003Ed__55(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			private void System_002EIDisposable_002EDispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}

			public object Current { get; }

			object IEnumerator.Current => Current;

			[DebuggerHidden]
			private void System_002ECollections_002EIEnumerator_002EReset()
			{
			}

			bool IEnumerator.MoveNext()
			{
				return MoveNext();
			}

			public void Dispose()
			{
				throw new NotImplementedException();
			}
		}

		[Header("Arm Settings")]
		public SubBehaviourIk ik;

		public SubBehaviourHandPose handPoser;

		public GameObject throwVfx;

		public bool crumbleDeath;

		private int _armsLayer;

		private int _mSecAnim;

		private int _locoCycleAnim;

		private int _flinchAnim;

		private int _angryAnim;

		private int _awakeAnim;

		private int _unGroundedAnim;

		private int _emissColor;

		private int _attackAnim;

		private int _clipIntAnim;

		private int _gestureAnim;

		private int _deathAnim;

		private float _animationBlendWeight;

		private float _animationBlendWeightV;

		private float _blendToAnimationTime;

		public bool elbow_y_rot_heur;

		public bool wrist_x_rot_heur;

		public bool wrist_y_rot_heur;

		public bool wrist_z_rot_heur;

		public float sin_speed_mod;

		public float sin_range_mod;

		public float elbow_strength;

		public float wrist_strength;

		public float artSlerpDrive;

		public float max_elbow_strength;

		private float adjusted_elbow_strength;

		public float max_wrist_strength;

		private float adjusted_wrist_strength;

		public ActionBuffers incomingActions;

		public BehaviourDriveController m_JdController;

		public BoxCollider frictionCollider;

		public PhysicMaterial high_friction;

		public PhysicMaterial low_friction;

		public float last_friction_val;

		public bool actionReady;

		protected override void OnInitiate()
		{
		}

		public override void OnReactivate(int phase = 0)
		{
		}

		public override void KillStart()
		{
		}

		public override void KillEnd()
		{
		}

		public void SetArtTargetRotation(ref Transform transform, float x, float y, float z, float lowX, float highX, float lowY, float highY, float lowZ, float highZ)
		{
		}

		public void SetBodyPartStrength(float spineStrength, float legStrength)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnLateUpdate()
		{
		}

		public void UpdateFriction(float decision)
		{
		}

		protected static float ScaleAction(float rawAction, float min, float max)
		{
			return 0f;
		}

		private void TakeDelayedAction()
		{
		}

		protected override void OnReadBehaviour()
		{
		}

		protected override void OnWriteBehaviour()
		{
		}

		protected override void OnMuscleHitBehaviour(MuscleHit hit)
		{
		}

		protected override void OnMuscleCollisionBehaviour(MuscleCollision m)
		{
		}

		protected override void ResetAnimator()
		{
		}

		[IteratorStateMachine(typeof(_003CSelfDespawn_003Ed__55))]
		private IEnumerator SelfDespawn(float duration)
		{
			return null;
		}

		public override void Freeze()
		{
		}

		public override void Unfreeze()
		{
		}

		protected override void SwitchMentalState(MentalState mState)
		{
		}

		protected override void SwitchLocoState(LocoState lState, float coolDown = 0f, bool forceSwitch = false)
		{
		}
	}
}
