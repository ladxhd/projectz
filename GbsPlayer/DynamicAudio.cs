using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using NAudio;
using NAudio.Wave;
using System.Data;

/// <summary>
/// Converts byte buffers to wave stream for audio playback.
/// </summary>
/// <remarks>
/// Take in raw bytes from Sound.cs, convert it to an NAudio wave stream, 
/// and playback the audio.
/// </remarks>
/// Ref: https://github.com/naudio/NAudio/blob/master/Docs/RawSourceWaveStream.md

namespace GbsPlayer
{
    public class DynamicAudio
    {
        // Wave playback client
        private WaveFormat fmt;

        private MemoryStream mem;
        private RawSourceWaveStream rawSrc;
        private WaveOutEvent waveout;

        public SoundState State = SoundState.Stopped;

        private object voiceLock = new Object();

        // Human hearable audio frequency range
        private const double FqMax = 20000;
        private const double FqMin = 20;

        public DynamicAudio(int sampleRate)
        {
            // Gameboy audio is 16-bit PCM Mono 48000 Hz
            fmt = new WaveFormat(sampleRate, 16, 1);
            waveout = new WaveOutEvent();
        }

        // offset and index are no longer needed, apparently.
        public void SubmitBuffer(byte[] buf, int offset, int index) {
            // Copy buffer into memory stream
            mem = new MemoryStream(buf);
            // Create raw source from memory stream + wave format
            rawSrc = new RawSourceWaveStream(mem, fmt);

            // lock the object instance, as to not modify the contents of memory.
            lock (voiceLock)
                waveout.Init(rawSrc);
        }

        public int GetPendingBufferCount()
        {
            // This probably doesn't work.
            lock (voiceLock) {
                return waveout.NumberOfBuffers;
            }
        }

        // Pause Audio Buffer
        public void Play()
        { 
            lock (voiceLock) {
                waveout.Play();
                State = SoundState.Playing;
            }
        }

        // Pause Audio Buffer
        public void Pause()
        { 
            lock (voiceLock) {
                waveout.Pause();
                State = SoundState.Paused;
            }
        }


        // Resume Audio Buffer
        public void Resume()
        { 
            lock (voiceLock) {
                waveout.Play();
                State = SoundState.Playing;
            }
        }

        // Stop Audio Buffer
        public void Stop()
        { 
            lock (voiceLock) {
                waveout.Stop();
                State = SoundState.Stopped;
                waveout.Dispose();
            }
        }

        // Set Stream Volume
        public void SetVolume(float volume)
        { 
            lock (voiceLock) {
                waveout.Volume = volume;
            }
        }
    }
}