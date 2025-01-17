using System.Collections.Generic;
using System.Linq;

namespace {
    public class FrameCount {
        private static FrameCount instance;
        public static FrameCount Instance {
            get {
                if (instance == null) {
                    instance = new FrameCount();
                }
                return instance;
            }
        }

        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }
        public const int MaximumSamples = 100;

        private Queue<float> _sampleBuffer = new Queue<float>();

        public void update(float deltaTime) {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            _sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (_sampleBuffer.Count > MaximumSamples) {
                _sampleBuffer.Dequeue();
                AverageFramesPerSecond = _sampleBuffer.Average(i => i);
            } else {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
            TotalSeconds += deltaTime;
        }
    }
}