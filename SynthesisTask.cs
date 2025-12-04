using TuneLab.Extensions.Voices;

namespace $safeprojectname$ForTuneLab
{
    /// <summary>
    /// 실제 합성을 담당하는 클래스 입니다.
    /// </summary>
    public class $safeprojectname$SynthesisTask : ISynthesisTask
    {
        /// <summary>
        /// 합성이 완료될 시, 해당 Action에 값을 넣어 전송합니다.
        /// </summary>
        public event Action<SynthesisResult>? Complete;

        /// <summary>
        /// 해당 값이 변할 시, TuneLab은 노트 위 진행바의 수치를 변화시킵니다.
        /// 최대 값은 data의 길이여야 합니다.
        /// </summary>
        public event Action<double>? Progress;

        /// <summary>
        /// 해당 값에 정보가 담길 경우, TuneLab은 Log와 파트 위 진행 바에 오류를 출력합니다.
        /// </summary>
        public event Action<string>? Error;

        /// <summary>
        /// 생성시 받은 렌더링 데이터 입니다.
        /// </summary>
        private ISynthesisData Data;

        /// <summary>
        /// 렌더링 하는 가수입니다.
        /// </summary>
        private $safeprojectname$Singer Singer;

        public $safeprojectname$SynthesisTask(ISynthesisData data, $safeprojectname$Singer singer)
        {
            this.Data = data;
            this.Singer = singer;
        }

        /// <summary>
        /// 렌더링 시작 함수입니다.
        /// </summary>
        public void Start()
        {

            Task.Run(delegate ()
            {
                try
                {
                    this.Progress?.Invoke(0.0);

                    // 여기에 렌더링 코드를 작성해주세요.

                    // 해당 값은 전부 임의 값이 들어가 있습니다.
                    // 본인의 렌더링 코드에 맞춰 값을 재대로 된 값으로 변경해주세요.
                    SynthesisResult result = new SynthesisResult(
                        startTime: 0.0,
                        samplingRate: 44100,
                        audioData: Array.Empty<float>(),
                        synthesizedPitch: null,
                        synthesizedPhoneme: null
                    );

                    this.Complete?.Invoke(result);
                }
                catch (Exception ex)
                {
                    this.Error?.Invoke(ex.Message);
                }
            });
        }

        /// <summary>
        /// 의도치 않게 렌더링이 끊겼을 경우, TuneLab은 Start 대신 해당 함수를 호출합니다.
        /// 해당 함수에서 이어 렌더링 할 수 있게 구현합니다.
        /// 해당 함수가 비어있을 경우, TuneLab은 Start 함수만 사용합니다.
        /// </summary>
        public void Resume() { }

        /// <summary>
        /// 의도치 않게 렌더링이 끊겼을 경우, TuneLab은 해당 함수를 즉시 호출합니다.
        /// 렌더링 중단 시 구현해야 할 코드를 아래에 추가해야 합니다.
        /// </summary>
        public void Stop() { }

        /// <summary>
        /// 추후 조사 필요.
        /// 비워둬도 무방합니다.
        /// </summary>
        public void Suspend() { }

        /// <summary>
        /// 추후 조사 필요.
        /// 비워둬도 무방합니다.
        /// </summary>
        /// <param name="dirtyType"></param>
        public void SetDirty(string dirtyType) { }
    }
}
