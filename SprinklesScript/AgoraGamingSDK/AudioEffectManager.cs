﻿using UnityEngine;
using System.Collections;

namespace agora_gaming_rtc
{
	public interface IAudioEffectManager
	{
		/**
		 * get audio effect volume in the range of [0.0..100.0]
		 *
		 * @return return effect volume
		 */
		double GetEffectsVolume ();

		/**
		 * set audio effect volume
		 *
		 * @param [in] volume
		 *        in the range of [0..100]
		 * @return return 0 if success or an error code
		 */
		int SetEffectsVolume (int volume);

		/**
		 * start playing local audio effect specified by file path and other parameters
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @param [in] filePath
		 *        specify the path and file name of the effect audio file to be played
		 * @param [in] loop
		 *        whether to loop the effect playing or not, default value is false
		 * @param [in] pitch
		 *        frequency, in the range of [0.5..2.0], default value is 1.0
		 * @param [in] pan
		 *        stereo effect, in the range of [-1..1] where -1 enables only left channel, default value is 0.0
		 * @param [in] gain
		 *        volume, in the range of [0..100], default value is 100
		 * @return return 0 if success or an error code
		 */
		int PlayEffect (int soundId, string filePath,
			int loopCount,
			double pitch = 1.0D,
			double pan = 0.0D,
			int gain = 100,
			bool publish = false
		);

		/**
		 * stop playing specified audio effect
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @return return 0 if success or an error code
		 */
		int StopEffect (int soundId);

		/**
		 * stop all playing audio effects
		 *
		 * @return return 0 if success or an error code
		 */
		int StopAllEffects ();

		/**
		 * preload a compressed audio effect file specified by file path for later playing
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @param [in] filePath
		 *        specify the path and file name of the effect audio file to be preloaded
		 * @return return 0 if success or an error code
		 */
		int PreloadEffect (int soundId, string filePath);

		/**
		 * unload specified audio effect file from SDK
		 *
		 * @return return 0 if success or an error code
		 */
		int UnloadEffect (int soundId);

		/**
		 * pause playing specified audio effect
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @return return 0 if success or an error code
		 */
		int PauseEffect (int soundId);

		/**
		 * pausing all playing audio effects
		 *
		 * @return return 0 if success or an error code
		 */
		int PauseAllEffects ();

		/**
		 * resume playing specified audio effect
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @return return 0 if success or an error code
		 */
		int ResumeEffect (int soundId);

		/**
		 * resume all playing audio effects
		 *
		 * @return return 0 if success or an error code
		 */
		int ResumeAllEffects ();

		/**
		 * set voice only mode(e.g. keyboard strokes sound will be eliminated)
		 *
		 * @param [in] enable
		 *        true for enable, false for disable
		 * @return return 0 if success or an error code
		 */
		int SetVoiceOnlyMode (bool enable);

		/**
		 * place specified speaker's voice with pan and gain
		 *
		 * @param [in] uid
		 *        speaker's uid
		 * @param [in] pan
		 *        stereo effect, in the range of [-1..1] where -1 enables only left channel, default value is 0.0
		 * @param [in] gain
		 *        volume, in the range of [0..100], default value is 100
		 * @return return 0 if success or an error code
		 */
		int SetRemoteVoicePosition (uint uid, double pan, double gain);

		/**
		 * change the pitch of local speaker's voice
		 *
		 * @param [in] pitch
		 *        frequency, in the range of [0.5..2.0], default value is 1.0
		 * @return return 0 if success or an error code
		 */
		int SetLocalVoicePitch (double pitch);
	}

	class AudioEffectManagerImpl : IAudioEffectManager
	{
		private IRtcEngine mEngine;

		public AudioEffectManagerImpl (IRtcEngine rtcEngine)
		{
			mEngine = rtcEngine;
		}

		// used internally
		public void SetEngine (IRtcEngine engine)
		{
			mEngine = engine;
		}

		public double GetEffectsVolume ()
		{
			if (mEngine == null)
				return 0.0;
			//return mEngine.GetParameter ("che.audio.game_get_effects_volume");
			return 0.0;
		}

		public int SetEffectsVolume (int volume)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetEffectsVolume (volume);
		}

		public int PlayEffect (int soundId, string filePath,
			int loopCount,
			double pitch = 1.0D,
			double pan = 0.0D,
			int gain = 100,
			bool publish = false)
		{
			if (mEngine == null)
				return 0;
			return mEngine.PlayEffect (soundId, filePath, loopCount, pitch, pan, gain, publish);
		}

		public int StopEffect (int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.StopEffect (soundId);
		}

		public int StopAllEffects ()
		{
			if (mEngine == null)
				return 0;
			return mEngine.StopAllEffects ();
		}

		public int PreloadEffect (int soundId, string filePath)
		{
			if (mEngine == null)
				return 0;
			return mEngine.PreloadEffect (soundId, filePath);
		}

		public int UnloadEffect (int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.UnloadEffect (soundId);
		}

		public int PauseEffect (int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.PauseEffect (soundId);
		}

		public int PauseAllEffects ()
		{
			if (mEngine == null)
				return 0;
			return mEngine.PauseAllEffects ();
		}

		public int ResumeEffect (int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.ResumeEffect (soundId);
		}

		public int ResumeAllEffects ()
		{
			if (mEngine == null)
				return 0;
			return mEngine.ResumeAllEffects ();
		}

		public int SetVoiceOnlyMode (bool enable)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetVoiceOnlyMode (enable);
		}

		public int SetRemoteVoicePosition (uint uid, double pan, double gain)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetRemoteVoicePosition (uid, pan, gain);
		}

		public int SetLocalVoicePitch (double pitch)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetLocalVoicePitch (pitch);
		}
	}
}
